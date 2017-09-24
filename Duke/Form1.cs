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
        private Random rnd = new Random();
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

        private string modCOMSource;
        private string modGRPSource;
        private string modSCNSource;
        private string modSWXSource;

        private string modCOMDest;
        private string modGRPDest;
        private string modSCNDest;
        private string modSWXDest;

        private string exeGameSetup;
        private string exeGameCommit;
        private string cfgGameCommit;
        private string cfgGame;
        private string batGame;
        private string batSetup;
        private string pathGame;

        private string exeShared;
        private string exeLocal;
        private string exeSharedUpdater;
        private string exeLocalUpdater;

        private string lastMapPlayed;

        private bool server = false;
        private bool client = false;
        private string timeOld;

        private string userName;
        private string userFile;
        private string termFile;
        private string soloFile;

        private int numOfPlayers;

        private bool copied = false;

        private string comboGameOld;

        private string playersSelected, mapSelected, ipSelected;

        private Settings settings = new Settings();
        private Process process;

        private DateTime gameStarted;

        private string[] online;
        private string[] onlineOld = {""};

        private string[] messages;
        private string[] messagesOld = { "" };

        private bool firstLoad = true;
        private bool newMessage = false;
        private bool newMessageBlinkStarted = false;
        private bool newMessageState = false;

        private bool gameOn = false;

        private bool lastIsMessage = false;
        private bool soloMode = false;

        private int width;
        private int height;
        private bool maximized = false;
        private bool sizeLoaded = false;

        private Color timestampNotification = ColorTranslator.FromHtml("#396590");
        private Color timestampMessage = ColorTranslator.FromHtml("#aa3635");
        private Color separatorLine = ColorTranslator.FromHtml("#777777");
        private Color colorNotExist = ColorTranslator.FromHtml("#ffcccc");

        private Icon ico;
        private Icon icoEmpty;
        private Icon icoMessage;

        private int sortColumn;
        private int timerDOSBoxMoved;

        private List<string> msgList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            ico = this.Icon;
            icoEmpty = Properties.Resources.duke_empty;
            icoMessage = Properties.Resources.duke_message;

            //this.Width = 906;
            //this.Height = 654;

            drawLines();

            txtUserName.Text = settings.LoadSetting("UserName");

            comboGame.Text = settings.LoadSetting("SelectedGame");
            if (comboGame.Text == "") comboGame.Text = "Duke Nukem 3D";

            comboPlayers.Text = settings.LoadSetting("Players");
            if (comboPlayers.Text == "") comboPlayers.Text = "Auto";

            checkFullScreen.Checked = settings.LoadSetting("FullScreen", "bool", "false");

            comboGameOld = comboGame.Text;

            loadSettings();
            updatePaths();
            readMaps();
            listIp();
            checkRandomChecked();

            if (Directory.Exists(pathShared))
            {
                deleteOldMessages();
                tryToCreateUserFile();
            }

            width = settings.LoadSetting("Width", "int", "1100");
            height = settings.LoadSetting("Height", "int", "750");
            maximized = settings.LoadSetting("Maximized", "bool", "false");

            if (width < 700 || height < 550)
            {
                width = 1100;
                height = 750;
            }

            Screen screen = Screen.FromPoint(Cursor.Position);
            if (width > screen.WorkingArea.Size.Width) width = screen.WorkingArea.Size.Width;
            if (height > screen.WorkingArea.Size.Height) height = screen.WorkingArea.Size.Height;

            this.Width = width;
            this.Height = height;

            this.Left = screen.WorkingArea.Left + (screen.WorkingArea.Size.Width / 2) - (this.Width / 2);
            this.Top = screen.WorkingArea.Top + (screen.WorkingArea.Size.Height / 2) - (this.Height / 2) - 1;

            if (maximized) this.WindowState = FormWindowState.Maximized;

        }

        // ************************************ EVENTS

        private void Form1_Shown(object sender, EventArgs e)
        {

            selectItems();
            resizeColumns();
            readName();

            addLine(appName);
            checkUpdate();
            txtSendMessage.Focus();

            firstLoad = false;
            sizeLoaded = true;

            string sOrd = settings.LoadSetting("MapsSortOrder", "string", "None");
            sortColumn = settings.LoadSetting("MapsSortColumn", "int", "0");

            SortOrder order;
            if (sOrd == "Ascending") order = SortOrder.Ascending;
            else if (sOrd == "Descending") order = SortOrder.Descending;
            else order = SortOrder.None;

            lstMaps.Sorting = order;
            lstMaps.SetSortIcon(sortColumn, order);
            lstMaps.Sort();
            if (sOrd != "None") lstMaps.ListViewItemSorter = new ListViewItemComparer(sortColumn, lstMaps.Sorting);

            if (lstMaps.SelectedItems.Count > 0) lstMaps.SelectedItems[0].EnsureVisible();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerStartClient.Stop();
            timerGameEnded.Stop();
            timerContinueClient.Stop();
            timerCheckAll.Stop();

            settings.SaveSetting("Width", width.ToString());
            settings.SaveSetting("Height", height.ToString());
            settings.SaveSetting("FullScreen", checkFullScreen.Checked.ToString());
            settings.SaveSetting("MapsSortOrder", lstMaps.Sorting.ToString());
            settings.SaveSetting("MapsSortColumn", sortColumn.ToString());

            if (this.WindowState == FormWindowState.Maximized) settings.SaveSetting("Maximized", "True");
            else settings.SaveSetting("Maximized", "False");

            settings.SaveSetting("RandomChecked", checkRandom.Checked.ToString());
            settings.SaveSetting("RandomNumber", numericRandom.Value.ToString());

            settings.SaveSetting("UserName", txtUserName.Text);

            if (comboGame.Text == "Duke Nukem 3D")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("DukeFolder", txtGamePath.Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("DukeSelectedMap", lstMaps.SelectedItems[0].Text);
                settings.SaveSetting("SelectedGame", "Duke Nukem 3D");
            }

            if (comboGame.Text == "Shadow Warrior")
            {
                if (txtGamePath.Text != "") settings.SaveSetting("SWFolder", txtGamePath.Text);
                if (lstMaps.SelectedItems.Count > 0) settings.SaveSetting("SWSelectedMap", lstMaps.SelectedItems[0].Text);
                settings.SaveSetting("SelectedGame", "Shadow Warrior");
            }

            settings.SaveSetting("Players", comboPlayers.Text);
            if (lstIp.SelectedItems.Count > 0) settings.SaveSetting("IP", lstIp.SelectedItems[0].Text);
            if (txtDosBoxPath.Text != "") settings.SaveSetting("DOSBoxFolder", txtDosBoxPath.Text);
            if (txtDosBoxCapturePath.Text != "") settings.SaveSetting("DOSBoxCaptureFolder", txtDosBoxCapturePath.Text);
            if (txtSharedConfig.Text != "") settings.SaveSetting("SharedConfigFolder", txtSharedConfig.Text);

            if (txtPlayerName.Text != "") modifyName(txtPlayerName.Text);

            tryToDelete(cfgShared);
            tryToDelete(userFile);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && sizeLoaded)
            {
                if (this.Width > 0) width = this.Width;
                if (this.Height > 0) height = this.Height;
            }
        }

        private void btnDukePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select game folder:";
            if (Directory.Exists(txtGamePath.Text)) folder.SelectedPath = txtGamePath.Text;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtGamePath.Text = folder.SelectedPath;
            updatePaths();
            readMaps();
            resizeColumns();
            resizeColumns();
        }

        private void btnDosBoxPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select DOSBox folder:";
            if (Directory.Exists(txtDosBoxPath.Text)) folder.SelectedPath = txtDosBoxPath.Text;
            else if (Directory.Exists(@"C:\Program Files (x86)\DOSBox-0.74") && txtDosBoxPath.Text == "") folder.SelectedPath = @"C:\Program Files (x86)\DOSBox-0.74";

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtDosBoxPath.Text = folder.SelectedPath;
            updatePaths();
            resizeColumns();
        }

        private void btnDosBoxCapturePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select DOSBox capture folder:\r\nUsually something like that: C:\\Users\\username\\AppData\\Local\\DOSBox\\capture";
            if (Directory.Exists(txtDosBoxCapturePath.Text)) folder.SelectedPath = txtDosBoxCapturePath.Text;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtDosBoxCapturePath.Text = folder.SelectedPath;
            updatePaths();
            resizeColumns();
        }

        private void btnSharedConfig_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.ShowNewFolderButton = false;
            folder.Description = "Select Shared folder:";
            if (Directory.Exists(txtSharedConfig.Text)) folder.SelectedPath = txtSharedConfig.Text;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSharedConfig.Text = folder.SelectedPath;
            updatePaths();
            readMaps();
            resizeColumns();
        }

        private void txtGamePath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtGamePath.Text)) txtGamePath.BackColor = Color.White;
            else txtGamePath.BackColor = colorNotExist;
        }

        private void txtDosBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDosBoxPath.Text)) txtDosBoxPath.BackColor = Color.White;
            else txtDosBoxPath.BackColor = colorNotExist;
        }

        private void txtDosBoxCapturePath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDosBoxCapturePath.Text)) txtDosBoxCapturePath.BackColor = Color.White;
            else txtDosBoxCapturePath.BackColor = colorNotExist;
        }

        private void txtSharedConfig_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSharedConfig.Text)) txtSharedConfig.BackColor = Color.White;
            else txtSharedConfig.BackColor = colorNotExist;
        }

        private void txtPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.Z) ||
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
            if (!firstLoad) comboChanged();
        }

        private void btnDeleteMaps_Click(object sender, EventArgs e)
        {
            if (lstMaps.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete selected maps?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
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

        private void comboPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPlayers.Text == "Auto") numOfPlayers = 0;
            else numOfPlayers = Convert.ToInt32(comboPlayers.Text);
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text != "" && Directory.Exists(pathShared))
            {
                string fileName = "msg_" + DateTime.Now.ToString(@"yyyy-MM-dd_HH-mm-ss-fff_") + userName;
                string fileFullPath = Path.Combine(pathShared, fileName);
                
                File.WriteAllText(fileFullPath, txtSendMessage.Text);
                
                txtSendMessage.Text = "";
            }
        }

        private void txtSendMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSendMessage.PerformClick();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeColumns();
        }

        private void btnTerminate_Click(object sendePcbr, EventArgs e)
        {
            //var result = MessageBox.Show("Are you sure you want to terminate all games?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (result == DialogResult.Yes) File.WriteAllText(termFile, userName);
            File.WriteAllText(termFile, userName);
            addLine("");
            addLine("Game terminated.");
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (btnLaunch.Text == "Launch game")
            {
                if (comboPlayers.Text == "Auto") startServer();
                else if (!soloMode && Convert.ToInt32(comboPlayers.Text) > lstOnline.Items.Count) waitPlayers();
                else startServer();
            }

            else
            {
                timerWaitPlayers.Stop();
                btnLaunch.Text = "Launch game";
            }
        }

        private void timerStartClient_Tick(object sender, EventArgs e)
        {
            if (!soloMode) startClient();
        }

        private void timerContinueClient_Tick(object sender, EventArgs e)
        {
            if (!soloMode) continueClient();
        }

        private void timerGameEnded_Tick(object sender, EventArgs e) 
        { 
            gameEnded(); 
        }

        private void timerCheckAll_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(pathShared))
            {
                if (!firstLoad)
                {
                    checkSolo();
                    loadDescription();
                    if (!gameOn) loadLastPlayed();
                    refreshOnline();
                    deleteOldMessages();
                    checkMessages();
                    checkTerminated();

                    /*
                    if (this.ContainsFocus)
                    {
                        newMessage = false;
                    }

                    if (!this.ContainsFocus && newMessage)
                    {
                        timerNewMessage.Start();
                        newMessage = false;
                        newMessageBlinkStarted = true;
                    }

                    if (this.ContainsFocus && newMessageBlinkStarted)
                    {
                        timerNewMessage.Stop();
                        newMessageBlinkStarted = false;
                        newMessageState = false;
                        this.Icon = ico;
                    }
                    */
                }
            }
        }

        private void timerNewMessage_Tick(object sender, EventArgs e)
        {
            if (newMessageState)
            {
                this.Icon = ico;
                newMessageState = false;
            }
            else
            {
                this.Icon = icoMessage;
                newMessageState = true;
            }
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            if (!soloMode)
            {
                File.WriteAllText(soloFile, "");
            }
            else
            {
                tryToDelete(soloFile);
            }
        }

        private void lstIp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnChangeUserName_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathShared))
            {
                tryToDelete(cfgShared);
                tryToDelete(userFile);
                deleteOldMessages();

                updatePaths();

                tryToCreateUserFile();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnChangeUserName.PerformClick();
        }

        private void lstMaps_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstMaps.BeginUpdate();

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lstMaps.Sorting = SortOrder.Ascending;
                lstMaps.SetSortIcon(e.Column, SortOrder.Ascending);
            }

            else
            {
                if (lstMaps.Sorting == SortOrder.Ascending)
                {
                    lstMaps.Sorting = SortOrder.Descending;
                    lstMaps.SetSortIcon(e.Column, SortOrder.Descending);
                }

                else
                {
                    lstMaps.Sorting = SortOrder.Ascending;
                    lstMaps.SetSortIcon(e.Column, SortOrder.Ascending);
                }
            }

            lstMaps.Sort();
            lstMaps.ListViewItemSorter = new ListViewItemComparer(e.Column, lstMaps.Sorting);

            lstMaps.SelectedItems[0].EnsureVisible();

            lstMaps.EndUpdate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string mapName = null;
            if (lstMaps.SelectedItems.Count > 0) mapName = lstMaps.SelectedItems[0].Text;
            //MessageBox.Show(mapName);

            //int i = 0;
            //if (lstMaps.SelectedItems.Count > 0) i = lstMaps.SelectedItems[0].Index;

            readMaps();

            //if (i > lstMaps.Items.Count - 1) lstMaps.Items[lstMaps.Items.Count - 1].Selected = true;
            //else if (i <= lstMaps.Items.Count - 1) lstMaps.Items[i].Selected = true;

            if (mapName != null)
            {
                foreach (ListViewItem item in lstMaps.Items)
                {
                    if (item.Text == mapName) item.Selected = true;
                    else item.Selected = false;
                }

                if (lstMaps.SelectedItems.Count > 0) lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
            }
        }

        private void timerWaitPlayers_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboPlayers.Text) == lstOnline.Items.Count)
            {
                waitPlayersStop();
                startServer();
            }
        }

        private void checkRandom_CheckedChanged(object sender, EventArgs e)
        {
            checkRandomChecked();
        }

        private void checkRandomChecked()
        {
            if (checkRandom.Checked) numericRandom.Enabled = true;
            else numericRandom.Enabled = false;
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = File.CreateText(batSetup))
            {
                writer.WriteLine("setup");
                writer.WriteLine("exit");
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = exeDosBox;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = batSetup + " -noconsole";
            process = Process.Start(startInfo);

            timerDOSBoxMoved = 0;
            timerDOSBox.Start();
        }

        private void timerDOSBox_Tick(object sender, EventArgs e)
        {
            timerDOSBoxMoved++;
            OpenWindows.centerDOSBox(this);
            
            if (timerDOSBoxMoved == 20) timerDOSBox.Stop();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (lstMaps.Items.Count > 1)
            {
                if (lstMaps.SelectedItems.Count == 0) lstMaps.Items[0].Selected = true;
                int selectedOld = lstMaps.SelectedItems[0].Index;
                int selected = selectedOld;

                if (checkRandom.Checked && numericRandom.Value > 1)
                {
                    while (selectedOld == selected)
                    {
                        getRandom();
                        selected = lstMaps.SelectedItems[0].Index;
                    }
                }
                else getRandom();
            }
        }

        private void getRandom()
        {
            int count = lstMaps.Items.Count;
            int rndCount;

            if (checkRandom.Checked) rndCount = (int)numericRandom.Value;
            else rndCount = count;

            if (rndCount > count) rndCount = count;

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (ListViewItem item in lstMaps.Items)
            {
                dict.Add(item.Text, item.SubItems[1].Text);
            }

            var dictSorted = dict.OrderBy(x => x.Value);

            int rndSelected = rnd.Next(rndCount);

            string selectedMap = dictSorted.ElementAt(rndSelected).Key;
            string selectedDate = dictSorted.ElementAt(rndSelected).Value;

            foreach (ListViewItem item in lstMaps.Items)
            {
                if (item.Text == selectedMap)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }

                else item.Selected = false;
            }
        }




    }
}
