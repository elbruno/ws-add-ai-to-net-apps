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
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Azure;
using Microsoft.AspNetCore.DataProtection;
using System.Net.Sockets;
using Azure.Search.Documents.Indexes;
using Microsoft.SemanticKernel.Embeddings;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

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

builder.Services.AddSingleton(sp =>
{
    var chatHistory = new ChatHistory();
    chatHistory.AddSystemMessage("You are a usefull assistant. You always reply with a short and funny message. If you don't know an answer, you say 'I don't know that.'");
    return chatHistory;
});

builder.Services.AddSingleton<ITextEmbeddingGenerationService>(sp =>
{
    var config = builder.Configuration;
    var ada002 = config["AZURE_OPENAI_ADA02"];
    var endpoint = config["AZURE_OPENAI_ENDPOINT"];
    var apiKey = config["AZURE_OPENAI_APIKEY"];

    return new AzureOpenAITextEmbeddingGenerationService(ada002, endpoint, apiKey);
});

// add memory storage using Semantic Kernel
builder.Services.AddSingleton<ISemanticTextMemory>(sp =>
{
    var config = builder.Configuration;
    var ada002 = config["AZURE_OPENAI_ADA02"];
    var endpoint = config["AZURE_OPENAI_ENDPOINT"];
    var apiKey = config["AZURE_OPENAI_APIKEY"];
    var aiSearchEndpoint = config["AZURE_AISEARCH_ENDPOINT"];
    var aiSearchApiKey = config["AZURE_AISEARCH_APIKEY"];

    var textEmbeddingService = new AzureOpenAITextEmbeddingGenerationService(ada002, endpoint, apiKey);

    var memoryBuilder = new MemoryBuilder();
    memoryBuilder.WithTextEmbeddingGeneration(textEmbeddingService); ;
    memoryBuilder.WithMemoryStore(new AzureAISearchMemoryStore(aiSearchEndpoint, aiSearchApiKey));

    //memoryBuilder.with WithAzureOpenAITextEmbeddingGeneration(ada002, endpoint, apiKey);

    var memory = memoryBuilder.Build();
    return memory;
});

var app = builder.Build();

app.MapDefaultEndpoints();

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
