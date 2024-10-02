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

    private IChatCompletionService _chatCompletionService;
    public ChatController(ILogger<ChatController> logger, IConfiguration config, ChatHistory chatHistory, IChatCompletionService chatCompletionService)
    {
        _logger = logger;
        _config = config;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;
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

        // complete chat history
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
        var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
        stopwatch.Stop();

        response.QuestionResponse = result[^1].Content;
        response.ElapsedTime = stopwatch.Elapsed;

        // return response
        _logger.LogInformation($"Response: {response}");
        return response;
    }

}
