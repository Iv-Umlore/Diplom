namespace Client
{
    partial class CreateUser
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
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.PassAgainLabel = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.Create = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.Pass1 = new System.Windows.Forms.TextBox();
            this.Pass2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(13, 13);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(38, 13);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Логин";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(13, 40);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(45, 13);
            this.PassLabel.TabIndex = 1;
            this.PassLabel.Text = "Пароль";
            // 
            // PassAgainLabel
            // 
            this.PassAgainLabel.AutoSize = true;
            this.PassAgainLabel.Location = new System.Drawing.Point(13, 69);
            this.PassAgainLabel.Name = "PassAgainLabel";
            this.PassAgainLabel.Size = new System.Drawing.Size(100, 13);
            this.PassAgainLabel.TabIndex = 2;
            this.PassAgainLabel.Text = "Повторите пароль";
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(12, 102);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(109, 13);
            this.Result.TabIndex = 3;
            this.Result.Text = "Заполните все поля";
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(109, 133);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(191, 23);
            this.Create.TabIndex = 4;
            this.Create.Text = "Создать нового менеджера";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(130, 13);
            this.Login.MaxLength = 100;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(272, 20);
            this.Login.TabIndex = 5;
            // 
            // Pass1
            // 
            this.Pass1.Location = new System.Drawing.Point(130, 40);
            this.Pass1.MaxLength = 100;
            this.Pass1.Name = "Pass1";
            this.Pass1.Size = new System.Drawing.Size(272, 20);
            this.Pass1.TabIndex = 6;
            this.Pass1.UseSystemPasswordChar = true;
            // 
            // Pass2
            // 
            this.Pass2.Location = new System.Drawing.Point(130, 66);
            this.Pass2.MaxLength = 100;
            this.Pass2.Name = "Pass2";
            this.Pass2.Size = new System.Drawing.Size(272, 20);
            this.Pass2.TabIndex = 7;
            this.Pass2.UseSystemPasswordChar = true;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 168);
            this.Controls.Add(this.Pass2);
            this.Controls.Add(this.Pass1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.PassAgainLabel);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.LoginLabel);
            this.Name = "CreateUser";
            this.Text = "Добавить новый аккаунт менеджера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label PassAgainLabel;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Pass1;
        private System.Windows.Forms.TextBox Pass2;
    }
}