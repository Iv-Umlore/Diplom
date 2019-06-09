namespace Client
{
    partial class AddFloor
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
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UnvalidFloors
            // 
            this.UnvalidFloors.FormattingEnabled = true;
            this.UnvalidFloors.Location = new System.Drawing.Point(13, 13);
            this.UnvalidFloors.Name = "UnvalidFloors";
            this.UnvalidFloors.Size = new System.Drawing.Size(300, 290);
            this.UnvalidFloors.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(89, 310);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(128, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // AddFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.UnvalidFloors);
            this.Name = "AddFloor";
            this.Text = "Неактивные этажи";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UnvalidFloors;
        private System.Windows.Forms.Button Add;
    }
}