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
    public partial class Form1 : Form, IMessageFilter
    {
        private string appName = "Duke Launcher v1.1";

        private string appPath;
        private string appDir;
        private string appFile;
        private string appCfg;

        private string pathDuke3d;
        private string exeDosBox;
        private string exeCommit;
        private string cfgCommit;
        private string cfgDuke3d;
        private string batDuke3d;
        private string pathSettings;
        private string cfgSettings;

        private string exeShared;
        private string exeLocal;

        private bool onceMinimized = false;
        private bool server = false;
        private bool client = false;
        private string timeOld;

        private Settings settings = new Settings();
        private Process process;

        private DateTime gameStarted;

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            centerForm();
        }

        // ************************************ EVENTS

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtDukePath.Text = settings.LoadSetting("DukeFolder");
            txtDosBoxPath.Text = settings.LoadSetting("DOSBoxFolder");
            txtSharedConfig.Text = settings.LoadSetting("SharedConfigFolder");
            string players = settings.LoadSetting("NumPlayers");
            string map = settings.LoadSetting("SelectedMap");
            string ip = settings.LoadSetting("IP");

            updatePaths();

            listIp();
            resizeColumns();

            foreach (ListViewItem item in lstMaps.Items)
            {
                if (map == item.Text)
                {
                    item.Selected = true;
                    lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
                }
            }

            foreach (ListViewItem item in lstPlayers.Items)
            {
                if (players == item.Text) item.Selected = true;
            }

            foreach (ListViewItem item in lstIp.Items)
            {
                if (ip == item.Text) item.Selected = true;
            }

            addLine(appName);
            downloadNewMaps(false);
            checkUpdate();
            textBox1.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtDukePath.Text != "") settings.SaveSetting("DukeFolder", txtDukePath.Text);
            if (txtDosBoxPath.Text != "") settings.SaveSetting("DOSBoxFolder", txtDosBoxPath.Text);
            if (txtSharedConfig.Text != "") settings.SaveSetting("SharedConfigFolder", txtSharedConfig.Text);
            if (lstPlayers.SelectedItems.Count > 0) settings.SaveSetting("NumPlayers", lstPlayers.SelectedItems[0].Text);
            if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("SelectedMap", lstMaps.SelectedItems[0].Text);
            if (lstIp.SelectedItems.Count > 0) settings.SaveSetting("IP", lstIp.SelectedItems[0].Text);

            if (File.Exists(cfgSettings)) File.Delete(cfgSettings);
            if (txtPlayerName.Text != "") modifyName(txtPlayerName.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!server && !client)
            {
                if (File.Exists(cfgSettings) &&
                  Directory.Exists(pathDuke3d) &&
                  File.Exists(exeDosBox) &&
                  txtPlayerName.Text != "")
                {
                    try
                    {
                        using (StreamReader reader = File.OpenText(cfgSettings))
                        {
                            string time = reader.ReadLine();
                            string name = reader.ReadLine();
                            string ip = reader.ReadLine();
                            string map = reader.ReadLine();
                            string players = reader.ReadLine();

                            if (timeOld != time)
                            {
                                timer1.Stop();
                                disableAll();
                                client = true;

                                addLine("");
                                addLine("Player \"" + name + "\" started server (" + ip + ").");
                                addLine("Map \"" + map + "\" (" + players + " players).");
                                timer3.Start();
                            }
                            timeOld = time;
                        }
                    }
                    catch { }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = File.OpenText(cfgSettings))
                {
                    string time = reader.ReadLine();
                    string name = reader.ReadLine();
                    string ip = reader.ReadLine();
                    string map = reader.ReadLine();
                    string players = reader.ReadLine();

                    timer3.Stop();

                    addLine("");
                    addLine("Launching Duke...");

                    modifyPlayers(Convert.ToInt32(players));
                    modifyName(txtPlayerName.Text);

                    using (StreamWriter writer = File.CreateText(batDuke3d))
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
                    startInfo.Arguments = batDuke3d + " -noconsole";
                    process = Process.Start(startInfo);

                    gameStarted = DateTime.Now;
                    timer2.Start();
                }
            }
            catch { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (process.HasExited)
            {
                onceMinimized = false;
                this.WindowState = FormWindowState.Normal;
                timer2.Stop();

                addLine("");
                addLine("Game ended.");
                TimeSpan duration = DateTime.Now - gameStarted;
                addLine("Duration: " + Convert.ToInt32(duration.TotalMinutes) + " mins, " + Convert.ToInt32(duration.Seconds) + " secs.");

                enableAll();
                if (server) deleteSharedConfig();
                server = false;
                client = false;
                timer1.Start();
            }
            else
            {
                if (!onceMinimized)
                {
                    onceMinimized = true;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (lstMaps.SelectedItems.Count > 0 &&
                lstPlayers.SelectedItems.Count > 0 &&
                lstIp.SelectedItems.Count > 0 &&
                Directory.Exists(pathSettings) &&
                Directory.Exists(pathDuke3d) &&
                File.Exists(exeDosBox) &&
                txtPlayerName.Text != "")
            {
                disableAll();

                addLine("");
                addLine("Server started.");
                addLine("Launching Duke...");

                int tries = 0;
                do
                {
                    tries++;
                } while (createSharedConfig() == false || tries < 50);

                modifyPlayers(Convert.ToInt32(lstPlayers.SelectedItems[0].Text));
                modifyName(txtPlayerName.Text);

                using (StreamWriter writer = File.CreateText(batDuke3d))
                {
                    writer.WriteLine("ipxnet startserver");
                    writer.WriteLine("commit.exe -map " + lstMaps.SelectedItems[0].Text);
                    writer.WriteLine("exit");
                }

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = exeDosBox;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = batDuke3d + " -noconsole";
                process = Process.Start(startInfo);

                gameStarted = DateTime.Now;
                timer2.Start();
            }
            else checkChoices();
        }

        private void btnDukePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select Duke3D folder:";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtDukePath.Text = folder.SelectedPath;
            updatePaths();
            if (Directory.Exists(pathDuke3d)) readMaps();
            resizeColumns();

            addLine("");
            addLine("Path for Duke added.");

        }

        private void btnDosBoxPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select DOSBox folder:";
            if (Directory.Exists("C:\\Program Files (x86)\\DOSBox-0.74") && txtDosBoxPath.Text == "") folder.SelectedPath = "C:\\Program Files (x86)\\DOSBox-0.74";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtDosBoxPath.Text = folder.SelectedPath;
            updatePaths();

            addLine("");
            addLine("Path for DOSBox added.");
        }

        private void btnSharedConfig_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select Shared folder:";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSharedConfig.Text = folder.SelectedPath;
            updatePaths();

            addLine("");
            addLine("Path for shared folder added.");
        }

        private void txtPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode > Keys.D0 && e.KeyCode < Keys.Z) ||
                e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Space ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Delete)
            {
                // do nothing 
            }
            else e.SuppressKeyPress = true;
        }

        private void lstMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMaps.SelectedItems.Count > 0)
            {
                string mapImage = Path.Combine(pathDuke3d, Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text)) + ".png";
                if (File.Exists(mapImage))
                {
                    FileStream fs;
                    fs = new FileStream(mapImage, FileMode.Open, FileAccess.Read);
                    picMapImage.Image = Image.FromStream(fs);
                    fs.Close();
                }
                else picMapImage.Image = null;
            }
            else picMapImage.Image = null;
        }

        private void btnUploadMap_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathSettings) &&
                Directory.Exists(pathDuke3d))
            {
                addLine("");
                if (lstMaps.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem map in lstMaps.SelectedItems)
                    {
                        string mapFileSource = Path.Combine(pathDuke3d, map.Text);
                        string mapFileDestination = Path.Combine(pathSettings, map.Text);

                        string mapImageSource = Path.Combine(pathDuke3d, Path.GetFileNameWithoutExtension(map.Text)) + ".PNG";
                        string mapImageDestination = Path.Combine(pathSettings, Path.GetFileNameWithoutExtension(map.Text)) + ".PNG";

                        if (File.Exists(mapFileSource) && Directory.Exists(pathSettings))
                        {
                            if (File.Exists(mapFileDestination)) File.Delete(mapFileDestination);
                            File.Copy(mapFileSource, mapFileDestination);
                            addLine("Map \"" + map.Text + "\" uploaded.");

                            if (File.Exists(mapImageSource))
                            {
                                if (File.Exists(mapImageDestination)) File.Delete(mapImageDestination);
                                File.Copy(mapImageSource, mapImageDestination);
                                string filenameImage = Path.GetFileNameWithoutExtension(map.Text) + ".PNG";
                                addLine("Image \"" + filenameImage + "\" uploaded.");
                            }
                        }
                    }
                }
                else
                {
                    addLine("No maps selected.");
                }
            }
        }

        private void btnDownloadMaps_Click(object sender, EventArgs e)
        {
            downloadNewMaps(true);
        }

        private void picMapImage_DoubleClick(object sender, EventArgs e)
        {
            string mapImage = Path.Combine(pathDuke3d, Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text)) + ".PNG";
            if (File.Exists(mapImage)) Process.Start(@mapImage);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string exeUpdate = Path.Combine(appDir, "Updater.exe");
            if (File.Exists(exeUpdate))
            {
                Process.Start(exeUpdate);
                this.Close();
            }
        }
 
        private void btnDukeOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDukePath.Text)) Process.Start(@txtDukePath.Text);
        }

        private void btnDosBoxOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDosBoxPath.Text)) Process.Start(@txtDosBoxPath.Text);
        }

        private void btnSharedOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSharedConfig.Text)) Process.Start(@txtSharedConfig.Text);
        }

    }
}
