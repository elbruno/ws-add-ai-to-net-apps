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

    private IConfiguration _config;

    private ChatHistory _chatHistory;

    public IChatCompletionService _chatCompletionService;

    public ISemanticTextMemory _memory;

    public ChatController(ILogger<ChatController> logger, IConfiguration config, ChatHistory chatHistory, IChatCompletionService chatCompletionService, ISemanticTextMemory semanticMemory)
    {
        _logger = logger;
        _config = config;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;
        _memory = semanticMemory;
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question}");

        var response = new Response
        {
            Author = _config["Author"]
        };

        // get response
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var result = await SearchResultInMemory(question);
        if (string.IsNullOrEmpty(result))
        {
            // complete chat history
            _chatHistory.AddUserMessage(question.UserQuestion);

            response.Author = "Azure GPT-4o";
            var resultResponse = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
            result = resultResponse[^1].Content;
            //await AddItemToMemory(question, result);
            response.FromCache = false;
        }
        else
        {
            response.Author += " [Azure AI Search]";
            response.FromCache = true;
        }

        response.QuestionResponse = result;

        // calculate elapsed time
        stopwatch.Stop();
        response.ElapsedTime = stopwatch.Elapsed;

        _logger.LogInformation($"Response: {response}");
        return response;
    }

    string collectionName = "contoso-products-index-01";

    async Task<string> SearchResultInMemory(Question question)
    {
        var returnValue = string.Empty;

        // search in memory
        var response = await _memory.SearchAsync(
            collectionName,
            question.UserQuestion,
            withEmbeddings: true,
            limit: 1).FirstOrDefaultAsync();
        if (response != null)
        {
            _logger.LogInformation($"{question.UserQuestion} >> ID: {response?.Metadata.Id} - Description: {response?.Metadata.Description} - Relevance: {response.Relevance} - Is Reference: {response?.Metadata.IsReference}");
            if (response.Relevance > 0.9)
            {
                returnValue = response?.Metadata.Description;
            }
        }
        return returnValue;
    }

}
