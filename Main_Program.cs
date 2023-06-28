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
using System.Resources;
using System.Reflection.Emit;
using System.IO;

namespace KR_WTKME
{
    public partial class Main_Program : Form
    {
        public Main_Program()
        {
            InitializeComponent();
            // Hintergrundfarbe basierend auf dem aktuellen Windows-Theme festlegen
            this.Load += Main_Program_Load;
            // Linien zeichnen
            this.Paint += Main_Program_Paint;
        }
        private void Main_Program_Paint(object sender, PaintEventArgs e)
        {
            // Weiße Linien zeichnen
            using (Pen pen = new Pen(Properties.Settings.Default.DarkThemeTextBoxLine)) 
            {
                int lineWidth = 2; // Breite der Linien anpassen, falls gewünscht

                // Linien für die Textboxen zeichnen
                e.Graphics.DrawLine(pen, PanzerZerstörtUserTextBox.Left, PanzerZerstörtUserTextBox.Bottom + lineWidth, PanzerZerstörtUserTextBox.Right, PanzerZerstörtUserTextBox.Bottom + lineWidth);
                e.Graphics.DrawLine(pen, FlugzeugZerstörtUserTextBox.Left, FlugzeugZerstörtUserTextBox.Bottom + lineWidth, FlugzeugZerstörtUserTextBox.Right, FlugzeugZerstörtUserTextBox.Bottom + lineWidth);
                e.Graphics.DrawLine(pen, SelectedGamefolder.Left, SelectedGamefolder.Bottom + lineWidth, SelectedGamefolder.Right, SelectedGamefolder.Bottom + lineWidth);
            }
        }
        private void Main_Program_Load(object sender, EventArgs e)
        {
            // Setze den standardmäßigen Pfad aus den Anwendungseinstellungen in die TextBox
            SelectedGamefolder.Text = Properties.Settings.Default.GamePath;
            PanzerZerstörtUserTextBox.Text = Properties.Settings.Default.PanzerZerstörtText;
            FlugzeugZerstörtUserTextBox.Text = Properties.Settings.Default.FlugzeugZerstörtText;

            // Wiederherstellen der Fensterposition beim Öffnen
            if (Properties.Settings.Default.WindowLocation != null)
            {
                this.Location = Properties.Settings.Default.WindowLocation;
                this.Size = Properties.Settings.Default.WindowSize;
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
                this.GamefolderTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.PanzerZerstörtTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.FlugzeugZerstörtTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.PanzerZerstörtUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.FlugzeugZerstörtUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.SelectedGamefolder.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.SaveButton.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.UpdateLangDirButton.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.CustomMessagesActivateButton.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.GameFolderButton.BackColor = Properties.Settings.Default.DarkThemeBackColor;

                this.GamefolderTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.PanzerZerstörtTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.FlugzeugZerstörtTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.PanzerZerstörtUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.FlugzeugZerstörtUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.SelectedGamefolder.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.SaveButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.UpdateLangDirButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.CustomMessagesActivateButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.GameFolderButton.ForeColor=Properties.Settings.Default.DarkThemeForeColor;


                this.GamefolderTextBox.BorderStyle = BorderStyle.None;
                this.PanzerZerstörtTextBox.BorderStyle = BorderStyle.None;
                this.FlugzeugZerstörtTextBox.BorderStyle = BorderStyle.None;
                this.PanzerZerstörtUserTextBox.BorderStyle = BorderStyle.None;
                this.FlugzeugZerstörtUserTextBox.BorderStyle = BorderStyle.None;
                this.SelectedGamefolder.BorderStyle = BorderStyle.None;
                this.SaveButton.FlatStyle = FlatStyle.Flat;
                this.UpdateLangDirButton.FlatStyle= FlatStyle.Flat;
                this.CustomMessagesActivateButton.FlatStyle = FlatStyle.Flat;
                this.GameFolderButton.FlatStyle = FlatStyle.Flat;

                this.SaveButton.FlatAppearance.BorderColor = Properties.Settings.Default.DarkThemeButtonBorderColor;
                this.UpdateLangDirButton.FlatAppearance.BorderColor = Properties.Settings.Default.DarkThemeButtonBorderColor;
                this.CustomMessagesActivateButton.FlatAppearance.BorderColor = Properties.Settings.Default.DarkThemeButtonBorderColor;
                this.GameFolderButton.FlatAppearance.BorderColor = Properties.Settings.Default.DarkThemeButtonBorderColor;


            }
            else
            {
                // Helles Windows-Theme
                this.BackColor = SystemColors.Window;

            }

        }
        
