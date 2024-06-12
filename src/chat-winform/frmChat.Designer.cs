
namespace chat_winform
{
	partial class frmChat
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripMenuItemServer = new ToolStripMenuItem();
            toolStripMenuItemSetServer = new ToolStripMenuItem();
            toolStripTextBoxChatServer = new ToolStripTextBox();
            chat_panel = new ChatForm.Chatbox();
            panelChatControl = new Panel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemSetUserName = new ToolStripMenuItem();
            toolStripTextBoxUserName = new ToolStripTextBox();
            menuStrip1.SuspendLayout();
            panelChatControl.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemServer });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemServer
            // 
            toolStripMenuItemServer.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemSetServer, toolStripTextBoxChatServer, toolStripSeparator1, toolStripMenuItemSetUserName, toolStripTextBoxUserName });
            toolStripMenuItemServer.Name = "toolStripMenuItemServer";
            toolStripMenuItemServer.Size = new Size(61, 20);
            toolStripMenuItemServer.Text = "Options";
            // 
            // toolStripMenuItemSetServer
            // 
            toolStripMenuItemSetServer.Name = "toolStripMenuItemSetServer";
            toolStripMenuItemSetServer.Size = new Size(180, 22);
            toolStripMenuItemSetServer.Text = "Set Chat Server";
            toolStripMenuItemSetServer.Click += toolStripMenuItemSetServer_Click;
            // 
            // toolStripTextBoxChatServer
            // 
            toolStripTextBoxChatServer.Name = "toolStripTextBoxChatServer";
            toolStripTextBoxChatServer.Size = new Size(100, 23);
            // 
            // chat_panel
            // 
            chat_panel.BackColor = Color.White;
            chat_panel.Dock = DockStyle.Fill;
            chat_panel.Location = new Point(0, 0);
            chat_panel.Margin = new Padding(4, 3, 4, 3);
            chat_panel.Name = "chat_panel";
            chat_panel.Size = new Size(800, 426);
            chat_panel.TabIndex = 1;
            // 
            // panelChatControl
            // 
            panelChatControl.Controls.Add(chat_panel);
            panelChatControl.Dock = DockStyle.Fill;
            panelChatControl.Location = new Point(0, 24);
            panelChatControl.Name = "panelChatControl";
            panelChatControl.Size = new Size(800, 426);
            panelChatControl.TabIndex = 2;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // toolStripMenuItemSetUserName
            // 
            toolStripMenuItemSetUserName.Name = "toolStripMenuItemSetUserName";
            toolStripMenuItemSetUserName.Size = new Size(180, 22);
            toolStripMenuItemSetUserName.Text = "Set User Name";
            toolStripMenuItemSetUserName.Click += toolStripMenuItemSetUserName_Click;
            // 
            // toolStripTextBoxUserName
            // 
            toolStripTextBoxUserName.Name = "toolStripTextBoxUserName";
            toolStripTextBoxUserName.Size = new Size(100, 23);
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelChatControl);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmChat";
            Text = "Semantic Kernel - Winforms Chat";
            Load += Form1_LoadAsync;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelChatControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemServer;
        private ToolStripMenuItem toolStripMenuItemSetServer;
        private ToolStripTextBox toolStripTextBoxChatServer;
        private ChatForm.Chatbox chat_panel;
        private Panel panelChatControl;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemSetUserName;
        private ToolStripTextBox toolStripTextBoxUserName;
    }
}

