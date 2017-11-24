using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Desktop_Editor
{
    partial class MainForm
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
        List<Games> gamesToShow = new List<Games>();
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToSNESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewGames = new System.Windows.Forms.ListView();
            this.gameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.comboBoxBorder = new System.Windows.Forms.ComboBox();
            this.checkBoxFrame = new System.Windows.Forms.CheckBox();
            this.importFrame = new System.Windows.Forms.Button();
            this.buttonBrowseImage = new System.Windows.Forms.Button();
            this.comboBoxBoostFX = new System.Windows.Forms.ComboBox();
            this.textBoxGameCode = new System.Windows.Forms.TextBox();
            this.pictureBoxArt = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxVol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxEpilepsy = new System.Windows.Forms.CheckBox();
            this.checkBoxRetroarch = new System.Windows.Forms.CheckBox();
            this.checkBoxOutpuDir = new System.Windows.Forms.CheckBox();
            this.checkBoxNoLowLat = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxArguments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxReleaseDate = new System.Windows.Forms.MaskedTextBox();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonTwoSim = new System.Windows.Forms.RadioButton();
            this.radioButtonTwo = new System.Windows.Forms.RadioButton();
            this.radioButtonOne = new System.Windows.Forms.RadioButton();
            this.labelMaxPlayers = new System.Windows.Forms.Label();
            this.labelRawTitle = new System.Windows.Forms.Label();
            this.textBoxRawTitle = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddGames = new System.Windows.Forms.Button();
            this.radioButtonNES = new System.Windows.Forms.RadioButton();
            this.radioButtonSNES = new System.Windows.Forms.RadioButton();
            this.buttonAddHack = new System.Windows.Forms.Button();
            this.openFileDialogNes = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArt)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToSNESToolStripMenuItem,
            this.synchronizeToolStripMenuItem,
            this.uninstallToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // exportToSNESToolStripMenuItem
            // 
            this.exportToSNESToolStripMenuItem.Name = "exportToSNESToolStripMenuItem";
            this.exportToSNESToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exportToSNESToolStripMenuItem.Text = "Get from files console";
            this.exportToSNESToolStripMenuItem.Click += new System.EventHandler(this.ButtonGetGames_Click);
            // 
            // synchronizeToolStripMenuItem
            // 
            this.synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem";
            this.synchronizeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.synchronizeToolStripMenuItem.Text = "Install modifications";
            this.synchronizeToolStripMenuItem.Click += new System.EventHandler(this.buttonAddHack_Click);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listViewGames
            // 
            this.listViewGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gameName});
            this.listViewGames.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewGames.HideSelection = false;
            this.listViewGames.Location = new System.Drawing.Point(12, 57);
            this.listViewGames.MultiSelect = false;
            this.listViewGames.Name = "listViewGames";
            this.listViewGames.Size = new System.Drawing.Size(282, 523);
            this.listViewGames.TabIndex = 7;
            this.listViewGames.UseCompatibleStateImageBehavior = false;
            this.listViewGames.View = System.Windows.Forms.View.Details;
            this.listViewGames.SelectedIndexChanged += new System.EventHandler(this.listViewGames_SelectedIndexChanged);
            this.listViewGames.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewGames_MouseClick);
            // 
            // gameName
            // 
            this.gameName.Text = "Game name";
            this.gameName.Width = 253;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.comboBoxBorder);
            this.groupBoxOptions.Controls.Add(this.checkBoxFrame);
            this.groupBoxOptions.Controls.Add(this.importFrame);
            this.groupBoxOptions.Controls.Add(this.buttonBrowseImage);
            this.groupBoxOptions.Controls.Add(this.comboBoxBoostFX);
            this.groupBoxOptions.Controls.Add(this.textBoxGameCode);
            this.groupBoxOptions.Controls.Add(this.pictureBoxArt);
            this.groupBoxOptions.Controls.Add(this.label7);
            this.groupBoxOptions.Controls.Add(this.comboBoxVol);
            this.groupBoxOptions.Controls.Add(this.label6);
            this.groupBoxOptions.Controls.Add(this.checkBoxEpilepsy);
            this.groupBoxOptions.Controls.Add(this.checkBoxRetroarch);
            this.groupBoxOptions.Controls.Add(this.checkBoxOutpuDir);
            this.groupBoxOptions.Controls.Add(this.checkBoxNoLowLat);
            this.groupBoxOptions.Controls.Add(this.label4);
            this.groupBoxOptions.Controls.Add(this.textBoxArguments);
            this.groupBoxOptions.Controls.Add(this.label3);
            this.groupBoxOptions.Controls.Add(this.maskedTextBoxReleaseDate);
            this.groupBoxOptions.Controls.Add(this.textBoxPublisher);
            this.groupBoxOptions.Controls.Add(this.label1);
            this.groupBoxOptions.Controls.Add(this.label2);
            this.groupBoxOptions.Controls.Add(this.radioButtonTwoSim);
            this.groupBoxOptions.Controls.Add(this.radioButtonTwo);
            this.groupBoxOptions.Controls.Add(this.radioButtonOne);
            this.groupBoxOptions.Controls.Add(this.labelMaxPlayers);
            this.groupBoxOptions.Controls.Add(this.labelRawTitle);
            this.groupBoxOptions.Controls.Add(this.textBoxRawTitle);
            this.groupBoxOptions.Controls.Add(this.textBoxName);
            this.groupBoxOptions.Controls.Add(this.labelName);
            this.groupBoxOptions.Controls.Add(this.labelID);
            this.groupBoxOptions.Location = new System.Drawing.Point(306, 27);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(293, 579);
            this.groupBoxOptions.TabIndex = 2;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Game options";
            // 
            // comboBoxBorder
            // 
            this.comboBoxBorder.Enabled = false;
            this.comboBoxBorder.FormattingEnabled = true;
            this.comboBoxBorder.Items.AddRange(new object[] {
            "4:3",
            "Pixel Perfect"});
            this.comboBoxBorder.Location = new System.Drawing.Point(142, 341);
            this.comboBoxBorder.Name = "comboBoxBorder";
            this.comboBoxBorder.Size = new System.Drawing.Size(54, 21);
            this.comboBoxBorder.TabIndex = 34;
            this.comboBoxBorder.Text = "4:3";
            this.comboBoxBorder.SelectedIndexChanged += new System.EventHandler(this.comboBoxBorder_SelectedIndexChanged);
            // 
            // checkBoxFrame
            // 
            this.checkBoxFrame.AutoSize = true;
            this.checkBoxFrame.Location = new System.Drawing.Point(8, 345);
            this.checkBoxFrame.Name = "checkBoxFrame";
            this.checkBoxFrame.Size = new System.Drawing.Size(131, 17);
            this.checkBoxFrame.TabIndex = 33;
            this.checkBoxFrame.Text = "--use-decorative-frame";
            this.checkBoxFrame.UseVisualStyleBackColor = true;
            this.checkBoxFrame.CheckedChanged += new System.EventHandler(this.checkBoxFrame_CheckedChanged);
            // 
            // importFrame
            // 
            this.importFrame.Enabled = false;
            this.importFrame.Location = new System.Drawing.Point(206, 340);
            this.importFrame.Name = "importFrame";
            this.importFrame.Size = new System.Drawing.Size(77, 24);
            this.importFrame.TabIndex = 32;
            this.importFrame.Text = "Import Frame";
            this.importFrame.UseVisualStyleBackColor = true;
            this.importFrame.Click += new System.EventHandler(this.importFrame_Click);
            // 
            // buttonBrowseImage
            // 
            this.buttonBrowseImage.Location = new System.Drawing.Point(225, 549);
            this.buttonBrowseImage.Name = "buttonBrowseImage";
            this.buttonBrowseImage.Size = new System.Drawing.Size(58, 24);
            this.buttonBrowseImage.TabIndex = 31;
            this.buttonBrowseImage.Text = "Browse";
            this.buttonBrowseImage.UseVisualStyleBackColor = true;
            this.buttonBrowseImage.Click += new System.EventHandler(this.buttonBrowseImage_Click);
            // 
            // comboBoxBoostFX
            // 
            this.comboBoxBoostFX.FormattingEnabled = true;
            this.comboBoxBoostFX.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxBoostFX.Location = new System.Drawing.Point(163, 315);
            this.comboBoxBoostFX.Name = "comboBoxBoostFX";
            this.comboBoxBoostFX.Size = new System.Drawing.Size(41, 21);
            this.comboBoxBoostFX.TabIndex = 30;
            this.comboBoxBoostFX.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBoostFX_SelectedIndexChanged);
            // 
            // textBoxGameCode
            // 
            this.textBoxGameCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGameCode.Location = new System.Drawing.Point(36, 21);
            this.textBoxGameCode.Name = "textBoxGameCode";
            this.textBoxGameCode.ReadOnly = true;
            this.textBoxGameCode.Size = new System.Drawing.Size(239, 13);
            this.textBoxGameCode.TabIndex = 29;
            // 
            // pictureBoxArt
            // 
            this.pictureBoxArt.Location = new System.Drawing.Point(71, 369);
            this.pictureBoxArt.Name = "pictureBoxArt";
            this.pictureBoxArt.Size = new System.Drawing.Size(140, 204);
            this.pictureBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxArt.TabIndex = 28;
            this.pictureBoxArt.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "-boost-fx";
            // 
            // comboBoxVol
            // 
            this.comboBoxVol.FormattingEnabled = true;
            this.comboBoxVol.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.comboBoxVol.Location = new System.Drawing.Point(64, 315);
            this.comboBoxVol.Name = "comboBoxVol";
            this.comboBoxVol.Size = new System.Drawing.Size(41, 21);
            this.comboBoxVol.TabIndex = 25;
            this.comboBoxVol.SelectedIndexChanged += new System.EventHandler(this.comboBoxVol_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "--volume";
            // 
            // checkBoxEpilepsy
            // 
            this.checkBoxEpilepsy.AccessibleDescription = "Activate Flash/Patterns compensation filter";
            this.checkBoxEpilepsy.AutoSize = true;
            this.checkBoxEpilepsy.Location = new System.Drawing.Point(8, 317);
            this.checkBoxEpilepsy.Name = "checkBoxEpilepsy";
            this.checkBoxEpilepsy.Size = new System.Drawing.Size(47, 17);
            this.checkBoxEpilepsy.TabIndex = 23;
            this.checkBoxEpilepsy.Text = "-fp 0";
            this.checkBoxEpilepsy.UseVisualStyleBackColor = true;
            this.checkBoxEpilepsy.CheckedChanged += new System.EventHandler(this.checkBoxEpilepsy_CheckedChanged);
            // 
            // checkBoxRetroarch
            // 
            this.checkBoxRetroarch.AccessibleDescription = "Enables Retroarch (if installed)";
            this.checkBoxRetroarch.AccessibleName = "Retroarch";
            this.checkBoxRetroarch.AutoSize = true;
            this.checkBoxRetroarch.Location = new System.Drawing.Point(197, 289);
            this.checkBoxRetroarch.Name = "checkBoxRetroarch";
            this.checkBoxRetroarch.Size = new System.Drawing.Size(74, 17);
            this.checkBoxRetroarch.TabIndex = 22;
            this.checkBoxRetroarch.Text = "--retroarch";
            this.checkBoxRetroarch.UseVisualStyleBackColor = true;
            this.checkBoxRetroarch.CheckedChanged += new System.EventHandler(this.checkBoxRetroarch_CheckedChanged);
            // 
            // checkBoxOutpuDir
            // 
            this.checkBoxOutpuDir.AccessibleDescription = "Specify where output files are written";
            this.checkBoxOutpuDir.AccessibleName = "Output dir";
            this.checkBoxOutpuDir.AutoSize = true;
            this.checkBoxOutpuDir.Location = new System.Drawing.Point(121, 289);
            this.checkBoxOutpuDir.Name = "checkBoxOutpuDir";
            this.checkBoxOutpuDir.Size = new System.Drawing.Size(73, 17);
            this.checkBoxOutpuDir.TabIndex = 21;
            this.checkBoxOutpuDir.Text = "-output-dir";
            this.checkBoxOutpuDir.UseVisualStyleBackColor = true;
            this.checkBoxOutpuDir.CheckedChanged += new System.EventHandler(this.checkBoxOutpuDir_CheckedChanged);
            // 
            // checkBoxNoLowLat
            // 
            this.checkBoxNoLowLat.AccessibleDescription = "Render in a separate thread, to accommodate \"slow\" titles.";
            this.checkBoxNoLowLat.AccessibleName = "No Low Latency";
            this.checkBoxNoLowLat.AutoSize = true;
            this.checkBoxNoLowLat.Location = new System.Drawing.Point(8, 289);
            this.checkBoxNoLowLat.Name = "checkBoxNoLowLat";
            this.checkBoxNoLowLat.Size = new System.Drawing.Size(94, 17);
            this.checkBoxNoLowLat.TabIndex = 20;
            this.checkBoxNoLowLat.Text = "-no-lowlatency";
            this.checkBoxNoLowLat.UseVisualStyleBackColor = true;
            this.checkBoxNoLowLat.CheckedChanged += new System.EventHandler(this.checkBoxNoLowLat_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Command line arguments (EXPERTS ONLY!)";
            // 
            // textBoxArguments
            // 
            this.textBoxArguments.Location = new System.Drawing.Point(18, 241);
            this.textBoxArguments.Name = "textBoxArguments";
            this.textBoxArguments.ReadOnly = true;
            this.textBoxArguments.Size = new System.Drawing.Size(257, 20);
            this.textBoxArguments.TabIndex = 18;
            this.textBoxArguments.TextChanged += new System.EventHandler(this.textBoxArguments_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Command line:";
            // 
            // maskedTextBoxReleaseDate
            // 
            this.maskedTextBoxReleaseDate.Location = new System.Drawing.Point(171, 169);
            this.maskedTextBoxReleaseDate.Mask = "0000-00-00";
            this.maskedTextBoxReleaseDate.Name = "maskedTextBoxReleaseDate";
            this.maskedTextBoxReleaseDate.Size = new System.Drawing.Size(65, 20);
            this.maskedTextBoxReleaseDate.TabIndex = 16;
            this.maskedTextBoxReleaseDate.TextChanged += new System.EventHandler(this.maskedTextBoxReleaseDate_TextChanged);
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(71, 196);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(204, 20);
            this.textBoxPublisher.TabIndex = 15;
            this.textBoxPublisher.TextChanged += new System.EventHandler(this.textBoxPublisher_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Release date (YYYY-MM-DD):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Publisher:";
            // 
            // radioButtonTwoSim
            // 
            this.radioButtonTwoSim.AutoSize = true;
            this.radioButtonTwoSim.Location = new System.Drawing.Point(103, 144);
            this.radioButtonTwoSim.Name = "radioButtonTwoSim";
            this.radioButtonTwoSim.Size = new System.Drawing.Size(149, 17);
            this.radioButtonTwoSim.TabIndex = 12;
            this.radioButtonTwoSim.TabStop = true;
            this.radioButtonTwoSim.Text = "Multiplayer, simultaneously";
            this.radioButtonTwoSim.UseVisualStyleBackColor = true;
            this.radioButtonTwoSim.CheckedChanged += new System.EventHandler(this.radioButtonTwoSim_CheckedChanged);
            // 
            // radioButtonTwo
            // 
            this.radioButtonTwo.AutoSize = true;
            this.radioButtonTwo.Location = new System.Drawing.Point(103, 125);
            this.radioButtonTwo.Name = "radioButtonTwo";
            this.radioButtonTwo.Size = new System.Drawing.Size(167, 17);
            this.radioButtonTwo.TabIndex = 11;
            this.radioButtonTwo.TabStop = true;
            this.radioButtonTwo.Text = "Multiplayer, not simultaneously";
            this.radioButtonTwo.UseVisualStyleBackColor = true;
            this.radioButtonTwo.CheckedChanged += new System.EventHandler(this.radioButtonTwo_CheckedChanged);
            // 
            // radioButtonOne
            // 
            this.radioButtonOne.AutoSize = true;
            this.radioButtonOne.Location = new System.Drawing.Point(103, 106);
            this.radioButtonOne.Name = "radioButtonOne";
            this.radioButtonOne.Size = new System.Drawing.Size(86, 17);
            this.radioButtonOne.TabIndex = 10;
            this.radioButtonOne.TabStop = true;
            this.radioButtonOne.Text = "Single Player";
            this.radioButtonOne.UseVisualStyleBackColor = true;
            this.radioButtonOne.CheckedChanged += new System.EventHandler(this.radioButtonOne_CheckedChanged);
            // 
            // labelMaxPlayers
            // 
            this.labelMaxPlayers.AutoSize = true;
            this.labelMaxPlayers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMaxPlayers.Location = new System.Drawing.Point(15, 107);
            this.labelMaxPlayers.Name = "labelMaxPlayers";
            this.labelMaxPlayers.Size = new System.Drawing.Size(67, 13);
            this.labelMaxPlayers.TabIndex = 9;
            this.labelMaxPlayers.Text = "Max Players:";
            // 
            // labelRawTitle
            // 
            this.labelRawTitle.AutoSize = true;
            this.labelRawTitle.Location = new System.Drawing.Point(15, 75);
            this.labelRawTitle.Name = "labelRawTitle";
            this.labelRawTitle.Size = new System.Drawing.Size(29, 13);
            this.labelRawTitle.TabIndex = 8;
            this.labelRawTitle.Text = "Sort:";
            // 
            // textBoxRawTitle
            // 
            this.textBoxRawTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxRawTitle.Location = new System.Drawing.Point(59, 72);
            this.textBoxRawTitle.Name = "textBoxRawTitle";
            this.textBoxRawTitle.Size = new System.Drawing.Size(216, 20);
            this.textBoxRawTitle.TabIndex = 7;
            this.textBoxRawTitle.TextChanged += new System.EventHandler(this.textBoxRawTitle_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(59, 44);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(216, 20);
            this.textBoxName.TabIndex = 6;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(15, 47);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(30, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Title:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(15, 21);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "ID:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select original games:";
            // 
            // buttonAddGames
            // 
            this.buttonAddGames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddGames.Location = new System.Drawing.Point(12, 586);
            this.buttonAddGames.Name = "buttonAddGames";
            this.buttonAddGames.Size = new System.Drawing.Size(135, 38);
            this.buttonAddGames.TabIndex = 3;
            this.buttonAddGames.Text = "Get files from console";
            this.buttonAddGames.UseVisualStyleBackColor = true;
            this.buttonAddGames.Click += new System.EventHandler(this.ButtonGetGames_Click);
            // 
            // radioButtonNES
            // 
            this.radioButtonNES.AutoSize = true;
            this.radioButtonNES.Location = new System.Drawing.Point(136, 31);
            this.radioButtonNES.Name = "radioButtonNES";
            this.radioButtonNES.Size = new System.Drawing.Size(47, 17);
            this.radioButtonNES.TabIndex = 4;
            this.radioButtonNES.Text = "NES";
            this.radioButtonNES.UseVisualStyleBackColor = true;
            this.radioButtonNES.CheckedChanged += new System.EventHandler(this.RadioButtonNES_CheckedChanged);
            // 
            // radioButtonSNES
            // 
            this.radioButtonSNES.AutoSize = true;
            this.radioButtonSNES.Checked = true;
            this.radioButtonSNES.Location = new System.Drawing.Point(208, 31);
            this.radioButtonSNES.Name = "radioButtonSNES";
            this.radioButtonSNES.Size = new System.Drawing.Size(54, 17);
            this.radioButtonSNES.TabIndex = 5;
            this.radioButtonSNES.TabStop = true;
            this.radioButtonSNES.Text = "SNES";
            this.radioButtonSNES.UseVisualStyleBackColor = true;
            this.radioButtonSNES.CheckedChanged += new System.EventHandler(this.RadioButtonSNES_CheckedChanged);
            // 
            // buttonAddHack
            // 
            this.buttonAddHack.Location = new System.Drawing.Point(159, 586);
            this.buttonAddHack.Name = "buttonAddHack";
            this.buttonAddHack.Size = new System.Drawing.Size(135, 38);
            this.buttonAddHack.TabIndex = 6;
            this.buttonAddHack.Text = "Install modifications";
            this.buttonAddHack.UseVisualStyleBackColor = true;
            this.buttonAddHack.Click += new System.EventHandler(this.buttonAddHack_Click);
            // 
            // openFileDialogNes
            // 
            this.openFileDialogNes.Multiselect = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(609, 636);
            this.Controls.Add(this.buttonAddHack);
            this.Controls.Add(this.radioButtonSNES);
            this.Controls.Add(this.radioButtonNES);
            this.Controls.Add(this.buttonAddGames);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.listViewGames);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(625, 675);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(625, 675);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToSNESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView listViewGames;
        private System.Windows.Forms.ColumnHeader gameName;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddGames;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxArguments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxReleaseDate;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonTwoSim;
        private System.Windows.Forms.RadioButton radioButtonTwo;
        private System.Windows.Forms.RadioButton radioButtonOne;
        private System.Windows.Forms.Label labelMaxPlayers;
        private System.Windows.Forms.Label labelRawTitle;
        private System.Windows.Forms.TextBox textBoxRawTitle;
        private System.Windows.Forms.PictureBox pictureBoxArt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxVol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxEpilepsy;
        private System.Windows.Forms.CheckBox checkBoxRetroarch;
        private System.Windows.Forms.CheckBox checkBoxOutpuDir;
        private System.Windows.Forms.CheckBox checkBoxNoLowLat;
        private System.Windows.Forms.Label label4;
        private TextBox textBoxGameCode;
        private RadioButton radioButtonNES;
        private RadioButton radioButtonSNES;
        private ComboBox comboBoxBoostFX;
        private Button buttonAddHack;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripSeparator exitToolStripMenuItem;
        private OpenFileDialog openFileDialogNes;
        private Button buttonBrowseImage;
        private OpenFileDialog openFileDialogImage;
        private Button importFrame;
        private CheckBox checkBoxFrame;
        private ComboBox comboBoxBorder;
    }
}

