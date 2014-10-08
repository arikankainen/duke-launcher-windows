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
        private string appName = "Duke Launcher v" + Application.ProductVersion;

        private string appPath;
        private string appDir;
        private string appFile;
        private string appCfg;

        private string exeDosBox;
        private string pathDosBox;
        private string pathDosBoxCapture;
        private string pathShared;
        private string cfgShared;

        private string exeGameCommit;
        private string cfgGameCommit;
        private string cfgGame;
        private string batGame;
        private string pathGame;

        private string exeShared;
        private string exeLocal;

        private string lastMapPlayed;

        private bool onceMinimized = false;
        private bool server = false;
        private bool client = false;
        private string timeOld;

        private bool copied = false;

        private string comboGameOld;

        private string playersSelected, mapSelected, ipSelected;

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
            string selectedGame = settings.LoadSetting("SelectedGame");
            if (selectedGame == "") selectedGame = "Duke Nukem 3D";
            comboGame.Text = selectedGame;
            comboGameOld = comboGame.Text;

            updatePaths();
            reselectGame();
            
            listIp();
            resizeColumns();

            selectItems();
            
            addLine(appName);
            //downloadNewMaps(false);
            checkUpdate();
            textBox1.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboGame.Text == "Duke Nukem 3D")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("DukeFolder", txtGamePath.Text);
                if (lstPlayers.SelectedItems.Count > 0) settings.SaveSetting("DukeNumPlayers", lstPlayers.SelectedItems[0].Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("DukeSelectedMap", lstMaps.SelectedItems[0].Text);
                settings.SaveSetting("SelectedGame", "Duke Nukem 3D");
            }

            if (comboGame.Text == "Shadow Warrior")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("SWFolder", txtGamePath.Text);
                if (lstPlayers.SelectedItems.Count > 0) settings.SaveSetting("SWNumPlayers", lstPlayers.SelectedItems[0].Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("SWSelectedMap", lstMaps.SelectedItems[0].Text);
                settings.SaveSetting("SelectedGame", "Shadow Warrior");
            }

            if (lstIp.SelectedItems.Count > 0) settings.SaveSetting("IP", lstIp.SelectedItems[0].Text);
            if (txtDosBoxPath.Text != "") settings.SaveSetting("DOSBoxFolder", txtDosBoxPath.Text);
            if (txtDosBoxCapturePath.Text != "") settings.SaveSetting("DOSBoxCaptureFolder", txtDosBoxCapturePath.Text);
            if (txtSharedConfig.Text != "") settings.SaveSetting("SharedConfigFolder", txtSharedConfig.Text);

            if (File.Exists(cfgShared)) File.Delete(cfgShared);
            if (txtPlayerName.Text != "") modifyName(txtPlayerName.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                                timer1.Stop();
                                comboGame.Text = game;
                                comboChanged();

                                disableAll();
                                client = true;

                                mapSelected = map;
                                playersSelected = players;
                                
                                if (lstMaps.SelectedItems.Count > 0)
                                {
                                    foreach (ListViewItem item in lstMaps.SelectedItems)
                                    {
                                        item.Selected = false;
                                    }
                                }
                                selectItems();

                                addLine("");
                                addLine("Player \"" + name + "\" started server (" + ip + ").");
                                addLine("Game \"" + game + "\" (" + players + " players).");
                                addLine("Map \"" + map + "\"");
                                addLine("");
                                addLine("Waiting for server to get ready.");

                                lastMapPlayed = map;

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
                using (StreamReader reader = File.OpenText(cfgShared))
                {
                    string time = reader.ReadLine();
                    string game = reader.ReadLine();
                    string name = reader.ReadLine();
                    string ip = reader.ReadLine();
                    string map = reader.ReadLine();
                    string players = reader.ReadLine();

                    timer3.Stop();

                    addLine("");
                    addLine("Game started.");

                    modifyPlayers(Convert.ToInt32(players));
                    modifyName(txtPlayerName.Text);

                    copyMap();

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
                //this.WindowState = FormWindowState.Normal;
                timer2.Stop();

                addLine("");
                addLine("Game ended.");
                TimeSpan duration = DateTime.Now - gameStarted;
                addLine("Duration: " + Convert.ToInt32(duration.TotalMinutes) + " mins, " + Convert.ToInt32(duration.Seconds) + " secs.");

                enableAll();
                if (server) deleteSharedConfig();
                if (copied) delMap();
                server = false;
                client = false;

                saveCapture();
                loadLastPlayed();
                
                timer1.Start();
            }
            else
            {
                if (!onceMinimized)
                {
                    onceMinimized = true;
                    //this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (lstMaps.SelectedItems.Count > 0 &&
                lstPlayers.SelectedItems.Count > 0 &&
                lstIp.SelectedItems.Count > 0 &&
                Directory.Exists(pathShared) &&
                Directory.Exists(pathGame) &&
                File.Exists(exeDosBox) &&
                txtPlayerName.Text != "")
            {
                disableAll();

                addLine("");
                addLine("Server started.");
                addLine("Game started.");

                int tries = 0;
                do
                {
                    tries++;
                } while (createSharedConfig() == false || tries < 50);

                copyMap();
                saveLastPlayed();

                modifyPlayers(Convert.ToInt32(lstPlayers.SelectedItems[0].Text));
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
                timer2.Start();
            }
            else checkChoices();
        }

        private void btnDukePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select game folder:";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtGamePath.Text = folder.SelectedPath;
            updatePaths();
            readMaps();
            resizeColumns();
            resizeColumns();

            addLine("");
            addLine("Game folder added.");

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
            resizeColumns();

            addLine("");
            addLine("DOSBox folder added.");
        }

        private void btnDosBoxCapturePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select DOSBox capture folder:\r\nUsually something like that: C:\\Users\\username\\AppData\\Local\\DOSBox\\capture";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtDosBoxCapturePath.Text = folder.SelectedPath;
            updatePaths();
            resizeColumns();

            addLine("");
            addLine("DOSBox capture folder added.");
        }

        private void btnSharedConfig_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select Shared folder:";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSharedConfig.Text = folder.SelectedPath;
            updatePaths();
            resizeColumns();

            addLine("");
            addLine("Shared folder added.");
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
                string mapImage = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text)) + ".PNG";
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

            loadDescription();
            loadLastPlayed();
        }

        private void picMapImage_DoubleClick(object sender, EventArgs e)
        {
            string mapImage = Path.Combine(Path.Combine(pathShared, comboGame.Text), Path.GetFileNameWithoutExtension(lstMaps.SelectedItems[0].Text)) + ".PNG";
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
            if (Directory.Exists(txtGamePath.Text)) Process.Start(txtGamePath.Text);
        }

        private void btnDosBoxOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDosBoxPath.Text)) Process.Start(@txtDosBoxPath.Text);
        }

        private void btnDosBoxCaptureOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDosBoxCapturePath.Text)) Process.Start(@txtDosBoxCapturePath.Text);
        }

        private void btnSharedOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSharedConfig.Text)) Process.Start(@txtSharedConfig.Text);
        }

        private void comboGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboChanged();
        }

        private void btnDeleteMaps_Click(object sender, EventArgs e)
        {
            if (lstMaps.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete selected maps?", "Confirm map deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes) deleteMaps();
            }

            else
            {
                addLine("");
                addLine("No maps selected.");
            }
        }

        private void btnSaveDescription_Click(object sender, EventArgs e)
        {
            saveDescription();
        }




    }
}
