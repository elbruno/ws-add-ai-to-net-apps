#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0020
#pragma warning disable SKEXP0027
#pragma warning disable SKEXP0050

using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(
    b => b.AddConsole().SetMinimumLevel(LogLevel.Trace)
);

builder.Services.AddSingleton<IChatCompletionService>(sp =>
{
    var config = builder.Configuration;
    var chatDeploymentName = config["AZURE_OPENAI_MODEL"];
    var endpoint = config["AZURE_OPENAI_ENDPOINT"];
    var apiKey = config["AZURE_OPENAI_APIKEY"];

    return new AzureOpenAIChatCompletionService(chatDeploymentName, endpoint, apiKey);
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
