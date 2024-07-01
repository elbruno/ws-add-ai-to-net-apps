using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace chat_winform
{
    public partial class frmChat : Form
    {
        HttpClient _client;
        private readonly ILogger _logger;

        string userName = @"Bruno";
        ChatForm.ChatboxInfo cbi;

        public frmChat(ILogger<frmChat> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            // chat control
            cbi = new ChatForm.ChatboxInfo();
            cbi.MainTitlePlaceholder = "Adding AI to a Winforms Chat";
            cbi.SubtitlePlaceholder = "Azure OpenAI - GPT4o";
            cbi.User = userName;
            toolStripTextBoxUserName.Text = userName;

            chatboxControl._client = _client;
            chatboxControl._logger = _logger;
            chatboxControl.SetChatBotInfo(cbi);

            // display chat server
            toolStripMenuItemShowServer.Text = $"Chat Server: {_client.BaseAddress.ToString()}";
        }

        private void toolStripMenuItemSetUserName_Click(object sender, EventArgs e)
        {
            userName = toolStripTextBoxUserName.Text;
            cbi.User = userName;
        }
    }
}
