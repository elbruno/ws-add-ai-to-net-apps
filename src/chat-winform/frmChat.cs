﻿using System;
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
            // http client
            client = new HttpClient();
            client.BaseAddress = new Uri(uriChatServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // chat control
            ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.MainTitlePlaceholder = "Semantic Kernel - Winforms Chat";
			cbi.SubtitlePlaceholder = "Azure OpenAI - GPT4o";
            cbi.User = "Bruno";

			var chat_panel = new ChatForm.Chatbox(cbi);
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
            
            // http client
            chat_panel.client = client;

            Controls.Add(chat_panel);
		}
	}
}
