namespace lab1
{
    partial class ClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetMsg = new System.Windows.Forms.Button();
            this.btnGetMsgById = new System.Windows.Forms.Button();
            this.btnPostMsg = new System.Windows.Forms.Button();
            this.btnPostMsgView = new System.Windows.Forms.Button();
            this.btnRegUser = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMsgId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIpChange = new System.Windows.Forms.Button();
            this.tbIpAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetMsg
            // 
            this.btnGetMsg.Location = new System.Drawing.Point(237, 16);
            this.btnGetMsg.Name = "btnGetMsg";
            this.btnGetMsg.Size = new System.Drawing.Size(127, 20);
            this.btnGetMsg.TabIndex = 0;
            this.btnGetMsg.Text = "GetMsg";
            this.btnGetMsg.UseVisualStyleBackColor = true;
            this.btnGetMsg.Click += new System.EventHandler(this.OnButtonGetMsgClick);
            // 
            // btnGetMsgById
            // 
            this.btnGetMsgById.Location = new System.Drawing.Point(237, 41);
            this.btnGetMsgById.Name = "btnGetMsgById";
            this.btnGetMsgById.Size = new System.Drawing.Size(127, 20);
            this.btnGetMsgById.TabIndex = 1;
            this.btnGetMsgById.Text = "GetMsgById";
            this.btnGetMsgById.UseVisualStyleBackColor = true;
            this.btnGetMsgById.Click += new System.EventHandler(this.OnButtonGetMsgByIdClick);
            // 
            // btnPostMsg
            // 
            this.btnPostMsg.Location = new System.Drawing.Point(237, 67);
            this.btnPostMsg.Name = "btnPostMsg";
            this.btnPostMsg.Size = new System.Drawing.Size(127, 20);
            this.btnPostMsg.TabIndex = 2;
            this.btnPostMsg.Text = "PostMsg";
            this.btnPostMsg.UseVisualStyleBackColor = true;
            this.btnPostMsg.Click += new System.EventHandler(this.OnButtonPostMsgClick);
            // 
            // btnPostMsgView
            // 
            this.btnPostMsgView.Location = new System.Drawing.Point(237, 93);
            this.btnPostMsgView.Name = "btnPostMsgView";
            this.btnPostMsgView.Size = new System.Drawing.Size(127, 20);
            this.btnPostMsgView.TabIndex = 3;
            this.btnPostMsgView.Text = "PostMsgView";
            this.btnPostMsgView.UseVisualStyleBackColor = true;
            this.btnPostMsgView.Click += new System.EventHandler(this.OnButtonPostMsgViewClick);
            // 
            // btnRegUser
            // 
            this.btnRegUser.Location = new System.Drawing.Point(237, 119);
            this.btnRegUser.Name = "btnRegUser";
            this.btnRegUser.Size = new System.Drawing.Size(127, 20);
            this.btnRegUser.TabIndex = 4;
            this.btnRegUser.Text = "RegUsers";
            this.btnRegUser.UseVisualStyleBackColor = true;
            this.btnRegUser.Click += new System.EventHandler(this.OnButtonRegUserClick);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(78, 16);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(144, 20);
            this.textBoxEmail.TabIndex = 9;
            this.textBoxEmail.Text = "mail@mail.ru";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "first name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "last name";
            // 
            // textBoxFName
            // 
            this.textBoxFName.Location = new System.Drawing.Point(78, 67);
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.Size = new System.Drawing.Size(144, 20);
            this.textBoxFName.TabIndex = 14;
            this.textBoxFName.Text = "standartf";
            // 
            // textBoxLName
            // 
            this.textBoxLName.Location = new System.Drawing.Point(78, 93);
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(144, 20);
            this.textBoxLName.TabIndex = 15;
            this.textBoxLName.Text = "standartl";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(78, 41);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(144, 20);
            this.textBoxPwd.TabIndex = 16;
            this.textBoxPwd.Text = "qwertyuiopasdf";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(237, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 20);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.OnButtonLoginClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "author";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(78, 118);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(144, 20);
            this.textBoxAuthor.TabIndex = 20;
            this.textBoxAuthor.Text = "standarta";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Location = new System.Drawing.Point(78, 144);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(144, 20);
            this.textBoxMsg.TabIndex = 21;
            this.textBoxMsg.Text = "text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "message";
            // 
            // textBoxMsgId
            // 
            this.textBoxMsgId.Location = new System.Drawing.Point(78, 170);
            this.textBoxMsgId.Name = "textBoxMsgId";
            this.textBoxMsgId.Size = new System.Drawing.Size(144, 20);
            this.textBoxMsgId.TabIndex = 23;
            this.textBoxMsgId.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "message ID";
            // 
            // btnIpChange
            // 
            this.btnIpChange.Location = new System.Drawing.Point(237, 171);
            this.btnIpChange.Name = "btnIpChange";
            this.btnIpChange.Size = new System.Drawing.Size(127, 20);
            this.btnIpChange.TabIndex = 25;
            this.btnIpChange.Text = "ChangeIp";
            this.btnIpChange.UseVisualStyleBackColor = true;
            this.btnIpChange.Click += new System.EventHandler(this.OnButtonChangeIpClick);
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.AutoSize = true;
            this.tbIpAddress.Location = new System.Drawing.Point(419, 16);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(17, 13);
            this.tbIpAddress.TabIndex = 26;
            this.tbIpAddress.Text = "IP";
            // 
            // ClientForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 310);
            this.Controls.Add(this.tbIpAddress);
            this.Controls.Add(this.btnIpChange);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMsgId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxLName);
            this.Controls.Add(this.textBoxFName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.btnRegUser);
            this.Controls.Add(this.btnPostMsgView);
            this.Controls.Add(this.btnPostMsg);
            this.Controls.Add(this.btnGetMsgById);
            this.Controls.Add(this.btnGetMsg);
            this.Name = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMsg;
        private System.Windows.Forms.Button btnGetMsgById;
        private System.Windows.Forms.Button btnPostMsg;
        private System.Windows.Forms.Button btnPostMsgView;
        private System.Windows.Forms.Button btnRegUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMsgId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnIpChange;
        private System.Windows.Forms.Label tbIpAddress;
    }
}

