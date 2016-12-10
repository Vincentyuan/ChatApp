using System;
namespace ChatClient{

    partial class ChatForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         
            this.users = new System.Windows.Forms.Button();
            this.topics = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chatFrame = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // users
            // 
            this.users.Location = new System.Drawing.Point(12, 75);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(124, 53);
            this.users.TabIndex = 0;
            this.users.Text = "users ";
            this.users.UseVisualStyleBackColor = true;
            this.users.Click += new System.EventHandler(this.users_Click);
            // 
            // topics
            // 
            this.topics.Location = new System.Drawing.Point(12, 169);
            this.topics.Name = "topics";
            this.topics.Size = new System.Drawing.Size(124, 54);
            this.topics.TabIndex = 1;
            this.topics.Text = "topics";
            this.topics.UseVisualStyleBackColor = true;
            this.topics.Click += new System.EventHandler(this.topics_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 24;
            this.listBox.Location = new System.Drawing.Point(160, 75);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(164, 388);
            this.listBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chatFrame
            // 
            this.chatFrame.Location = new System.Drawing.Point(351, 75);
            this.chatFrame.Multiline = true;
            this.chatFrame.Name = "chatFrame";
            this.chatFrame.Size = new System.Drawing.Size(441, 338);
            this.chatFrame.TabIndex = 4;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(691, 453);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(121, 39);
            this.sendMessageButton.TabIndex = 5;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            // 
            // messageType
            // 
            this.messageType.Location = new System.Drawing.Point(351, 434);
            this.messageType.Multiline = true;
            this.messageType.Name = "messageType";
            this.messageType.Size = new System.Drawing.Size(299, 58);
            this.messageType.TabIndex = 6;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 551);
            this.Controls.Add(this.messageType);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.chatFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.topics);
            this.Controls.Add(this.users);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button topics;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chatFrame;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox messageType;
    }
}