using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using chat_models;


namespace chat_winform.ChatForm
{
    public partial class Chatbox : UserControl
    {
        public ChatboxInfo chatbox_info;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // http client
        public HttpClient client;

        public Chatbox()
        {
            InitializeComponent();
        }

        public void SetChatBotInfo(ChatboxInfo _chatbox_info)
        {
            chatbox_info = _chatbox_info;

            maintitleLabel.Text = chatbox_info.MainTitlePlaceholder;
            subtitleContent.Text = chatbox_info.SubtitlePlaceholder;
            chatTextbox.Text = chatbox_info.ChatPlaceholder;

            chatTextbox.Enter += ChatEnter;
            chatTextbox.Leave += ChatLeave;
            sendButton.Click += SendMessage;
            attachButton.Click += BuildAttachment;
            removeButton.Click += CancelAttachment;

            chatTextbox.KeyUp += OnEnter;

            AddMessage(null);
        }

        /// <summary>
        /// Event handler for the Enter key press in the chat textbox.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The KeyEventArgs object containing the event data.</param>
        async void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
            else if (e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
        }

        /// <summary>
        /// ChatItem objects are generated dynamically from IChatModel. By default, a ChatItem is allowed to be resized up to 60% of the entire screen.
        /// I've thought about it being editable from outside, but there's no real need to.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(IChatModel message)
        {
            var chatItem = new ChatItem(message);
            chatItem.Name = "chatItem" + itemsPanel.Controls.Count;
            chatItem.Dock = DockStyle.Top;
            itemsPanel.Controls.Add(chatItem);
            chatItem.BringToFront();

            chatItem.ResizeBubbles((int)(itemsPanel.Width * 0.6));

            itemsPanel.ScrollControlIntoView(chatItem);
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chatTextbox.Text))
            {
                chatTextbox.Text = chatbox_info.ChatPlaceholder;
                chatTextbox.ForeColor = Color.Gray;
            }
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatEnter(object sender, EventArgs e)
        {
            chatTextbox.ForeColor = Color.Black;
            if (chatTextbox.Text == chatbox_info.ChatPlaceholder)
            {
                chatTextbox.Text = "";
            }
        }

        //Cross-tested this with the Twilio API and the RingCentral API, and async messaging is the way to go.
        async void SendMessage(object sender, EventArgs e)
        {
            string tonumber = subtitleContent.Text;
            string chatmessage = chatTextbox.Text;

            IChatModel genericFileMessage = null;
            ImageChatModel imageMessage = null;
            TextChatModel textMessage = null;

            // make local QA to process
            var questionLocal = new Question
            {
                UserName = chatbox_info.User
            };

            if (chatbox_info.Attachment != null && chatbox_info.AttachmentType.Contains("image"))
            {
                //Upload image to Azure Blog Storage
                var imageUploaded = await Azure.AzureBlobContainer.UploadFileToAzureBlob(chatbox_info.AttachmentName, chatbox_info.AttachmentFileName);

                imageMessage = new ImageChatModel()
                {
                    Author = chatbox_info.User,
                    Image = Image.FromStream(new MemoryStream(chatbox_info.Attachment)),
                    ImageName = chatbox_info.AttachmentName,
                    ImageUri = imageUploaded,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
            }
            else if (chatbox_info.Attachment != null)
            {
                genericFileMessage = new AttachmentChatModel()
                {
                    Author = chatbox_info.User,
                    Attachment = chatbox_info.Attachment,
                    Filename = chatbox_info.AttachmentName,
                    Read = true,
                    Inbound = false,
                    Time = DateTime.Now
                };
            }

            if (!string.IsNullOrWhiteSpace(chatmessage) && chatmessage != chatbox_info.ChatPlaceholder)
            {
                textMessage = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = chatmessage,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
            }

            try
            {

                if (imageMessage != null)
                {
                    AddMessage(imageMessage);
                    CancelAttachment(null, null);
                    questionLocal.ImageUrl = imageMessage.ImageUri;
                }
                if (textMessage != null)
                {
                    AddMessage(textMessage);
                    chatTextbox.Text = string.Empty;

                    // make local QA to process
                    questionLocal.UserQuestion = textMessage.Body;
                }

                // get response from server
                var responseLocal = new Response();
                var httpResponse = await client.PostAsJsonAsync("api/chat", questionLocal);
                if (httpResponse.IsSuccessStatusCode)
                {
                    responseLocal = await httpResponse.Content.ReadFromJsonAsync<Response>();
                }

                // display response in the chat history
                var responseTextModel = new TextChatModel()
                {
                    Author = responseLocal.Author,
                    Body = responseLocal.QuestionResponse,
                    ElapsedTime = responseLocal.ElapsedTime,
                    Inbound = true,
                    Read = false,
                    Time = DateTime.Now
                };
                AddMessage(responseTextModel);

            }
            catch (Exception exc)
            {
                //If any exception is found, then it is printed on the screen. Feel free to change this method if you don't want people to see exceptions.
                textMessage = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = "The message could not be processed. Please see the reason below.\r\n" + exc.Message,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
                AddMessage(textMessage);
            }
        }

        void BuildAttachment(object sender, EventArgs e)
        {
            fileDialog.InitialDirectory = initialdirectory;
            fileDialog.Reset();
            fileDialog.Multiselect = false;

            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selected = fileDialog.FileName;
                try
                {
                    var file = File.ReadAllBytes(selected);
                    //Limits the size of the attachment to 1.45 MB, which is less than the max possible size of an SMS attachment of 1.5 MB.
                    if (file.Length > 1450000)
                    {
                        MessageBox.Show("The attachment provided " + fileDialog.SafeFileName + " is too big to be process by the chat. Please select another.", "Attachment not added.");
                        return;
                    }
                    else
                    {
                        chatbox_info.Attachment = file;
                        chatbox_info.AttachmentFileName = selected;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an issue with retrieving the file.", "File Operation Error");
                }
            }
            else
            {
                return;
            }

            if (chatbox_info.Attachment != null)
            {
                string smallname = fileDialog.SafeFileName;
                chatbox_info.AttachmentName = fileDialog.SafeFileName;

                string name = Path.GetFileNameWithoutExtension(smallname);
                string extension = Path.GetExtension(smallname);
                if (smallname.Length > 12)
                {
                    smallname = name.Substring(0, 7) + ".." + extension;
                    attachButton.Text = smallname;
                }
                else
                {
                    attachButton.Text = smallname;
                }

                removeButton.Visible = true;
                attachButton.Width = 115;
                chatbox_info.AttachmentType = ChatUtility.GetMimeType(extension);
            }
        }

        void CancelAttachment(object sender, EventArgs e)
        {
            attachButton.Text = string.Empty;
            chatbox_info.Attachment = null;
            chatbox_info.AttachmentName = null;
            chatbox_info.AttachmentType = null;
            removeButton.Visible = false;
            attachButton.Width = 35;
        }

        //When the Control resizes, it will trigger the resize event for all the ChatItem object inside as well, again with a default width of 60%.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var control in itemsPanel.Controls)
            {
                if (control is ChatItem)
                {
                    (control as ChatItem).ResizeBubbles((int)(itemsPanel.Width * 0.6));
                }
            }
        }

        private void subtitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
