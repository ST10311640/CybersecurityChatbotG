namespace CybersecurityChatbotG
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox txtAsciiArt;
        private System.Windows.Forms.RichTextBox txtChatHistory;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnPlayGreeting;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAsciiArt = new System.Windows.Forms.RichTextBox();
            this.txtChatHistory = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnPlayGreeting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAsciiArt
            // 
            this.txtAsciiArt.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAsciiArt.Location = new System.Drawing.Point(12, 12);
            this.txtAsciiArt.Name = "txtAsciiArt";
            this.txtAsciiArt.ReadOnly = true;
            this.txtAsciiArt.Size = new System.Drawing.Size(560, 120);
            this.txtAsciiArt.TabIndex = 0;
            this.txtAsciiArt.Text = "";
            // 
            // txtChatHistory
            // 
            this.txtChatHistory.Location = new System.Drawing.Point(12, 138);
            this.txtChatHistory.Name = "txtChatHistory";
            this.txtChatHistory.ReadOnly = true;
            this.txtChatHistory.Size = new System.Drawing.Size(560, 200);
            this.txtChatHistory.TabIndex = 1;
            this.txtChatHistory.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(12, 345);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(400, 23);
            this.txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(418, 344);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 25);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnPlayGreeting
            // 
            this.btnPlayGreeting.Location = new System.Drawing.Point(499, 344);
            this.btnPlayGreeting.Name = "btnPlayGreeting";
            this.btnPlayGreeting.Size = new System.Drawing.Size(75, 25);
            this.btnPlayGreeting.TabIndex = 4;
            this.btnPlayGreeting.Text = "Greeting";
            this.btnPlayGreeting.UseVisualStyleBackColor = true;
            this.btnPlayGreeting.Click += new System.EventHandler(this.btnPlayGreeting_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.btnPlayGreeting);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.txtChatHistory);
            this.Controls.Add(this.txtAsciiArt);
            this.Name = "Form1";
            this.Text = "Cybersecurity Chatbot";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

