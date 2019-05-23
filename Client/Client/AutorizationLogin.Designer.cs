namespace Client
{
    partial class AutorizationLogin
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
            this.Autorization = new System.Windows.Forms.Button();
            this.Логин = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Autorization
            // 
            this.Autorization.Location = new System.Drawing.Point(91, 80);
            this.Autorization.Name = "Autorization";
            this.Autorization.Size = new System.Drawing.Size(122, 23);
            this.Autorization.TabIndex = 0;
            this.Autorization.Text = "Авторизация";
            this.Autorization.UseVisualStyleBackColor = true;
            this.Autorization.Click += new System.EventHandler(this.Autorization_Click);
            // 
            // Логин
            // 
            this.Логин.AutoSize = true;
            this.Логин.Location = new System.Drawing.Point(13, 19);
            this.Логин.Name = "Логин";
            this.Логин.Size = new System.Drawing.Size(38, 13);
            this.Логин.TabIndex = 1;
            this.Логин.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пароль";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(81, 37);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(205, 20);
            this.Password.TabIndex = 4;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(81, 11);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(205, 20);
            this.Login.TabIndex = 3;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(33, 62);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(0, 13);
            this.Result.TabIndex = 5;
            // 
            // AutorizationLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(298, 115);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Логин);
            this.Controls.Add(this.Autorization);
            this.Name = "AutorizationLogin";
            this.Text = "Авторизация";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.AutorizationLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Autorization;
        private System.Windows.Forms.Label Логин;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Label Result;
    }
}