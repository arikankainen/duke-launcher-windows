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
        private void selectItems()
        {
            foreach (ListViewItem item in lstMaps.Items)
            {
                if (mapSelected == item.Text)
                {
                    item.Selected = true;
                    lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
                }
            }

            foreach (ListViewItem item in lstPlayers.Items)
            {
                if (playersSelected == item.Text) item.Selected = true;
            }

            foreach (ListViewItem item in lstIp.Items)
            {
                if (ipSelected == item.Text) item.Selected = true;
            }
        }
        
        private void reselectGame()
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

            txtDosBoxPath.Text = settings.LoadSetting("DOSBoxFolder");
            txtDosBoxCapturePath.Text = settings.LoadSetting("DOSBoxCaptureFolder");
            txtSharedConfig.Text = settings.LoadSetting("SharedConfigFolder");
            ipSelected = settings.LoadSetting("IP");

            updatePaths();
        }
        
        private void comboChanged()
        {
            if (comboGameOld == "Duke Nukem 3D")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("DukeFolder", txtGamePath.Text);
                if (lstPlayers.SelectedItems.Count > 0) settings.SaveSetting("DukeNumPlayers", lstPlayers.SelectedItems[0].Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("DukeSelectedMap", lstMaps.SelectedItems[0].Text);
            }

            if (comboGameOld == "Shadow Warrior")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("SWFolder", txtGamePath.Text);
                if (lstPlayers.SelectedItems.Count > 0) settings.SaveSetting("SWNumPlayers", lstPlayers.SelectedItems[0].Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("SWSelectedMap", lstMaps.SelectedItems[0].Text);
            }

            if (lstIp.SelectedItems.Count > 0) settings.SaveSetting("IP", lstIp.SelectedItems[0].Text);
            if (txtDosBoxPath.Text != "") settings.SaveSetting("DOSBoxFolder", txtDosBoxPath.Text);
            if (txtDosBoxCapturePath.Text != "") settings.SaveSetting("DOSBoxCaptureFolder", txtDosBoxCapturePath.Text);
            if (txtSharedConfig.Text != "") settings.SaveSetting("SharedConfigFolder", txtSharedConfig.Text);

            if (txtPlayerName.Text != "") modifyName(txtPlayerName.Text);

            comboGameOld = comboGame.Text;

            lstMaps.Items.Clear();
            picMapImage.Image = null;
            reselectGame();
            updatePaths();
            selectItems();
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
            batGame = Path.Combine(pathGame, "dukiaine.bat");
            cfgShared = Path.Combine(pathShared, "dukiainen.txt");

            exeShared = Path.Combine(pathShared, "Duke.exe");
            exeLocal = Path.Combine(appDir, "Duke.exe");

            if (Directory.Exists(pathGame))
            {
                string[] cfgList = Directory.GetFiles(pathGame, "*.cfg", SearchOption.TopDirectoryOnly);
                if (cfgList.Count() > 0) cfgGame = Path.Combine(pathGame, cfgList[0]);
            }

            if (Directory.Exists(pathGame)) readMaps();
            if (File.Exists(cfgGame)) txtPlayerName.Text = readName();

        }

        private void checkUpdate()
        {
            if (Directory.Exists(txtSharedConfig.Text))
            {
                if (File.Exists(exeShared) && File.Exists(exeLocal))
                {
                    var versionInfoShared = FileVersionInfo.GetVersionInfo(exeShared);
                    string versionSharedString = versionInfoShared.ProductVersion.Substring(0, 3);
                    int versionShared = Convert.ToInt32(versionInfoShared.ProductVersion.Replace(".", ""));

                    var versionInfoLocal = FileVersionInfo.GetVersionInfo(exeLocal);
                    string versionLocalString = versionInfoLocal.ProductVersion.Substring(0, 3);
                    int versionLocal = Convert.ToInt32(versionInfoLocal.ProductVersion.Replace(".", ""));

                    if (versionShared > versionLocal)
                    {
                        addLine("Program update available. Get it now!");
                    }
                }
            }
        }

        private void readMaps()
        {
            string[] mapList = Directory.GetFiles(pathGame, "*.map", SearchOption.TopDirectoryOnly);

            lstMaps.BeginUpdate();
            lstMaps.Items.Clear();

            foreach (string map in mapList)
            {
                lstMaps.Items.Add(Path.GetFileName(map).ToUpper());
            }
            lstMaps.EndUpdate();
        }

        private void modifyPlayers(int num)
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

        private void modifyName(string name)
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

        private string readName()
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

            return name;
        }

        private void addLine(string line)
        {
            string timestamp = DateTime.Now.ToString(@"HH:mm:ss");
            if (line != "") line = timestamp + "  " + line;
            else line = "--------";

            textBox1.Text = textBox1.Text + line + System.Environment.NewLine;
            Application.DoEvents();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private bool createSharedConfig()
        {
            try
            {
                using (StreamWriter writer = File.CreateText(cfgShared))
                {
                    writer.WriteLine(DateTime.Now.ToString(@"HH:mm:ss"));
                    writer.WriteLine(comboGame.Text);
                    writer.WriteLine(txtPlayerName.Text);
                    writer.WriteLine(lstIp.SelectedItems[0].Text);
                    writer.WriteLine(lstMaps.SelectedItems[0].Text);
                    writer.WriteLine(lstPlayers.SelectedItems[0].Text);
                }

                server = true;
                return true;
            }
            catch { }
            return false;
        }

        private void deleteSharedConfig()
        {
            try
            {
                if (File.Exists(cfgShared)) File.Delete(cfgShared);
                server = false;
            }
            catch { }

            if (File.Exists(cfgShared)) deleteSharedConfig();
        }

        private void listIp()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                var ipProps = adapter.GetIPProperties();

                foreach (var ip in ipProps.UnicastAddresses)
                {
                    if ((adapter.OperationalStatus == OperationalStatus.Up)
                        && (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        ListViewItem item = new ListViewItem(ip.Address.ToString(), 0);
                        item.SubItems.Add(adapter.Description.ToString());
                        lstIp.Items.Add(item);
                    }
                }
            }
        }

        private void checkChoices()
        {
            addLine("");
            addLine("Can't launch game:");
            if (lstMaps.SelectedItems.Count == 0) addLine("Map not selected.");
            if (lstPlayers.SelectedItems.Count == 0) addLine("Number of players not selected.");
            if (lstIp.SelectedItems.Count == 0) addLine("IP address not selected.");
            if (txtPlayerName.Text == "") addLine("Player name not defined.");
            if (!Directory.Exists(pathGame)) addLine("Game folder not selected.");
            if (!File.Exists(exeDosBox)) addLine("DOSBox folder not selected.");
            if (!Directory.Exists(pathShared)) addLine("Shared folder not selected.");
        }

        private void resizeColumns()
        {
            clmMaps.Width = lstMaps.ClientRectangle.Width;
            clmPlayers.Width = lstPlayers.ClientRectangle.Width;
            clmIp.Width = -1;
            clmIp.Width = clmIp.Width + 20;
            clmAdapter.Width = lstIp.ClientRectangle.Width - clmIp.Width;
        }

        private void disableAll()
        {
            btnLaunch.Enabled = false;
            lstMaps.Enabled = false;
            lstPlayers.Enabled = false;
            lstIp.Enabled = false;
            txtDosBoxPath.Enabled = false;
            txtGamePath.Enabled = false;
            txtSharedConfig.Enabled = false;
            txtPlayerName.Enabled = false;
            btnDosBoxPath.Enabled = false;
            btnGamePath.Enabled = false;
            btnSharedConfig.Enabled = false;
            btnUploadMap.Enabled = false;
            btnDownloadMaps.Enabled = false;
            btnUpdate.Enabled = false;
            comboGame.Enabled = false;
            btnDosBoxOpen.Enabled = false;
            btnGameOpen.Enabled = false;
            btnSharedOpen.Enabled = false;
            txtDosBoxCapturePath.Enabled = false;
            btnDosBoxCaptureOpen.Enabled = false;
        }

        private void enableAll()
        {
            btnLaunch.Enabled = true;
            lstMaps.Enabled = true;
            lstPlayers.Enabled = true;
            lstIp.Enabled = true;
            txtDosBoxPath.Enabled = true;
            txtGamePath.Enabled = true;
            txtSharedConfig.Enabled = true;
            txtPlayerName.Enabled = true;
            btnDosBoxPath.Enabled = true;
            btnGamePath.Enabled = true;
            btnSharedConfig.Enabled = true;
            btnUploadMap.Enabled = true;
            btnDownloadMaps.Enabled = true;
            btnUpdate.Enabled = true;
            comboGame.Enabled = true;
            btnDosBoxOpen.Enabled = true;
            btnGameOpen.Enabled = true;
            btnSharedOpen.Enabled = true;
            txtDosBoxCapturePath.Enabled = true;
            btnDosBoxCaptureOpen.Enabled = true;
        }

        private void centerForm()
        {
            Screen screen = Screen.FromControl(this);
            this.WindowState = FormWindowState.Normal;
            this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
            this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
        }

        private void downloadNewMaps(bool showAllMessages)
        {
            if (Directory.Exists(Path.Combine(pathShared, comboGame.Text)) &&
                Directory.Exists(pathGame))
            {
                string[] fileList = Directory.GetFiles(Path.Combine(pathShared, comboGame.Text), "*.map", SearchOption.TopDirectoryOnly);
                bool found = false;
                if (showAllMessages)
                {
                    addLine("");
                    addLine("Checking new maps...");
                }

                if (fileList.Count() > 0)
                {
                    int i = 0;
                    foreach (string file in fileList)
                    {
                        if (file == cfgShared) continue;

                        i++;
                        string filename = Path.GetFileName(file);
                        string filenameImage = Path.GetFileNameWithoutExtension(file) + ".PNG";

                        string mapFileSource = file;
                        string mapFileDestination = Path.Combine(pathGame, filename);

                        DateTime mapFileSourceTime = DateTime.MinValue;
                        DateTime mapFileDestinationTime = DateTime.MinValue;

                        if (File.Exists(mapFileSource)) mapFileSourceTime = File.GetLastWriteTime(mapFileSource);
                        if (File.Exists(mapFileDestination)) mapFileDestinationTime = File.GetLastWriteTime(mapFileDestination);

                        string mapImageSource = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(filename)) + ".PNG";
                        string mapImageDestination = Path.Combine(pathGame, Path.GetFileNameWithoutExtension(filename)) + ".PNG";

                        DateTime mapImageSourceTime = DateTime.MinValue;
                        DateTime mapImageDestinationTime = DateTime.MinValue;

                        if (File.Exists(mapImageSource)) mapImageSourceTime = File.GetLastWriteTime(mapImageSource);
                        if (File.Exists(mapImageDestination)) mapImageDestinationTime = File.GetLastWriteTime(mapImageDestination);

                        if (File.Exists(mapFileSource) && Directory.Exists(pathGame))
                        {
                            if (File.Exists(mapFileDestination))
                            {
                                if (mapFileSourceTime != mapFileDestinationTime)
                                {
                                    File.Delete(mapFileDestination);
                                    File.Copy(mapFileSource, mapFileDestination);
                                    addLine("Map \"" + filename + "\" downloaded.");
                                    found = true;
                                }
                            }
                            else
                            {
                                File.Copy(mapFileSource, mapFileDestination);
                                addLine("Map \"" + filename + "\" downloaded.");
                                found = true;
                            }

                            if (File.Exists(mapImageSource))
                            {
                                if (File.Exists(mapImageDestination))
                                {
                                    if (mapImageSourceTime != mapImageDestinationTime)
                                    {
                                        File.Delete(mapImageDestination);
                                        File.Copy(mapImageSource, mapImageDestination);
                                        addLine("Image \"" + filenameImage + "\" downloaded.");
                                        found = true;
                                    }
                                }
                                else
                                {
                                    File.Copy(mapImageSource, mapImageDestination);
                                    addLine("Image \"" + filenameImage + "\" downloaded.");
                                    found = true;
                                }
                            }
                        }


                    }
                    string currentMap = "";
                    if (lstMaps.SelectedItems.Count > 0) currentMap = lstMaps.SelectedItems[0].Text;
                    readMaps();
                    picMapImage.Image = null;

                    foreach (ListViewItem map in lstMaps.Items)
                    {
                        if (map.Text == currentMap)
                        {
                            map.Selected = true;
                            lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
                        }
                    }
                }
                if (!found)
                {
                    if (showAllMessages) addLine("No new maps found.");
                }
            }
        }

        private void saveCapture()
        {
            if (Directory.Exists(pathDosBoxCapture))
            {
                string wildcard = "";
                if (comboGame.Text == "Duke Nukem 3D") wildcard = "duke*.png";
                if (comboGame.Text == "Shadow Warrior") wildcard = "sw*.png";
                string[] fileList = Directory.GetFiles(pathDosBoxCapture, wildcard, SearchOption.TopDirectoryOnly);

                if (fileList.Count() > 0)
                {
                    string captureFile = fileList[fileList.Count() - 1];
                    string mapName = lastMapPlayed;
                    string mapImage = Path.GetFileNameWithoutExtension(mapName) + ".PNG";

                    try
                    {
                        if (File.Exists(Path.Combine(pathGame, mapImage))) File.Delete(Path.Combine(pathGame, mapImage));
                        File.Copy(captureFile, Path.Combine(pathGame, mapImage));
                        addLine("Screen capture saved to \"" + mapImage + "\"");

                        if (File.Exists(Path.Combine(pathGame, mapImage)))
                        {
                            FileStream fs;
                            fs = new FileStream(Path.Combine(pathGame, mapImage), FileMode.Open, FileAccess.Read);
                            picMapImage.Image = Image.FromStream(fs);
                            fs.Close();
                        }
                        else picMapImage.Image = null;

                    }
                    catch { }

                    try
                    {
                        string pathDosBoxCaptureAll = Path.Combine(pathDosBoxCapture, "all");
                        if (!Directory.Exists(pathDosBoxCaptureAll)) Directory.CreateDirectory(pathDosBoxCaptureAll);

                        foreach (string file in fileList)
                        {
                            string filename = Path.GetFileName(file);
                            string destFile = Path.Combine(pathDosBoxCaptureAll, filename);
                            string fileDate = File.GetLastWriteTime(file).ToString(@"yyyy-MM-dd_hh-mm-ss_");
                            string destFileCustom = Path.Combine(pathDosBoxCaptureAll, fileDate + filename);

                            if (File.Exists(destFileCustom)) File.Delete(destFileCustom);
                            File.Move(file, destFileCustom);
                        }
                    }
                    catch { }

                }
            }
        }



    }
}
