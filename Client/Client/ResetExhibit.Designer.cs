namespace Client
{
    partial class ResetExhibit
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
            this.ThisPoint = new System.Windows.Forms.ListBox();
            this.Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThisPoint
            // 
            this.ThisPoint.FormattingEnabled = true;
            this.ThisPoint.Location = new System.Drawing.Point(13, 13);
            this.ThisPoint.Name = "ThisPoint";
            this.ThisPoint.Size = new System.Drawing.Size(224, 225);
            this.ThisPoint.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(13, 245);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(224, 23);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Снять выбранный экспонат";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ResetExhibit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 279);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ThisPoint);
            this.Name = "ResetExhibit";
            this.Text = "ResetExhibit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ThisPoint;
        private System.Windows.Forms.Button Reset;
    }
}