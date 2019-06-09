namespace Client
{
    partial class SetExhibit
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
            this.FreeExhibits = new System.Windows.Forms.ListBox();
            this.Set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FreeExhibits
            // 
            this.FreeExhibits.FormattingEnabled = true;
            this.FreeExhibits.Location = new System.Drawing.Point(13, 13);
            this.FreeExhibits.Name = "FreeExhibits";
            this.FreeExhibits.Size = new System.Drawing.Size(236, 251);
            this.FreeExhibits.TabIndex = 0;
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(13, 278);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(236, 23);
            this.Set.TabIndex = 1;
            this.Set.Text = "Повесить выбранный экспонат";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // SetExhibit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 313);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.FreeExhibits);
            this.Name = "SetExhibit";
            this.Text = "Свободные экспонаты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox FreeExhibits;
        private System.Windows.Forms.Button Set;
    }
}