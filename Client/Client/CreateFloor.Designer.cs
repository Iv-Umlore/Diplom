namespace Client
{
    partial class CreateFloor
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.EnterValue = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 340);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.button);
            this.ToolsPanel.Location = new System.Drawing.Point(13, 359);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(580, 61);
            this.ToolsPanel.TabIndex = 1;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(19, 3);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(178, 55);
            this.button.TabIndex = 0;
            this.button.Text = "Стереть";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // EnterValue
            // 
            this.EnterValue.AutoSize = true;
            this.EnterValue.Location = new System.Drawing.Point(609, 13);
            this.EnterValue.Name = "EnterValue";
            this.EnterValue.Size = new System.Drawing.Size(134, 13);
            this.EnterValue.TabIndex = 2;
            this.EnterValue.Text = "Введите название этажа";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(612, 30);
            this.textBox1.MaxLength = 100;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 47);
            this.textBox1.TabIndex = 3;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(600, 359);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(188, 61);
            this.Create.TabIndex = 4;
            this.Create.Text = "Сохранить";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(609, 186);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(166, 13);
            this.Result.TabIndex = 5;
            this.Result.Text = "Нарисуйте схему нового этажа";
            // 
            // CreateFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 424);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EnterValue);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CreateFloor";
            this.Text = "CreateFloor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.Label EnterValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Button button;
    }
}