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

namespace $safeprojectname$
{
    public partial class Settings : Form
    {
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
                    MessageBox.Show("Fehler beim Abfragen des Registrierungsschlüssels für das aktuelle Windows-Theme: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!isLightTheme)
                {
                // Dunkles Windows-Theme
                this.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.upsTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                
                this.upsTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;

                this.upsTextBox.BorderStyle = BorderStyle.None;

            }
                else
                {
                    // Helles Windows-Theme
                    this.BackColor = SystemColors.Window;

            }
            
        }
        
    }
}
