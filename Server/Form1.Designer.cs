
namespace SocketServerGUI
{
    partial class Form1
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
            this.btnAcceptIncomingConnection = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.serverDebugTextField = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.portNumber = new System.Windows.Forms.TextBox();
            this.stopListening = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAcceptIncomingConnection
            // 
            this.btnAcceptIncomingConnection.Location = new System.Drawing.Point(153, 12);
            this.btnAcceptIncomingConnection.Name = "btnAcceptIncomingConnection";
            this.btnAcceptIncomingConnection.Size = new System.Drawing.Size(158, 37);
            this.btnAcceptIncomingConnection.TabIndex = 0;
            this.btnAcceptIncomingConnection.Text = "Start Listening";
            this.btnAcceptIncomingConnection.UseVisualStyleBackColor = true;
            this.btnAcceptIncomingConnection.Click += new System.EventHandler(this.btnAcceptIncomingConnection_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(70, 450);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(300, 23);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(382, 442);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(85, 37);
            this.btnSendAll.TabIndex = 4;
            this.btnSendAll.Text = "Send All";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // serverDebugTextField
            // 
            this.serverDebugTextField.Location = new System.Drawing.Point(12, 55);
            this.serverDebugTextField.Name = "serverDebugTextField";
            this.serverDebugTextField.ReadOnly = true;
            this.serverDebugTextField.Size = new System.Drawing.Size(456, 381);
            this.serverDebugTextField.TabIndex = 6;
            this.serverDebugTextField.Text = "";
            this.serverDebugTextField.TextChanged += new System.EventHandler(this.serverDebugTextField_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port";
            // 
            // portNumber
            // 
            this.portNumber.Location = new System.Drawing.Point(47, 20);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(100, 23);
            this.portNumber.TabIndex = 9;
            this.portNumber.TextChanged += new System.EventHandler(this.portNumber_TextChanged);
            // 
            // stopListening
            // 
            this.stopListening.Enabled = false;
            this.stopListening.Location = new System.Drawing.Point(317, 12);
            this.stopListening.Name = "stopListening";
            this.stopListening.Size = new System.Drawing.Size(151, 37);
            this.stopListening.TabIndex = 10;
            this.stopListening.Text = "Stop Listening";
            this.stopListening.UseVisualStyleBackColor = true;
            this.stopListening.Click += new System.EventHandler(this.stopListening_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 491);
            this.Controls.Add(this.stopListening);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverDebugTextField);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnAcceptIncomingConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sweeter Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcceptIncomingConnection;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.RichTextBox serverDebugTextField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portNumber;
        private System.Windows.Forms.Button stopListening;
    }
}

