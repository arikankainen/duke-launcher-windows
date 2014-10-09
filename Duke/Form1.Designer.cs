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
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
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
            this.txtLastPlayed = new System.Windows.Forms.TextBox();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.comboPlayers = new System.Windows.Forms.ComboBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lstOnline = new Duke.VisualStylesListView();
            this.clmOnline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstIp = new Duke.VisualStylesListView();
            this.clmIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAdapter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstMaps = new Duke.VisualStylesListView();
            this.clmMaps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.picMapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.btnLaunch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(714, 328);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(167, 127);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch game!";
            this.btnLaunch.UseMnemonic = false;
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.Location = new System.Drawing.Point(204, 100);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(485, 177);
            this.textBox1.TabIndex = 3;
            // 
            // txtGamePath
            // 
            this.txtGamePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGamePath.Location = new System.Drawing.Point(326, 483);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.ReadOnly = true;
            this.txtGamePath.Size = new System.Drawing.Size(380, 20);
            this.txtGamePath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Game folder:";
            // 
            // btnGamePath
            // 
            this.btnGamePath.Location = new System.Drawing.Point(714, 481);
            this.btnGamePath.Name = "btnGamePath";
            this.btnGamePath.Size = new System.Drawing.Size(86, 23);
            this.btnGamePath.TabIndex = 9;
            this.btnGamePath.Text = "Select folder...";
            this.btnGamePath.UseVisualStyleBackColor = true;
            this.btnGamePath.Click += new System.EventHandler(this.btnDukePath_Click);
            // 
            // txtDosBoxPath
            // 
            this.txtDosBoxPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxPath.Location = new System.Drawing.Point(326, 516);
            this.txtDosBoxPath.Name = "txtDosBoxPath";
            this.txtDosBoxPath.ReadOnly = true;
            this.txtDosBoxPath.Size = new System.Drawing.Size(380, 20);
            this.txtDosBoxPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "DOSBox folder:";
            // 
            // btnDosBoxPath
            // 
            this.btnDosBoxPath.Location = new System.Drawing.Point(714, 514);
            this.btnDosBoxPath.Name = "btnDosBoxPath";
            this.btnDosBoxPath.Size = new System.Drawing.Size(86, 23);
            this.btnDosBoxPath.TabIndex = 12;
            this.btnDosBoxPath.Text = "Select folder...";
            this.btnDosBoxPath.UseVisualStyleBackColor = true;
            this.btnDosBoxPath.Click += new System.EventHandler(this.btnDosBoxPath_Click);
            // 
            // txtSharedConfig
            // 
            this.txtSharedConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSharedConfig.Location = new System.Drawing.Point(326, 582);
            this.txtSharedConfig.Name = "txtSharedConfig";
            this.txtSharedConfig.ReadOnly = true;
            this.txtSharedConfig.Size = new System.Drawing.Size(380, 20);
            this.txtSharedConfig.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Shared folder:";
            // 
            // btnSharedConfig
            // 
            this.btnSharedConfig.Location = new System.Drawing.Point(714, 580);
            this.btnSharedConfig.Name = "btnSharedConfig";
            this.btnSharedConfig.Size = new System.Drawing.Size(86, 23);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Player name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(407, 417);
            this.txtPlayerName.MaxLength = 10;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(154, 20);
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
            this.picMapImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMapImage.Location = new System.Drawing.Point(12, 328);
            this.picMapImage.Name = "picMapImage";
            this.picMapImage.Size = new System.Drawing.Size(167, 127);
            this.picMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapImage.TabIndex = 20;
            this.picMapImage.TabStop = false;
            this.picMapImage.DoubleClick += new System.EventHandler(this.picMapImage_DoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(714, 283);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(167, 23);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Check for program updates";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGameOpen
            // 
            this.btnGameOpen.Location = new System.Drawing.Point(806, 481);
            this.btnGameOpen.Name = "btnGameOpen";
            this.btnGameOpen.Size = new System.Drawing.Size(75, 23);
            this.btnGameOpen.TabIndex = 26;
            this.btnGameOpen.Text = "Open folder";
            this.btnGameOpen.UseVisualStyleBackColor = true;
            this.btnGameOpen.Click += new System.EventHandler(this.btnDukeOpen_Click);
            // 
            // btnDosBoxOpen
            // 
            this.btnDosBoxOpen.Location = new System.Drawing.Point(806, 514);
            this.btnDosBoxOpen.Name = "btnDosBoxOpen";
            this.btnDosBoxOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDosBoxOpen.TabIndex = 27;
            this.btnDosBoxOpen.Text = "Open folder";
            this.btnDosBoxOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxOpen.Click += new System.EventHandler(this.btnDosBoxOpen_Click);
            // 
            // btnSharedOpen
            // 
            this.btnSharedOpen.Location = new System.Drawing.Point(806, 580);
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
            this.comboGame.Location = new System.Drawing.Point(407, 355);
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(154, 21);
            this.comboGame.TabIndex = 29;
            this.comboGame.SelectedIndexChanged += new System.EventHandler(this.comboGame_SelectedIndexChanged);
            // 
            // btnDosBoxCaptureOpen
            // 
            this.btnDosBoxCaptureOpen.Location = new System.Drawing.Point(806, 547);
            this.btnDosBoxCaptureOpen.Name = "btnDosBoxCaptureOpen";
            this.btnDosBoxCaptureOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDosBoxCaptureOpen.TabIndex = 33;
            this.btnDosBoxCaptureOpen.Text = "Open folder";
            this.btnDosBoxCaptureOpen.UseVisualStyleBackColor = true;
            this.btnDosBoxCaptureOpen.Click += new System.EventHandler(this.btnDosBoxCaptureOpen_Click);
            // 
            // btnDosBoxCapturePath
            // 
            this.btnDosBoxCapturePath.Location = new System.Drawing.Point(714, 547);
            this.btnDosBoxCapturePath.Name = "btnDosBoxCapturePath";
            this.btnDosBoxCapturePath.Size = new System.Drawing.Size(86, 23);
            this.btnDosBoxCapturePath.TabIndex = 32;
            this.btnDosBoxCapturePath.Text = "Select folder...";
            this.btnDosBoxCapturePath.UseVisualStyleBackColor = true;
            this.btnDosBoxCapturePath.Click += new System.EventHandler(this.btnDosBoxCapturePath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 552);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DOSBox capture folder:";
            // 
            // txtDosBoxCapturePath
            // 
            this.txtDosBoxCapturePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDosBoxCapturePath.Location = new System.Drawing.Point(326, 549);
            this.txtDosBoxCapturePath.Name = "txtDosBoxCapturePath";
            this.txtDosBoxCapturePath.ReadOnly = true;
            this.txtDosBoxCapturePath.Size = new System.Drawing.Size(380, 20);
            this.txtDosBoxCapturePath.TabIndex = 30;
            // 
            // btnDeleteMaps
            // 
            this.btnDeleteMaps.Location = new System.Drawing.Point(12, 283);
            this.btnDeleteMaps.Name = "btnDeleteMaps";
            this.btnDeleteMaps.Size = new System.Drawing.Size(167, 23);
            this.btnDeleteMaps.TabIndex = 34;
            this.btnDeleteMaps.Text = "Delete selected maps";
            this.btnDeleteMaps.UseVisualStyleBackColor = true;
            this.btnDeleteMaps.Click += new System.EventHandler(this.btnDeleteMaps_Click);
            // 
            // btnSaveDescription
            // 
            this.btnSaveDescription.Location = new System.Drawing.Point(12, 580);
            this.btnSaveDescription.Name = "btnSaveDescription";
            this.btnSaveDescription.Size = new System.Drawing.Size(167, 23);
            this.btnSaveDescription.TabIndex = 35;
            this.btnSaveDescription.Text = "Save description";
            this.btnSaveDescription.UseVisualStyleBackColor = true;
            this.btnSaveDescription.Click += new System.EventHandler(this.btnSaveDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 510);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(167, 64);
            this.txtDescription.TabIndex = 36;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLastPlayed
            // 
            this.txtLastPlayed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLastPlayed.Location = new System.Drawing.Point(12, 484);
            this.txtLastPlayed.MaxLength = 10;
            this.txtLastPlayed.Name = "txtLastPlayed";
            this.txtLastPlayed.ReadOnly = true;
            this.txtLastPlayed.Size = new System.Drawing.Size(167, 20);
            this.txtLastPlayed.TabIndex = 38;
            this.txtLastPlayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // comboPlayers
            // 
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
            this.comboPlayers.Location = new System.Drawing.Point(407, 386);
            this.comboPlayers.Name = "comboPlayers";
            this.comboPlayers.Size = new System.Drawing.Size(154, 21);
            this.comboPlayers.TabIndex = 41;
            this.comboPlayers.SelectedIndexChanged += new System.EventHandler(this.comboPlayers_SelectedIndexChanged);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(204, 285);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(387, 20);
            this.txtSendMessage.TabIndex = 42;
            this.txtSendMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendMessage_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Players:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Select game:";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(597, 283);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(92, 23);
            this.btnSendMessage.TabIndex = 45;
            this.btnSendMessage.Text = "Send message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lstOnline
            // 
            this.lstOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmOnline});
            this.lstOnline.Location = new System.Drawing.Point(714, 12);
            this.lstOnline.MultiSelect = false;
            this.lstOnline.Name = "lstOnline";
            this.lstOnline.Size = new System.Drawing.Size(167, 265);
            this.lstOnline.TabIndex = 40;
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
            this.lstIp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIp,
            this.clmAdapter});
            this.lstIp.FullRowSelect = true;
            this.lstIp.Location = new System.Drawing.Point(204, 12);
            this.lstIp.MultiSelect = false;
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(485, 82);
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
            // lstMaps
            // 
            this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMaps});
            this.lstMaps.FullRowSelect = true;
            this.lstMaps.Location = new System.Drawing.Point(12, 12);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(167, 265);
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
            this.ClientSize = new System.Drawing.Size(893, 615);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.comboPlayers);
            this.Controls.Add(this.lstOnline);
            this.Controls.Add(this.txtLastPlayed);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSaveDescription);
            this.Controls.Add(this.btnDeleteMaps);
            this.Controls.Add(this.btnDosBoxCaptureOpen);
            this.Controls.Add(this.btnDosBoxCapturePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDosBoxCapturePath);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnSharedOpen);
            this.Controls.Add(this.btnDosBoxOpen);
            this.Controls.Add(this.btnGameOpen);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.picMapImage);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Timer timer3;
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
        private System.Windows.Forms.TextBox txtLastPlayed;
        private System.Windows.Forms.Timer timer4;
        private VisualStylesListView lstOnline;
        private System.Windows.Forms.ColumnHeader clmOnline;
        private System.Windows.Forms.ComboBox comboPlayers;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

