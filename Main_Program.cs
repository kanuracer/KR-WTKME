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
using System.Security.Cryptography;

namespace KR_WTKME
{
    public partial class Main_Program : Form
    {
        //msgStrings
        private string msgThemeError;
        private string msgLocalizationActivated;
        private string msgConfigUpdatedSuccessfully;
        private string msgConfigFileNotFound;
        private string msgInvalidGamePath;
        private string msgErrorTitle;
        private string msgSuccessTitle;
        private string msgInfoTitle;
        private string msgTextsUpdatedSuccessfully;
        private string msgLangFolderNotFound;
        private string msgLinesNotFoundOrError;
        private string msgLanguageDirectoryCleared;
        private string msgLangDirectoryNotFound;

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
                e.Graphics.DrawLine(pen, HitUserTextBox.Left, HitUserTextBox.Bottom + lineWidth, HitUserTextBox.Right, HitUserTextBox.Bottom + lineWidth);
                e.Graphics.DrawLine(pen, CriticalHitUserTextBox.Left, CriticalHitUserTextBox.Bottom + lineWidth, CriticalHitUserTextBox.Right, CriticalHitUserTextBox.Bottom + lineWidth);
                e.Graphics.DrawLine(pen, TargetUndamagedUserTextBox.Left, TargetUndamagedUserTextBox.Bottom + lineWidth, TargetUndamagedUserTextBox.Right, TargetUndamagedUserTextBox.Bottom + lineWidth);
                e.Graphics.DrawLine(pen, HelikopterZerstörtUserTextBox.Left, HelikopterZerstörtUserTextBox.Bottom + lineWidth, HelikopterZerstörtUserTextBox.Right, HelikopterZerstörtUserTextBox.Bottom + lineWidth);
            }
        }
        private void Main_Program_Load(object sender, EventArgs e)
        {
            // Setze den standardmäßigen Pfad aus den Anwendungseinstellungen in die TextBox
            SelectedGamefolder.Text = Properties.Settings.Default.GamePath;
            PanzerZerstörtUserTextBox.Text = Properties.Settings.Default.PanzerZerstörtText;
            FlugzeugZerstörtUserTextBox.Text = Properties.Settings.Default.FlugzeugZerstörtText;
            HitUserTextBox.Text = Properties.Settings.Default.HitText;
            CriticalHitUserTextBox.Text = Properties.Settings.Default.CriticalHitText;
            TargetUndamagedUserTextBox.Text = Properties.Settings.Default.TargetUndamagedText;
            HelikopterZerstörtUserTextBox.Text = Properties.Settings.Default.HelikopterZertsörtText;

            //Überprüfe Sprache und setze entsprechenden Text
            if (Properties.Settings.Default.Language == "de-DE")
            {
                //Textboxen
                GamefolderTextBox.Text = "Speileverzeichnis:";
                PanzerZerstörtTextBox.Text = "Panzer zerstört:";
                FlugzeugZerstörtTextBox.Text = "Flugzeug zerstört:";
                HitTextBox.Text = "Treffer:";
                CriticalHitTextBox.Text = "Kritischer Treffer:";
                TargetUndamagedTextBox.Text = "Ziel unbeschädigt:";
                HelikopterZerstörtTextBox.Text = "Helikopter zerstört:";


                //buttons
                CustomMessagesActivateButton.Text = "Eigene Kill Message aktivieren";
                GameFolderButton.Text = "Auswählen";
                UpdateLangDirButton.Text = "Update";
                SaveButton.Text = "Speichern";

                //msg
                msgThemeError = "Fehler beim Abfragen des Registrierungsschlüssels für das aktuelle Windows-Theme: ";
                msgLocalizationActivated = "Die testLocalization ist bereits aktiviert.";
                msgConfigUpdatedSuccessfully = "Die Konfigurationsdatei wurde erfolgreich aktualisiert. Bitte starte War Thunder und beende es anschließend";
                msgConfigFileNotFound = "Die Datei config.blk wurde nicht im angegebenen Pfad gefunden.";
                msgInvalidGamePath = "Der Pfad zu War Thunder stimmt nicht. Bitte prüfe deine Einstellungen.";
                msgTextsUpdatedSuccessfully = "Die Texte wurden erfolgreich in der menu.csv-Datei aktualisiert.\nViel Spaß beim Spielen!";
                msgLangFolderNotFound = "Der Sprachordner wurde nicht im angegebenen Gamepath gefunden.";
                msgLinesNotFoundOrError = "Die Zeilen mit den zu ersetzenden Texten konnten nicht gefunden werden oder es ist ein Fehler aufgetreten.";
                msgLanguageDirectoryCleared = "Der Inhalt des Sprachverzeichnisses wurde gelöscht.\n\nBitte starte War Thunder und schließe es wieder, um das Verzeichnis zu aktualisieren.\nDrücke anschließend auf Speichern, um deine persönlichen Killmessages zu speichern.";
                msgLangDirectoryNotFound = "Das \"lang\"-Verzeichnis wurde nicht im angegebenen Gamepath gefunden.";
                msgErrorTitle = "Fehler";
                msgSuccessTitle = "Erfolgreich";
                msgInfoTitle = "Info";

            }
            else if (Properties.Settings.Default.Language == "en-US")
            {
                //Textboxen
                GamefolderTextBox.Text = "Gamefolder:";
                PanzerZerstörtTextBox.Text = "Tank destroyed:";
                FlugzeugZerstörtTextBox.Text = "Aircraft destroyed:";
                HitTextBox.Text = "Hit:";
                CriticalHitTextBox.Text = "Critical Hit:";
                TargetUndamagedTextBox.Text = "Target undamaged:";
                HelikopterZerstörtTextBox.Text = "Helicopter destroyed:";

                //buttons
                CustomMessagesActivateButton.Text = "Activate Kill Messages";
                GameFolderButton.Text = "Select";
                UpdateLangDirButton.Text = "Update";
                SaveButton.Text = "Save";

                //msg
                msgThemeError = "Error querying the registry key for the current Windows theme: ";
                msgLocalizationActivated = "The testLocalization is already activated.";
                msgConfigUpdatedSuccessfully = "The configuration file has been successfully updated. Please start War Thunder and exit afterwards.";
                msgConfigFileNotFound = "The config.blk file was not found in the specified path.";
                msgInvalidGamePath = "The War Thunder path is incorrect. Please check your settings.";
                msgTextsUpdatedSuccessfully = "The texts have been successfully updated in the menu.csv file.\nEnjoy gaming!";
                msgLangFolderNotFound = "The language folder was not found in the specified game path.";
                msgLinesNotFoundOrError = "The lines with the texts to be replaced could not be found or an error occurred.";
                msgLanguageDirectoryCleared = "The content of the language directory has been cleared.\n\nPlease start War Thunder and close it again to update the directory.\nThen click Save to save your custom kill messages.";
                msgLangDirectoryNotFound = "The \"lang\" directory was not found in the specified game path.";
                msgErrorTitle = "Error";
                msgSuccessTitle = "Success";
                msgInfoTitle = "Info";
            }


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
                MessageBox.Show(msgThemeError + ex.Message, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.HitTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.HitUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.CriticalHitTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.CriticalHitUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.TargetUndamagedTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.TargetUndamagedUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.HelikopterZerstörtUserTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;
                this.HelikopterZerstörtTextBox.BackColor = Properties.Settings.Default.DarkThemeBackColor;

                this.GamefolderTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.PanzerZerstörtTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.FlugzeugZerstörtTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.PanzerZerstörtUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.FlugzeugZerstörtUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.SelectedGamefolder.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.SaveButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.UpdateLangDirButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.CustomMessagesActivateButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.GameFolderButton.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.HitTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.HitUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.CriticalHitTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.CriticalHitUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.TargetUndamagedTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.TargetUndamagedUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.HelikopterZerstörtUserTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;
                this.HelikopterZerstörtTextBox.ForeColor = Properties.Settings.Default.DarkThemeForeColor;


                this.GamefolderTextBox.BorderStyle = BorderStyle.None;
                this.PanzerZerstörtTextBox.BorderStyle = BorderStyle.None;
                this.FlugzeugZerstörtTextBox.BorderStyle = BorderStyle.None;
                this.PanzerZerstörtUserTextBox.BorderStyle = BorderStyle.None;
                this.FlugzeugZerstörtUserTextBox.BorderStyle = BorderStyle.None;
                this.SelectedGamefolder.BorderStyle = BorderStyle.None;
                this.HitTextBox.BorderStyle = BorderStyle.None;
                this.HitUserTextBox.BorderStyle = BorderStyle.None;
                this.CriticalHitTextBox.BorderStyle = BorderStyle.None;
                this.CriticalHitUserTextBox.BorderStyle = BorderStyle.None;
                this.TargetUndamagedTextBox.BorderStyle = BorderStyle.None;
                this.TargetUndamagedUserTextBox.BorderStyle = BorderStyle.None;
                HelikopterZerstörtUserTextBox.BorderStyle = BorderStyle.None;
                HelikopterZerstörtTextBox.BorderStyle = BorderStyle.None;  

                this.SaveButton.FlatStyle = FlatStyle.Flat;
                this.UpdateLangDirButton.FlatStyle = FlatStyle.Flat;
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
                                MessageBox.Show(msgLocalizationActivated, msgInfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(msgConfigUpdatedSuccessfully, msgSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Datei nicht gefunden, gib eine Fehlermeldung aus
                    MessageBox.Show(msgConfigFileNotFound, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                // Datei nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show(msgInvalidGamePath, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Properties.Settings.Default.HitText = HitUserTextBox.Text;
            Properties.Settings.Default.CriticalHitText = CriticalHitUserTextBox.Text;
            Properties.Settings.Default.TargetUndamagedText = TargetUndamagedUserTextBox.Text;
            Properties.Settings.Default.HelikopterZertsörtText = HelikopterZerstörtUserTextBox.Text;
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
                                    for (int i = 1; i < panzerColumns.Length; i++)
                                    {
                                        panzerColumns[i] = "\"" + PanzerZerstörtUserTextBox.Text + "\"";
                                    }

                                    // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                    Array.Resize(ref panzerColumns, panzerColumns.Length + 2);
                                    panzerColumns[panzerColumns.Length - 2] = "";
                                    panzerColumns[panzerColumns.Length - 1] = "";

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
                                for (int i = 1; i < flugzeugColumns.Length; i++)
                                {
                                    flugzeugColumns[i] = "\"" + FlugzeugZerstörtUserTextBox.Text + "\"";
                                }

                                // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                Array.Resize(ref flugzeugColumns, flugzeugColumns.Length + 2);
                                flugzeugColumns[flugzeugColumns.Length - 2] = "";
                                flugzeugColumns[flugzeugColumns.Length - 1] = "";

                                // Baue die aktualisierte Zeile zusammen
                                string updatedFlugzeugLine = string.Join(";", flugzeugColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(flugzeugLine, updatedFlugzeugLine);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(HitUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.HitText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für "Hit"
                    string hitSearchString = "\"exp_reasons/hit\"";
                    int hitLineIndex = fileContent.IndexOf(hitSearchString);

                    if (hitLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für "Hit"
                        int hitEndIndex = fileContent.IndexOf("\n", hitLineIndex);

                        if (hitEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für "Hit"
                            string hitLine = fileContent.Substring(hitLineIndex, hitEndIndex - hitLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] hitColumns = hitLine.Split(';');

                            if (hitColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für "Hit"
                                for (int i = 1; i < hitColumns.Length; i++)
                                {
                                    hitColumns[i] = "\"" + HitUserTextBox.Text + "\"";
                                }

                                // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                Array.Resize(ref hitColumns, hitColumns.Length + 2);
                                hitColumns[hitColumns.Length - 2] = "";
                                hitColumns[hitColumns.Length - 1] = "";

                                // Baue die aktualisierte Zeile zusammen
                                string updatedHitLine = string.Join(";", hitColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(hitLine, updatedHitLine);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(CriticalHitUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.CriticalHitText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für "CriticalHit"
                    string criticalHitSearchString = "\"exp_reasons/critical_hit\"";
                    int criticalHitLineIndex = fileContent.IndexOf(criticalHitSearchString);

                    if (criticalHitLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für "CriticalHit"
                        int criticalHitEndIndex = fileContent.IndexOf("\n", criticalHitLineIndex);

                        if (criticalHitEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für "CriticalHit"
                            string criticalHitLine = fileContent.Substring(criticalHitLineIndex, criticalHitEndIndex - criticalHitLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] criticalHitColumns = criticalHitLine.Split(';');

                            if (criticalHitColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für "CriticalHit"
                                for (int i = 1; i < criticalHitColumns.Length; i++)
                                {
                                    criticalHitColumns[i] = "\"" + CriticalHitUserTextBox.Text + "\"";
                                }

                                // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                Array.Resize(ref criticalHitColumns, criticalHitColumns.Length + 2);
                                criticalHitColumns[criticalHitColumns.Length - 2] = "";
                                criticalHitColumns[criticalHitColumns.Length - 1] = "";

                                // Baue die aktualisierte Zeile zusammen
                                string updatedCriticalHitLine = string.Join(";", criticalHitColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(criticalHitLine, updatedCriticalHitLine);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(TargetUndamagedUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.TargetUndamagedText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für "Target undamaged"
                    string targetUndamagedSearchString = "\"exp_reasons/ineffective_hit\"";
                    int targetUndamagedLineIndex = fileContent.IndexOf(targetUndamagedSearchString);

                    if (targetUndamagedLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für "Target undamaged"
                        int targetUndamagedEndIndex = fileContent.IndexOf("\n", targetUndamagedLineIndex);

                        if (targetUndamagedEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für "Target undamaged"
                            string targetUndamagedLine = fileContent.Substring(targetUndamagedLineIndex, targetUndamagedEndIndex - targetUndamagedLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] targetUndamagedColumns = targetUndamagedLine.Split(';');

                            if (targetUndamagedColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für "Target undamaged"
                                for (int i = 1; i < targetUndamagedColumns.Length; i++)
                                {
                                    targetUndamagedColumns[i] = "\"" + TargetUndamagedUserTextBox.Text + "\"";
                                }

                                // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                Array.Resize(ref targetUndamagedColumns, targetUndamagedColumns.Length + 2);
                                targetUndamagedColumns[targetUndamagedColumns.Length - 2] = "";
                                targetUndamagedColumns[targetUndamagedColumns.Length - 1] = "";

                                // Baue die aktualisierte Zeile zusammen
                                string updatedTargetUndamagedLine = string.Join(";", targetUndamagedColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(targetUndamagedLine, updatedTargetUndamagedLine);
                            }
                        }
                    }
                }

                // Überprüfe, ob die Textboxen nicht leer sind
                if (!string.IsNullOrEmpty(HelikopterZerstörtUserTextBox.Text) && !string.IsNullOrEmpty(Properties.Settings.Default.HelikopterZertsörtText))
                {
                    // Suche nach der Zeile mit dem zu ersetzenden Text für Helikopter
                    string helikopterSearchString = "\"exp_reasons/kill_helicopter\"";
                    int helikopterLineIndex = fileContent.IndexOf(helikopterSearchString);

                    if (helikopterLineIndex != -1)
                    {
                        // Suche das Ende der Zeile für Helikopter
                        int helikopterEndIndex = fileContent.IndexOf("\n", helikopterLineIndex);

                        if (helikopterEndIndex != -1)
                        {
                            // Extrahiere die Zeile mit dem zu ersetzenden Text für Helikopter
                            string helikopterLine = fileContent.Substring(helikopterLineIndex, helikopterEndIndex - helikopterLineIndex);

                            // Teile die Zeile in Spalten auf
                            string[] helikopterColumns = helikopterLine.Split(';');

                            if (helikopterColumns.Length >= 2)
                            {
                                // Ersetze den Text in allen Sprachenspalten für helikoptere
                                for (int i = 1; i < helikopterColumns.Length; i++)
                                {
                                    helikopterColumns[i] = "\"" + HelikopterZerstörtUserTextBox.Text + "\"";
                                }

                                // Füge die beiden zusätzlichen leeren Spalten am Ende hinzu
                                Array.Resize(ref helikopterColumns, helikopterColumns.Length + 2);
                                helikopterColumns[helikopterColumns.Length - 2] = "";
                                helikopterColumns[helikopterColumns.Length - 1] = "";

                                // Baue die aktualisierte Zeile zusammen
                                string updatedHelikopterLine = string.Join(";", helikopterColumns);

                                // Ersetze die alte Zeile durch die aktualisierte Zeile im Dateiinhalt
                                fileContent = fileContent.Replace(helikopterLine, updatedHelikopterLine);
                            }
                        }
                    }
                }

                // Schreibe den aktualisierten Inhalt in die menu.csv-Datei
                File.WriteAllText(menuFilePath, fileContent);

                // Erfolgmeldung anzeigen
                MessageBox.Show(msgTextsUpdatedSuccessfully, msgSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Der lang-Ordner wurde nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show(msgLangFolderNotFound, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Fehlermeldung anzeigen, wenn die Zeilen nicht gefunden oder nicht korrekt aktualisiert werden konnten
            MessageBox.Show(msgLinesNotFoundOrError, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(msgLanguageDirectoryCleared, msgInfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Das "lang"-Verzeichnis wurde nicht gefunden, gib eine Fehlermeldung aus
                MessageBox.Show(msgLangDirectoryNotFound, msgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
