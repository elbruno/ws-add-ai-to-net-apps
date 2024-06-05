﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;
using sk_chat_models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sk_chat_server.Controllers
{
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
            // complete history
            _chatHistory.AddUserMessage(question.UserQuestion);

            // get response
            var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory);
            var response = new Response
            {
                Author = "Semantic Kernel",
                QuestionResponse = result[^1].Content
            };
            return response;
        }


    }
}
