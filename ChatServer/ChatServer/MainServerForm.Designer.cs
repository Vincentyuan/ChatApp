namespace ChatServer
{
    partial class MainServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleListBox = new System.Windows.Forms.ListBox();
            this.startServer = new System.Windows.Forms.Button();
            this.IPAddressText = new System.Windows.Forms.TextBox();
            this.PortNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stopServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consoleListBox
            // 
            this.consoleListBox.FormattingEnabled = true;
            this.consoleListBox.ItemHeight = 24;
            this.consoleListBox.Location = new System.Drawing.Point(16, 297);
            this.consoleListBox.Name = "consoleListBox";
            this.consoleListBox.Size = new System.Drawing.Size(912, 268);
            this.consoleListBox.TabIndex = 0;
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(12, 165);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(197, 42);
            this.startServer.TabIndex = 1;
            this.startServer.Text = "Start server";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // IPAddressText
            // 
            this.IPAddressText.Location = new System.Drawing.Point(242, 31);
            this.IPAddressText.Name = "IPAddressText";
            this.IPAddressText.Size = new System.Drawing.Size(159, 35);
            this.IPAddressText.TabIndex = 2;
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(242, 89);
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(159, 35);
            this.PortNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "server IP Address";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "port number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "console:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // stopServer
            // 
            this.stopServer.Location = new System.Drawing.Point(242, 165);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(100, 42);
            this.stopServer.TabIndex = 7;
            this.stopServer.Text = "Stop";
            this.stopServer.UseVisualStyleBackColor = true;
            this.stopServer.Click += new System.EventHandler(this.stopServer_Click);
            // 
            // MainServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 577);
            this.Controls.Add(this.stopServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.IPAddressText);
            this.Controls.Add(this.startServer);
            this.Controls.Add(this.consoleListBox);
            this.Name = "MainServerForm";
            this.Text = "ChatServer";
            this.Load += new System.EventHandler(this.MainServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox consoleListBox;
        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.TextBox IPAddressText;
        private System.Windows.Forms.TextBox PortNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stopServer;
    }
}

