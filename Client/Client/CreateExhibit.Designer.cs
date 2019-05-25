namespace Client
{
    partial class CreateExhibitWindows
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
            this.Name = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.Descript = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.SearchAndDownloadImage = new System.Windows.Forms.Button();
            this.DownloadLabel = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(13, 13);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(113, 13);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Название экспоната";
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(133, 5);
            this.Name.MaxLength = 100;
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(222, 20);
            this.Name.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(14, 68);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(113, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Описание экспоната";
            // 
            // Descript
            // 
            this.Descript.Location = new System.Drawing.Point(133, 36);
            this.Descript.MaxLength = 900;
            this.Descript.Multiline = true;
            this.Descript.Name = "Descript";
            this.Descript.Size = new System.Drawing.Size(222, 76);
            this.Descript.TabIndex = 3;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(280, 160);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 4;
            this.Create.Text = "Создать";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // SearchAndDownloadImage
            // 
            this.SearchAndDownloadImage.Location = new System.Drawing.Point(280, 118);
            this.SearchAndDownloadImage.Name = "SearchAndDownloadImage";
            this.SearchAndDownloadImage.Size = new System.Drawing.Size(75, 23);
            this.SearchAndDownloadImage.TabIndex = 5;
            this.SearchAndDownloadImage.Text = "Обзор";
            this.SearchAndDownloadImage.UseVisualStyleBackColor = true;
            this.SearchAndDownloadImage.Click += new System.EventHandler(this.SearchAndDownloadImage_Click);
            // 
            // DownloadLabel
            // 
            this.DownloadLabel.AutoSize = true;
            this.DownloadLabel.Location = new System.Drawing.Point(12, 123);
            this.DownloadLabel.Name = "DownloadLabel";
            this.DownloadLabel.Size = new System.Drawing.Size(130, 13);
            this.DownloadLabel.TabIndex = 6;
            this.DownloadLabel.Text = "Загрузить изображения";
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(12, 165);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(88, 13);
            this.Result.TabIndex = 7;
            this.Result.Text = "Заполните поля";
            // 
            // CreateExhibitWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 195);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.DownloadLabel);
            this.Controls.Add(this.SearchAndDownloadImage);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Descript);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.LoginLabel);
            //this.Name = "CreateExhibitWindows";
            this.Text = "Создание экспоната";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox Descript;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button SearchAndDownloadImage;
        private System.Windows.Forms.Label DownloadLabel;
        private System.Windows.Forms.Label Result;
    }
}