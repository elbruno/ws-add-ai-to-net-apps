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

builder.Logging.AddOpenTelemetry(logging =>
{
    var config = builder.Configuration;
    var otlpEndPoint = "https://probable-dollop-ppppr5gx6v37p7p-4317.app.github.dev";
    logging.AddOtlpExporter(configure => configure.Endpoint = new Uri(otlpEndPoint));
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
});

builder.Services.AddSingleton<IConfiguration>(sp => 
{
    return builder.Configuration;
});

builder.Services.AddSingleton<IChatCompletionService>(sp =>
{
    // add Phi-3 model from a ollama server
    var model = "phi3";
    var endpoint = "https://probable-dollop-ppppr5gx6v37p7p-11434.app.github.dev";
    var apiKey = "apiKey";

    return new OpenAIChatCompletionService(model, new Uri(endpoint), apiKey);
});

builder.Services.AddSingleton(sp => 
{
    return new ChatHistory();
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
