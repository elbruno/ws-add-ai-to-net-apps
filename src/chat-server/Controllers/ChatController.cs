using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;
using chat_models;

namespace chat_server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;
    private ChatHistory _chatHistory;
    public IChatCompletionService _chatCompletionService;

    public ChatController(ILogger<ChatController> logger, ChatHistory chatHistory, IChatCompletionService chatCompletionService)
    {
        _logger = logger;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;
    }

    // POST api/<ChatController>
    [HttpPost]
    public async Task<Response> Post(Question question)
    {
        _logger.LogInformation($"Input question: {question.ToString()}"); 

        // complete history
        _chatHistory.AddUserMessage(question.UserQuestion);

        // get response
        var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
        var response = new Response
        {
            Author = "Azure OpenAI", 
            QuestionResponse = result[^1].Content
        };

        _logger.LogInformation($"Response: {response.ToString()}");
        return response;
    }
}
