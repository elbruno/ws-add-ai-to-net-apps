
namespace chat_winform.ChatForm
{
	partial class ChatItem
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
            authorPanel = new Panel();
            authorLabel = new Label();
            bodyPanel = new Panel();
            bodyTextBox = new RichTextBox();
            authorPanel.SuspendLayout();
            bodyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // authorPanel
            // 
            authorPanel.Controls.Add(authorLabel);
            authorPanel.Dock = DockStyle.Bottom;
            authorPanel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            authorPanel.ForeColor = SystemColors.ButtonShadow;
            authorPanel.Location = new Point(12, 52);
            authorPanel.Margin = new Padding(4, 3, 4, 3);
            authorPanel.Name = "authorPanel";
            authorPanel.Padding = new Padding(0, 6, 0, 0);
            authorPanel.Size = new Size(683, 30);
            authorPanel.TabIndex = 8;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Dock = DockStyle.Left;
            authorLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            authorLabel.Location = new Point(0, 6);
            authorLabel.Margin = new Padding(4, 0, 4, 0);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(142, 19);
            authorLabel.TabIndex = 0;
            authorLabel.Text = "System - 10/22/2020";
            // 
            // bodyPanel
            // 
            bodyPanel.BackColor = Color.RoyalBlue;
            bodyPanel.Controls.Add(bodyTextBox);
            bodyPanel.Dock = DockStyle.Left;
            bodyPanel.Location = new Point(12, 6);
            bodyPanel.Margin = new Padding(4, 3, 4, 3);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(2);
            bodyPanel.Size = new Size(424, 46);
            bodyPanel.TabIndex = 9;
            // 
            // bodyTextBox
            // 
            bodyTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bodyTextBox.BackColor = Color.RoyalBlue;
            bodyTextBox.BorderStyle = BorderStyle.None;
            bodyTextBox.Font = new Font("Segoe UI", 12F);
            bodyTextBox.ForeColor = Color.White;
            bodyTextBox.Location = new Point(6, 6);
            bodyTextBox.Margin = new Padding(4, 3, 4, 3);
            bodyTextBox.Name = "bodyTextBox";
            bodyTextBox.ReadOnly = true;
            bodyTextBox.ScrollBars = RichTextBoxScrollBars.None;
            bodyTextBox.Size = new Size(412, 35);
            bodyTextBox.TabIndex = 4;
            bodyTextBox.Text = "Hello there. This is a test for the longer word usage.\n\nHello there. This is a test for the longer word usage.\n\nHello there. This is a test for the longer word usage.\n\n";
            // 
            // ChatItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(bodyPanel);
            Controls.Add(authorPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChatItem";
            Padding = new Padding(12, 6, 12, 6);
            Size = new Size(707, 88);
            Load += ChatItem_Load;
            authorPanel.ResumeLayout(false);
            authorPanel.PerformLayout();
            bodyPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel authorPanel;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.Panel bodyPanel;
		private System.Windows.Forms.RichTextBox bodyTextBox;
    }
}
