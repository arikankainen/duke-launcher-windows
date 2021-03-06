﻿namespace Duke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGamePath = new System.Windows.Forms.Button();
            this.txtDosBoxPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDosBoxPath = new System.Windows.Forms.Button();
            this.txtSharedConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSharedConfig = new System.Windows.Forms.Button();
            this.timerStartClient = new System.Windows.Forms.Timer(this.components);
            this.timerGameEnded = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.timerContinueClient = new System.Windows.Forms.Timer(this.components);
            this.picMapImage = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGameOpen = new System.Windows.Forms.Button();
            this.btnDosBoxOpen = new System.Windows.Forms.Button();
            this.btnSharedOpen = new System.Windows.Forms.Button();
            this.comboGame = new System.Windows.Forms.ComboBox();
            this.btnDosBoxCaptureOpen = new System.Windows.Forms.Button();
            this.btnDosBoxCapturePath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDosBoxCapturePath = new System.Windows.Forms.TextBox();
            this.btnDeleteMaps = new System.Windows.Forms.Button();
            this.btnSaveDescription = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.timerCheckAll = new System.Windows.Forms.Timer(this.components);
            this.comboPlayers = new System.Windows.Forms.ComboBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.timerNewMessage = new System.Windows.Forms.Timer(this.components);
            this.btnTerminate = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSolo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timerWaitPlayers = new System.Windows.Forms.Timer(this.components);
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnChangeUserName = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.numericRandom = new System.Windows.Forms.NumericUpDown();
            this.checkRandom = new System.Windows.Forms.CheckBox();
            this.lstMaps = new Duke.VisualStylesListView();
            this.clmMaps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlayed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstOnline = new Duke.VisualStylesListView();
            this.clmOnline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstIp = new Duke.VisualStylesListView();
            this.clmIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAdapter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.checkFullScreen = new System.Windows.Forms.CheckBox();
            this.labelLastPlayed = new System.Windows.Forms.Label();
            this.timerDOSBox = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMapImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRandom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.btnLaunch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(978, 670);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(5);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(167, 99);
            this.btnLaunch.TabIndex = 33;
            this.btnLaunch.Text = "Launch game";
            this.btnLaunch.UseMnemonic = false;
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // txtGamePath
            // 
            this.txtGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGamePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGamePath.Location = new System.Drawing.Point(391, 713);
            this.txtGamePath.Margin = new System.Windows.Forms.Padding(5);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(439, 20);
            this.txtGamePath.TabIndex = 10;
            this.txtGamePath.TextChanged += new System.EventHandler(this.txtGamePath_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 716);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Game folder:";
            // 
            // btnGamePath
            // 
            this.btnGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePath.Location = new System.Drawing.Point(840, 711);
            this.btnGamePath.Margin = new System.Windows.Forms.Padding(5);
            this.btnGamePath.Name = "btnGamePath";
            this.btnGamePath.Size = new System.Drawing.Size(59, 23);
            this.btnGamePath.TabIndex = 11;
            this.btnGamePath.Text = "Select...";
            this.btnGamePath.UseVisualStyleBackColor = true;
            this.btnGamePath.Click += new System.EventHandler(this.btnDukePath_Click);
            // 
            // txtDosBoxPath
            // 
            this.txtDosBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosBoxPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxPath.Location = new System.Drawing.Point(391, 746);
            this.txtDosBoxPath.Margin = new System.Windows.Forms.Padding(5);
            this.txtDosBoxPath.Name = "txtDosBoxPath";
            this.txtDosBoxPath.Size = new System.Drawing.Size(439, 20);
            this.txtDosBoxPath.TabIndex = 14;
            this.txtDosBoxPath.TextChanged += new System.EventHandler(this.txtDosBoxPath_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "DOSBox folder:";
            // 
            // btnDosBoxPath
            // 
            this.btnDosBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxPath.Location = new System.Drawing.Point(840, 744);
            this.btnDosBoxPath.Margin = new System.Windows.Forms.Padding(5);
            this.btnDosBoxPath.Name = "btnDosBoxPath";
            this.btnDosBoxPath.Size = new System.Drawing.Size(59, 23);
            this.btnDosBoxPath.TabIndex = 15;
            this.btnDosBoxPath.Text = "Select...";
            this.btnDosBoxPath.UseVisualStyleBackColor = true;
            this.btnDosBoxPath.Click += new System.EventHandler(this.btnDosBoxPath_Click);
            // 
            // txtSharedConfig
            // 
            this.txtSharedConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSharedConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSharedConfig.Location = new System.Drawing.Point(391, 812);
            this.txtSharedConfig.Margin = new System.Windows.Forms.Padding(5);
            this.txtSharedConfig.Name = "txtSharedConfig";
            this.txtSharedConfig.Size = new System.Drawing.Size(439, 20);
            this.txtSharedConfig.TabIndex = 22;
            this.txtSharedConfig.TextChanged += new System.EventHandler(this.txtSharedConfig_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 815);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Shared folder:";
            // 
            // btnSharedConfig
            // 
            this.btnSharedConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSharedConfig.Location = new System.Drawing.Point(840, 810);
            this.btnSharedConfig.Margin = new System.Windows.Forms.Padding(5);
            this.btnSharedConfig.Name = "btnSharedConfig";
            this.btnSharedConfig.Size = new System.Drawing.Size(59, 23);
            this.btnSharedConfig.TabIndex = 23;
            this.btnSharedConfig.Text = "Select...";
            this.btnSharedConfig.UseVisualStyleBackColor = true;
            this.btnSharedConfig.Click += new System.EventHandler(this.btnSharedConfig_Click);
            // 
            // timerStartClient
            // 
            this.timerStartClient.Enabled = true;
            this.timerStartClient.Interval = 1500;
            this.timerStartClient.Tick += new System.EventHandler(this.timerStartClient_Tick);
            // 
            // timerGameEnded
            // 
            this.timerGameEnded.Interval = 1500;
            this.timerGameEnded.Tick += new System.EventHandler(this.timerGameEnded_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(975, 586);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Player name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerName.Location = new System.Drawing.Point(977, 604);
            this.txtPlayerName.Margin = new System.Windows.Forms.Padding(5);
            this.txtPlayerName.MaxLength = 10;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(166, 20);
            this.txtPlayerName.TabIndex = 32;
            this.txtPlayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlayerName_KeyDown);
            // 
            // timerContinueClient
            // 
            this.timerContinueClient.Tick += new System.EventHandler(this.timerContinueClient_Tick);
            // 
            // picMapImage
            // 
            this.picMapImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picMapImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picMapImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMapImage.Location = new System.Drawing.Point(14, 510);
            this.picMapImage.Margin = new System.Windows.Forms.Padding(5);
            this.picMapImage.Name = "picMapImage";
            this.picMapImage.Size = new System.Drawing.Size(273, 203);
            this.picMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapImage.TabIndex = 20;
            this.picMapImage.TabStop = false;
            this.picMapImage.DoubleClick += new System.EventHandler(this.picMapImage_DoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(977, 449);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(167, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Check for program updates";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGameOpen
            // 
            this.btnGameOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGameOpen.Location = new System.Drawing.Point(909, 711);
            this.btnGameOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnGameOpen.Name = "btnGameOpen";
            this.btnGameOpen.Size = new System.Drawing.Size(45, 23);
            this.btnGameOpen.TabIndex = 12;
            this.btnGameOpen.Text = "Open";
            this.btnGameOpen.UseVisualStyleBackColor = true;
            this.btnGameOpen.Click += new System.EventHandler(this.btnDukeOpen_Click);
            // 
            // btnDosBoxOpen
            // 
            this.btnDosBoxOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxOpen.Location = new System.Drawing.Point(909, 744);
            this.btnDosBoxOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnDosBoxOpen.Name = "btnDosBoxOpen";
            this.btnDosBoxOpen.Size = new System.Drawing.Size(45, 23);
            this.btnDosBoxOpen.TabIndex = 16;
            this.btnDosBoxOpen.Text = "Open";
            this.btnDosBoxOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxOpen.Click += new System.EventHandler(this.btnDosBoxOpen_Click);
            // 
            // btnSharedOpen
            // 
            this.btnSharedOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSharedOpen.Location = new System.Drawing.Point(909, 810);
            this.btnSharedOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnSharedOpen.Name = "btnSharedOpen";
            this.btnSharedOpen.Size = new System.Drawing.Size(45, 23);
            this.btnSharedOpen.TabIndex = 24;
            this.btnSharedOpen.Text = "Open";
            this.btnSharedOpen.UseVisualStyleBackColor = true;
            this.btnSharedOpen.Click += new System.EventHandler(this.btnSharedOpen_Click);
            // 
            // comboGame
            // 
            this.comboGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGame.FormattingEnabled = true;
            this.comboGame.Items.AddRange(new object[] {
            "Duke Nukem 3D",
            "Shadow Warrior"});
            this.comboGame.Location = new System.Drawing.Point(978, 508);
            this.comboGame.Margin = new System.Windows.Forms.Padding(5);
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(165, 21);
            this.comboGame.TabIndex = 28;
            this.comboGame.SelectedIndexChanged += new System.EventHandler(this.comboGame_SelectedIndexChanged);
            // 
            // btnDosBoxCaptureOpen
            // 
            this.btnDosBoxCaptureOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxCaptureOpen.Location = new System.Drawing.Point(909, 777);
            this.btnDosBoxCaptureOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnDosBoxCaptureOpen.Name = "btnDosBoxCaptureOpen";
            this.btnDosBoxCaptureOpen.Size = new System.Drawing.Size(45, 23);
            this.btnDosBoxCaptureOpen.TabIndex = 20;
            this.btnDosBoxCaptureOpen.Text = "Open";
            this.btnDosBoxCaptureOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxCaptureOpen.Click += new System.EventHandler(this.btnDosBoxCaptureOpen_Click);
            // 
            // btnDosBoxCapturePath
            // 
            this.btnDosBoxCapturePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxCapturePath.Location = new System.Drawing.Point(840, 777);
            this.btnDosBoxCapturePath.Margin = new System.Windows.Forms.Padding(5);
            this.btnDosBoxCapturePath.Name = "btnDosBoxCapturePath";
            this.btnDosBoxCapturePath.Size = new System.Drawing.Size(59, 23);
            this.btnDosBoxCapturePath.TabIndex = 19;
            this.btnDosBoxCapturePath.Text = "Select...";
            this.btnDosBoxCapturePath.UseVisualStyleBackColor = true;
            this.btnDosBoxCapturePath.Click += new System.EventHandler(this.btnDosBoxCapturePath_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 782);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Capture folder:";
            // 
            // txtDosBoxCapturePath
            // 
            this.txtDosBoxCapturePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosBoxCapturePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxCapturePath.Location = new System.Drawing.Point(391, 779);
            this.txtDosBoxCapturePath.Margin = new System.Windows.Forms.Padding(5);
            this.txtDosBoxCapturePath.Name = "txtDosBoxCapturePath";
            this.txtDosBoxCapturePath.Size = new System.Drawing.Size(439, 20);
            this.txtDosBoxCapturePath.TabIndex = 18;
            this.txtDosBoxCapturePath.TextChanged += new System.EventHandler(this.txtDosBoxCapturePath_TextChanged);
            // 
            // btnDeleteMaps
            // 
            this.btnDeleteMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMaps.Location = new System.Drawing.Point(14, 442);
            this.btnDeleteMaps.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteMaps.Name = "btnDeleteMaps";
            this.btnDeleteMaps.Size = new System.Drawing.Size(145, 23);
            this.btnDeleteMaps.TabIndex = 1;
            this.btnDeleteMaps.Text = "Delete selected maps";
            this.btnDeleteMaps.UseVisualStyleBackColor = true;
            this.btnDeleteMaps.Click += new System.EventHandler(this.btnDeleteMaps_Click);
            // 
            // btnSaveDescription
            // 
            this.btnSaveDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDescription.Location = new System.Drawing.Point(14, 810);
            this.btnSaveDescription.Margin = new System.Windows.Forms.Padding(5);
            this.btnSaveDescription.Name = "btnSaveDescription";
            this.btnSaveDescription.Size = new System.Drawing.Size(273, 23);
            this.btnSaveDescription.TabIndex = 4;
            this.btnSaveDescription.Text = "Save description";
            this.btnSaveDescription.UseVisualStyleBackColor = true;
            this.btnSaveDescription.Click += new System.EventHandler(this.btnSaveDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescription.Location = new System.Drawing.Point(14, 723);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(273, 77);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerCheckAll
            // 
            this.timerCheckAll.Enabled = true;
            this.timerCheckAll.Interval = 500;
            this.timerCheckAll.Tick += new System.EventHandler(this.timerCheckAll_Tick);
            // 
            // comboPlayers
            // 
            this.comboPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlayers.FormattingEnabled = true;
            this.comboPlayers.Items.AddRange(new object[] {
            "Auto",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboPlayers.Location = new System.Drawing.Point(977, 556);
            this.comboPlayers.Margin = new System.Windows.Forms.Padding(5);
            this.comboPlayers.Name = "comboPlayers";
            this.comboPlayers.Size = new System.Drawing.Size(167, 21);
            this.comboPlayers.TabIndex = 30;
            this.comboPlayers.SelectedIndexChanged += new System.EventHandler(this.comboPlayers_SelectedIndexChanged);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendMessage.Location = new System.Drawing.Point(308, 669);
            this.txtSendMessage.Margin = new System.Windows.Forms.Padding(5);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(522, 20);
            this.txtSendMessage.TabIndex = 7;
            this.txtSendMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendMessage_KeyUp);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(975, 538);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Number of players:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(975, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Game:";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(840, 667);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(5);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(115, 23);
            this.btnSendMessage.TabIndex = 8;
            this.btnSendMessage.Text = "Send message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // timerNewMessage
            // 
            this.timerNewMessage.Interval = 750;
            this.timerNewMessage.Tick += new System.EventHandler(this.timerNewMessage_Tick);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminate.Location = new System.Drawing.Point(978, 810);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(79, 23);
            this.btnTerminate.TabIndex = 34;
            this.btnTerminate.Text = "Terminate all";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(310, 134);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(644, 523);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // btnSolo
            // 
            this.btnSolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolo.Location = new System.Drawing.Point(1066, 810);
            this.btnSolo.Name = "btnSolo";
            this.btnSolo.Size = new System.Drawing.Size(79, 23);
            this.btnSolo.TabIndex = 35;
            this.btnSolo.Text = "Solo mode";
            this.btnSolo.UseVisualStyleBackColor = true;
            this.btnSolo.Click += new System.EventHandler(this.btnSolo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(169, 442);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(118, 23);
            this.btnRefresh.TabIndex = 36;
            this.btnRefresh.Text = "Refresh list";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(308, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(647, 525);
            this.textBox1.TabIndex = 37;
            // 
            // timerWaitPlayers
            // 
            this.timerWaitPlayers.Interval = 500;
            this.timerWaitPlayers.Tick += new System.EventHandler(this.timerWaitPlayers_Tick);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(977, 32);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUserName.MaxLength = 25;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(166, 20);
            this.txtUserName.TabIndex = 38;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(976, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "User name:";
            // 
            // btnChangeUserName
            // 
            this.btnChangeUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeUserName.Location = new System.Drawing.Point(976, 62);
            this.btnChangeUserName.Margin = new System.Windows.Forms.Padding(5);
            this.btnChangeUserName.Name = "btnChangeUserName";
            this.btnChangeUserName.Size = new System.Drawing.Size(167, 23);
            this.btnChangeUserName.TabIndex = 40;
            this.btnChangeUserName.Text = "Change name";
            this.btnChangeUserName.UseVisualStyleBackColor = true;
            this.btnChangeUserName.Click += new System.EventHandler(this.btnChangeUserName_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(14, 14);
            this.btnRandom.Margin = new System.Windows.Forms.Padding(5);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(273, 23);
            this.btnRandom.TabIndex = 41;
            this.btnRandom.Text = "Select random map";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // numericRandom
            // 
            this.numericRandom.Location = new System.Drawing.Point(85, 45);
            this.numericRandom.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericRandom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRandom.Name = "numericRandom";
            this.numericRandom.Size = new System.Drawing.Size(42, 20);
            this.numericRandom.TabIndex = 43;
            this.numericRandom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericRandom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkRandom
            // 
            this.checkRandom.AutoSize = true;
            this.checkRandom.Location = new System.Drawing.Point(34, 47);
            this.checkRandom.Name = "checkRandom";
            this.checkRandom.Size = new System.Drawing.Size(49, 17);
            this.checkRandom.TabIndex = 44;
            this.checkRandom.Text = "From";
            this.checkRandom.UseVisualStyleBackColor = true;
            this.checkRandom.CheckedChanged += new System.EventHandler(this.checkRandom_CheckedChanged);
            // 
            // lstMaps
            // 
            this.lstMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMaps,
            this.clmPlayed});
            this.lstMaps.FullRowSelect = true;
            this.lstMaps.HideSelection = false;
            this.lstMaps.Location = new System.Drawing.Point(14, 74);
            this.lstMaps.Margin = new System.Windows.Forms.Padding(5);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(273, 358);
            this.lstMaps.TabIndex = 0;
            this.lstMaps.UseCompatibleStateImageBehavior = false;
            this.lstMaps.View = System.Windows.Forms.View.Details;
            this.lstMaps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstMaps_ColumnClick);
            this.lstMaps.SelectedIndexChanged += new System.EventHandler(this.lstMaps_SelectedIndexChanged);
            // 
            // clmMaps
            // 
            this.clmMaps.Text = "Maps";
            this.clmMaps.Width = 120;
            // 
            // clmPlayed
            // 
            this.clmPlayed.Text = "Last played";
            this.clmPlayed.Width = 175;
            // 
            // lstOnline
            // 
            this.lstOnline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmOnline});
            this.lstOnline.HideSelection = false;
            this.lstOnline.Location = new System.Drawing.Point(977, 95);
            this.lstOnline.Margin = new System.Windows.Forms.Padding(5);
            this.lstOnline.MultiSelect = false;
            this.lstOnline.Name = "lstOnline";
            this.lstOnline.Size = new System.Drawing.Size(167, 344);
            this.lstOnline.TabIndex = 25;
            this.lstOnline.UseCompatibleStateImageBehavior = false;
            this.lstOnline.View = System.Windows.Forms.View.Details;
            // 
            // clmOnline
            // 
            this.clmOnline.Text = "Users online";
            this.clmOnline.Width = 109;
            // 
            // lstIp
            // 
            this.lstIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIp,
            this.clmAdapter});
            this.lstIp.FullRowSelect = true;
            this.lstIp.HideSelection = false;
            this.lstIp.Location = new System.Drawing.Point(308, 14);
            this.lstIp.Margin = new System.Windows.Forms.Padding(5);
            this.lstIp.MultiSelect = false;
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(647, 98);
            this.lstIp.TabIndex = 5;
            this.lstIp.UseCompatibleStateImageBehavior = false;
            this.lstIp.View = System.Windows.Forms.View.Details;
            this.lstIp.SelectedIndexChanged += new System.EventHandler(this.lstIp_SelectedIndexChanged);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "least recently played maps";
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.Location = new System.Drawing.Point(978, 779);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(5);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(167, 23);
            this.btnSetup.TabIndex = 46;
            this.btnSetup.Text = "Run setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // checkFullScreen
            // 
            this.checkFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkFullScreen.AutoSize = true;
            this.checkFullScreen.Location = new System.Drawing.Point(1024, 645);
            this.checkFullScreen.Name = "checkFullScreen";
            this.checkFullScreen.Size = new System.Drawing.Size(74, 17);
            this.checkFullScreen.TabIndex = 47;
            this.checkFullScreen.Text = "Fullscreen";
            this.checkFullScreen.UseVisualStyleBackColor = true;
            // 
            // labelLastPlayed
            // 
            this.labelLastPlayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLastPlayed.Location = new System.Drawing.Point(14, 487);
            this.labelLastPlayed.Name = "labelLastPlayed";
            this.labelLastPlayed.Size = new System.Drawing.Size(273, 15);
            this.labelLastPlayed.TabIndex = 48;
            this.labelLastPlayed.Text = "Last played: never";
            this.labelLastPlayed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerDOSBox
            // 
            this.timerDOSBox.Tick += new System.EventHandler(this.timerDOSBox_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 845);
            this.Controls.Add(this.labelLastPlayed);
            this.Controls.Add(this.checkFullScreen);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkRandom);
            this.Controls.Add(this.numericRandom);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnChangeUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSolo);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnDeleteMaps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstMaps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.comboPlayers);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.lstOnline);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSaveDescription);
            this.Controls.Add(this.btnDosBoxCaptureOpen);
            this.Controls.Add(this.btnDosBoxCapturePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDosBoxCapturePath);
            this.Controls.Add(this.btnSharedOpen);
            this.Controls.Add(this.btnDosBoxOpen);
            this.Controls.Add(this.btnGameOpen);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.picMapImage);
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
            this.Controls.Add(this.btnLaunch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 550);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duke Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picMapImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRandom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
        private VisualStylesListView lstMaps;
        private System.Windows.Forms.ColumnHeader clmMaps;
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
        private System.Windows.Forms.Timer timerStartClient;
        private System.Windows.Forms.Timer timerGameEnded;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Timer timerContinueClient;
        private System.Windows.Forms.PictureBox picMapImage;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGameOpen;
        private System.Windows.Forms.Button btnDosBoxOpen;
        private System.Windows.Forms.Button btnSharedOpen;
        private System.Windows.Forms.ComboBox comboGame;
        private System.Windows.Forms.Button btnDosBoxCaptureOpen;
        private System.Windows.Forms.Button btnDosBoxCapturePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDosBoxCapturePath;
        private System.Windows.Forms.Button btnDeleteMaps;
        private System.Windows.Forms.Button btnSaveDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Timer timerCheckAll;
        private VisualStylesListView lstOnline;
        private System.Windows.Forms.ColumnHeader clmOnline;
        private System.Windows.Forms.ComboBox comboPlayers;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Timer timerNewMessage;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSolo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timerWaitPlayers;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChangeUserName;
        private System.Windows.Forms.ColumnHeader clmPlayed;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.NumericUpDown numericRandom;
        private System.Windows.Forms.CheckBox checkRandom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.CheckBox checkFullScreen;
        private System.Windows.Forms.Label labelLastPlayed;
        private System.Windows.Forms.Timer timerDOSBox;
    }
}

