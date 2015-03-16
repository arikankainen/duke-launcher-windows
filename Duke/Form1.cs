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

        private string modCOMSource;
        private string modGRPSource;
        private string modSCNSource;
        private string modSWXSource;

        private string modCOMDest;
        private string modGRPDest;
        private string modSCNDest;
        private string modSWXDest;

        private string exeGameCommit;
        private string cfgGameCommit;
        private string cfgGame;
        private string batGame;
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

        private Color timestampNotification = ColorTranslator.FromHtml("#396590");
        private Color timestampMessage = ColorTranslator.FromHtml("#aa3635");
        private Color separatorLine = ColorTranslator.FromHtml("#777777");

        Icon ico;
        Icon icoEmpty;
        Icon icoMessage;

        private List<string> msgList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            
            ico = this.Icon;
            icoEmpty = Properties.Resources.duke_empty;
            icoMessage = Properties.Resources.duke_message;

            this.Width = 906;
            this.Height = 654;

            drawLines();

            comboGame.Text = settings.LoadSetting("SelectedGame");
            if (comboGame.Text == "") comboGame.Text = "Duke Nukem 3D";

            comboPlayers.Text = settings.LoadSetting("Players");
            if (comboPlayers.Text == "") comboPlayers.Text = "Auto";

            comboGameOld = comboGame.Text;

            loadSettings();
            updatePaths();
            readMaps();
            listIp();

            deleteOldMessages();
            tryToCreateUserFile();
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerStartClient.Stop();
            timerGameEnded.Stop();
            timerContinueClient.Stop();
            timerCheckAll.Stop();

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
            readMaps();
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
            var result = MessageBox.Show("Are you sure you want to terminate all games?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes) File.WriteAllText(termFile, userName);

        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            startServer();
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
            if (!firstLoad)
            {
                checkSolo();
                loadDescription();
                loadLastPlayed();
                refreshOnline();
                deleteOldMessages();
                checkMessages();
                checkTerminated();

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (lstMaps.SelectedItems.Count > 0) i = lstMaps.SelectedItems[0].Index;

            readMaps();

            if (i > lstMaps.Items.Count - 1) lstMaps.Items[lstMaps.Items.Count - 1].Selected = true;
            else if (i <= lstMaps.Items.Count - 1) lstMaps.Items[i].Selected = true;

            if (lstMaps.SelectedItems.Count > 0) lstMaps.EnsureVisible(lstMaps.SelectedItems[0].Index);
        }




    }
}
