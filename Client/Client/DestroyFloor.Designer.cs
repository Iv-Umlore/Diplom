namespace Client
{
    partial class DestroyFloor
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
            this.UnvalidFloors = new System.Windows.Forms.ListBox();
            this.DeleteFloor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UnvalidFloors
            // 
            this.UnvalidFloors.FormattingEnabled = true;
            this.UnvalidFloors.Location = new System.Drawing.Point(13, 13);
            this.UnvalidFloors.Name = "UnvalidFloors";
            this.UnvalidFloors.Size = new System.Drawing.Size(301, 303);
            this.UnvalidFloors.TabIndex = 0;
            // 
            // DeleteFloor
            // 
            this.DeleteFloor.Location = new System.Drawing.Point(67, 323);
            this.DeleteFloor.Name = "DeleteFloor";
            this.DeleteFloor.Size = new System.Drawing.Size(175, 23);
            this.DeleteFloor.TabIndex = 1;
            this.DeleteFloor.Text = "Удалить этаж";
            this.DeleteFloor.UseVisualStyleBackColor = true;
            this.DeleteFloor.Click += new System.EventHandler(this.DeleteFloor_Click);
            // 
            // DestroyFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 350);
            this.Controls.Add(this.DeleteFloor);
            this.Controls.Add(this.UnvalidFloors);
            this.Name = "DestroyFloor";
            this.Text = "DestroyFloor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UnvalidFloors;
        private System.Windows.Forms.Button DeleteFloor;
    }
}