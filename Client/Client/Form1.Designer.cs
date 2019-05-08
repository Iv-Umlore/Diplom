namespace Client
{
    partial class Form1
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
            this.DeleteExponat = new System.Windows.Forms.Button();
            this.AddExponat = new System.Windows.Forms.Button();
            this.Autorization = new System.Windows.Forms.Button();
            this.ShowExponat = new System.Windows.Forms.Button();
            this.ShowFloor = new System.Windows.Forms.Button();
            this.ChangeExponat = new System.Windows.Forms.Button();
            this.SetExponat = new System.Windows.Forms.Button();
            this.ResetExponat = new System.Windows.Forms.Button();
            this.ChangeFloor = new System.Windows.Forms.Button();
            this.AddExponatPoint = new System.Windows.Forms.Button();
            this.DeleteExponatPoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteExponat
            // 
            this.DeleteExponat.Location = new System.Drawing.Point(135, 41);
            this.DeleteExponat.Name = "DeleteExponat";
            this.DeleteExponat.Size = new System.Drawing.Size(143, 23);
            this.DeleteExponat.TabIndex = 0;
            this.DeleteExponat.Text = "Удалить экспонат";
            this.DeleteExponat.UseVisualStyleBackColor = true;
            this.DeleteExponat.Click += new System.EventHandler(this.DeleteExponat_Click);
            // 
            // AddExponat
            // 
            this.AddExponat.Location = new System.Drawing.Point(135, 11);
            this.AddExponat.Name = "AddExponat";
            this.AddExponat.Size = new System.Drawing.Size(143, 23);
            this.AddExponat.TabIndex = 1;
            this.AddExponat.Text = "Добавить экспонат";
            this.AddExponat.UseVisualStyleBackColor = true;
            this.AddExponat.Click += new System.EventHandler(this.AddExponat_Click);
            // 
            // Autorization
            // 
            this.Autorization.Location = new System.Drawing.Point(12, 70);
            this.Autorization.Name = "Autorization";
            this.Autorization.Size = new System.Drawing.Size(117, 23);
            this.Autorization.TabIndex = 2;
            this.Autorization.Text = "Авторизоваться";
            this.Autorization.UseVisualStyleBackColor = true;
            this.Autorization.Click += new System.EventHandler(this.Autorization_Click);
            // 
            // ShowExponat
            // 
            this.ShowExponat.Location = new System.Drawing.Point(12, 41);
            this.ShowExponat.Name = "ShowExponat";
            this.ShowExponat.Size = new System.Drawing.Size(117, 23);
            this.ShowExponat.TabIndex = 3;
            this.ShowExponat.Text = "Показать экспонат";
            this.ShowExponat.UseVisualStyleBackColor = true;
            this.ShowExponat.Click += new System.EventHandler(this.ShowExponat_Click);
            // 
            // ShowFloor
            // 
            this.ShowFloor.Location = new System.Drawing.Point(12, 12);
            this.ShowFloor.Name = "ShowFloor";
            this.ShowFloor.Size = new System.Drawing.Size(117, 23);
            this.ShowFloor.TabIndex = 4;
            this.ShowFloor.Text = "Показать этаж";
            this.ShowFloor.UseVisualStyleBackColor = true;
            this.ShowFloor.Click += new System.EventHandler(this.ShowFloor_Click);
            // 
            // ChangeExponat
            // 
            this.ChangeExponat.Location = new System.Drawing.Point(135, 70);
            this.ChangeExponat.Name = "ChangeExponat";
            this.ChangeExponat.Size = new System.Drawing.Size(143, 23);
            this.ChangeExponat.TabIndex = 5;
            this.ChangeExponat.Text = "Редактировать экспонат";
            this.ChangeExponat.UseVisualStyleBackColor = true;
            this.ChangeExponat.Click += new System.EventHandler(this.ChangeExponat_Click);
            // 
            // SetExponat
            // 
            this.SetExponat.Location = new System.Drawing.Point(284, 11);
            this.SetExponat.Name = "SetExponat";
            this.SetExponat.Size = new System.Drawing.Size(134, 23);
            this.SetExponat.TabIndex = 6;
            this.SetExponat.Text = "Повесить экспонат";
            this.SetExponat.UseVisualStyleBackColor = true;
            this.SetExponat.Click += new System.EventHandler(this.SetExponat_Click);
            // 
            // ResetExponat
            // 
            this.ResetExponat.Location = new System.Drawing.Point(284, 40);
            this.ResetExponat.Name = "ResetExponat";
            this.ResetExponat.Size = new System.Drawing.Size(134, 23);
            this.ResetExponat.TabIndex = 7;
            this.ResetExponat.Text = "Снять экспонат";
            this.ResetExponat.UseVisualStyleBackColor = true;
            this.ResetExponat.Click += new System.EventHandler(this.ResetExponat_Click);
            // 
            // ChangeFloor
            // 
            this.ChangeFloor.Location = new System.Drawing.Point(284, 69);
            this.ChangeFloor.Name = "ChangeFloor";
            this.ChangeFloor.Size = new System.Drawing.Size(134, 23);
            this.ChangeFloor.TabIndex = 8;
            this.ChangeFloor.Text = "Редактировать этаж";
            this.ChangeFloor.UseVisualStyleBackColor = true;
            this.ChangeFloor.Click += new System.EventHandler(this.ChangeFloor_Click);
            // 
            // AddExponatPoint
            // 
            this.AddExponatPoint.Location = new System.Drawing.Point(424, 11);
            this.AddExponatPoint.Name = "AddExponatPoint";
            this.AddExponatPoint.Size = new System.Drawing.Size(129, 38);
            this.AddExponatPoint.TabIndex = 9;
            this.AddExponatPoint.Text = "Добавить место для экспоната";
            this.AddExponatPoint.UseVisualStyleBackColor = true;
            this.AddExponatPoint.Click += new System.EventHandler(this.AddExponatPoint_Click);
            // 
            // DeleteExponatPoint
            // 
            this.DeleteExponatPoint.Location = new System.Drawing.Point(424, 55);
            this.DeleteExponatPoint.Name = "DeleteExponatPoint";
            this.DeleteExponatPoint.Size = new System.Drawing.Size(129, 37);
            this.DeleteExponatPoint.TabIndex = 10;
            this.DeleteExponatPoint.Text = "Удалить место для экспоната";
            this.DeleteExponatPoint.UseVisualStyleBackColor = true;
            this.DeleteExponatPoint.Click += new System.EventHandler(this.DeleteExponatPoint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 119);
            this.Controls.Add(this.DeleteExponatPoint);
            this.Controls.Add(this.AddExponatPoint);
            this.Controls.Add(this.ChangeFloor);
            this.Controls.Add(this.ResetExponat);
            this.Controls.Add(this.SetExponat);
            this.Controls.Add(this.ChangeExponat);
            this.Controls.Add(this.ShowFloor);
            this.Controls.Add(this.ShowExponat);
            this.Controls.Add(this.Autorization);
            this.Controls.Add(this.AddExponat);
            this.Controls.Add(this.DeleteExponat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteExponat;
        private System.Windows.Forms.Button AddExponat;
        private System.Windows.Forms.Button Autorization;
        private System.Windows.Forms.Button ShowExponat;
        private System.Windows.Forms.Button ShowFloor;
        private System.Windows.Forms.Button ChangeExponat;
        private System.Windows.Forms.Button SetExponat;
        private System.Windows.Forms.Button ResetExponat;
        private System.Windows.Forms.Button ChangeFloor;
        private System.Windows.Forms.Button AddExponatPoint;
        private System.Windows.Forms.Button DeleteExponatPoint;
    }
}

