#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0020
#pragma warning disable SKEXP0027
#pragma warning disable SKEXP0050

using chat_models;
using System.Diagnostics;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace chat_server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private bool _useCache = false;

    private readonly ILogger<ChatController> _logger;

    private ChatHistory _chatHistory;

    public ISemanticTextMemory _memory;

    public IChatCompletionService _chatCompletionService;
    public IConfiguration _config;
    public ChatController(ILogger<ChatController> logger, ChatHistory chatHistory, IChatCompletionService chatCompletionService, ISemanticTextMemory semanticMemory, IConfiguration config)
    {
        _logger = logger;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;
        _memory = semanticMemory;
        _config = config;
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question}");

        var response = new Response();

        // complete chat history
        _chatHistory.AddUserMessage(question.UserQuestion);

        // get response
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var result = await SearchResultInMemory(question);
        if (string.IsNullOrEmpty(result))
        {
            response.Author = "Azure GPT-4o";

            var aiSearchEndpoint = _config["AZURE_AISEARCH_ENDPOINT"];
            var aiSearchApiKey = _config["AZURE_AISEARCH_APIKEY"];
            var azureSearchExtensionConfiguration = new AzureSearchChatExtensionConfiguration
            {
                SearchEndpoint = new Uri(aiSearchEndpoint),
                Authentication = new OnYourDataApiKeyAuthenticationOptions(aiSearchApiKey),
                IndexName = "contoso-products-with-weather-index"
            };
            var chatExtensionsOptions = new AzureChatExtensionsOptions { Extensions = { azureSearchExtensionConfiguration } };
            var executionSettings = new OpenAIPromptExecutionSettings { AzureChatExtensionsOptions = chatExtensionsOptions };

            var resultResponse = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
            result = resultResponse[^1].Content;
            await AddItemToMemory(question, result);
            response.FromCache = false;

            // process citations
            response = AddCitationsToResponse(resultResponse, response);
        }
        else
        {
            response.Author = "Azure GPT-4o - Cache";
            response.FromCache = true;
        }

        response.QuestionResponse = result;

        // calculate elapsed time
        stopwatch.Stop();
        response.ElapsedTime = stopwatch.Elapsed;

        _logger.LogInformation($"Response: {response}");
        return response;
    }

    Response AddCitationsToResponse(IReadOnlyList<ChatMessageContent> resultResponse, Response response)
    {
        if (resultResponse.FirstOrDefault().InnerContent is ChatResponseMessage)
        {
            var innerContent = resultResponse.FirstOrDefault().InnerContent as ChatResponseMessage;
            if (innerContent.AzureExtensionsContext != null)
            {
                var aec = innerContent.AzureExtensionsContext;
                var citations = aec.Citations;
                if (aec.Citations.Count > 0)
                {
                    response.Citations = new List<Citation>();
                    foreach (var citation in citations)
                    {
                        response.Citations.Add(
                            new Citation()
                            {
                                Title = citation.Title,
                                URL = citation.Url,
                                FilePath = citation.Filepath
                            });
                    }
                }
            }
        }

        return response;
    }

    async Task AddItemToMemory(Question question, string questionAnswer)
    {
        if (!_useCache) return;

        int chunkSize = 6000;
        List<string> chunks = new List<string>();
        for (int i = 0; i < question.UserQuestion.Length; i += chunkSize)
        {
            string chunk = question.UserQuestion.Substring(i, Math.Min(chunkSize, question.UserQuestion.Length - i));
            string key = question.UserQuestion + "-" + i;

            // process key to only contain letters, digits, underscore (_), dash (-), or equal sign (=)
            key = new string(key.Where(c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '=').ToArray());

            await _memory.SaveInformationAsync(
                collection: GetMemoryCollectionName(question),
                text: chunk,
                id: key,
                description: questionAnswer);

            _logger.LogInformation($"Saved chunk: {key} - {chunk}");
        }
    }

    async Task<string> SearchResultInMemory(Question question)
    {
        if (!_useCache) return "";

        var returnValue = string.Empty;

        // search in memory
        var response = await _memory.SearchAsync(
            GetMemoryCollectionName(question),
            question.UserQuestion,
            withEmbeddings: true,
            limit: 1).FirstOrDefaultAsync();
        if (response != null)
        {
            _logger.LogInformation($"{question.UserQuestion} >> ID: {response?.Metadata.Id} - Description: {response?.Metadata.Description} - Relevance: {response.Relevance} - Is Reference: {response?.Metadata.IsReference}");
            if (response.Relevance > 0.8)
            {
                returnValue = response?.Metadata.Description;
            }
        }
        return returnValue;
    }

    string GetMemoryCollectionName(Question question)
    {
        return $"user-{question.UserName}-chat";
    }

}
