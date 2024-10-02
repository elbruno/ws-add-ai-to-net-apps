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
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Azure.AI.OpenAI.Chat;
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

    private string _aiSearchEndpoint;
    private string _aiSearchApiKey;
    private string _aiSearchIndexName;


    public ChatController(ILogger<ChatController> logger, IConfiguration config, ChatHistory chatHistory, IChatCompletionService chatCompletionService)
    {
        _logger = logger;
        _config = config;
        _chatHistory = chatHistory;
        _chatCompletionService = chatCompletionService;

        _aiSearchEndpoint = _config["AZURE_AISEARCH_ENDPOINT"];
        _aiSearchApiKey = _config["AZURE_AISEARCH_APIKEY"];
        _aiSearchIndexName = _config["AZURE_AISEARCH_INDEXNAME"];
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
    
        var acds = new AzureSearchChatDataSource
        {
            Endpoint = new Uri(_aiSearchEndpoint),
            IndexName = _aiSearchIndexName,
            Authentication = DataSourceAuthentication.FromApiKey(_aiSearchApiKey),
            QueryType = DataSourceQueryType.VectorSemanticHybrid,
            MaxSearchQueries = 3,
            VectorizationSource = DataSourceVectorizer.FromEndpoint(
                new Uri(_aiSearchEndpoint), DataSourceAuthentication.FromApiKey(_aiSearchApiKey))
        };
        var executionSettings = new AzureOpenAIPromptExecutionSettings
        {
            AzureChatDataSource = acds
        };

        // run the prompt
        var result = await _chatCompletionService.GetChatMessageContentsAsync(_chatHistory, executionSettings);

        if (result.FirstOrDefault().InnerContent is OpenAI.Chat.ChatCompletion)
        {

            var ic = result.FirstOrDefault().InnerContent as OpenAI.Chat.ChatCompletion;

            response.Citations = new List<Citation>();

            //    var ic = result.FirstOrDefault().InnerContent as ChatResponseMessage;
            //    var aec = ic.AzureExtensionsContext;
            //    var citations = aec.Citations;
            //    int count = 0;
            //    foreach (var citation in citations)
            //    {
            //        if (count >= 3) break;
            //        count++;
            //        var newC = new Citation();
            //        newC.Title = citation.Title;
            //        newC.URL = citation.Url;
            //        newC.FilePath = citation.Filepath;
            //        newC.Content = citation.Content;
            //        response.Citations.Add(newC);
            //    }
        }

        stopwatch.Stop();
    
        response.QuestionResponse = result[^1].Content;
        response.ElapsedTime = stopwatch.Elapsed;
    
        // return response
        _logger.LogInformation($"Response: {response}");
        return response;
    }

}
