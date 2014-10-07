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
        private void updatePaths()
        {
            appPath = Application.ExecutablePath;
            appDir = Path.GetDirectoryName(Application.ExecutablePath);
            appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath));
            appCfg = Path.Combine(appDir, "Settings.cfg");

            pathDuke3d = txtDukePath.Text;
            exeDosBox = Path.Combine(txtDosBoxPath.Text, "DOSBox.exe");
            pathSettings = txtSharedConfig.Text;

            exeCommit = Path.Combine(pathDuke3d, "commit.exe");
            cfgCommit = Path.Combine(pathDuke3d, "commit.dat");
            batDuke3d = Path.Combine(pathDuke3d, "dukiaine.bat");
            cfgSettings = Path.Combine(pathSettings, "dukiainen.txt");

            exeShared = Path.Combine(pathSettings, "Duke.exe");
            exeLocal = Path.Combine(appDir, "Duke.exe");

            if (Directory.Exists(pathDuke3d))
            {
                string[] cfgList = Directory.GetFiles(pathDuke3d, "*.cfg", SearchOption.TopDirectoryOnly);
                if (cfgList.Count() > 0) cfgDuke3d = Path.Combine(pathDuke3d, cfgList[0]);
            }

            if (Directory.Exists(pathDuke3d)) readMaps();
            if (File.Exists(cfgDuke3d)) txtPlayerName.Text = readName();

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
            string[] mapList = Directory.GetFiles(pathDuke3d, "*.map", SearchOption.TopDirectoryOnly);
            lstMaps.Items.Clear();

            foreach (string map in mapList)
            {
                lstMaps.Items.Add(Path.GetFileName(map).ToUpper());
            }
        }

        private void modifyPlayers(int num)
        {
            StringBuilder newFile = new StringBuilder();

            string[] file = File.ReadAllLines(@cfgCommit);

            foreach (string line in file)
            {
                if (line.Contains("NUMPLAYERS = "))
                {
                    string temp = "NUMPLAYERS = " + num.ToString();
                    newFile.Append(temp + "\r\n");
                }
                else newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@cfgCommit, newFile.ToString());
        }

        private void modifyName(string name)
        {
            StringBuilder newFile = new StringBuilder();

            string[] file = File.ReadAllLines(@cfgDuke3d);

            foreach (string line in file)
            {
                if (line.Contains("PlayerName = "))
                {
                    string temp = "PlayerName = \"" + name + "\"";
                    newFile.Append(temp + "\r\n");
                }
                else newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@cfgDuke3d, newFile.ToString());
        }

        private string readName()
        {
            StringBuilder newFile = new StringBuilder();

            string[] file = File.ReadAllLines(@cfgDuke3d);
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
                using (StreamWriter writer = File.CreateText(cfgSettings))
                {
                    writer.WriteLine(DateTime.Now.ToString(@"HH:mm:ss"));
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
                if (File.Exists(cfgSettings)) File.Delete(cfgSettings);
                server = false;
            }
            catch { }

            if (File.Exists(cfgSettings)) deleteSharedConfig();
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
            //textBox1.Text = "";
            addLine("");
            addLine("Can't launch Duke:");
            if (lstMaps.SelectedItems.Count == 0) addLine("Map not selected.");
            if (lstPlayers.SelectedItems.Count == 0) addLine("Number of players not selected.");
            if (lstIp.SelectedItems.Count == 0) addLine("IP address not selected.");
            if (txtPlayerName.Text == "") addLine("Player name not defined.");
            if (!Directory.Exists(pathDuke3d)) addLine("Path for Duke3D not defined.");
            if (!File.Exists(exeDosBox)) addLine("Path for DOSBox not defined.");
            if (!Directory.Exists(pathSettings)) addLine("Path for shared folder not defined.");
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
            txtDukePath.Enabled = false;
            txtSharedConfig.Enabled = false;
            txtPlayerName.Enabled = false;
            btnDosBoxPath.Enabled = false;
            btnDukePath.Enabled = false;
            btnSharedConfig.Enabled = false;
            btnUploadMap.Enabled = false;
            btnDownloadMaps.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void enableAll()
        {
            btnLaunch.Enabled = true;
            lstMaps.Enabled = true;
            lstPlayers.Enabled = true;
            lstIp.Enabled = true;
            txtDosBoxPath.Enabled = true;
            txtDukePath.Enabled = true;
            txtSharedConfig.Enabled = true;
            txtPlayerName.Enabled = true;
            btnDosBoxPath.Enabled = true;
            btnDukePath.Enabled = true;
            btnSharedConfig.Enabled = true;
            btnUploadMap.Enabled = true;
            btnDownloadMaps.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void centerForm()
        {
            Screen screen = Screen.FromControl(this);

            this.WindowState = FormWindowState.Normal;

            this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
            //this.Left = screen.WorkingArea.Right - this.Width - this.Top;
            this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
        }

        private void downloadNewMaps(bool showAllMessages)
        {
            if (Directory.Exists(pathSettings) &&
                Directory.Exists(pathDuke3d))
            {
                string[] fileList = Directory.GetFiles(pathSettings, "*.map", SearchOption.TopDirectoryOnly);
                bool found = false;
                if (showAllMessages) addLine("");

                if (fileList.Count() > 0)
                {
                    int i = 0;
                    foreach (string file in fileList)
                    {
                        if (file == cfgSettings) continue;

                        i++;
                        string filename = Path.GetFileName(file);
                        string filenameImage = Path.GetFileNameWithoutExtension(file) + ".PNG";

                        string mapFileSource = file;
                        string mapFileDestination = Path.Combine(pathDuke3d, filename);

                        DateTime mapFileSourceTime = DateTime.MinValue;
                        DateTime mapFileDestinationTime = DateTime.MinValue;

                        if (File.Exists(mapFileSource)) mapFileSourceTime = File.GetLastWriteTime(mapFileSource);
                        if (File.Exists(mapFileDestination)) mapFileDestinationTime = File.GetLastWriteTime(mapFileDestination);

                        string mapImageSource = Path.Combine(pathSettings, Path.GetFileNameWithoutExtension(filename)) + ".PNG";
                        string mapImageDestination = Path.Combine(pathDuke3d, Path.GetFileNameWithoutExtension(filename)) + ".PNG";

                        DateTime mapImageSourceTime = DateTime.MinValue;
                        DateTime mapImageDestinationTime = DateTime.MinValue;

                        if (File.Exists(mapImageSource)) mapImageSourceTime = File.GetLastWriteTime(mapImageSource);
                        if (File.Exists(mapImageDestination)) mapImageDestinationTime = File.GetLastWriteTime(mapImageDestination);

                        if (File.Exists(mapFileSource) && Directory.Exists(pathDuke3d))
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




    }
}
