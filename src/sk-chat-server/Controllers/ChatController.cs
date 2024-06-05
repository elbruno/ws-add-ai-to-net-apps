using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;

namespace sk_chat_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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


        [HttpPost(Name = "AnswerQuestion")]
        public async Task<string> AnswerQuestion(string question)
        {
            _chatHistory.AddUserMessage(question);
            var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
            var response = result[^1].Content;
            return $"AI response: {response} // {DateTime.Now.ToString()}";
        }
    }
}
