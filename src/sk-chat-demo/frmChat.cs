using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace sk_chat_winform
{
    public partial class frmChat : Form
	{
        HttpClient client;
        string uriChatServer = @"https://localhost:7075/";

        public frmChat()
		{
			InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
		{
            // http client
            client = new HttpClient();
            client.BaseAddress = new Uri(uriChatServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // chat control
            ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.NamePlaceholder = "Semantic Kernel - Winforms Chat";
			cbi.PhonePlaceholder = "Azure OpenAI - GPT4o";

			var chat_panel = new ChatForm.Chatbox(cbi);
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
            
            // http client
            chat_panel.client = client;
            chat_panel.userName = "Bruno";

            Controls.Add(chat_panel);
		}
	}
}
