namespace Client
{
    partial class DeleteFloor
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
            this.ValidFloor = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ValidFloor
            // 
            this.ValidFloor.FormattingEnabled = true;
            this.ValidFloor.Location = new System.Drawing.Point(12, 12);
            this.ValidFloor.Name = "ValidFloor";
            this.ValidFloor.Size = new System.Drawing.Size(261, 290);
            this.ValidFloor.TabIndex = 0;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(69, 306);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(140, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Убрать этаж";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // DeleteFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 341);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.ValidFloor);
            this.Name = "DeleteFloor";
            this.Text = "DeleteFloor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ValidFloor;
        private System.Windows.Forms.Button Delete;
    }
}