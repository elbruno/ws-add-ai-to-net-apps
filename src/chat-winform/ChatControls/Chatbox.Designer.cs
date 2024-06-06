
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
            topPanel = new System.Windows.Forms.Panel();
            statusLabel = new System.Windows.Forms.Label();
            subtitleLabel = new System.Windows.Forms.Label();
            maintitleLabel = new System.Windows.Forms.Label();
            bottomPanel = new System.Windows.Forms.Panel();
            chatTextbox = new System.Windows.Forms.TextBox();
            attachButton = new System.Windows.Forms.Button();
            removeButton = new System.Windows.Forms.Button();
            sendButton = new System.Windows.Forms.Button();
            itemsPanel = new System.Windows.Forms.Panel();
            topPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = System.Drawing.Color.BlueViolet;
            topPanel.Controls.Add(statusLabel);
            topPanel.Controls.Add(subtitleLabel);
            topPanel.Controls.Add(maintitleLabel);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            topPanel.Name = "topPanel";
            topPanel.Padding = new System.Windows.Forms.Padding(18, 17, 18, 17);
            topPanel.Size = new System.Drawing.Size(479, 89);
            topPanel.TabIndex = 0;
            topPanel.Paint += topPanel_Paint;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = System.Windows.Forms.DockStyle.Right;
            statusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            statusLabel.Location = new System.Drawing.Point(395, 42);
            statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(66, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "status label";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            subtitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            subtitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            subtitleLabel.Location = new System.Drawing.Point(18, 51);
            subtitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new System.Drawing.Size(65, 21);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "subtitle";
            // 
            // maintitleLabel
            // 
            maintitleLabel.AutoSize = true;
            maintitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            maintitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            maintitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            maintitleLabel.Location = new System.Drawing.Point(18, 17);
            maintitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            maintitleLabel.Name = "maintitleLabel";
            maintitleLabel.Size = new System.Drawing.Size(98, 25);
            maintitleLabel.TabIndex = 0;
            maintitleLabel.Text = "Main Title";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.DarkViolet;
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(attachButton);
            bottomPanel.Controls.Add(removeButton);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            bottomPanel.Location = new System.Drawing.Point(0, 633);
            bottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            bottomPanel.Size = new System.Drawing.Size(479, 62);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            chatTextbox.Location = new System.Drawing.Point(18, 12);
            chatTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.Size = new System.Drawing.Size(292, 38);
            chatTextbox.TabIndex = 7;
            // 
            // attachButton
            // 
            attachButton.BackColor = System.Drawing.Color.GhostWhite;
            attachButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("attachButton.BackgroundImage");
            attachButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            attachButton.Dock = System.Windows.Forms.DockStyle.Right;
            attachButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            attachButton.ForeColor = System.Drawing.SystemColors.ControlText;
            attachButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            attachButton.Location = new System.Drawing.Point(310, 12);
            attachButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            attachButton.Name = "attachButton";
            attachButton.Size = new System.Drawing.Size(41, 38);
            attachButton.TabIndex = 6;
            attachButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            attachButton.UseVisualStyleBackColor = false;
            // 
            // removeButton
            // 
            removeButton.BackColor = System.Drawing.Color.Red;
            removeButton.Dock = System.Windows.Forms.DockStyle.Right;
            removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            removeButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold);
            removeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            removeButton.Location = new System.Drawing.Point(351, 12);
            removeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            removeButton.Name = "removeButton";
            removeButton.Size = new System.Drawing.Size(22, 38);
            removeButton.TabIndex = 5;
            removeButton.Text = "X";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Visible = false;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.Color.DarkViolet;
            sendButton.Dock = System.Windows.Forms.DockStyle.Right;
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sendButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            sendButton.Location = new System.Drawing.Point(373, 12);
            sendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(88, 38);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            itemsPanel.Location = new System.Drawing.Point(0, 89);
            itemsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new System.Drawing.Size(479, 544);
            itemsPanel.TabIndex = 2;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Chatbox";
            Size = new System.Drawing.Size(479, 695);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label subtitleLabel;
		private System.Windows.Forms.Label maintitleLabel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button attachButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.TextBox chatTextbox;
		private System.Windows.Forms.Panel itemsPanel;
	}
}
