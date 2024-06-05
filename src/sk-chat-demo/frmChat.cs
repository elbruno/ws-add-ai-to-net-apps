using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System;
using System.Windows.Forms;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Redis;
using Microsoft.SemanticKernel.Memory;
using StackExchange.Redis;
using System.Threading.Tasks;

#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0020
#pragma warning disable SKEXP0027
#pragma warning disable SKEXP0050

namespace sk_chat_demo
{
    public partial class frmChat : Form
	{
		Kernel kernel;
        IChatCompletionService chat;
        ChatHistory history;

        public frmChat()
		{
			InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
		{
            var config = new ConfigurationBuilder().AddUserSecrets<frmChat>().Build();

            // Redis 
            string aoaiEndpoint = config["aoaiEndpoint"];
            string aoaiApiKey = config["aoaiApiKey"];
            string redisConnection = config["redisConnection"];
            string aoaiModel = config["aoaiModel"];
            string aoaiEmbeddingModel = config["aoaiEmbeddingModel"];
            const string systemMessageSet = "systemMessageSet";
            const string userMessageSet = "userMessageSet";
            const string assistantMessageSet = "assistantMessageSet";
            var _redisConnection = await Redis.RedisConnection.InitializeAsync(redisConnection);

            // Azure OpenAI
            var builder = Kernel.CreateBuilder();
            builder.AddAzureOpenAIChatCompletion(
                config["AZURE_OPENAI_MODEL"],
                config["AZURE_OPENAI_ENDPOINT"],
                config["AZURE_OPENAI_APIKEY"]);

            builder.AddAzureOpenAITextEmbeddingGeneration(aoaiEmbeddingModel, config["AZURE_OPENAI_ENDPOINT"], config["AZURE_OPENAI_APIKEY"]);


            builder.Services.AddLogging(
                b => b.AddConsole().SetMinimumLevel(LogLevel.Trace)
                );
            kernel = builder.Build();

            // Initialize Redis memory store. See https://stackexchange.github.io/StackExchange.Redis/Basics#basic-usage
            ConnectionMultiplexer connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(redisConnection);
            IDatabase database = connectionMultiplexer.GetDatabase();
            RedisMemoryStore memoryStore = new RedisMemoryStore(database, vectorSize: 1536);
            string collectionName = "Fsharpupdate";
            var memory = new SemanticTextMemory(
                memoryStore,
                new AzureOpenAITextEmbeddingGenerationService(aoaiEmbeddingModel, aoaiEndpoint, aoaiApiKey)
                );

            chat = kernel.GetRequiredService<IChatCompletionService>();
            history = new ChatHistory();

            ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.NamePlaceholder = "Semantic Kernel - Winforms Chat";
			cbi.PhonePlaceholder = "Azure OpenAI - GPT4o";

			var chat_panel = new ChatForm.Chatbox(cbi);
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
            
            // share SK elements
            chat_panel.kernel = kernel;
            chat_panel.chat = chat;
            chat_panel.history = history;
            chat_panel.memory = memory;

            Controls.Add(chat_panel);
		}
	}
}
