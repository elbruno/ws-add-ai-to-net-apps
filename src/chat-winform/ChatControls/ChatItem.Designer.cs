
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
            authorPanel = new System.Windows.Forms.Panel();
            authorLabel = new System.Windows.Forms.Label();
            bodyPanel = new System.Windows.Forms.Panel();
            bodyTextBox = new System.Windows.Forms.TextBox();
            authorPanel.SuspendLayout();
            bodyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // authorPanel
            // 
            authorPanel.Controls.Add(authorLabel);
            authorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            authorPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            authorPanel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            authorPanel.Location = new System.Drawing.Point(12, 52);
            authorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            authorPanel.Name = "authorPanel";
            authorPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            authorPanel.Size = new System.Drawing.Size(683, 30);
            authorPanel.TabIndex = 8;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            authorLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            authorLabel.Location = new System.Drawing.Point(0, 6);
            authorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new System.Drawing.Size(110, 13);
            authorLabel.TabIndex = 0;
            authorLabel.Text = "System - 10/22/2020";
            // 
            // bodyPanel
            // 
            bodyPanel.BackColor = System.Drawing.Color.RoyalBlue;
            bodyPanel.Controls.Add(bodyTextBox);
            bodyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            bodyPanel.Location = new System.Drawing.Point(12, 6);
            bodyPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            bodyPanel.Size = new System.Drawing.Size(424, 46);
            bodyPanel.TabIndex = 9;
            // 
            // bodyTextBox
            // 
            bodyTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bodyTextBox.BackColor = System.Drawing.Color.DarkViolet;
            bodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            bodyTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            bodyTextBox.ForeColor = System.Drawing.Color.White;
            bodyTextBox.Location = new System.Drawing.Point(6, 6);
            bodyTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bodyTextBox.Multiline = true;
            bodyTextBox.Name = "bodyTextBox";
            bodyTextBox.ReadOnly = true;
            bodyTextBox.Size = new System.Drawing.Size(412, 35);
            bodyTextBox.TabIndex = 4;
            bodyTextBox.Text = "Hello there. This is a test for the longer word usage.";
            // 
            // ChatItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(bodyPanel);
            Controls.Add(authorPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ChatItem";
            Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            Size = new System.Drawing.Size(707, 88);
            Load += ChatItem_Load;
            authorPanel.ResumeLayout(false);
            authorPanel.PerformLayout();
            bodyPanel.ResumeLayout(false);
            bodyPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel authorPanel;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.Panel bodyPanel;
		private System.Windows.Forms.TextBox bodyTextBox;
	}
}
