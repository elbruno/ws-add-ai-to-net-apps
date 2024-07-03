#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0020
#pragma warning disable SKEXP0027
#pragma warning disable SKEXP0050

using Microsoft.Build.Framework;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(
    b => b.AddConsole().SetMinimumLevel(LogLevel.Trace)
);

builder.Services.AddSingleton<IConfiguration>(sp => 
{
    return builder.Configuration;
});

builder.Services.AddSingleton(sp =>
{
    var chatHistory = new ChatHistory();
    chatHistory.AddSystemMessage("You are a usefull assistant. You always reply with a short and funny message. If you don't know an answer, you say 'I don't know that.'");
    return chatHistory;
});

builder.Services.AddSingleton<IChatCompletionService>(sp =>
{
    // add Azure OpenAI Chat Completion service
    var config = builder.Configuration;
    var chatDeploymentName = config["AZURE_OPENAI_MODEL"];
    var endpoint = config["AZURE_OPENAI_ENDPOINT"];
    var apiKey = config["AZURE_OPENAI_APIKEY"];
    // set author
    config["author"]= "Azure OpenAI - GPT-4o";

    return new AzureOpenAIChatCompletionService(chatDeploymentName, endpoint, apiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
