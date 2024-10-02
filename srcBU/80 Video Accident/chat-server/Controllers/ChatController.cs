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
using OpenCvSharp;
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
        if (question.IsVideo)
        {
            var collectionItems = new ChatMessageContentItemCollection
    {
        new TextContent(question.UserQuestion)
    };
            var videoFrames = VideoFrames(question.FileBytes);
            foreach (var frame in videoFrames)
            {
                var bytes = System.IO.File.ReadAllBytes(frame);
                collectionItems.Add(new ImageContent(bytes, "image/jpeg"));
            }

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

    public List<string> VideoFrames(byte[] videoArray) {

        List<string> videoFrames = new List<string>();

        // Create or clear the "data" folder
        string dataFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (Directory.Exists(dataFolderPath))
        {
            Directory.Delete(dataFolderPath, true);
        }
        Directory.CreateDirectory(dataFolderPath);


        string videoFile = Path.Combine(Directory.GetCurrentDirectory(), "data/insurance_v3.mp4");
        int numberOfFrames = 5;

        SaveVideo(videoArray, videoFile);

        // Create the directory to store the frames
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data/frames"));

        // Extract the frames from the video
        var video = new VideoCapture(videoFile);
        var frames = new List<Mat>();
        while (video.IsOpened())
        {
            var frame = new Mat();
            if (!video.Read(frame) || frame.Empty())
                break;
            frames.Add(frame);
        }
        video.Release();

        // Save the frames
        int step = (int)Math.Ceiling((double)frames.Count / numberOfFrames);
        for (int i = 0; i < frames.Count; i += step)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"data/frames/frame_{i / step}.jpg");
            Cv2.ImWrite(filePath, frames[i]);
            videoFrames.Add(filePath);
        }

        return videoFrames;
    }
    public void SaveVideo(byte[] video, string filePath)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            fileStream.Write(video, 0, video.Length);
        }
    }

}
