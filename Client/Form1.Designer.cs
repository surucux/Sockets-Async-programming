
namespace AsyncSocketClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.portLBL = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dbgTextBox = new System.Windows.Forms.RichTextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.userSearchTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetSweets = new System.Windows.Forms.Button();
            this.btn_getAllSweets = new System.Windows.Forms.Button();
            this.asd = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetFollowSweetFeed = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFollowers = new System.Windows.Forms.Button();
            this.btnGetFollowers = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBlockUser = new System.Windows.Forms.Button();
            this.usrBlockTextBox = new System.Windows.Forms.TextBox();
            this.btnFollow = new System.Windows.Forms.Button();
            this.followUserTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnListUser = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteSweet = new System.Windows.Forms.Button();
            this.deleteSweetTextBox = new System.Windows.Forms.TextBox();
            this.asd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(74, 26);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 23);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "127.0.0.1";
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
            // 
            // portLBL
            // 
            this.portLBL.AutoSize = true;
            this.portLBL.Location = new System.Drawing.Point(6, 61);
            this.portLBL.Name = "portLBL";
            this.portLBL.Size = new System.Drawing.Size(29, 15);
            this.portLBL.TabIndex = 2;
            this.portLBL.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(74, 55);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "23000";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 122);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 25);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dbgTextBox
            // 
            this.dbgTextBox.Location = new System.Drawing.Point(12, 12);
            this.dbgTextBox.Name = "dbgTextBox";
            this.dbgTextBox.ReadOnly = true;
            this.dbgTextBox.Size = new System.Drawing.Size(477, 301);
            this.dbgTextBox.TabIndex = 5;
            this.dbgTextBox.Text = "";
            this.dbgTextBox.TextChanged += new System.EventHandler(this.dbgTextBox_TextChanged);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(95, 122);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(85, 25);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(12, 319);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(393, 23);
            this.msgBox.TabIndex = 7;
            this.msgBox.TextChanged += new System.EventHandler(this.msgBox_TextChanged);
            this.msgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msgBox_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(414, 319);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username";
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(74, 84);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(100, 23);
            this.username_textbox.TabIndex = 10;
            this.username_textbox.Text = "maxverstappen";
            this.username_textbox.TextChanged += new System.EventHandler(this.username_textbox_TextChanged);
            // 
            // userSearchTextBox
            // 
            this.userSearchTextBox.Location = new System.Drawing.Point(7, 37);
            this.userSearchTextBox.Name = "userSearchTextBox";
            this.userSearchTextBox.PlaceholderText = "Username";
            this.userSearchTextBox.Size = new System.Drawing.Size(168, 23);
            this.userSearchTextBox.TabIndex = 11;
            this.userSearchTextBox.TextChanged += new System.EventHandler(this.userSearchTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Get Sweets";
            // 
            // btnGetSweets
            // 
            this.btnGetSweets.Enabled = false;
            this.btnGetSweets.Location = new System.Drawing.Point(7, 62);
            this.btnGetSweets.Name = "btnGetSweets";
            this.btnGetSweets.Size = new System.Drawing.Size(168, 27);
            this.btnGetSweets.TabIndex = 13;
            this.btnGetSweets.Text = "Get";
            this.btnGetSweets.UseVisualStyleBackColor = true;
            this.btnGetSweets.Click += new System.EventHandler(this.btnGetSweets_Click);
            // 
            // btn_getAllSweets
            // 
            this.btn_getAllSweets.Enabled = false;
            this.btn_getAllSweets.Location = new System.Drawing.Point(7, 95);
            this.btn_getAllSweets.Name = "btn_getAllSweets";
            this.btn_getAllSweets.Size = new System.Drawing.Size(168, 27);
            this.btn_getAllSweets.TabIndex = 14;
            this.btn_getAllSweets.Text = "Get All Sweets";
            this.btn_getAllSweets.UseVisualStyleBackColor = true;
            this.btn_getAllSweets.Click += new System.EventHandler(this.btn_getAllSweets_Click);
            // 
            // asd
            // 
            this.asd.Controls.Add(this.label1);
            this.asd.Controls.Add(this.txtIPAddress);
            this.asd.Controls.Add(this.portLBL);
            this.asd.Controls.Add(this.txtPort);
            this.asd.Controls.Add(this.label2);
            this.asd.Controls.Add(this.username_textbox);
            this.asd.Controls.Add(this.btnConnect);
            this.asd.Controls.Add(this.btnDisconnect);
            this.asd.Location = new System.Drawing.Point(495, 12);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(186, 162);
            this.asd.TabIndex = 15;
            this.asd.TabStop = false;
            this.asd.Text = "Login";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetFollowSweetFeed);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnGetSweets);
            this.groupBox1.Controls.Add(this.userSearchTextBox);
            this.groupBox1.Controls.Add(this.btn_getAllSweets);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(495, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 162);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sweet Operations";
            // 
            // btnGetFollowSweetFeed
            // 
            this.btnGetFollowSweetFeed.Enabled = false;
            this.btnGetFollowSweetFeed.Location = new System.Drawing.Point(6, 128);
            this.btnGetFollowSweetFeed.Name = "btnGetFollowSweetFeed";
            this.btnGetFollowSweetFeed.Size = new System.Drawing.Size(167, 27);
            this.btnGetFollowSweetFeed.TabIndex = 18;
            this.btnGetFollowSweetFeed.Text = "Get Follow Sweet Feed";
            this.btnGetFollowSweetFeed.UseVisualStyleBackColor = true;
            this.btnGetFollowSweetFeed.Click += new System.EventHandler(this.btnGetFollowSweetFeed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 96);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Opeartions";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFollowers);
            this.groupBox3.Controls.Add(this.btnGetFollowers);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnBlockUser);
            this.groupBox3.Controls.Add(this.usrBlockTextBox);
            this.groupBox3.Controls.Add(this.btnFollow);
            this.groupBox3.Controls.Add(this.followUserTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnListUser);
            this.groupBox3.Location = new System.Drawing.Point(687, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 268);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Operations";
            // 
            // btnFollowers
            // 
            this.btnFollowers.Enabled = false;
            this.btnFollowers.Location = new System.Drawing.Point(6, 80);
            this.btnFollowers.Name = "btnFollowers";
            this.btnFollowers.Size = new System.Drawing.Size(168, 23);
            this.btnFollowers.TabIndex = 21;
            this.btnFollowers.Text = "Get Follower List";
            this.btnFollowers.UseVisualStyleBackColor = true;
            this.btnFollowers.Click += new System.EventHandler(this.btnFollowers_Click);
            // 
            // btnGetFollowers
            // 
            this.btnGetFollowers.Enabled = false;
            this.btnGetFollowers.Location = new System.Drawing.Point(6, 51);
            this.btnGetFollowers.Name = "btnGetFollowers";
            this.btnGetFollowers.Size = new System.Drawing.Size(168, 23);
            this.btnGetFollowers.TabIndex = 20;
            this.btnGetFollowers.Text = "Get Followed List";
            this.btnGetFollowers.UseVisualStyleBackColor = true;
            this.btnGetFollowers.Click += new System.EventHandler(this.btnGetFollowers_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Block User";
            // 
            // btnBlockUser
            // 
            this.btnBlockUser.Enabled = false;
            this.btnBlockUser.Location = new System.Drawing.Point(6, 238);
            this.btnBlockUser.Name = "btnBlockUser";
            this.btnBlockUser.Size = new System.Drawing.Size(168, 23);
            this.btnBlockUser.TabIndex = 18;
            this.btnBlockUser.Text = "Block";
            this.btnBlockUser.UseVisualStyleBackColor = true;
            this.btnBlockUser.Click += new System.EventHandler(this.btnBlockUser_Click);
            // 
            // usrBlockTextBox
            // 
            this.usrBlockTextBox.Location = new System.Drawing.Point(6, 209);
            this.usrBlockTextBox.Name = "usrBlockTextBox";
            this.usrBlockTextBox.PlaceholderText = "Username";
            this.usrBlockTextBox.Size = new System.Drawing.Size(168, 23);
            this.usrBlockTextBox.TabIndex = 17;
            this.usrBlockTextBox.TextChanged += new System.EventHandler(this.usrBlockTextBox_TextChanged);
            // 
            // btnFollow
            // 
            this.btnFollow.Enabled = false;
            this.btnFollow.Location = new System.Drawing.Point(6, 156);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(168, 23);
            this.btnFollow.TabIndex = 16;
            this.btnFollow.Text = "Follow";
            this.btnFollow.UseVisualStyleBackColor = true;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // followUserTextBox
            // 
            this.followUserTextBox.Location = new System.Drawing.Point(6, 127);
            this.followUserTextBox.Name = "followUserTextBox";
            this.followUserTextBox.PlaceholderText = "Username";
            this.followUserTextBox.Size = new System.Drawing.Size(168, 23);
            this.followUserTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Follow User";
            // 
            // btnListUser
            // 
            this.btnListUser.Enabled = false;
            this.btnListUser.Location = new System.Drawing.Point(6, 22);
            this.btnListUser.Name = "btnListUser";
            this.btnListUser.Size = new System.Drawing.Size(168, 23);
            this.btnListUser.TabIndex = 0;
            this.btnListUser.Text = "Get User List";
            this.btnListUser.UseVisualStyleBackColor = true;
            this.btnListUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteSweet);
            this.groupBox4.Controls.Add(this.deleteSweetTextBox);
            this.groupBox4.Location = new System.Drawing.Point(687, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 56);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete Sweet";
            // 
            // btnDeleteSweet
            // 
            this.btnDeleteSweet.Enabled = false;
            this.btnDeleteSweet.Location = new System.Drawing.Point(112, 22);
            this.btnDeleteSweet.Name = "btnDeleteSweet";
            this.btnDeleteSweet.Size = new System.Drawing.Size(62, 23);
            this.btnDeleteSweet.TabIndex = 1;
            this.btnDeleteSweet.Text = "Delete";
            this.btnDeleteSweet.UseVisualStyleBackColor = true;
            this.btnDeleteSweet.Click += new System.EventHandler(this.btnDeleteSweet_Click);
            // 
            // deleteSweetTextBox
            // 
            this.deleteSweetTextBox.Location = new System.Drawing.Point(6, 22);
            this.deleteSweetTextBox.Name = "deleteSweetTextBox";
            this.deleteSweetTextBox.PlaceholderText = "Sweet ID";
            this.deleteSweetTextBox.Size = new System.Drawing.Size(100, 23);
            this.deleteSweetTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 354);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.asd);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.dbgTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sweeter Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.asd.ResumeLayout(false);
            this.asd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label portLBL;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox dbgTextBox;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox userSearchTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetSweets;
        private System.Windows.Forms.Button btn_getAllSweets;
        private System.Windows.Forms.GroupBox asd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnListUser;
        private System.Windows.Forms.Button btnFollow;
        private System.Windows.Forms.TextBox followUserTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetFollowSweetFeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBlockUser;
        private System.Windows.Forms.TextBox usrBlockTextBox;
        private System.Windows.Forms.Button btnGetFollowers;
        private System.Windows.Forms.Button btnFollowers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteSweet;
        private System.Windows.Forms.TextBox deleteSweetTextBox;
    }
}