        private void GotoSettings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }

        private void Gamefolder_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void GameFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Stelle den Dialogtext und den Titel ein
            folderBrowserDialog.Description = "Wähle das War Thunder Verzeichnis aus";
            folderBrowserDialog.SelectedPath = "C:\\"; // Optional: Startpfad setzen
            folderBrowserDialog.ShowNewFolderButton = false; // Optional: Das Erstellen neuer Ordner deaktivieren
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // Optional: Root-Folder festlegen

            // Öffne den Dialog und überprüfe, ob der Benutzer "OK" ausgewählt hat
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog.SelectedPath;
                SelectedGamefolder.Text = selectedPath;
                // Speichere den ausgewählten Pfad in den Anwendungseinstellungen
                Properties.Settings.Default.GamePath = selectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void CustomMessagesActivateButton_Click(object sender, EventArgs e)
        {
            string gamePath = Properties.Settings.Default.GamePath;
            string filePath = Path.Combine(gamePath, "eac_wt_mlauncher.exe");
            string configPath = Path.Combine(gamePath, "config.blk");

            if (File.Exists(filePath))
            {
                if (File.Exists(configPath))
                {
                    // Lese den Inhalt der Datei
                    string fileContent = File.ReadAllText(configPath);

                    // Überprüfe, ob der debug-Abschnitt vorhanden ist
                    int debugIndex = fileContent.IndexOf("debug{");
                    if (debugIndex != -1)
                    {
                        // Finde das Ende des debug-Abschnitts
                        int endIndex = fileContent.IndexOf("}", debugIndex);

                        if (endIndex != -1)
                        {
                            // Überprüfe, ob die Zeile bereits vorhanden ist
                            string searchString = "testLocalization:b=yes";
                            int lineIndex = fileContent.IndexOf(searchString, debugIndex, endIndex - debugIndex);
                            if (lineIndex != -1)
                            {
                                // Zeile bereits vorhanden, zeige eine Meldung an
                                MessageBox.Show("Die testLocalization ist bereits aktiviert.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return; // Beende die Methode, um keine weitere Aktion auszuführen
                            }

                            // Füge die neue Zeile hinzu
                            string newLine = "  testLocalization:b=yes";
                            fileContent = fileContent.Insert(endIndex - 1, $"\n{newLine}");
                        }
                    }

                    // Speichere den aktualisierten Inhalt zurück in die Datei
                    File.WriteAllText(configPath, fileContent);

                    // Bestätigung anzeigen
                    MessageBox.Show("Die Konfigurationsdatei wurde erfolgreich aktualisiert. Bitte starte War Thunder und beende es anschließend", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Datei nicht gefunden, gib eine Fehlermeldung aus
                    MessageBox.Show("Die Datei config.blk wurde nicht im angegebenen Pfad gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                // Datei nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show("Der Pfad zu War Thunder stimmt nicht. Bitte prüfe deine Einstellungen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Program_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.WindowLocation = this.Location;
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Speichern des Inhalts der Textboxen in den Einstellungen
            Properties.Settings.Default.PanzerZerstörtText = PanzerZerstörtUserTextBox.Text;
            Properties.Settings.Default.FlugzeugZerstörtText = FlugzeugZerstörtUserTextBox.Text;
            // Speichern der geänderten Einstellungen
            Properties.Settings.Default.Save();

            string gamePath = Properties.Settings.Default.GamePath;
            string langFolderPath = Path.Combine(gamePath, "lang");
            string menuFilePath = Path.Combine(langFolderPath, "menu.csv");

            if (Directory.Exists(langFolderPath))
            {
                // Lese den Inhalt der menu.csv-Datei
                string fileContent = File.ReadAllText(menuFilePath);

                // Überprüfe, ob die Textboxen nicht leer sind
                if (!string.IsNullOrEmpty(PanzerZerstörtUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.PanzerZerstörtText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für Panzer
                    string panzerSearchString = "\"exp_reasons/kill_gm\"";
                    int panzerLineIndex = fileContent.IndexOf(panzerSearchString);

                    if (panzerLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für Panzer
                        int panzerEndIndex = fileContent.IndexOf("\n", panzerLineIndex);

                        if (panzerEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für Panzer
                            string panzerLine = fileContent.Substring(panzerLineIndex, panzerEndIndex - panzerLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] panzerColumns = panzerLine.Split(';');

                            if (panzerColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für Panzer
                                for (int i = 1; i < panzerColumns.Length - 1; i++)
                                {
                                    panzerColumns[i] = "\"" + PanzerZerstörtUserTextBox.Text + "\"";
                                }

                                // Baue die aktualisierte Zeile zusammen
                                string updatedPanzerLine = string.Join(";", panzerColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(panzerLine, updatedPanzerLine);
                            }
                        }
                    }
                }

                // Überprüfe, ob die Textboxen nicht leer sind
                if (!string.IsNullOrEmpty(FlugzeugZerstörtUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.FlugzeugZerstörtText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für Flugzeuge
                    string flugzeugSearchString = "\"exp_reasons/kill\"";
                    int flugzeugLineIndex = fileContent.IndexOf(flugzeugSearchString);

                    if (flugzeugLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für Flugzeuge
                        int flugzeugEndIndex = fileContent.IndexOf("\n", flugzeugLineIndex);

                        if (flugzeugEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für Flugzeuge
                            string flugzeugLine = fileContent.Substring(flugzeugLineIndex, flugzeugEndIndex - flugzeugLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] flugzeugColumns = flugzeugLine.Split(';');

                            if (flugzeugColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für Flugzeuge
                                for (int i = 1; i < flugzeugColumns.Length - 1; i++)
                                {
                                    flugzeugColumns[i] = "\"" + FlugzeugZerstörtUserTextBox.Text + "\"";
                                }

                                // Baue die aktualisierte Zeile zusammen
                                string updatedFlugzeugLine = string.Join(";", flugzeugColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(flugzeugLine, updatedFlugzeugLine);
                            }
                        }
                    }
                }

                // Schreibe den aktualisierten Inhalt in die menu.csv-Datei
                File.WriteAllText(menuFilePath, fileContent);

                // Erfolgmeldung anzeigen
                MessageBox.Show("Die Texte wurden erfolgreich in der menu.csv-Datei aktualisiert.\nViel spaß beim zocken!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Der lang-Ordner wurde nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show("Der Sprachordner wurde nicht im angegebenen Gamepath gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Fehlermeldung anzeigen, wenn die Zeilen nicht gefunden oder nicht korrekt aktualisiert werden konnten
            MessageBox.Show("Die Zeilen mit den zu ersetzenden Texten konnten nicht gefunden werden oder es ist ein Fehler aufgetreten.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UpdateLangDirButton_Click(object sender, EventArgs e)
        {
            string gamePath = Properties.Settings.Default.GamePath;
            string langFolderPath = Path.Combine(gamePath, "lang");
            if (Directory.Exists(langFolderPath))
            {
                // Lösche den Inhalt des "lang"-Verzeichnisses
                Directory.Delete(langFolderPath, true);

                // Zeige die Nachricht an
                MessageBox.Show("Der Inhalt des Sprachverzeichnisses wurde gelöscht.\n\nBitte starte War Thunder und schließe es wieder, um das Verzeichnis zu aktualisieren.\nDrücke anschließend auf Speichern, um deine persönlichen Killmessages zu speichern.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Das "lang"-Verzeichnis wurde nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show("Das \"lang\"-Verzeichnis wurde nicht im angegebenen Gamepath gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
