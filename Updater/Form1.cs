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

namespace Updater
{
    public partial class Form1 : Form
    {
        private Settings settings = new Settings();
        private string pathSharedConfig;
        private string appPath;
        private string appDir;
        private string exeShared;
        private string exeLocal;
        
        public Form1()
        {
            InitializeComponent();

            pathSharedConfig = settings.LoadSetting("SharedConfigFolder");
            appPath = Application.ExecutablePath;
            appDir = Path.GetDirectoryName(Application.ExecutablePath);
            exeShared = Path.Combine(pathSharedConfig, "Duke.exe");
            exeLocal = Path.Combine(appDir, "Duke.exe");

        }

        private void doUpdate()
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
                    label1.Text = "Updated version found!\r\n(v" + versionSharedString + ")";
                    btnUpdate.Enabled = true;
                    btnUpdate.Focus();
                }
                else label1.Text = "You are using the latest version.\r\n(v" + versionLocalString + ")";

            }
            else if (File.Exists(exeLocal))
            {
                var versionInfoLocal = FileVersionInfo.GetVersionInfo(exeLocal);
                string versionLocalString = versionInfoLocal.ProductVersion.Substring(0, 3);
                int versionLocal = Convert.ToInt32(versionInfoLocal.ProductVersion.Replace(".", ""));

                label1.Text = "You are using the latest version.\r\n(v" + versionLocalString + ")";
            }
            else
            {
                label1.Text = "Duke.exe not found!";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            doUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(exeLocal)) Process.Start(exeLocal);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Enabled = false;
                File.Delete(exeLocal);
                File.Copy(exeShared, exeLocal);
                label1.Text = "Update completed.";
            }
            catch
            {
                btnUpdate.Enabled = true;
                label1.Text = "Error occurred during update.";
            }

        }
    }
}
