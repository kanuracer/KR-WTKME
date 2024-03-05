namespace KR_WTKME
{
    partial class Main_Program
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Program));
            this.GotoSettings = new System.Windows.Forms.PictureBox();
            this.CustomMessagesActivateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SelectedGamefolder = new System.Windows.Forms.TextBox();
            this.GameFolderButton = new System.Windows.Forms.Button();
            this.GamefolderTextBox = new System.Windows.Forms.TextBox();
            this.PanzerZerstörtTextBox = new System.Windows.Forms.TextBox();
            this.PanzerZerstörtUserTextBox = new System.Windows.Forms.TextBox();
            this.FlugzeugZerstörtTextBox = new System.Windows.Forms.TextBox();
            this.FlugzeugZerstörtUserTextBox = new System.Windows.Forms.TextBox();
            this.UpdateLangDirButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.HitTextBox = new System.Windows.Forms.TextBox();
            this.HitUserTextBox = new System.Windows.Forms.TextBox();
            this.CriticalHitTextBox = new System.Windows.Forms.TextBox();
            this.CriticalHitUserTextBox = new System.Windows.Forms.TextBox();
            this.TargetUndamagedTextBox = new System.Windows.Forms.TextBox();
            this.TargetUndamagedUserTextBox = new System.Windows.Forms.TextBox();
            this.HelikopterZerstörtUserTextBox = new System.Windows.Forms.TextBox();
            this.HelikopterZerstörtTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GotoSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // GotoSettings
            // 
            this.GotoSettings.Image = ((System.Drawing.Image)(resources.GetObject("GotoSettings.Image")));
            this.GotoSettings.Location = new System.Drawing.Point(410, 5);
            this.GotoSettings.Name = "GotoSettings";
            this.GotoSettings.Size = new System.Drawing.Size(34, 33);
            this.GotoSettings.TabIndex = 0;
            this.GotoSettings.TabStop = false;
            this.GotoSettings.Click += new System.EventHandler(this.GotoSettings_Click);
            // 
            // CustomMessagesActivateButton
            // 
            this.CustomMessagesActivateButton.Location = new System.Drawing.Point(12, 12);
            this.CustomMessagesActivateButton.Name = "CustomMessagesActivateButton";
            this.CustomMessagesActivateButton.Size = new System.Drawing.Size(266, 23);
            this.CustomMessagesActivateButton.TabIndex = 1;
            this.CustomMessagesActivateButton.Text = "Eigene Kill Message aktivieren";
            this.CustomMessagesActivateButton.UseVisualStyleBackColor = true;
            this.CustomMessagesActivateButton.Click += new System.EventHandler(this.CustomMessagesActivateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(114, 244);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(329, 28);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Speichern";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SelectedGamefolder
            // 
            this.SelectedGamefolder.Location = new System.Drawing.Point(284, 55);
            this.SelectedGamefolder.Name = "SelectedGamefolder";
            this.SelectedGamefolder.ReadOnly = true;
            this.SelectedGamefolder.Size = new System.Drawing.Size(160, 20);
            this.SelectedGamefolder.TabIndex = 3;
            this.SelectedGamefolder.TabStop = false;
            this.SelectedGamefolder.TextChanged += new System.EventHandler(this.Gamefolder_TextChanged);
            // 
            // GameFolderButton
            // 
            this.GameFolderButton.Location = new System.Drawing.Point(118, 49);
            this.GameFolderButton.Name = "GameFolderButton";
            this.GameFolderButton.Size = new System.Drawing.Size(160, 23);
            this.GameFolderButton.TabIndex = 4;
            this.GameFolderButton.Text = "Auswählen";
            this.GameFolderButton.UseVisualStyleBackColor = true;
            this.GameFolderButton.Click += new System.EventHandler(this.GameFolderButton_Click);
            // 
            // GamefolderTextBox
            // 
            this.GamefolderTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GamefolderTextBox.Location = new System.Drawing.Point(12, 52);
            this.GamefolderTextBox.Name = "GamefolderTextBox";
            this.GamefolderTextBox.ReadOnly = true;
            this.GamefolderTextBox.Size = new System.Drawing.Size(100, 20);
            this.GamefolderTextBox.TabIndex = 7;
            this.GamefolderTextBox.TabStop = false;
            this.GamefolderTextBox.Text = "Spieleverzeichnis:";
            // 
            // PanzerZerstörtTextBox
            // 
            this.PanzerZerstörtTextBox.Location = new System.Drawing.Point(12, 78);
            this.PanzerZerstörtTextBox.Name = "PanzerZerstörtTextBox";
            this.PanzerZerstörtTextBox.ReadOnly = true;
            this.PanzerZerstörtTextBox.Size = new System.Drawing.Size(100, 20);
            this.PanzerZerstörtTextBox.TabIndex = 8;
            this.PanzerZerstörtTextBox.TabStop = false;
            this.PanzerZerstörtTextBox.Text = "Panzer zerstört:";
            // 
            // PanzerZerstörtUserTextBox
            // 
            this.PanzerZerstörtUserTextBox.Location = new System.Drawing.Point(118, 78);
            this.PanzerZerstörtUserTextBox.Name = "PanzerZerstörtUserTextBox";
            this.PanzerZerstörtUserTextBox.Size = new System.Drawing.Size(160, 20);
            this.PanzerZerstörtUserTextBox.TabIndex = 9;
            // 
            // FlugzeugZerstörtTextBox
            // 
            this.FlugzeugZerstörtTextBox.Location = new System.Drawing.Point(12, 107);
            this.FlugzeugZerstörtTextBox.Name = "FlugzeugZerstörtTextBox";
            this.FlugzeugZerstörtTextBox.ReadOnly = true;
            this.FlugzeugZerstörtTextBox.Size = new System.Drawing.Size(100, 20);
            this.FlugzeugZerstörtTextBox.TabIndex = 10;
            this.FlugzeugZerstörtTextBox.TabStop = false;
            this.FlugzeugZerstörtTextBox.Text = "Flugzeug zerstört:";
            // 
            // FlugzeugZerstörtUserTextBox
            // 
            this.FlugzeugZerstörtUserTextBox.Location = new System.Drawing.Point(118, 104);
            this.FlugzeugZerstörtUserTextBox.Name = "FlugzeugZerstörtUserTextBox";
            this.FlugzeugZerstörtUserTextBox.Size = new System.Drawing.Size(160, 20);
            this.FlugzeugZerstörtUserTextBox.TabIndex = 11;
            // 
            // UpdateLangDirButton
            // 
            this.UpdateLangDirButton.Location = new System.Drawing.Point(8, 244);
            this.UpdateLangDirButton.Name = "UpdateLangDirButton";
            this.UpdateLangDirButton.Size = new System.Drawing.Size(100, 28);
            this.UpdateLangDirButton.TabIndex = 12;
            this.UpdateLangDirButton.Text = "Update";
            this.UpdateLangDirButton.UseVisualStyleBackColor = true;
            this.UpdateLangDirButton.Click += new System.EventHandler(this.UpdateLangDirButton_Click);
            // 
            // HitTextBox
            // 
            this.HitTextBox.Location = new System.Drawing.Point(12, 159);
            this.HitTextBox.Name = "HitTextBox";
            this.HitTextBox.ReadOnly = true;
            this.HitTextBox.Size = new System.Drawing.Size(100, 20);
            this.HitTextBox.TabIndex = 13;
            this.HitTextBox.TabStop = false;
            this.HitTextBox.Text = "Treffer:";
            // 
            // HitUserTextBox
            // 
            this.HitUserTextBox.Location = new System.Drawing.Point(119, 158);
            this.HitUserTextBox.Name = "HitUserTextBox";
            this.HitUserTextBox.Size = new System.Drawing.Size(158, 20);
            this.HitUserTextBox.TabIndex = 14;
            // 
            // CriticalHitTextBox
            // 
            this.CriticalHitTextBox.Location = new System.Drawing.Point(12, 186);
            this.CriticalHitTextBox.Name = "CriticalHitTextBox";
            this.CriticalHitTextBox.ReadOnly = true;
            this.CriticalHitTextBox.Size = new System.Drawing.Size(100, 20);
            this.CriticalHitTextBox.TabIndex = 15;
            this.CriticalHitTextBox.TabStop = false;
            this.CriticalHitTextBox.Text = "Kritischer Treffer:";
            // 
            // CriticalHitUserTextBox
            // 
            this.CriticalHitUserTextBox.Location = new System.Drawing.Point(119, 185);
            this.CriticalHitUserTextBox.Name = "CriticalHitUserTextBox";
            this.CriticalHitUserTextBox.Size = new System.Drawing.Size(158, 20);
            this.CriticalHitUserTextBox.TabIndex = 16;
            // 
            // TargetUndamagedTextBox
            // 
            this.TargetUndamagedTextBox.Location = new System.Drawing.Point(12, 213);
            this.TargetUndamagedTextBox.Name = "TargetUndamagedTextBox";
            this.TargetUndamagedTextBox.ReadOnly = true;
            this.TargetUndamagedTextBox.Size = new System.Drawing.Size(100, 20);
            this.TargetUndamagedTextBox.TabIndex = 17;
            this.TargetUndamagedTextBox.TabStop = false;
            this.TargetUndamagedTextBox.Text = "Ziel unbeschädigt:";
            // 
            // TargetUndamagedUserTextBox
            // 
            this.TargetUndamagedUserTextBox.Location = new System.Drawing.Point(119, 213);
            this.TargetUndamagedUserTextBox.Name = "TargetUndamagedUserTextBox";
            this.TargetUndamagedUserTextBox.Size = new System.Drawing.Size(158, 20);
            this.TargetUndamagedUserTextBox.TabIndex = 18;
            // 
            // HelikopterZerstörtUserTextBox
            // 
            this.HelikopterZerstörtUserTextBox.Location = new System.Drawing.Point(119, 132);
            this.HelikopterZerstörtUserTextBox.Name = "HelikopterZerstörtUserTextBox";
            this.HelikopterZerstörtUserTextBox.Size = new System.Drawing.Size(158, 20);
            this.HelikopterZerstörtUserTextBox.TabIndex = 20;
            // 
            // HelikopterZerstörtTextBox
            // 
            this.HelikopterZerstörtTextBox.Location = new System.Drawing.Point(12, 133);
            this.HelikopterZerstörtTextBox.Name = "HelikopterZerstörtTextBox";
            this.HelikopterZerstörtTextBox.ReadOnly = true;
            this.HelikopterZerstörtTextBox.Size = new System.Drawing.Size(100, 20);
            this.HelikopterZerstörtTextBox.TabIndex = 19;
            this.HelikopterZerstörtTextBox.TabStop = false;
            this.HelikopterZerstörtTextBox.Text = "Helikopter zerstört:";
            // 
            // Main_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 279);
            this.Controls.Add(this.HelikopterZerstörtUserTextBox);
            this.Controls.Add(this.HelikopterZerstörtTextBox);
            this.Controls.Add(this.TargetUndamagedUserTextBox);
            this.Controls.Add(this.TargetUndamagedTextBox);
            this.Controls.Add(this.CriticalHitUserTextBox);
            this.Controls.Add(this.CriticalHitTextBox);
            this.Controls.Add(this.HitUserTextBox);
            this.Controls.Add(this.HitTextBox);
            this.Controls.Add(this.GotoSettings);
            this.Controls.Add(this.PanzerZerstörtUserTextBox);
            this.Controls.Add(this.UpdateLangDirButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FlugzeugZerstörtTextBox);
            this.Controls.Add(this.GamefolderTextBox);
            this.Controls.Add(this.FlugzeugZerstörtUserTextBox);
            this.Controls.Add(this.SelectedGamefolder);
            this.Controls.Add(this.PanzerZerstörtTextBox);
            this.Controls.Add(this.CustomMessagesActivateButton);
            this.Controls.Add(this.GameFolderButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KR-WTKME";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Program_FormClosed);
            this.Load += new System.EventHandler(this.Main_Program_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GotoSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GotoSettings;
        private System.Windows.Forms.Button CustomMessagesActivateButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SelectedGamefolder;
        private System.Windows.Forms.Button GameFolderButton;
        private System.Windows.Forms.TextBox GamefolderTextBox;
        private System.Windows.Forms.TextBox PanzerZerstörtTextBox;
        private System.Windows.Forms.TextBox PanzerZerstörtUserTextBox;
        private System.Windows.Forms.TextBox FlugzeugZerstörtTextBox;
        private System.Windows.Forms.TextBox FlugzeugZerstörtUserTextBox;
        private System.Windows.Forms.Button UpdateLangDirButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox HitTextBox;
        private System.Windows.Forms.TextBox HitUserTextBox;
        private System.Windows.Forms.TextBox CriticalHitTextBox;
        private System.Windows.Forms.TextBox CriticalHitUserTextBox;
        private System.Windows.Forms.TextBox TargetUndamagedTextBox;
        private System.Windows.Forms.TextBox TargetUndamagedUserTextBox;
        private System.Windows.Forms.TextBox HelikopterZerstörtUserTextBox;
        private System.Windows.Forms.TextBox HelikopterZerstörtTextBox;
    }
}

