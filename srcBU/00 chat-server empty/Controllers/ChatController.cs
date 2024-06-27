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

    public ChatController(ILogger<ChatController> logger, ChatHistory chatHistory)
    {
        _logger = logger;
        _chatHistory = chatHistory;
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question}");

        var response = new Response
        {
            Author = "ChatBot"
        };
        // complete chat history
        _chatHistory.AddUserMessage(question.UserQuestion);

        // get response
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var chatResponse = $" Your question [{question.UserQuestion}] is {question.UserQuestion.Length} chars long.";
        stopwatch.Stop();
        response.QuestionResponse = chatResponse;
        response.ElapsedTime = stopwatch.Elapsed;

        // return response
        _logger.LogInformation($"Response: {response}");
        return response;
    }
}
