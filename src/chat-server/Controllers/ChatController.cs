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


    private string _aiSearchEndpoint;
    private string _aiSearchApiKey;
    private string _aiSearchIndexName;

    public ChatController(ILogger<ChatController> logger, ChatHistory chatHistory, IChatCompletionService chatCompletionService, IConfiguration config)
    {
        _logger = logger;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;
        _config = config;

        _aiSearchEndpoint = _config["AZURE_AISEARCH_ENDPOINT"];
        _aiSearchApiKey = _config["AZURE_AISEARCH_APIKEY"];
        _aiSearchIndexName = _config["AZURE_AISEARCH_INDEXNAME"];
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question}");

        var response = new Response();

        // validate if question.ImageUrl is a valid url
        if (question.IsImage)
        {
            var collectionItems = new ChatMessageContentItemCollection
    {
        new TextContent(question.UserQuestion),
        new ImageContent(question.FileBytes, question.ImageMimeType)
        };
            _chatHistory.AddUserMessage(collectionItems);
        }
        else
        {
            _chatHistory.AddUserMessage(question.UserQuestion);
        }

        // get response
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var azureSearchExtensionConfiguration = new AzureSearchChatExtensionConfiguration
        {
            SearchEndpoint = new Uri(_aiSearchEndpoint),
            Authentication = new OnYourDataApiKeyAuthenticationOptions(_aiSearchApiKey),
            IndexName = _aiSearchIndexName
        };

        var chatExtensionsOptions = new AzureChatExtensionsOptions { Extensions = { azureSearchExtensionConfiguration } };
        var executionSettings = new OpenAIPromptExecutionSettings { AzureChatExtensionsOptions = chatExtensionsOptions };

        // run the prompt
        var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory, executionSettings);

        if (result.FirstOrDefault().InnerContent is ChatResponseMessage)
        {
            response.Citations = new List<Citation>();
            var ic = result.FirstOrDefault().InnerContent as ChatResponseMessage;
            var aec = ic.AzureExtensionsContext;
            var citations = aec.Citations;
            int count = 0;
            foreach (var citation in citations)
            {
                if (count >= 3) break;
                count++;
                var newC = new Citation();
                newC.Title = citation.Title;
                newC.URL = citation.Url;
                newC.FilePath = citation.Filepath;
                newC.Content = citation.Content;
                response.Citations.Add(newC);
            }
        }

        stopwatch.Stop();

        response.Author = "Azure OpenAI";
        response.QuestionResponse = result[^1].Content;
        response.ElapsedTime = stopwatch.Elapsed;

        // return response
        _logger.LogInformation($"Response: {response}");
        return response;
    }


}
