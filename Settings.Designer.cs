namespace KR_WTKME
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.upsTextBox = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // upsTextBox
            // 
            this.upsTextBox.Location = new System.Drawing.Point(357, 12);
            this.upsTextBox.Name = "upsTextBox";
            this.upsTextBox.ReadOnly = true;
            this.upsTextBox.Size = new System.Drawing.Size(288, 123);
            this.upsTextBox.TabIndex = 0;
            this.upsTextBox.TabStop = false;
            this.upsTextBox.Text = resources.GetString("upsTextBox.Text");
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 141);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(633, 624);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("https://kanuracer.eu/index.php/news-kr-wtkme/", System.UriKind.Absolute);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Location = new System.Drawing.Point(27, 55);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(121, 30);
            this.SaveSettingsButton.TabIndex = 2;
            this.SaveSettingsButton.Text = "button1";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(78, 28);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.LanguageComboBox.TabIndex = 3;
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(12, 29);
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.ReadOnly = true;
            this.LanguageTextBox.Size = new System.Drawing.Size(60, 20);
            this.LanguageTextBox.TabIndex = 4;
            this.LanguageTextBox.TabStop = false;
            this.LanguageTextBox.Text = "Language";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 777);
            this.Controls.Add(this.LanguageTextBox);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.upsTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Einstellungen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.First_Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox upsTextBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.TextBox LanguageTextBox;
    }
}