namespace Client
{
    partial class Client
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
            this.Refresh = new System.ComponentModel.BackgroundWorker();
            this.Scheme_Panel = new System.Windows.Forms.Panel();
            this.Floore_Scheme = new System.Windows.Forms.PictureBox();
            this.Floor_Name = new System.Windows.Forms.Label();
            this.Autorization = new System.Windows.Forms.Button();
            this.GoToNextFloor = new System.Windows.Forms.Button();
            this.ManagerPanel = new System.Windows.Forms.Panel();
            this.AllFloorList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateNewExhibit = new System.Windows.Forms.Button();
            this.ChangePass = new System.Windows.Forms.Button();
            this.AddExhibitSpase = new System.Windows.Forms.Button();
            this.EditFloor = new System.Windows.Forms.Button();
            this.ShowThisFloor = new System.Windows.Forms.Button();
            this.CreateNewFloor = new System.Windows.Forms.Button();
            this.AdministratorPanel = new System.Windows.Forms.Panel();
            this.DeleteFloor = new System.Windows.Forms.Button();
            this.DeleteManager = new System.Windows.Forms.Button();
            this.CreateManager = new System.Windows.Forms.Button();
            this.GoodFloorList = new System.Windows.Forms.ComboBox();
            this.Exit = new System.Windows.Forms.Button();
            this.Scheme_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Floore_Scheme)).BeginInit();
            this.ManagerPanel.SuspendLayout();
            this.AdministratorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scheme_Panel
            // 
            this.Scheme_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Scheme_Panel.Controls.Add(this.Floore_Scheme);
            this.Scheme_Panel.Location = new System.Drawing.Point(0, 38);
            this.Scheme_Panel.Name = "Scheme_Panel";
            this.Scheme_Panel.Size = new System.Drawing.Size(603, 368);
            this.Scheme_Panel.TabIndex = 0;
            // 
            // Floore_Scheme
            // 
            this.Floore_Scheme.Location = new System.Drawing.Point(13, 13);
            this.Floore_Scheme.Name = "Floore_Scheme";
            this.Floore_Scheme.Size = new System.Drawing.Size(574, 339);
            this.Floore_Scheme.TabIndex = 0;
            this.Floore_Scheme.TabStop = false;
            // 
            // Floor_Name
            // 
            this.Floor_Name.AutoSize = true;
            this.Floor_Name.Location = new System.Drawing.Point(13, 13);
            this.Floor_Name.Name = "Floor_Name";
            this.Floor_Name.Size = new System.Drawing.Size(263, 13);
            this.Floor_Name.TabIndex = 1;
            this.Floor_Name.Text = "Очень длинное название этажа размерос со штат";
            // 
            // Autorization
            // 
            this.Autorization.Location = new System.Drawing.Point(485, 8);
            this.Autorization.Name = "Autorization";
            this.Autorization.Size = new System.Drawing.Size(118, 23);
            this.Autorization.TabIndex = 2;
            this.Autorization.Text = "Авторизация";
            this.Autorization.UseVisualStyleBackColor = true;
            this.Autorization.Click += new System.EventHandler(this.Autorization_Click);
            // 
            // GoToNextFloor
            // 
            this.GoToNextFloor.Location = new System.Drawing.Point(528, 412);
            this.GoToNextFloor.Name = "GoToNextFloor";
            this.GoToNextFloor.Size = new System.Drawing.Size(75, 26);
            this.GoToNextFloor.TabIndex = 4;
            this.GoToNextFloor.Text = "Перейти";
            this.GoToNextFloor.UseVisualStyleBackColor = true;
            // 
            // ManagerPanel
            // 
            this.ManagerPanel.Controls.Add(this.Exit);
            this.ManagerPanel.Controls.Add(this.AllFloorList);
            this.ManagerPanel.Controls.Add(this.label1);
            this.ManagerPanel.Controls.Add(this.CreateNewExhibit);
            this.ManagerPanel.Controls.Add(this.ChangePass);
            this.ManagerPanel.Controls.Add(this.AddExhibitSpase);
            this.ManagerPanel.Controls.Add(this.EditFloor);
            this.ManagerPanel.Controls.Add(this.ShowThisFloor);
            this.ManagerPanel.Controls.Add(this.CreateNewFloor);
            this.ManagerPanel.Location = new System.Drawing.Point(610, 8);
            this.ManagerPanel.Name = "ManagerPanel";
            this.ManagerPanel.Size = new System.Drawing.Size(178, 271);
            this.ManagerPanel.TabIndex = 5;
            // 
            // AllFloorList
            // 
            this.AllFloorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AllFloorList.FormattingEnabled = true;
            this.AllFloorList.Location = new System.Drawing.Point(4, 129);
            this.AllFloorList.Name = "AllFloorList";
            this.AllFloorList.Size = new System.Drawing.Size(169, 21);
            this.AllFloorList.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Управление музеем";
            // 
            // CreateNewExhibit
            // 
            this.CreateNewExhibit.Location = new System.Drawing.Point(3, 243);
            this.CreateNewExhibit.Name = "CreateNewExhibit";
            this.CreateNewExhibit.Size = new System.Drawing.Size(170, 25);
            this.CreateNewExhibit.TabIndex = 6;
            this.CreateNewExhibit.Text = "Создать новый экспонат";
            this.CreateNewExhibit.UseVisualStyleBackColor = true;
            // 
            // ChangePass
            // 
            this.ChangePass.Location = new System.Drawing.Point(3, 5);
            this.ChangePass.Name = "ChangePass";
            this.ChangePass.Size = new System.Drawing.Size(172, 23);
            this.ChangePass.TabIndex = 5;
            this.ChangePass.Text = "Изменить пароль";
            this.ChangePass.UseVisualStyleBackColor = true;
            // 
            // AddExhibitSpase
            // 
            this.AddExhibitSpase.Location = new System.Drawing.Point(3, 214);
            this.AddExhibitSpase.Name = "AddExhibitSpase";
            this.AddExhibitSpase.Size = new System.Drawing.Size(170, 23);
            this.AddExhibitSpase.TabIndex = 4;
            this.AddExhibitSpase.Text = "Добавить точку экспонатов";
            this.AddExhibitSpase.UseVisualStyleBackColor = true;
            // 
            // EditFloor
            // 
            this.EditFloor.Location = new System.Drawing.Point(3, 185);
            this.EditFloor.Name = "EditFloor";
            this.EditFloor.Size = new System.Drawing.Size(170, 23);
            this.EditFloor.TabIndex = 3;
            this.EditFloor.Text = "Редактировать этаж";
            this.EditFloor.UseVisualStyleBackColor = true;
            // 
            // ShowThisFloor
            // 
            this.ShowThisFloor.Location = new System.Drawing.Point(3, 156);
            this.ShowThisFloor.Name = "ShowThisFloor";
            this.ShowThisFloor.Size = new System.Drawing.Size(171, 23);
            this.ShowThisFloor.TabIndex = 1;
            this.ShowThisFloor.Text = "Показать этаж";
            this.ShowThisFloor.UseVisualStyleBackColor = true;
            // 
            // CreateNewFloor
            // 
            this.CreateNewFloor.Location = new System.Drawing.Point(3, 104);
            this.CreateNewFloor.Name = "CreateNewFloor";
            this.CreateNewFloor.Size = new System.Drawing.Size(172, 23);
            this.CreateNewFloor.TabIndex = 0;
            this.CreateNewFloor.Text = "Создать новый этаж";
            this.CreateNewFloor.UseVisualStyleBackColor = true;
            // 
            // AdministratorPanel
            // 
            this.AdministratorPanel.Controls.Add(this.DeleteFloor);
            this.AdministratorPanel.Controls.Add(this.DeleteManager);
            this.AdministratorPanel.Controls.Add(this.CreateManager);
            this.AdministratorPanel.Location = new System.Drawing.Point(610, 285);
            this.AdministratorPanel.Name = "AdministratorPanel";
            this.AdministratorPanel.Size = new System.Drawing.Size(178, 153);
            this.AdministratorPanel.TabIndex = 6;
            // 
            // DeleteFloor
            // 
            this.DeleteFloor.Location = new System.Drawing.Point(4, 123);
            this.DeleteFloor.Name = "DeleteFloor";
            this.DeleteFloor.Size = new System.Drawing.Size(170, 23);
            this.DeleteFloor.TabIndex = 2;
            this.DeleteFloor.Text = "Удалить этаж";
            this.DeleteFloor.UseVisualStyleBackColor = true;
            this.DeleteFloor.Click += new System.EventHandler(this.DeleteFloor_Click);
            // 
            // DeleteManager
            // 
            this.DeleteManager.Location = new System.Drawing.Point(4, 42);
            this.DeleteManager.Name = "DeleteManager";
            this.DeleteManager.Size = new System.Drawing.Size(170, 23);
            this.DeleteManager.TabIndex = 1;
            this.DeleteManager.Text = "Удалить менеджера";
            this.DeleteManager.UseVisualStyleBackColor = true;
            // 
            // CreateManager
            // 
            this.CreateManager.Location = new System.Drawing.Point(3, 13);
            this.CreateManager.Name = "CreateManager";
            this.CreateManager.Size = new System.Drawing.Size(172, 23);
            this.CreateManager.TabIndex = 0;
            this.CreateManager.Text = "Создать нового менеджера";
            this.CreateManager.UseVisualStyleBackColor = true;
            // 
            // GoodFloorList
            // 
            this.GoodFloorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GoodFloorList.FormattingEnabled = true;
            this.GoodFloorList.Location = new System.Drawing.Point(13, 416);
            this.GoodFloorList.Name = "GoodFloorList";
            this.GoodFloorList.Size = new System.Drawing.Size(121, 21);
            this.GoodFloorList.TabIndex = 7;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(4, 35);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(169, 23);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Выйти из учётной записи";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoodFloorList);
            this.Controls.Add(this.AdministratorPanel);
            this.Controls.Add(this.ManagerPanel);
            this.Controls.Add(this.GoToNextFloor);
            this.Controls.Add(this.Autorization);
            this.Controls.Add(this.Floor_Name);
            this.Controls.Add(this.Scheme_Panel);
            this.Name = "Client";
            this.Text = "Client";
            this.Scheme_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Floore_Scheme)).EndInit();
            this.ManagerPanel.ResumeLayout(false);
            this.ManagerPanel.PerformLayout();
            this.AdministratorPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker Refresh;
        private System.Windows.Forms.Panel Scheme_Panel;
        private System.Windows.Forms.PictureBox Floore_Scheme;
        private System.Windows.Forms.Label Floor_Name;
        private System.Windows.Forms.Button Autorization;
        private System.Windows.Forms.Button GoToNextFloor;
        private System.Windows.Forms.Panel ManagerPanel;
        private System.Windows.Forms.Button CreateNewExhibit;
        private System.Windows.Forms.Button ChangePass;
        private System.Windows.Forms.Button AddExhibitSpase;
        private System.Windows.Forms.Button EditFloor;
        private System.Windows.Forms.Button ShowThisFloor;
        private System.Windows.Forms.Button CreateNewFloor;
        private System.Windows.Forms.Panel AdministratorPanel;
        private System.Windows.Forms.Button DeleteFloor;
        private System.Windows.Forms.Button DeleteManager;
        private System.Windows.Forms.Button CreateManager;
        private System.Windows.Forms.ComboBox GoodFloorList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AllFloorList;
        private System.Windows.Forms.Button Exit;
    }
}