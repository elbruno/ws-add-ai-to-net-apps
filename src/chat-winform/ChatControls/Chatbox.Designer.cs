
namespace chat_winform.ChatForm
{
	partial class Chatbox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chatbox));
            topPanel = new Panel();
            panelTexts = new Panel();
            maintitleLabel = new Label();
            subtitleContent = new Label();
            pictureBoxLogo = new PictureBox();
            bottomPanel = new Panel();
            chatTextbox = new TextBox();
            attachButton = new Button();
            removeButton = new Button();
            sendButton = new Button();
            itemsPanel = new Panel();
            topPanel.SuspendLayout();
            panelTexts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.BlueViolet;
            topPanel.Controls.Add(panelTexts);
            topPanel.Controls.Add(pictureBoxLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.ForeColor = SystemColors.ButtonHighlight;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(479, 89);
            topPanel.TabIndex = 0;
            // 
            // panelTexts
            // 
            panelTexts.Controls.Add(maintitleLabel);
            panelTexts.Controls.Add(subtitleContent);
            panelTexts.Dock = DockStyle.Fill;
            panelTexts.Location = new Point(126, 0);
            panelTexts.Name = "panelTexts";
            panelTexts.Size = new Size(353, 89);
            panelTexts.TabIndex = 4;
            // 
            // maintitleLabel
            // 
            maintitleLabel.AutoSize = true;
            maintitleLabel.Dock = DockStyle.Top;
            maintitleLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            maintitleLabel.ForeColor = SystemColors.ControlLightLight;
            maintitleLabel.Location = new Point(0, 0);
            maintitleLabel.Margin = new Padding(0);
            maintitleLabel.Name = "maintitleLabel";
            maintitleLabel.Padding = new Padding(5);
            maintitleLabel.Size = new Size(108, 35);
            maintitleLabel.TabIndex = 0;
            maintitleLabel.Text = "Main Title";
            // 
            // subtitleContent
            // 
            subtitleContent.AutoSize = true;
            subtitleContent.Dock = DockStyle.Bottom;
            subtitleContent.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            subtitleContent.ForeColor = SystemColors.ControlLightLight;
            subtitleContent.Location = new Point(0, 37);
            subtitleContent.Margin = new Padding(0);
            subtitleContent.Name = "subtitleContent";
            subtitleContent.Padding = new Padding(5);
            subtitleContent.Size = new Size(83, 52);
            subtitleContent.TabIndex = 1;
            subtitleContent.Text = "Content \r\nContent\r\n";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxLogo.Dock = DockStyle.Left;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Padding = new Padding(10);
            pictureBoxLogo.Size = new Size(126, 89);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 3;
            pictureBoxLogo.TabStop = false;
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.DarkViolet;
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(attachButton);
            bottomPanel.Controls.Add(removeButton);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.ForeColor = SystemColors.ControlLightLight;
            bottomPanel.Location = new Point(0, 633);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(18, 12, 18, 12);
            bottomPanel.Size = new Size(479, 62);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Dock = DockStyle.Fill;
            chatTextbox.Location = new Point(18, 12);
            chatTextbox.Margin = new Padding(4, 3, 4, 3);
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.Size = new Size(292, 38);
            chatTextbox.TabIndex = 7;
            // 
            // attachButton
            // 
            attachButton.BackColor = Color.GhostWhite;
            attachButton.BackgroundImage = (Image)resources.GetObject("attachButton.BackgroundImage");
            attachButton.BackgroundImageLayout = ImageLayout.Center;
            attachButton.Dock = DockStyle.Right;
            attachButton.FlatStyle = FlatStyle.Flat;
            attachButton.ForeColor = SystemColors.ControlText;
            attachButton.ImageAlign = ContentAlignment.MiddleLeft;
            attachButton.Location = new Point(310, 12);
            attachButton.Margin = new Padding(4, 3, 4, 3);
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(41, 38);
            attachButton.TabIndex = 6;
            attachButton.TextAlign = ContentAlignment.MiddleRight;
            attachButton.UseVisualStyleBackColor = false;
            // 
            // removeButton
            // 
            removeButton.BackColor = Color.Red;
            removeButton.Dock = DockStyle.Right;
            removeButton.FlatStyle = FlatStyle.Popup;
            removeButton.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Bold);
            removeButton.ForeColor = SystemColors.ControlLightLight;
            removeButton.Location = new Point(351, 12);
            removeButton.Margin = new Padding(4, 3, 4, 3);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(22, 38);
            removeButton.TabIndex = 5;
            removeButton.Text = "X";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Visible = false;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.DarkViolet;
            sendButton.Dock = DockStyle.Right;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            sendButton.Location = new Point(373, 12);
            sendButton.Margin = new Padding(4, 3, 4, 3);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(88, 38);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = DockStyle.Fill;
            itemsPanel.Location = new Point(0, 89);
            itemsPanel.Margin = new Padding(4, 3, 4, 3);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(479, 544);
            itemsPanel.TabIndex = 2;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Chatbox";
            Size = new Size(479, 695);
            topPanel.ResumeLayout(false);
            panelTexts.ResumeLayout(false);
            panelTexts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label subtitleContent;
		private System.Windows.Forms.Label maintitleLabel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button attachButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.TextBox chatTextbox;
		private System.Windows.Forms.Panel itemsPanel;
        private PictureBox pictureBoxLogo;
        private Panel panelTexts;
    }
}
