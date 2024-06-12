using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace chat_winform
{
    public partial class frmChat : Form
    {
        HttpClient client;
        string uriChatServer = @"http://localhost:5259/";

        public frmChat()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {

            // chat control
            ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
            cbi.MainTitlePlaceholder = "Semantic Kernel - Winforms Chat";
            cbi.SubtitlePlaceholder = "Azure OpenAI - GPT4o";
            cbi.User = "Bruno";

            chat_panel.SetChatBotInfo(cbi);
            SetHttpClientforChatServer();

        }

        private void SetHttpClientforChatServer()
        {
            // http client
            client = new HttpClient();
            client.BaseAddress = new Uri(uriChatServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            toolStripTextBoxChatServer.Text = uriChatServer;
            chat_panel.client = client;
        }

        private void toolStripMenuItemSetServer_Click(object sender, EventArgs e)
        {
            uriChatServer = toolStripTextBoxChatServer.Text;
            SetHttpClientforChatServer();
        }
    }
}
