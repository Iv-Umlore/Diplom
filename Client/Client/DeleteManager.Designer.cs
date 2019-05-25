namespace Client
{
    partial class DeleteManager
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
            this.AllManagers = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllManagers
            // 
            this.AllManagers.FormattingEnabled = true;
            this.AllManagers.Location = new System.Drawing.Point(13, 13);
            this.AllManagers.Name = "AllManagers";
            this.AllManagers.Size = new System.Drawing.Size(260, 251);
            this.AllManagers.TabIndex = 0;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(55, 279);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(168, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // DeleteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 314);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.AllManagers);
            this.Name = "DeleteManager";
            this.Text = "Удалить менеджера";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AllManagers;
        private System.Windows.Forms.Button Delete;
    }
}