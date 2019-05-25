namespace Client
{
    partial class ChangePass
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
            this.Change = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Password2 = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            this.Password1 = new System.Windows.Forms.TextBox();
            this.Логин = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(91, 80);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(122, 23);
            this.Change.TabIndex = 0;
            this.Change.Text = "Изменить";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Повторите пароль";
            // 
            // Password2
            // 
            this.Password2.Location = new System.Drawing.Point(107, 37);
            this.Password2.MaxLength = 100;
            this.Password2.Name = "Password2";
            this.Password2.Size = new System.Drawing.Size(179, 20);
            this.Password2.TabIndex = 4;
            this.Password2.UseSystemPasswordChar = true;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(33, 62);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(0, 13);
            this.Result.TabIndex = 5;
            // 
            // Password1
            // 
            this.Password1.Location = new System.Drawing.Point(107, 11);
            this.Password1.MaxLength = 100;
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(179, 20);
            this.Password1.TabIndex = 3;
            this.Password1.UseSystemPasswordChar = true;
            // 
            // Логин
            // 
            this.Логин.AutoSize = true;
            this.Логин.Location = new System.Drawing.Point(1, 18);
            this.Логин.Name = "Логин";
            this.Логин.Size = new System.Drawing.Size(45, 13);
            this.Логин.TabIndex = 1;
            this.Логин.Text = "Пароль";
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(298, 115);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Password2);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Логин);
            this.Controls.Add(this.Change);
            this.Name = "ChangePass";
            this.Text = "Изменить пароль";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.AutorizationLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password2;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TextBox Password1;
        private System.Windows.Forms.Label Логин;
    }
}