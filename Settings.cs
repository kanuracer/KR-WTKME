using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KR_WTKME
{
    public partial class Settings : Form
    {
        //msgStrings
        private string msgThemeError;
        private string msgConfigUpdatedSuccessfully;
        private string msgErrorTitle;
        private string msgSuccessTitle;
        public Settings()
        {
            InitializeComponent();
            // Hintergrundfarbe basierend auf dem aktuellen Windows-Theme festlegen
            this.Load += Settings_Load;
        }

        private void First_Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.WindowLocation = this.Location;
            Properties.Settings.Default.WindowSizeSettings = this.Size;
            Properties.Settings.Default.Save();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

            //Überprüfe Sprache und setze entsprechenden Text
            if (Properties.Settings.Default.Language == "de-DE")
            {
                //Textboxen
                LanguageTextBox.Text = "Sprache:";
                


                //buttons
                SaveSettingsButton.Text = "Speichern";

                //msg
                msgThemeError = "Fehler beim Abfragen des Registrierungsschlüssels für das aktuelle Windows-Theme: ";
                msgConfigUpdatedSuccessfully = "The language has been successfully updated. Please restart the application.";
                msgErrorTitle = "Fehler";
                msgSuccessTitle = "Erfolgreich";

            }
            else if (Properties.Settings.Default.Language == "en-US")
            {
                //Textboxen
                LanguageTextBox.Text = "Language:";

                //buttons
                SaveSettingsButton.Text = "Save";

                //msg
                msgThemeError = "Error querying the registry key for the current Windows theme: ";
                msgConfigUpdatedSuccessfully = "Die Sprache wurde erfolgreich aktualisiert. Bitte starte die Anwendung neu.";
                msgErrorTitle = "Error";
                msgSuccessTitle = "Success";
            }

            // Entferne vorhandene Einträge, falls vorhanden
            LanguageComboBox.Items.Clear();

            // Füge die Optionen zur ComboBox hinzu
            LanguageComboBox.Items.Add("Deutsch");
            LanguageComboBox.Items.Add("English");

            // Setze die Vorauswahl basierend auf der Einstellung
            if (Properties.Settings.Default.Language == "de-DE")
            {
                LanguageComboBox.SelectedItem = "Deutsch";
            }
            else if (Properties.Settings.Default.Language == "en-US")
            {
                LanguageComboBox.SelectedItem = "English";
            }


            webBrowser1.ScriptErrorsSuppressed = true;
            // Wiederherstellen der Fensterposition beim Öffnen
            if (Properties.Settings.Default.WindowLocation != null)
                {
                    this.Location = Properties.Settings.Default.WindowLocation;
                    this.Size = Properties.Settings.Default.WindowSizeSettings;
                }

                // Hintergrundfarbe basierend auf dem aktuellen Windows-Theme festlegen
                this.BackColor = SystemColors.Window;

                bool isLightTheme = true;

                try
                {
                    // Versuchen, den Registrierungsschlüssel für das aktuelle Windows-Theme abzurufen
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                    {
                        if (key != null)
                        {
                            // Überprüfen, ob das System das helle oder dunkle Windows-Theme verwendet
                            object keyValue = key.GetValue("SystemUsesLightTheme");

                            if (keyValue != null)
                            {
                                isLightTheme = (int)keyValue != 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Fehler beim Abfragen des Registrierungsschlüssels
                    MessageBox.Show(msgThemeError + ex.Message, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!isLightTheme)
                {
                // Dunkles Windows-Theme
                this.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.upsTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.LanguageTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.SaveSettingsButton.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.LanguageComboBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;

                this.upsTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.LanguageTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.SaveSettingsButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.LanguageComboBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;

                this.upsTextBox.BorderStyle = BorderStyle.None;
                this.LanguageTextBox.BorderStyle = BorderStyle.None;

                this.SaveSettingsButton.FlatStyle = FlatStyle.Flat;
                this.LanguageComboBox.FlatStyle = FlatStyle.Flat;

                this.SaveSettingsButton.FlatAppearance.BorderColor = Properties.Settings.Default.DarkThemeButtonBorderColor;

            }
                else
                {
                    // Helles Windows-Theme
                    this.BackColor = SystemColors.Window;

            }
            
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            if (LanguageComboBox.SelectedItem.ToString() == "Deutsch")
            {
                Properties.Settings.Default.Language = "de-DE";
            }
            else if (LanguageComboBox.SelectedItem.ToString() == "English")
            {
                Properties.Settings.Default.Language = "en-US";
            }

            // Speichere die geänderten Einstellungen
            Properties.Settings.Default.Save();

            // Gib eine Bestätigungsmeldung aus
            MessageBox.Show(msgConfigUpdatedSuccessfully, msgSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
