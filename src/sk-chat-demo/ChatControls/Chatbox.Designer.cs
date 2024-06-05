
namespace sk_chat_demo.ChatForm
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
            phoneLabel = new System.Windows.Forms.Label();
            clientnameLabel = new System.Windows.Forms.Label();
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
            topPanel.BackColor = System.Drawing.Color.RoyalBlue;
            topPanel.Controls.Add(statusLabel);
            topPanel.Controls.Add(phoneLabel);
            topPanel.Controls.Add(clientnameLabel);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            topPanel.Name = "topPanel";
            topPanel.Padding = new System.Windows.Forms.Padding(21, 23, 21, 23);
            topPanel.Size = new System.Drawing.Size(547, 119);
            topPanel.TabIndex = 0;
            topPanel.Paint += topPanel_Paint;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = System.Windows.Forms.DockStyle.Right;
            statusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            statusLabel.Location = new System.Drawing.Point(441, 55);
            statusLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(85, 20);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "LastViewed";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            phoneLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            phoneLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            phoneLabel.Location = new System.Drawing.Point(21, 68);
            phoneLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(148, 28);
            phoneLabel.TabIndex = 1;
            phoneLabel.Text = "(408) 262-9190";
            // 
            // clientnameLabel
            // 
            clientnameLabel.AutoSize = true;
            clientnameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            clientnameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            clientnameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            clientnameLabel.Location = new System.Drawing.Point(21, 23);
            clientnameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            clientnameLabel.Name = "clientnameLabel";
            clientnameLabel.Size = new System.Drawing.Size(149, 32);
            clientnameLabel.TabIndex = 0;
            clientnameLabel.Text = "Client Name";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.RoyalBlue;
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(attachButton);
            bottomPanel.Controls.Add(removeButton);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            bottomPanel.Location = new System.Drawing.Point(0, 844);
            bottomPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new System.Windows.Forms.Padding(21, 16, 21, 16);
            bottomPanel.Size = new System.Drawing.Size(547, 83);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            chatTextbox.Location = new System.Drawing.Point(21, 16);
            chatTextbox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.Size = new System.Drawing.Size(332, 51);
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
            attachButton.Location = new System.Drawing.Point(353, 16);
            attachButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            attachButton.Name = "attachButton";
            attachButton.Size = new System.Drawing.Size(47, 51);
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
            removeButton.Location = new System.Drawing.Point(400, 16);
            removeButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            removeButton.Name = "removeButton";
            removeButton.Size = new System.Drawing.Size(25, 51);
            removeButton.TabIndex = 5;
            removeButton.Text = "X";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Visible = false;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.Color.RoyalBlue;
            sendButton.Dock = System.Windows.Forms.DockStyle.Right;
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sendButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            sendButton.Location = new System.Drawing.Point(425, 16);
            sendButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(101, 51);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            itemsPanel.Location = new System.Drawing.Point(0, 119);
            itemsPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new System.Drawing.Size(547, 725);
            itemsPanel.TabIndex = 2;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            Name = "Chatbox";
            Size = new System.Drawing.Size(547, 927);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label phoneLabel;
		private System.Windows.Forms.Label clientnameLabel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button attachButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.TextBox chatTextbox;
		private System.Windows.Forms.Panel itemsPanel;
	}
}
