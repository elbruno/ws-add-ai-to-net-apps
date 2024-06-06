namespace sk_chat_winform.ChatForm
{
    public class ChatboxInfo
    {
        public string User { get; set; }
        public string MainTitlePlaceholder { get; set; }
        public string SubtitlePlaceholder { get; set; }
        public string StatusPlaceholder { get; set; }
        public string ChatPlaceholder = "Please enter a message...";
        public byte[] Attachment { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
    }
}
