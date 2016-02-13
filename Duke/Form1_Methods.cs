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
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace Duke
{
    public partial class Form1
    {
        private void drawLines()
        {
            lineV2(0, 191, 675, (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left)); // pysty - erottaa mapit muusta
            lineV2(0, 698, 675, (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right)); // pysty - erottaa userit muusta

            lineH2(321, 0, 191, (AnchorStyles.Left | AnchorStyles.Bottom)); // vaaka - mappilistan alla
            lineH2(321, 699, 191, (AnchorStyles.Right | AnchorStyles.Bottom)); // vaaka - userlistan alla

            lineH2(120, 191, 507, (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top)); // vaaka - ip listan alla
            lineH2(471, 191, 507, (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom)); // vaaka - chatin alla
        }
        
        private void lineV2 (int top, int left, int height, AnchorStyles a)
        {
            lineV(top, left, height, Color.Silver, true, a);
            lineV(top, left + 1, height, Color.White, false, a);
        }

        private void lineH2(int top, int left, int width, AnchorStyles a)
        {
            lineH(top, left, width, Color.Silver, true, a);
            lineH(top + 1, left, width, Color.White, false, a);
        }

        private void lineV(int top, int left, int height, Color color, bool front, AnchorStyles a)
        {
            Panel line = new Panel();
            line.Top = top;
            line.Left = left;
            line.Width = 1;
            line.Height = height;
            line.BackColor = color;
            line.Anchor = a;
            this.Controls.Add(line);
            if (front) line.BringToFront();
        }

        private void lineH(int top, int left, int width, Color color, bool front, AnchorStyles a)
        {
            Panel line = new Panel();
            line.Top = top;
            line.Left = left;
            line.Width = width;
            line.Height = 1;
            line.BackColor = color;
            line.Anchor = a;
            this.Controls.Add(line);
            if (front) line.BringToFront();
        }

        private void selectItems()
        {
            foreach (ListViewItem item in lstMaps.Items)
            {
                if (mapSelected == item.Text)
                {
                    item.Selected = true;
                    lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
                }
                else item.Selected = false;
            }

            foreach (ListViewItem item in lstIp.Items)
            {
                if (ipSelected == item.Text) item.Selected = true;
            }
        }
        
        private void loadSettings()
        {
            if (comboGame.Text == "Duke Nukem 3D")
            {
                txtGamePath.Text = settings.LoadSetting("DukeFolder");
                playersSelected = settings.LoadSetting("DukeNumPlayers");
                mapSelected = settings.LoadSetting("DukeSelectedMap");
            }

            if (comboGame.Text == "Shadow Warrior")
            {
                txtGamePath.Text = settings.LoadSetting("SWFolder");
                playersSelected = settings.LoadSetting("SWNumPlayers");
                mapSelected = settings.LoadSetting("SWSelectedMap");
            }

            comboPlayers.Text = settings.LoadSetting("Players");
            ipSelected = settings.LoadSetting("IP");
            txtDosBoxPath.Text = settings.LoadSetting("DOSBoxFolder");
            txtDosBoxCapturePath.Text = settings.LoadSetting("DOSBoxCaptureFolder");
            txtSharedConfig.Text = settings.LoadSetting("SharedConfigFolder");
        }
        
        private void comboChanged()
        {
            if (comboGameOld == "Duke Nukem 3D")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("DukeFolder", txtGamePath.Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("DukeSelectedMap", lstMaps.SelectedItems[0].Text);
            }

            if (comboGameOld == "Shadow Warrior")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("SWFolder", txtGamePath.Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("SWSelectedMap", lstMaps.SelectedItems[0].Text);
            }

            settings.SaveSetting("Players", comboPlayers.Text);
            if (lstIp.SelectedItems.Count > 0) settings.SaveSetting("IP", lstIp.SelectedItems[0].Text);
            if (txtDosBoxPath.Text != "") settings.SaveSetting("DOSBoxFolder", txtDosBoxPath.Text);
            if (txtDosBoxCapturePath.Text != "") settings.SaveSetting("DOSBoxCaptureFolder", txtDosBoxCapturePath.Text);
            if (txtSharedConfig.Text != "") settings.SaveSetting("SharedConfigFolder", txtSharedConfig.Text);
            if (txtPlayerName.Text != "") modifyName(txtPlayerName.Text);

            comboGameOld = comboGame.Text;

            lstMaps.Items.Clear();
            picMapImage.Image = null;

            loadSettings();
            updatePaths();
            readMaps();
            selectItems();
            readName();
            resizeColumns();
        }

        private void updatePaths()
        {
            appPath = Application.ExecutablePath;
            appDir = Path.GetDirectoryName(Application.ExecutablePath);
            appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath));
            appCfg = Path.Combine(appDir, "Settings.cfg");

            pathGame = txtGamePath.Text;
            pathDosBox = txtDosBoxPath.Text;
            pathDosBoxCapture = txtDosBoxCapturePath.Text;
            pathShared = txtSharedConfig.Text;

            exeDosBox = Path.Combine(txtDosBoxPath.Text, "DOSBox.exe");

            exeGameCommit = Path.Combine(pathGame, "commit.exe");
            cfgGameCommit = Path.Combine(pathGame, "commit.dat");
            batGame = Path.Combine(pathGame, "dukebat.bat");
            cfgShared = Path.Combine(pathShared, "server");

            exeShared = Path.Combine(pathShared, "Duke.exe");
            exeLocal = Path.Combine(appDir, "Duke.exe");
            exeSharedUpdater = Path.Combine(pathShared, "Updater.exe");
            exeLocalUpdater = Path.Combine(appDir, "Updater.exe");

            userName = Environment.UserName;
            userFile = Path.Combine(pathShared, "online_" + userName);
            termFile = Path.Combine(pathShared, "terminate");
            soloFile = Path.Combine(pathShared, "solo");

            modCOMSource = Path.Combine(pathShared, "mod.com");
            modGRPSource = Path.Combine(pathShared, "mod.grp");
            modSCNSource = Path.Combine(pathShared, "mod.scn");
            modSWXSource = Path.Combine(pathShared, "mod.swx");

            modCOMDest = Path.Combine(pathGame, "mod.com");
            modGRPDest = Path.Combine(pathGame, "mod.grp");
            modSCNDest = Path.Combine(pathGame, "mod.scn");
            modSWXDest = Path.Combine(pathGame, "mod.swx");

            if (Directory.Exists(pathGame))
            {
                string[] cfgList = Directory.GetFiles(pathGame, "*.cfg", SearchOption.TopDirectoryOnly);
                if (cfgList.Count() > 0) cfgGame = Path.Combine(pathGame, cfgList[0]);
            }
        }

        private void checkUpdate()
        {
            try
            {
                if (Directory.Exists(txtSharedConfig.Text))
                {
                    if (File.Exists(exeShared) && File.Exists(exeLocal))
                    {
                        var versionInfoShared = FileVersionInfo.GetVersionInfo(exeShared);
                        string versionSharedString = versionInfoShared.ProductVersion;
                        int versionShared = Convert.ToInt32(versionInfoShared.ProductVersion.Replace(".", ""));

                        var versionInfoLocal = FileVersionInfo.GetVersionInfo(exeLocal);
                        string versionLocalString = versionInfoLocal.ProductVersion;
                        int versionLocal = Convert.ToInt32(versionInfoLocal.ProductVersion.Replace(".", ""));

                        if (versionShared > versionLocal)
                        {
                            addLine("");
                            addLine("Program update available! (v" + versionSharedString + ")");
                        }
                    }

                    if (File.Exists(exeSharedUpdater) && File.Exists(exeLocalUpdater))
                    {
                        var versionInfoSharedUpdater = FileVersionInfo.GetVersionInfo(exeSharedUpdater);
                        string versionSharedStringUpdater = versionInfoSharedUpdater.ProductVersion;
                        int versionSharedUpdater = Convert.ToInt32(versionInfoSharedUpdater.ProductVersion.Replace(".", ""));

                        var versionInfoLocalUpdater = FileVersionInfo.GetVersionInfo(exeLocalUpdater);
                        string versionLocalStringUpdater = versionInfoLocalUpdater.ProductVersion;
                        int versionLocalUpdater = Convert.ToInt32(versionInfoLocalUpdater.ProductVersion.Replace(".", ""));

                        if (versionSharedUpdater > versionLocalUpdater)
                        {
                            File.Delete(exeLocalUpdater);
                            File.Copy(exeSharedUpdater, exeLocalUpdater);
                        }
                    }

                    else if (File.Exists(exeSharedUpdater))
                    {
                        File.Copy(exeSharedUpdater, exeLocalUpdater);
                    }


                }
            }
            
            catch (Exception ex)
            {
                addLine("Error checking update.");
                addLine(ex.Message + " (Code 1)");
            }
        }

        private void readMaps()
        {
            try
            {
                string mapDir = Path.Combine(pathShared, comboGame.Text);

                if (Directory.Exists(mapDir))
                {
                    string[] mapList = Directory.GetFiles(mapDir, "*.map", SearchOption.TopDirectoryOnly);

                    lstMaps.BeginUpdate();
                    lstMaps.Items.Clear();

                    foreach (string map in mapList)
                    {
                        lstMaps.Items.Add(Path.GetFileName(map).ToUpper());
                    }
                    lstMaps.EndUpdate();

                    clmMaps.Text = "Maps  (" + lstMaps.Items.Count + ")";
                }
            }
            
            catch (Exception ex)
            {
                addLine("");
                addLine("Error reading maps.");
                addLine(ex.Message + " (Code 2)");
            }
        }

        private void modifyPlayers(int num)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();

                string[] file = File.ReadAllLines(cfgGameCommit);

                foreach (string line in file)
                {
                    if (line.Contains("NUMPLAYERS = "))
                    {
                        string temp = "NUMPLAYERS = " + num.ToString();
                        newFile.Append(temp + "\r\n");
                    }
                    else newFile.Append(line + "\r\n");
                }

                File.WriteAllText(cfgGameCommit, newFile.ToString());
            }
            
            catch (Exception ex)
            {
                addLine("Error setting player count.");
                addLine(ex.Message + " (Code 3)");
            }
        }

        private void modifyMod(bool mod)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();

                string[] file = File.ReadAllLines(cfgGameCommit);

                foreach (string line in file)
                {
                    if (line.Contains("LAUNCHNAME = "))
                    {
                        string temp;
                        if (mod) temp = "LAUNCHNAME = \"MOD.COM\"";
                        else temp = "LAUNCHNAME = \"SW.EXE\"";
                        newFile.Append(temp + "\r\n");
                    }
                    else newFile.Append(line + "\r\n");
                }

                File.WriteAllText(cfgGameCommit, newFile.ToString());
            }

            catch (Exception ex)
            {
                addLine("Error setting player count.");
                addLine(ex.Message + " (Code 3)");
            }
        }

        private void modifyName(string name)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();

                string[] file = File.ReadAllLines(cfgGame);

                foreach (string line in file)
                {
                    if (line.Contains("PlayerName = "))
                    {
                        string temp = "PlayerName = \"" + name + "\"";
                        newFile.Append(temp + "\r\n");
                    }
                    else newFile.Append(line + "\r\n");
                }

                File.WriteAllText(cfgGame, newFile.ToString());
            }
            
            catch (Exception ex)
            {
                addLine("Error setting player name.");
                addLine(ex.Message + " (Code 4)");
            }
        }

        private void readName()
        {
            try
            {
                if (File.Exists(cfgGame))
                {
                    StringBuilder newFile = new StringBuilder();

                    string[] file = File.ReadAllLines(cfgGame);
                    string name = "";

                    foreach (string line in file)
                    {
                        if (line.Contains("PlayerName = "))
                        {
                            name = line.Replace("PlayerName = \"", "").Replace("\"", "");
                        }
                    }

                    txtPlayerName.Text = name;
                }
            }
            
            catch (Exception ex)
            {
                txtPlayerName.Text = "Error!";
                addLine("Error reading player name.");
                addLine(ex.Message + " (Code 5)");
            }
        }

        private void addLine(string line)
        {
            lastIsMessage = false;
            string timestamp = DateTime.Now.ToString(@"HH:mm:ss");

            if (line != "")
            {
                richTextBox1.SelectionColor = timestampNotification;
                richTextBox1.AppendText("[" + timestamp + "]  ");
                goToLineEnd();

                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.AppendText(line);
                goToLineEnd();
            }
            else
            {
                richTextBox1.SelectionColor = separatorLine;
                richTextBox1.AppendText(" ----------");
                goToLineEnd();
            }

            richTextBox1.AppendText(System.Environment.NewLine);
            goToLineEnd();

            Application.DoEvents();
            richTextBox1.ScrollToCaret();
        }

        private void addLineTime(string user, string line, string timestamp)
        {
            lastIsMessage = true;

            if (line != "")
            {
                richTextBox1.SelectionColor = timestampMessage;
                richTextBox1.AppendText("[" + timestamp + "]  ");
                goToLineEnd();

                richTextBox1.SelectionFont = new Font("Segoe UI Semibold", 10);
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.AppendText(user);
                goToLineEnd();

                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                richTextBox1.AppendText(": " + line);
                goToLineEnd();
            }
            else
            {
                richTextBox1.SelectionColor = separatorLine;
                richTextBox1.AppendText(" ----------");
                goToLineEnd();
            }
            
            richTextBox1.AppendText(System.Environment.NewLine);
            goToLineEnd();

            Application.DoEvents();
            richTextBox1.ScrollToCaret();
        }

        private void goToLineEnd()
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        private bool createSharedConfig()
        {
            try
            {
                using (StreamWriter writer = File.CreateText(cfgShared))
                {
                    writer.WriteLine(DateTime.Now.ToString(@"HH:mm:ss"));
                    writer.WriteLine(comboGame.Text);
                    writer.WriteLine(userName);
                    writer.WriteLine(lstIp.SelectedItems[0].Text);
                    writer.WriteLine(lstMaps.SelectedItems[0].Text);
                    
                    if (numOfPlayers == 0) writer.WriteLine(lstOnline.Items.Count);
                    else writer.WriteLine(comboPlayers.Text);
                }

                server = true;
                return true;
            }
            
            catch (Exception ex)
            {
                addLine("Error creating server.");
                addLine(ex.Message + " (Code 6)");
            }
            return false;
        }

        private void deleteSharedConfig()
        {
            try
            {
                if (File.Exists(cfgShared)) File.Delete(cfgShared);
                server = false;
            }
            
            catch (Exception ex)
            {
                addLine("Error deleting server.");
                addLine(ex.Message + " (Code 7)");
            }

            try // again
            {
                if (File.Exists(cfgShared)) File.Delete(cfgShared);
                server = false;
            }
            
            catch (Exception ex)
            {
                addLine("Error deleting server.");
                addLine(ex.Message + " (Code 8)");
            }
        }

        private void listIp()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                var ipProps = adapter.GetIPProperties();

                foreach (var ip in ipProps.UnicastAddresses)
                {
                    if ((adapter.OperationalStatus == OperationalStatus.Up) && (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        if (!IPAddress.IsLoopback(ip.Address))
                        {
                            ListViewItem item = new ListViewItem(ip.Address.ToString(), 0);
                            item.SubItems.Add(adapter.Description.ToString());
                            lstIp.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void checkChoices()
        {
            addLine("");
            addLine("Can't launch game:");
            if (lstMaps.SelectedItems.Count == 0) addLine("Map not selected.");
            if (lstIp.SelectedItems.Count == 0) addLine("IP address not selected.");
            if (txtPlayerName.Text == "") addLine("Player name not defined.");
            if (comboPlayers.Text == "") addLine("Number of players not defined.");
            if (!Directory.Exists(pathGame)) addLine("Game folder not selected.");
            if (!File.Exists(exeDosBox)) addLine("DOSBox folder not selected.");
            if (!Directory.Exists(pathShared)) addLine("Shared folder not selected.");
        }

        private void resizeColumns()
        {
            clmMaps.Width = lstMaps.ClientRectangle.Width;
            clmIp.Width = -1;
            clmAdapter.Width = lstIp.ClientRectangle.Width - clmIp.Width;
            clmOnline.Width = lstOnline.ClientRectangle.Width;
        }

        private void disableAll()
        {
            btnLaunch.Enabled = false;
            lstMaps.Enabled = false;
            lstIp.Enabled = false;
            txtDosBoxPath.Enabled = false;
            txtGamePath.Enabled = false;
            txtSharedConfig.Enabled = false;
            txtPlayerName.Enabled = false;
            btnDosBoxPath.Enabled = false;
            btnGamePath.Enabled = false;
            btnSharedConfig.Enabled = false;
            btnUpdate.Enabled = false;
            comboGame.Enabled = false;
            txtDosBoxCapturePath.Enabled = false;
            btnDosBoxCapturePath.Enabled = false;
            btnDeleteMaps.Enabled = false;
            btnSaveDescription.Enabled = false;
            txtDescription.Enabled = false;
            txtLastPlayed.Enabled = false;
            comboPlayers.Enabled = false;
        }

        private void enableAll()
        {
            btnLaunch.Enabled = true;
            lstMaps.Enabled = true;
            lstIp.Enabled = true;
            txtDosBoxPath.Enabled = true;
            txtGamePath.Enabled = true;
            txtSharedConfig.Enabled = true;
            txtPlayerName.Enabled = true;
            btnDosBoxPath.Enabled = true;
            btnGamePath.Enabled = true;
            btnSharedConfig.Enabled = true;
            btnUpdate.Enabled = true;
            comboGame.Enabled = true;
            txtDosBoxCapturePath.Enabled = true;
            btnDosBoxCapturePath.Enabled = true;
            btnDeleteMaps.Enabled = true;
            btnSaveDescription.Enabled = true;
            txtDescription.Enabled = true;
            txtLastPlayed.Enabled = true;
            comboPlayers.Enabled = true;
        }

        private void saveCapture()
        {
            try
            {
                if (Directory.Exists(pathDosBoxCapture))
                {
                    string wildcard = "";
                    if (comboGame.Text == "Duke Nukem 3D") wildcard = "duke*.png";
                    if (comboGame.Text == "Shadow Warrior") wildcard = "sw*.png";
                    if (comboGame.Text == "Shadow Warrior" && File.Exists(modCOMSource)) wildcard = "mod*.png";

                    string[] fileList = Directory.GetFiles(pathDosBoxCapture, wildcard, SearchOption.TopDirectoryOnly);

                    if (fileList.Count() > 0)
                    {
                        string captureFile = fileList[fileList.Count() - 1];
                        string mapName = lastMapPlayed;
                        string mapImage = Path.GetFileNameWithoutExtension(mapName) + ".PNG";

                        try
                        {
                            string mapImageFullPath = Path.Combine(Path.Combine(pathShared, comboGame.Text), mapImage);

                            if (File.Exists(mapImageFullPath)) File.Delete(mapImageFullPath);
                            File.Copy(captureFile, mapImageFullPath);
                            addLine("Screen capture saved to \"" + mapImage + "\".");

                            if (File.Exists(mapImageFullPath))
                            {
                                FileStream fs;
                                fs = new FileStream(mapImageFullPath, FileMode.Open, FileAccess.Read);
                                picMapImage.Image = Image.FromStream(fs);
                                fs.Close();
                            }
                            else picMapImage.Image = null;

                        }
                        
                        catch (Exception ex)
                        {
                            addLine("Error saving capture.");
                            addLine(ex.Message + " (Code 9).");
                        }

                        try
                        {
                            string pathDosBoxCaptureAll = Path.Combine(pathDosBoxCapture, "all");
                            if (!Directory.Exists(pathDosBoxCaptureAll)) Directory.CreateDirectory(pathDosBoxCaptureAll);

                            foreach (string file in fileList)
                            {
                                string filename = Path.GetFileName(file);
                                string destFile = Path.Combine(pathDosBoxCaptureAll, filename);
                                string fileDate = File.GetLastWriteTime(file).ToString(@"yyyy-MM-dd_HH-mm-ss_");
                                string destFileCustom = Path.Combine(pathDosBoxCaptureAll, fileDate + filename);

                                if (File.Exists(destFileCustom)) File.Delete(destFileCustom);
                                File.Move(file, destFileCustom);
                            }
                        }
                        
                        catch (Exception ex)
                        {
                            addLine("Error saving capture.");
                            addLine(ex.Message + " (Code 10).");
                        }

                    }
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error saving capture.");
                addLine(ex.Message + " (Code 11).");
            }
        }

        private void copyMap()
        {
            try
            {
                string mapFileSource = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileName(lstMaps.SelectedItems[0].Text));
                string mapFileDestination = Path.Combine(pathGame, Path.GetFileName(lstMaps.SelectedItems[0].Text));

                if (File.Exists(mapFileSource))
                {
                    if (!File.Exists(mapFileDestination))
                    {
                        File.Copy(mapFileSource, mapFileDestination);
                        copied = true;
                    }
                    else copied = false;
                }
                else copied = false;
            }
            
            catch (Exception ex)
            {
                addLine("Error copying map.");
                addLine(ex.Message + " (Code 12).");
                copied = false;
            }
        }

        private void copyMod()
        {
            try
            {
                if (File.Exists(modCOMSource))
                {
                    if (File.Exists(modCOMDest)) File.Delete(modCOMDest);
                    File.Copy(modCOMSource, modCOMDest);
                }

                if (File.Exists(modGRPSource))
                {
                    if (File.Exists(modGRPDest)) File.Delete(modGRPDest);
                    File.Copy(modGRPSource, modGRPDest);
                }

                if (File.Exists(modSCNSource))
                {
                    if (File.Exists(modSCNDest)) File.Delete(modSCNDest);
                    File.Copy(modSCNSource, modSCNDest);
                }

                if (File.Exists(modSWXSource))
                {
                    if (File.Exists(modSWXDest)) File.Delete(modSWXDest);
                    File.Copy(modSWXSource, modSWXDest);
                }
            }

            catch (Exception ex)
            {
                addLine("Error copying mod.");
                addLine(ex.Message + " (Code 12.5).");
            }
        }

        private void deleteCopiedMap()
        {
            if (copied)
            {
                try
                {
                    string mapFileDestination = Path.Combine(pathGame, Path.GetFileName(lstMaps.SelectedItems[0].Text));

                    if (File.Exists(mapFileDestination))
                    {
                        File.Delete(mapFileDestination);
                    }
                    copied = false;
                }
                
                catch (Exception ex)
                {
                    addLine("Error deleting copied map.");
                    addLine(ex.Message + " (Code 13).");
                    copied = false;
                }
            }
        }

        private void deleteMaps()
        {
            try
            {
                if (Directory.Exists(Path.Combine(pathShared, comboGame.Text)))
                {
                    addLine("");

                    if (lstMaps.SelectedItems.Count > 0)
                    {
                        foreach (ListViewItem map in lstMaps.SelectedItems)
                        {
                            string mapFile = Path.Combine(Path.Combine(pathShared, comboGame.Text), map.Text);
                            string mapImage = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(map.Text)) + ".PNG";
                            string mapDesc = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(map.Text)) + ".TXT";
                            string mapLp = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(map.Text)) + ".LP";

                            if (File.Exists(mapFile))
                            {
                                File.Delete(mapFile);
                                addLine("Map \"" + map.Text + "\" deleted.");
                            }

                            if (File.Exists(mapImage)) File.Delete(mapImage);
                            if (File.Exists(mapDesc)) File.Delete(mapDesc);
                            if (File.Exists(mapLp)) File.Delete(mapLp);
                        }
                    }
                    else
                    {
                        addLine("No maps selected.");
                    }
                }

                if (lstMaps.SelectedItems.Count > 0)
                {
                    if (lstMaps.SelectedItems[0].Index > 0)
                    {
                        int i = lstMaps.SelectedItems[0].Index;
                        readMaps();
                        if (lstMaps.Items.Count > i) lstMaps.Items[i].Selected = true;
                        else lstMaps.Items[lstMaps.Items.Count - 1].Selected = true;
                    }
                    
                    else
                    {
                        readMaps();
                        if (lstMaps.Items.Count > 0) lstMaps.Items[0].Selected = true;
                    }
                    
                    if (lstMaps.SelectedItems.Count > 0) lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
                    resizeColumns();
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error deleting maps.");
                addLine(ex.Message + " (Code 14).");
            }
        }

        private void saveDescription()
        {
            try
            {
                if (lstMaps.SelectedItems.Count == 1)
                {
                    string mapName = Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text);
                    string descName = mapName + ".txt";
                    string descFile = Path.Combine(Path.Combine(pathShared, comboGame.Text), descName);

                    if (txtDescription.Text.Trim() == "" && File.Exists(descFile))
                    {
                        File.Delete(descFile);
                        addLine("");
                        addLine("Map description for \"" + mapName + ".MAP\" deleted.");
                    }
                    
                    else if (txtDescription.Text.Trim() == "")
                    {
                        addLine("");
                        addLine("Map description not changed.");
                    }
                    
                    else
                    {
                        File.WriteAllText(descFile, txtDescription.Text);
                        addLine("");
                        addLine("Map description for \"" + mapName + ".MAP\" saved.");
                    }

                }
                else
                {
                    addLine("");
                    addLine("Select one map to save description.");
                }
            }
            
            catch (Exception ex)
            {
                addLine("");
                addLine("Error saving description.");
                addLine(ex.Message + " (Code 15).");
            }
        }

        private void loadDescription()
        {
            try
            {
                if (txtDescription.Focused == false && btnSaveDescription.Focused == false)
                {
                    if (lstMaps.SelectedItems.Count == 1)
                    {
                        string mapName = Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text);
                        string descName = mapName + ".txt";
                        string descFile = Path.Combine(Path.Combine(pathShared, comboGame.Text), descName);

                        if (File.Exists(descFile))
                        {
                            StringBuilder newFile = new StringBuilder();

                            using (StreamReader sr = new StreamReader(File.Open(descFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                            {
                                String line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    newFile.Append(line + "\r\n");
                                }
                            }
                            txtDescription.Text = newFile.ToString();

                        }
                        else txtDescription.Text = "";
                    }
                    else txtDescription.Text = "";
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error loading description.");
                addLine(ex.Message + " (Code 16).");
                txtDescription.Text = "";
            }
        }

        private void saveLastPlayed()
        {
            try
            {
                string lastPlayed = DateTime.Now.ToString(@"d.M.yyyy");

                if (lstMaps.SelectedItems.Count == 1)
                {
                    string mapName = Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text);
                    string lpName = mapName + ".lp";
                    string lpFile = Path.Combine(Path.Combine(pathShared, comboGame.Text), lpName);

                    File.WriteAllText(lpFile, lastPlayed);
                }
            }
            catch (Exception ex)
            {
                addLine("Error saving last played date.");
                addLine(ex.Message + " (Code 17).");
            }
        }

        private void loadLastPlayed()
        {
            try
            {
                if (lstMaps.SelectedItems.Count == 1)
                {
                    string mapName = Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text);
                    string lpName = mapName + ".lp";
                    string lpFile = Path.Combine(Path.Combine(pathShared, comboGame.Text), lpName);

                    if (File.Exists(lpFile))
                    {
                        string[] file = File.ReadAllLines(lpFile);
                        txtLastPlayed.Text = "Last played: " + file[0].ToString();
                    }
                    else txtLastPlayed.Text = "Last played: never";
                }
                else txtLastPlayed.Text = "";
            }
            
            catch (Exception ex)
            {
                addLine("Error loading last played date.");
                addLine(ex.Message + " (Code 18).");
                txtLastPlayed.Text = "";
            }
        }

        private void refreshOnline()
        {
            try
            {
                string wildcard = "online_*";
                online = Directory.GetFiles(pathShared, wildcard, SearchOption.TopDirectoryOnly);

                if (!online.SequenceEqual(onlineOld))
                {
                    lstOnline.BeginUpdate();
                    lstOnline.Items.Clear();

                    foreach (string file in online)
                    {
                        string user = Path.GetFileNameWithoutExtension(file).Replace("online_", "");
                        lstOnline.Items.Add(user);
                    }

                    lstOnline.EndUpdate();
                }
                onlineOld = online;

                clmOnline.Text = "Users online  (" + lstOnline.Items.Count + ")";
            }
            
            catch (Exception ex)
            {
                addLine("Error refreshing online players.");
                addLine(ex.Message + " (Code 19).");
            }
        }

        private void checkMessages()
        {
            try
            {
                string wildcard = "msg_*";
                messages = Directory.GetFiles(pathShared, wildcard, SearchOption.TopDirectoryOnly);

                if (!messages.SequenceEqual(messagesOld))
                {

                    foreach (string file in messages)
                    {
                        string f = Path.GetFileNameWithoutExtension(file);

                        string timeYear = f.Substring(4, 4);
                        string timeMonth = f.Substring(9, 2);
                        string timeDay = f.Substring(12, 2);
                        string timeHour = f.Substring(15, 2);
                        string timeMin = f.Substring(18, 2);
                        string timeSec = f.Substring(21, 2);
                        string timeMilliSec = f.Substring(24, 3);
                        string user = f.Substring(28);

                        string dateString = timeDay + "." + timeMonth + "." + timeYear + " " + timeHour + ":" + timeMin + ":" + timeSec + ":" + timeMilliSec;
                        string timestamp = timeHour + ":" + timeMin + ":" + timeSec;

                        if (!msgList.Contains(dateString))
                        {
                            msgList.Add(dateString);
                            string[] msg = File.ReadAllLines(file);

                            if (!lastIsMessage) addLineTime("", "", timestamp);
                            addLineTime(user, msg[0], timestamp);
                            if (user != userName) newMessage = true;
                        }
                    }

                }
                messagesOld = messages;
            }
            
            catch (Exception ex)
            {
                addLine("Error reading messages.");
                addLine(ex.Message + " (Code 20).");
            }
        }

        private void deleteOldMessages()
        {
            try
            {
                string wildcard = "msg_*";
                messages = Directory.GetFiles(pathShared, wildcard, SearchOption.TopDirectoryOnly);

                foreach (string file in messages)
                {
                    string f = Path.GetFileNameWithoutExtension(file);

                    string timeYear = f.Substring(4, 4);
                    string timeMonth = f.Substring(9, 2);
                    string timeDay = f.Substring(12, 2);
                    string timeHour = f.Substring(15, 2);
                    string timeMin = f.Substring(18, 2);
                    string timeSec = f.Substring(21, 2);

                    DateTime msgDate = new DateTime(Convert.ToInt32(timeYear), Convert.ToInt32(timeMonth), Convert.ToInt32(timeDay), Convert.ToInt32(timeHour), Convert.ToInt32(timeMin), Convert.ToInt32(timeSec));
                    DateTime nowDate = DateTime.Now;

                    TimeSpan difference = nowDate - msgDate;
                    if (difference.TotalMinutes > 60)
                    {
                        tryToDelete(file);
                    }
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error deleting old messages.");
                addLine(ex.Message + " (Code 21).");
            }
        }

        private void checkTerminated()
        {
            try
            {
                if (File.Exists(termFile) && (gameOn) && !soloMode)
                {
                    string[] msg = File.ReadAllLines(termFile);

                    gameOn = false;
                    cancelGame(msg[0]);

                    try
                    {
                        if (process != null) process.Kill();
                    }
                    
                    catch (Exception ex)
                    {
                        addLine("Error checking for termination.");
                        addLine(ex.Message + " (Code 22).");
                    }
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error checking for termination.");
                addLine(ex.Message + " (Code 23).");
            }
        }

        private void checkSolo()
        {
            try
            {
                if (File.Exists(soloFile))
                {
                    btnSolo.BackColor = Color.LightGreen;
                    soloMode = true;
                }
                else
                {
                    btnSolo.BackColor = Color.Transparent;
                    soloMode = false;
                }
            }
            
            catch (Exception ex)
            {
                addLine("Error checking for solo.");
                addLine(ex.Message + " (Code 24).");
            }
        }

        private void cancelGame(string user)
        {
            timerGameEnded.Stop();
            timerContinueClient.Stop();
            
            addLine("");
            addLine("Game terminated by \"" + user + "\".");

            tryToCreateUserFile();
            enableAll();
            if (server) deleteSharedConfig();
            deleteCopiedMap();
            server = false;
            client = false;

            loadLastPlayed();

            timerStartClient.Start();

        }

        private bool tryToDelete(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    return true;
                }
                return false;
            }
            
            catch (Exception ex)
            {
                addLine("Error deleting file.");
                addLine(ex.Message + " (Code 25).");
                return false;
            }
        }

        private bool tryToCreateUserFile()
        {
            try
            {
                File.WriteAllText(userFile, "");
                return true;
            }
            
            catch (Exception ex)
            {
                addLine("Error creating user file.");
                addLine(ex.Message + " (Code 26).");
                return false;
            }
        }

        private void waitPlayers()
        {
            btnLaunch.Text = "Waiting for players...";
            timerWaitPlayers.Start();
        }

        private void waitPlayersStop()
        {
            btnLaunch.Text = "Launch game";
            timerWaitPlayers.Stop();
        }

        private void startServer()
        {
                if (lstMaps.SelectedItems.Count > 0 &&
                    lstIp.SelectedItems.Count > 0 &&
                    Directory.Exists(pathShared) &&
                    Directory.Exists(pathGame) &&
                    File.Exists(exeDosBox) &&
                    comboPlayers.Text != "" &&
                    txtPlayerName.Text != "")
                {
                    try
                    {
                        gameOn = true;
                        disableAll();

                        addLine("");
                        if (!soloMode) addLine("Game started as server.");
                        else addLine("Game started as solo.");

                        tryToDelete(termFile);
                        tryToDelete(userFile);

                        if (!createSharedConfig() && !soloMode) createSharedConfig();

                        copyMap();
                        
                        if (comboGame.Text == "Shadow Warrior")
                        {
                            copyMod();
                            modifyMod(File.Exists(modCOMSource));
                        }

                        if (!soloMode) saveLastPlayed();

                        if (soloMode) modifyPlayers(1);
                        else if (numOfPlayers == 0) modifyPlayers(lstOnline.Items.Count);
                        else modifyPlayers(numOfPlayers);

                        modifyName(txtPlayerName.Text);

                        using (StreamWriter writer = File.CreateText(batGame))
                        {
                            writer.WriteLine("ipxnet startserver");
                            writer.WriteLine("commit.exe -map " + lstMaps.SelectedItems[0].Text);
                            writer.WriteLine("exit");
                        }

                        lastMapPlayed = lstMaps.SelectedItems[0].Text;

                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = false;
                        startInfo.UseShellExecute = false;
                        startInfo.FileName = exeDosBox;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.Arguments = batGame + " -noconsole";
                        process = Process.Start(startInfo);

                        gameStarted = DateTime.Now;
                        timerGameEnded.Start();
                    }
                    
                    catch (Exception ex)
                    {
                        gameOn = false;
                        enableAll();
                        deleteCopiedMap();
                        timerGameEnded.Stop();
                        addLine("");
                        addLine("Error starting server.");
                        addLine(ex.Message + " (Code 27).");
                    }
                }
                else checkChoices();

            }

        private void startClient()
        {
            if (!server && !client)
            {
                if (File.Exists(cfgShared) &&
                  Directory.Exists(pathGame) &&
                  File.Exists(exeDosBox) &&
                  txtPlayerName.Text != "")
                {
                    try
                    {
                        using (StreamReader reader = File.OpenText(cfgShared))
                        {
                            string time = reader.ReadLine();
                            string game = reader.ReadLine();
                            string name = reader.ReadLine();
                            string ip = reader.ReadLine();
                            string map = reader.ReadLine();
                            string players = reader.ReadLine();

                            if (timeOld != time)
                            {
                                timerStartClient.Stop();

                                comboGame.Text = game;
                                comboChanged();

                                gameOn = true;
                                disableAll();
                                client = true;

                                mapSelected = map;
                                playersSelected = players;

                                selectItems();

                                addLine("");
                                addLine("Player \"" + name + "\" started server (" + ip + ").");
                                addLine("Game \"" + game + "\" (" + players + " players).");
                                addLine("Map \"" + map + "\".");
                                addLine("");

                                lastMapPlayed = map;

                                timerContinueClient.Start();
                            }
                            timeOld = time;
                        }
                    }
                    
                    catch (Exception ex)
                    {
                        timerStartClient.Stop();
                        timerContinueClient.Stop();
                        gameOn = false;
                        enableAll();
                        client = false;
                        addLine("");
                        addLine("Error connecting to server.");
                        addLine(ex.Message + " (Code 28).");
                    }
                }
            }
        }
    
        private void continueClient()
        {
            try
            {
                using (StreamReader reader = File.OpenText(cfgShared))
                {
                    string time = reader.ReadLine();
                    string game = reader.ReadLine();
                    string name = reader.ReadLine();
                    string ip = reader.ReadLine();
                    string map = reader.ReadLine();
                    string players = reader.ReadLine();

                    timerContinueClient.Stop();

                    addLine("");
                    addLine("Game started.");

                    if (File.Exists(userFile)) File.Delete(userFile);

                    modifyPlayers(Convert.ToInt32(players));
                    modifyName(txtPlayerName.Text);

                    copyMap();

                    if (comboGame.Text == "Shadow Warrior")
                    {
                        copyMod();
                        modifyMod(File.Exists(modCOMSource));
                    }

                    using (StreamWriter writer = File.CreateText(batGame))
                    {
                        writer.WriteLine("ipxnet connect " + ip);
                        writer.WriteLine("commit.exe -map " + map);
                        writer.WriteLine("exit");
                    }

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = exeDosBox;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.Arguments = batGame + " -noconsole";
                    process = Process.Start(startInfo);

                    gameStarted = DateTime.Now;
                    timerGameEnded.Start();
                }
            }
            
            catch (Exception ex)
            {
                timerGameEnded.Stop();
                timerContinueClient.Stop();

                addLine("");
                addLine("Game terminated.");
                addLine(ex.Message + " (Code 29).");

                tryToCreateUserFile();
                enableAll();
                if (server) deleteSharedConfig();
                deleteCopiedMap();
                server = false;
                client = false;
                loadLastPlayed();

                timerStartClient.Start();
            }
        }

        private void gameEnded()
        {
            try
            {
                if (process.HasExited)
                {
                    timerGameEnded.Stop();

                    TimeSpan duration = DateTime.Now - gameStarted;
                    addLine("");
                    addLine("Game ended. Duration: " + Convert.ToInt32(duration.TotalMinutes) + " mins, " + Convert.ToInt32(duration.Seconds) + " secs.");

                    File.WriteAllText(userFile, "");

                    gameOn = false;
                    enableAll();
                    if (server) deleteSharedConfig();
                    if (copied) deleteCopiedMap();
                    server = false;
                    client = false;

                    saveCapture();
                    loadLastPlayed();

                    timerStartClient.Start();
                }
            }
            
            catch (Exception ex) // sama sisältö kuin try'n "if (process.HasExited)":ssa!!!
            {
                timerGameEnded.Stop();

                TimeSpan duration = DateTime.Now - gameStarted;
                addLine("");
                addLine("Game ended. Duration: " + Convert.ToInt32(duration.TotalMinutes) + " mins, " + Convert.ToInt32(duration.Seconds) + " secs.");
                addLine(ex.Message + " (Code 30).");

                File.WriteAllText(userFile, "");

                gameOn = false;
                enableAll();
                if (server) deleteSharedConfig();
                if (copied) deleteCopiedMap();
                server = false;
                client = false;

                saveCapture();
                loadLastPlayed();

                timerStartClient.Start();
            }
        }





    }
}
