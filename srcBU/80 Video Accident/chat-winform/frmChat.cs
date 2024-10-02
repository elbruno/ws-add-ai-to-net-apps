using Microsoft.Extensions.Logging;

namespace chat_winform
{
    public partial class frmChat : Form
    {
        ChatApiClient _chatApiClient;
        private readonly ILogger _logger;

        string userName = @"Bruno";
        ChatForm.ChatboxInfo cbi;

        public frmChat(ILogger<frmChat> logger, ChatApiClient chatApiClient)
        {
            _logger = logger;
            _chatApiClient = chatApiClient;
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            // chat control
            cbi = new ChatForm.ChatboxInfo
            {
                MainTitlePlaceholder = "Adding AI to a Winforms Chat",
                SubtitlePlaceholder = "No LLM",
                User = userName
            };
            toolStripTextBoxUserName.Text = userName;

            chatboxControl._chatApiClient = _chatApiClient;
            chatboxControl._logger = _logger;
            chatboxControl.SetChatBotInfo(cbi);

            // display chat server
            toolStripMenuItemShowServer.Text = $"Chat Server: {_chatApiClient.BaseAddress}";
        }

        private void toolStripMenuItemSetUserName_Click(object sender, EventArgs e)
        {
            userName = toolStripTextBoxUserName.Text;
            cbi.User = userName;
        }
    }
}
