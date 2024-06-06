using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;
using chat_models;

namespace chat_server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;

    public ChatController(ILogger<ChatController> logger)
    {
        _logger = logger;
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question}");

        var response = new Response
        {
            QuestionResponse = $" Your question [{question.UserQuestion}] is {question.UserQuestion.Length} chars long."
        };

        _logger.LogInformation($"Response: {response}");
        return response;
    }
}
