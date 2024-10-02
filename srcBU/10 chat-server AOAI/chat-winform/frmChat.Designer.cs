
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            menuStrip1 = new MenuStrip();
            toolStripMenuItemServer = new ToolStripMenuItem();
            toolStripMenuItemShowServer = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemSetUserName = new ToolStripMenuItem();
            toolStripTextBoxUserName = new ToolStripTextBox();
            panelChatControl = new Panel();
            chatboxControl = new ChatForm.Chatbox();
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
            toolStripMenuItemServer.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemShowServer, toolStripSeparator1, toolStripMenuItemSetUserName, toolStripTextBoxUserName });
            toolStripMenuItemServer.Name = "toolStripMenuItemServer";
            toolStripMenuItemServer.Size = new Size(61, 20);
            toolStripMenuItemServer.Text = "Options";
            // 
            // toolStripMenuItemShowServer
            // 
            toolStripMenuItemShowServer.Name = "toolStripMenuItemShowServer";
            toolStripMenuItemShowServer.Size = new Size(180, 22);
            toolStripMenuItemShowServer.Text = "Chat Server";
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
            // panelChatControl
            // 
            panelChatControl.Controls.Add(chatboxControl);
            panelChatControl.Dock = DockStyle.Fill;
            panelChatControl.Location = new Point(0, 24);
            panelChatControl.Name = "panelChatControl";
            panelChatControl.Size = new Size(800, 426);
            panelChatControl.TabIndex = 2;
            // 
            // chatboxControl
            // 
            chatboxControl._logger = null;
            chatboxControl.BackColor = Color.White;
            chatboxControl.Dock = DockStyle.Fill;
            chatboxControl.Location = new Point(0, 0);
            chatboxControl.Margin = new Padding(4, 3, 4, 3);
            chatboxControl.Name = "chatboxControl";
            chatboxControl.Size = new Size(800, 426);
            chatboxControl.TabIndex = 0;
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelChatControl);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private ToolStripMenuItem toolStripMenuItemShowServer;
        private Panel panelChatControl;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemSetUserName;
        private ToolStripTextBox toolStripTextBoxUserName;
        private ChatForm.Chatbox chatboxControl;
    }
}

