namespace Duke
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("5");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("6");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("7");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("8");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGamePath = new System.Windows.Forms.Button();
            this.txtDosBoxPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDosBoxPath = new System.Windows.Forms.Button();
            this.txtSharedConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSharedConfig = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.picMapImage = new System.Windows.Forms.PictureBox();
            this.btnUploadMap = new System.Windows.Forms.Button();
            this.btnDownloadMaps = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGameOpen = new System.Windows.Forms.Button();
            this.btnDosBoxOpen = new System.Windows.Forms.Button();
            this.btnSharedOpen = new System.Windows.Forms.Button();
            this.comboGame = new System.Windows.Forms.ComboBox();
            this.btnDosBoxCaptureOpen = new System.Windows.Forms.Button();
            this.btnDosBoxCapturePath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDosBoxCapturePath = new System.Windows.Forms.TextBox();
            this.lstIp = new Duke.VisualStylesListView();
            this.clmIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAdapter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstPlayers = new Duke.VisualStylesListView();
            this.clmPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstMaps = new Duke.VisualStylesListView();
            this.clmMaps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.picMapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.btnLaunch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(559, 394);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(125, 96);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch!";
            this.btnLaunch.UseMnemonic = false;
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.Location = new System.Drawing.Point(191, 193);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(493, 190);
            this.textBox1.TabIndex = 3;
            // 
            // txtGamePath
            // 
            this.txtGamePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGamePath.Location = new System.Drawing.Point(137, 519);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.ReadOnly = true;
            this.txtGamePath.Size = new System.Drawing.Size(360, 20);
            this.txtGamePath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Game folder:";
            // 
            // btnGamePath
            // 
            this.btnGamePath.Location = new System.Drawing.Point(510, 517);
            this.btnGamePath.Name = "btnGamePath";
            this.btnGamePath.Size = new System.Drawing.Size(90, 23);
            this.btnGamePath.TabIndex = 9;
            this.btnGamePath.Text = "Select folder...";
            this.btnGamePath.UseVisualStyleBackColor = true;
            this.btnGamePath.Click += new System.EventHandler(this.btnDukePath_Click);
            // 
            // txtDosBoxPath
            // 
            this.txtDosBoxPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxPath.Location = new System.Drawing.Point(137, 552);
            this.txtDosBoxPath.Name = "txtDosBoxPath";
            this.txtDosBoxPath.ReadOnly = true;
            this.txtDosBoxPath.Size = new System.Drawing.Size(360, 20);
            this.txtDosBoxPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "DOSBox folder:";
            // 
            // btnDosBoxPath
            // 
            this.btnDosBoxPath.Location = new System.Drawing.Point(510, 550);
            this.btnDosBoxPath.Name = "btnDosBoxPath";
            this.btnDosBoxPath.Size = new System.Drawing.Size(90, 23);
            this.btnDosBoxPath.TabIndex = 12;
            this.btnDosBoxPath.Text = "Select folder...";
            this.btnDosBoxPath.UseVisualStyleBackColor = true;
            this.btnDosBoxPath.Click += new System.EventHandler(this.btnDosBoxPath_Click);
            // 
            // txtSharedConfig
            // 
            this.txtSharedConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSharedConfig.Location = new System.Drawing.Point(137, 618);
            this.txtSharedConfig.Name = "txtSharedConfig";
            this.txtSharedConfig.ReadOnly = true;
            this.txtSharedConfig.Size = new System.Drawing.Size(360, 20);
            this.txtSharedConfig.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 621);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Shared folder:";
            // 
            // btnSharedConfig
            // 
            this.btnSharedConfig.Location = new System.Drawing.Point(510, 616);
            this.btnSharedConfig.Name = "btnSharedConfig";
            this.btnSharedConfig.Size = new System.Drawing.Size(90, 23);
            this.btnSharedConfig.TabIndex = 15;
            this.btnSharedConfig.Text = "Select folder...";
            this.btnSharedConfig.UseVisualStyleBackColor = true;
            this.btnSharedConfig.Click += new System.EventHandler(this.btnSharedConfig_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 503);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 1);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(0, 504);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 1);
            this.panel2.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Player name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(449, 428);
            this.txtPlayerName.MaxLength = 10;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(97, 20);
            this.txtPlayerName.TabIndex = 19;
            this.txtPlayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlayerName_KeyDown);
            // 
            // timer3
            // 
            this.timer3.Interval = 5000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // picMapImage
            // 
            this.picMapImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picMapImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMapImage.Location = new System.Drawing.Point(12, 363);
            this.picMapImage.Name = "picMapImage";
            this.picMapImage.Size = new System.Drawing.Size(167, 127);
            this.picMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapImage.TabIndex = 20;
            this.picMapImage.TabStop = false;
            this.picMapImage.DoubleClick += new System.EventHandler(this.picMapImage_DoubleClick);
            // 
            // btnUploadMap
            // 
            this.btnUploadMap.Location = new System.Drawing.Point(191, 394);
            this.btnUploadMap.Name = "btnUploadMap";
            this.btnUploadMap.Size = new System.Drawing.Size(174, 28);
            this.btnUploadMap.TabIndex = 21;
            this.btnUploadMap.Text = "Upload selected maps";
            this.btnUploadMap.UseVisualStyleBackColor = true;
            this.btnUploadMap.Click += new System.EventHandler(this.btnUploadMap_Click);
            // 
            // btnDownloadMaps
            // 
            this.btnDownloadMaps.Location = new System.Drawing.Point(191, 428);
            this.btnDownloadMaps.Name = "btnDownloadMaps";
            this.btnDownloadMaps.Size = new System.Drawing.Size(174, 28);
            this.btnDownloadMaps.TabIndex = 23;
            this.btnDownloadMaps.Text = "Download new maps";
            this.btnDownloadMaps.UseVisualStyleBackColor = true;
            this.btnDownloadMaps.Click += new System.EventHandler(this.btnDownloadMaps_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(191, 462);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(174, 28);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Check for program update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGameOpen
            // 
            this.btnGameOpen.Location = new System.Drawing.Point(609, 517);
            this.btnGameOpen.Name = "btnGameOpen";
            this.btnGameOpen.Size = new System.Drawing.Size(75, 23);
            this.btnGameOpen.TabIndex = 26;
            this.btnGameOpen.Text = "Open folder";
            this.btnGameOpen.UseVisualStyleBackColor = true;
            this.btnGameOpen.Click += new System.EventHandler(this.btnDukeOpen_Click);
            // 
            // btnDosBoxOpen
            // 
            this.btnDosBoxOpen.Location = new System.Drawing.Point(609, 550);
            this.btnDosBoxOpen.Name = "btnDosBoxOpen";
            this.btnDosBoxOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDosBoxOpen.TabIndex = 27;
            this.btnDosBoxOpen.Text = "Open folder";
            this.btnDosBoxOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxOpen.Click += new System.EventHandler(this.btnDosBoxOpen_Click);
            // 
            // btnSharedOpen
            // 
            this.btnSharedOpen.Location = new System.Drawing.Point(609, 616);
            this.btnSharedOpen.Name = "btnSharedOpen";
            this.btnSharedOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSharedOpen.TabIndex = 28;
            this.btnSharedOpen.Text = "Open folder";
            this.btnSharedOpen.UseVisualStyleBackColor = true;
            this.btnSharedOpen.Click += new System.EventHandler(this.btnSharedOpen_Click);
            // 
            // comboGame
            // 
            this.comboGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGame.FormattingEnabled = true;
            this.comboGame.Items.AddRange(new object[] {
            "Duke Nukem 3D",
            "Shadow Warrior"});
            this.comboGame.Location = new System.Drawing.Point(378, 395);
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(168, 21);
            this.comboGame.TabIndex = 29;
            this.comboGame.SelectedIndexChanged += new System.EventHandler(this.comboGame_SelectedIndexChanged);
            // 
            // btnDosBoxCaptureOpen
            // 
            this.btnDosBoxCaptureOpen.Location = new System.Drawing.Point(609, 583);
            this.btnDosBoxCaptureOpen.Name = "btnDosBoxCaptureOpen";
            this.btnDosBoxCaptureOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDosBoxCaptureOpen.TabIndex = 33;
            this.btnDosBoxCaptureOpen.Text = "Open folder";
            this.btnDosBoxCaptureOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxCaptureOpen.Click += new System.EventHandler(this.btnDosBoxCaptureOpen_Click);
            // 
            // btnDosBoxCapturePath
            // 
            this.btnDosBoxCapturePath.Location = new System.Drawing.Point(510, 583);
            this.btnDosBoxCapturePath.Name = "btnDosBoxCapturePath";
            this.btnDosBoxCapturePath.Size = new System.Drawing.Size(90, 23);
            this.btnDosBoxCapturePath.TabIndex = 32;
            this.btnDosBoxCapturePath.Text = "Select folder...";
            this.btnDosBoxCapturePath.UseVisualStyleBackColor = true;
            this.btnDosBoxCapturePath.Click += new System.EventHandler(this.btnDosBoxCapturePath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 588);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DOSBox capture folder:";
            // 
            // txtDosBoxCapturePath
            // 
            this.txtDosBoxCapturePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxCapturePath.Location = new System.Drawing.Point(137, 585);
            this.txtDosBoxCapturePath.Name = "txtDosBoxCapturePath";
            this.txtDosBoxCapturePath.ReadOnly = true;
            this.txtDosBoxCapturePath.Size = new System.Drawing.Size(360, 20);
            this.txtDosBoxCapturePath.TabIndex = 30;
            // 
            // lstIp
            // 
            this.lstIp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIp,
            this.clmAdapter});
            this.lstIp.FullRowSelect = true;
            this.lstIp.Location = new System.Drawing.Point(257, 14);
            this.lstIp.MultiSelect = false;
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(427, 167);
            this.lstIp.TabIndex = 6;
            this.lstIp.UseCompatibleStateImageBehavior = false;
            this.lstIp.View = System.Windows.Forms.View.Details;
            // 
            // clmIp
            // 
            this.clmIp.Text = "IP address";
            this.clmIp.Width = 90;
            // 
            // clmAdapter
            // 
            this.clmAdapter.Text = "Adapter name";
            this.clmAdapter.Width = 113;
            // 
            // lstPlayers
            // 
            this.lstPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPlayers});
            this.lstPlayers.FullRowSelect = true;
            this.lstPlayers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lstPlayers.Location = new System.Drawing.Point(191, 14);
            this.lstPlayers.MultiSelect = false;
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(53, 167);
            this.lstPlayers.TabIndex = 2;
            this.lstPlayers.UseCompatibleStateImageBehavior = false;
            this.lstPlayers.View = System.Windows.Forms.View.Details;
            // 
            // clmPlayers
            // 
            this.clmPlayers.Text = "Players";
            this.clmPlayers.Width = 49;
            // 
            // lstMaps
            // 
            this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMaps});
            this.lstMaps.FullRowSelect = true;
            this.lstMaps.Location = new System.Drawing.Point(12, 14);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(167, 336);
            this.lstMaps.TabIndex = 1;
            this.lstMaps.UseCompatibleStateImageBehavior = false;
            this.lstMaps.View = System.Windows.Forms.View.Details;
            this.lstMaps.SelectedIndexChanged += new System.EventHandler(this.lstMaps_SelectedIndexChanged);
            // 
            // clmMaps
            // 
            this.clmMaps.Text = "Map";
            this.clmMaps.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 650);
            this.Controls.Add(this.btnDosBoxCaptureOpen);
            this.Controls.Add(this.btnDosBoxCapturePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDosBoxCapturePath);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnSharedOpen);
            this.Controls.Add(this.btnDosBoxOpen);
            this.Controls.Add(this.btnGameOpen);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDownloadMaps);
            this.Controls.Add(this.btnUploadMap);
            this.Controls.Add(this.picMapImage);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSharedConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSharedConfig);
            this.Controls.Add(this.btnDosBoxPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDosBoxPath);
            this.Controls.Add(this.btnGamePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.lstIp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.lstMaps);
            this.Controls.Add(this.btnLaunch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duke Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picMapImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
        private VisualStylesListView lstMaps;
        private System.Windows.Forms.ColumnHeader clmMaps;
        private VisualStylesListView lstPlayers;
        private System.Windows.Forms.ColumnHeader clmPlayers;
        private System.Windows.Forms.TextBox textBox1;
        private VisualStylesListView lstIp;
        private System.Windows.Forms.ColumnHeader clmIp;
        private System.Windows.Forms.ColumnHeader clmAdapter;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGamePath;
        private System.Windows.Forms.TextBox txtDosBoxPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDosBoxPath;
        private System.Windows.Forms.TextBox txtSharedConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSharedConfig;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox picMapImage;
        private System.Windows.Forms.Button btnUploadMap;
        private System.Windows.Forms.Button btnDownloadMaps;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGameOpen;
        private System.Windows.Forms.Button btnDosBoxOpen;
        private System.Windows.Forms.Button btnSharedOpen;
        private System.Windows.Forms.ComboBox comboGame;
        private System.Windows.Forms.Button btnDosBoxCaptureOpen;
        private System.Windows.Forms.Button btnDosBoxCapturePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDosBoxCapturePath;
    }
}

