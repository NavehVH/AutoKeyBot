namespace AutoKeyBot.Applications
{
    partial class RegularBot : AutoKeyBot.Master.KeystrokeBot
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.clientDetailsTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.botNameTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.pictureDetectSettingsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hpBarPictureBox = new System.Windows.Forms.PictureBox();
            this.miniMapGroupBox = new System.Windows.Forms.GroupBox();
            this.miniMapPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simulatorButton = new System.Windows.Forms.Button();
            this.setImageButton = new System.Windows.Forms.Button();
            this.cropImageComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.keysTabPage = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.keysDeleteButton = new System.Windows.Forms.Button();
            this.keysCopyPasteButton = new System.Windows.Forms.Button();
            this.rowDownButton = new System.Windows.Forms.Button();
            this.rowUpButton = new System.Windows.Forms.Button();
            this.keysDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.keyTextBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.spamTimeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.eventsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.eventDeleteButton = new System.Windows.Forms.Button();
            this.eventCopyPasteButton = new System.Windows.Forms.Button();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.addEventButton = new System.Windows.Forms.Button();
            this.eventTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.runBotTabPage = new System.Windows.Forms.TabPage();
            this.pauseButton = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.bottingTimeLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.hpStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureDetectionBot = new System.Windows.Forms.Button();
            this.stopBottingButton = new System.Windows.Forms.Button();
            this.startBottingButton = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.eventStatus = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.botStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.otherPlayerInTheMapStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.playerPositionStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.clientDetailsTabPage.SuspendLayout();
            this.pictureDetectSettingsTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hpBarPictureBox)).BeginInit();
            this.miniMapGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.keysTabPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keysDataGridView)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.eventsTabPage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.runBotTabPage.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.clientDetailsTabPage);
            this.tabControl.Controls.Add(this.pictureDetectSettingsTabPage);
            this.tabControl.Controls.Add(this.keysTabPage);
            this.tabControl.Controls.Add(this.eventsTabPage);
            this.tabControl.Controls.Add(this.runBotTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(335, 562);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // clientDetailsTabPage
            // 
            this.clientDetailsTabPage.Controls.Add(this.label1);
            this.clientDetailsTabPage.Controls.Add(this.botNameTextBox);
            this.clientDetailsTabPage.Controls.Add(this.label14);
            this.clientDetailsTabPage.Controls.Add(this.saveButton);
            this.clientDetailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.clientDetailsTabPage.Name = "clientDetailsTabPage";
            this.clientDetailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clientDetailsTabPage.Size = new System.Drawing.Size(327, 536);
            this.clientDetailsTabPage.TabIndex = 0;
            this.clientDetailsTabPage.Text = "Client Details";
            this.clientDetailsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(77, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "Regular Bot";
            // 
            // botNameTextBox
            // 
            this.botNameTextBox.Location = new System.Drawing.Point(93, 102);
            this.botNameTextBox.Name = "botNameTextBox";
            this.botNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.botNameTextBox.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Bot Name:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(244, 505);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // pictureDetectSettingsTabPage
            // 
            this.pictureDetectSettingsTabPage.Controls.Add(this.groupBox3);
            this.pictureDetectSettingsTabPage.Controls.Add(this.miniMapGroupBox);
            this.pictureDetectSettingsTabPage.Controls.Add(this.groupBox1);
            this.pictureDetectSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.pictureDetectSettingsTabPage.Name = "pictureDetectSettingsTabPage";
            this.pictureDetectSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pictureDetectSettingsTabPage.Size = new System.Drawing.Size(327, 536);
            this.pictureDetectSettingsTabPage.TabIndex = 1;
            this.pictureDetectSettingsTabPage.Text = "Picture Detect Settings";
            this.pictureDetectSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.hpBarPictureBox);
            this.groupBox3.Location = new System.Drawing.Point(11, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 69);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Health Bar Position";
            // 
            // hpBarPictureBox
            // 
            this.hpBarPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hpBarPictureBox.Location = new System.Drawing.Point(3, 16);
            this.hpBarPictureBox.Name = "hpBarPictureBox";
            this.hpBarPictureBox.Size = new System.Drawing.Size(305, 50);
            this.hpBarPictureBox.TabIndex = 0;
            this.hpBarPictureBox.TabStop = false;
            // 
            // miniMapGroupBox
            // 
            this.miniMapGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miniMapGroupBox.Controls.Add(this.miniMapPictureBox);
            this.miniMapGroupBox.Location = new System.Drawing.Point(8, 144);
            this.miniMapGroupBox.Name = "miniMapGroupBox";
            this.miniMapGroupBox.Size = new System.Drawing.Size(311, 230);
            this.miniMapGroupBox.TabIndex = 1;
            this.miniMapGroupBox.TabStop = false;
            this.miniMapGroupBox.Text = "Full Map Overlay Position";
            // 
            // miniMapPictureBox
            // 
            this.miniMapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miniMapPictureBox.Location = new System.Drawing.Point(3, 16);
            this.miniMapPictureBox.Name = "miniMapPictureBox";
            this.miniMapPictureBox.Size = new System.Drawing.Size(305, 211);
            this.miniMapPictureBox.TabIndex = 0;
            this.miniMapPictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.simulatorButton);
            this.groupBox1.Controls.Add(this.setImageButton);
            this.groupBox1.Controls.Add(this.cropImageComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture Position Detecting";
            // 
            // simulatorButton
            // 
            this.simulatorButton.Location = new System.Drawing.Point(6, 103);
            this.simulatorButton.Name = "simulatorButton";
            this.simulatorButton.Size = new System.Drawing.Size(63, 23);
            this.simulatorButton.TabIndex = 4;
            this.simulatorButton.Text = "Simulator";
            this.simulatorButton.UseVisualStyleBackColor = true;
            this.simulatorButton.Click += new System.EventHandler(this.simulatorButton_Click);
            // 
            // setImageButton
            // 
            this.setImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setImageButton.Location = new System.Drawing.Point(230, 103);
            this.setImageButton.Name = "setImageButton";
            this.setImageButton.Size = new System.Drawing.Size(75, 23);
            this.setImageButton.TabIndex = 3;
            this.setImageButton.Text = "Set Image";
            this.setImageButton.UseVisualStyleBackColor = true;
            this.setImageButton.Click += new System.EventHandler(this.SetTypeButton_Click);
            // 
            // cropImageComboBox
            // 
            this.cropImageComboBox.FormattingEnabled = true;
            this.cropImageComboBox.Items.AddRange(new object[] {
            "Mini-Map",
            "HP Bar"});
            this.cropImageComboBox.Location = new System.Drawing.Point(151, 48);
            this.cropImageComboBox.Name = "cropImageComboBox";
            this.cropImageComboBox.Size = new System.Drawing.Size(121, 21);
            this.cropImageComboBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Choose Image type to crop:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Drag the cursor around the area you choose to capture.";
            // 
            // keysTabPage
            // 
            this.keysTabPage.Controls.Add(this.groupBox6);
            this.keysTabPage.Controls.Add(this.groupBox5);
            this.keysTabPage.Location = new System.Drawing.Point(4, 22);
            this.keysTabPage.Name = "keysTabPage";
            this.keysTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.keysTabPage.Size = new System.Drawing.Size(327, 536);
            this.keysTabPage.TabIndex = 2;
            this.keysTabPage.Text = "Keys";
            this.keysTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.keysDeleteButton);
            this.groupBox6.Controls.Add(this.keysCopyPasteButton);
            this.groupBox6.Controls.Add(this.rowDownButton);
            this.groupBox6.Controls.Add(this.rowUpButton);
            this.groupBox6.Controls.Add(this.keysDataGridView);
            this.groupBox6.Location = new System.Drawing.Point(6, 129);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(321, 407);
            this.groupBox6.TabIndex = 58;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Main Keys Order:";
            // 
            // keysDeleteButton
            // 
            this.keysDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keysDeleteButton.Location = new System.Drawing.Point(128, 376);
            this.keysDeleteButton.Name = "keysDeleteButton";
            this.keysDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.keysDeleteButton.TabIndex = 31;
            this.keysDeleteButton.Text = "Delete";
            this.keysDeleteButton.UseVisualStyleBackColor = true;
            this.keysDeleteButton.Click += new System.EventHandler(this.Delete_Click);
            // 
            // keysCopyPasteButton
            // 
            this.keysCopyPasteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keysCopyPasteButton.Location = new System.Drawing.Point(209, 376);
            this.keysCopyPasteButton.Name = "keysCopyPasteButton";
            this.keysCopyPasteButton.Size = new System.Drawing.Size(75, 23);
            this.keysCopyPasteButton.TabIndex = 30;
            this.keysCopyPasteButton.Text = "Copy Paste";
            this.keysCopyPasteButton.UseVisualStyleBackColor = true;
            this.keysCopyPasteButton.Click += new System.EventHandler(this.CopyPaste_Click);
            // 
            // rowDownButton
            // 
            this.rowDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rowDownButton.Location = new System.Drawing.Point(290, 376);
            this.rowDownButton.Name = "rowDownButton";
            this.rowDownButton.Size = new System.Drawing.Size(23, 23);
            this.rowDownButton.TabIndex = 29;
            this.rowDownButton.Text = "↓";
            this.rowDownButton.UseVisualStyleBackColor = true;
            this.rowDownButton.Click += new System.EventHandler(this.RowDown_Click);
            // 
            // rowUpButton
            // 
            this.rowUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rowUpButton.Location = new System.Drawing.Point(292, 19);
            this.rowUpButton.Name = "rowUpButton";
            this.rowUpButton.Size = new System.Drawing.Size(23, 23);
            this.rowUpButton.TabIndex = 28;
            this.rowUpButton.Text = "↑";
            this.rowUpButton.UseVisualStyleBackColor = true;
            this.rowUpButton.Click += new System.EventHandler(this.RowUp_Click);
            // 
            // keysDataGridView
            // 
            this.keysDataGridView.AllowUserToAddRows = false;
            this.keysDataGridView.AllowUserToDeleteRows = false;
            this.keysDataGridView.AllowUserToResizeColumns = false;
            this.keysDataGridView.AllowUserToResizeRows = false;
            this.keysDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keysDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.keysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keysDataGridView.Location = new System.Drawing.Point(6, 48);
            this.keysDataGridView.Name = "keysDataGridView";
            this.keysDataGridView.ReadOnly = true;
            this.keysDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.keysDataGridView.Size = new System.Drawing.Size(309, 322);
            this.keysDataGridView.TabIndex = 27;
            this.keysDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.keysDataGridView_CellDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.keyTextBox);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.addKeyButton);
            this.groupBox5.Controls.Add(this.spamTimeTextBox);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 117);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Adding a new Key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.FormattingEnabled = true;
            this.keyTextBox.Location = new System.Drawing.Point(40, 23);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(121, 21);
            this.keyTextBox.TabIndex = 15;
            this.keyTextBox.SelectedIndexChanged += new System.EventHandler(this.Key_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Key:";
            // 
            // addKeyButton
            // 
            this.addKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addKeyButton.Location = new System.Drawing.Point(237, 88);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(75, 23);
            this.addKeyButton.TabIndex = 10;
            this.addKeyButton.Text = "Add Key";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.AddKey_Click);
            // 
            // spamTimeTextBox
            // 
            this.spamTimeTextBox.Location = new System.Drawing.Point(200, 48);
            this.spamTimeTextBox.Name = "spamTimeTextBox";
            this.spamTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.spamTimeTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Spam Time (Put 0 if to press one time):";
            // 
            // eventsTabPage
            // 
            this.eventsTabPage.Controls.Add(this.groupBox8);
            this.eventsTabPage.Controls.Add(this.groupBox7);
            this.eventsTabPage.Location = new System.Drawing.Point(4, 22);
            this.eventsTabPage.Name = "eventsTabPage";
            this.eventsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTabPage.Size = new System.Drawing.Size(327, 536);
            this.eventsTabPage.TabIndex = 3;
            this.eventsTabPage.Text = "Events";
            this.eventsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.eventDeleteButton);
            this.groupBox8.Controls.Add(this.eventCopyPasteButton);
            this.groupBox8.Controls.Add(this.eventsDataGridView);
            this.groupBox8.Location = new System.Drawing.Point(5, 99);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(321, 441);
            this.groupBox8.TabIndex = 59;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Events";
            // 
            // eventDeleteButton
            // 
            this.eventDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eventDeleteButton.Location = new System.Drawing.Point(160, 406);
            this.eventDeleteButton.Name = "eventDeleteButton";
            this.eventDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.eventDeleteButton.TabIndex = 31;
            this.eventDeleteButton.Text = "Delete";
            this.eventDeleteButton.UseVisualStyleBackColor = true;
            this.eventDeleteButton.Click += new System.EventHandler(this.DeleteEvent_Click);
            // 
            // eventCopyPasteButton
            // 
            this.eventCopyPasteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eventCopyPasteButton.Location = new System.Drawing.Point(241, 406);
            this.eventCopyPasteButton.Name = "eventCopyPasteButton";
            this.eventCopyPasteButton.Size = new System.Drawing.Size(75, 23);
            this.eventCopyPasteButton.TabIndex = 30;
            this.eventCopyPasteButton.Text = "Copy Paste";
            this.eventCopyPasteButton.UseVisualStyleBackColor = true;
            this.eventCopyPasteButton.Click += new System.EventHandler(this.CopyPasteEvent_Click);
            // 
            // eventsDataGridView
            // 
            this.eventsDataGridView.AllowUserToAddRows = false;
            this.eventsDataGridView.AllowUserToDeleteRows = false;
            this.eventsDataGridView.AllowUserToResizeColumns = false;
            this.eventsDataGridView.AllowUserToResizeRows = false;
            this.eventsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.ReadOnly = true;
            this.eventsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsDataGridView.Size = new System.Drawing.Size(309, 381);
            this.eventsDataGridView.TabIndex = 27;
            this.eventsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventsDataGridView_CellDoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.addEventButton);
            this.groupBox7.Controls.Add(this.eventTypeComboBox);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(8, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(312, 87);
            this.groupBox7.TabIndex = 58;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Add Event";
            // 
            // addEventButton
            // 
            this.addEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addEventButton.Location = new System.Drawing.Point(231, 58);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(75, 23);
            this.addEventButton.TabIndex = 2;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // eventTypeComboBox
            // 
            this.eventTypeComboBox.FormattingEnabled = true;
            this.eventTypeComboBox.Items.AddRange(new object[] {
            "Player Position",
            "Other Players In The Map",
            "HP",
            "Timer"});
            this.eventTypeComboBox.Location = new System.Drawing.Point(168, 19);
            this.eventTypeComboBox.Name = "eventTypeComboBox";
            this.eventTypeComboBox.Size = new System.Drawing.Size(141, 21);
            this.eventTypeComboBox.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Choose type of event to create:";
            // 
            // runBotTabPage
            // 
            this.runBotTabPage.Controls.Add(this.pauseButton);
            this.runBotTabPage.Controls.Add(this.groupBox11);
            this.runBotTabPage.Controls.Add(this.groupBox10);
            this.runBotTabPage.Controls.Add(this.pictureDetectionBot);
            this.runBotTabPage.Controls.Add(this.stopBottingButton);
            this.runBotTabPage.Controls.Add(this.startBottingButton);
            this.runBotTabPage.Controls.Add(this.groupBox12);
            this.runBotTabPage.Controls.Add(this.groupBox9);
            this.runBotTabPage.Location = new System.Drawing.Point(4, 22);
            this.runBotTabPage.Name = "runBotTabPage";
            this.runBotTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.runBotTabPage.Size = new System.Drawing.Size(327, 536);
            this.runBotTabPage.TabIndex = 4;
            this.runBotTabPage.Text = "Run Bot";
            this.runBotTabPage.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(87, 505);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 9;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.bottingTimeLabel);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Location = new System.Drawing.Point(8, 229);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(316, 58);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Time Data";
            // 
            // bottingTimeLabel
            // 
            this.bottingTimeLabel.AutoSize = true;
            this.bottingTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bottingTimeLabel.Location = new System.Drawing.Point(82, 26);
            this.bottingTimeLabel.Name = "bottingTimeLabel";
            this.bottingTimeLabel.Size = new System.Drawing.Size(34, 13);
            this.bottingTimeLabel.TabIndex = 3;
            this.bottingTimeLabel.Text = "00:00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Time Botting:";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.hpStatus);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Location = new System.Drawing.Point(8, 165);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(316, 58);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Potions Data";
            // 
            // hpStatus
            // 
            this.hpStatus.AutoSize = true;
            this.hpStatus.ForeColor = System.Drawing.Color.Red;
            this.hpStatus.Location = new System.Drawing.Point(67, 26);
            this.hpStatus.Name = "hpStatus";
            this.hpStatus.Size = new System.Drawing.Size(54, 13);
            this.hpStatus.TabIndex = 3;
            this.hpStatus.Text = "NOT SET";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Health Bar:";
            // 
            // pictureDetectionBot
            // 
            this.pictureDetectionBot.Location = new System.Drawing.Point(8, 293);
            this.pictureDetectionBot.Name = "pictureDetectionBot";
            this.pictureDetectionBot.Size = new System.Drawing.Size(75, 23);
            this.pictureDetectionBot.TabIndex = 6;
            this.pictureDetectionBot.Text = "Live Data";
            this.pictureDetectionBot.UseVisualStyleBackColor = true;
            this.pictureDetectionBot.Click += new System.EventHandler(this.PictureDetectionBotButton_Click);
            // 
            // stopBottingButton
            // 
            this.stopBottingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBottingButton.Location = new System.Drawing.Point(168, 505);
            this.stopBottingButton.Name = "stopBottingButton";
            this.stopBottingButton.Size = new System.Drawing.Size(75, 23);
            this.stopBottingButton.TabIndex = 5;
            this.stopBottingButton.Text = "Stop Botting";
            this.stopBottingButton.UseVisualStyleBackColor = true;
            this.stopBottingButton.Click += new System.EventHandler(this.StopBotting_Click);
            // 
            // startBottingButton
            // 
            this.startBottingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startBottingButton.Location = new System.Drawing.Point(249, 505);
            this.startBottingButton.Name = "startBottingButton";
            this.startBottingButton.Size = new System.Drawing.Size(75, 23);
            this.startBottingButton.TabIndex = 4;
            this.startBottingButton.Text = "Start Botting";
            this.startBottingButton.UseVisualStyleBackColor = true;
            this.startBottingButton.Click += new System.EventHandler(this.StartBotting_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.eventStatus);
            this.groupBox12.Controls.Add(this.label15);
            this.groupBox12.Controls.Add(this.botStatus);
            this.groupBox12.Controls.Add(this.label13);
            this.groupBox12.Location = new System.Drawing.Point(8, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(316, 74);
            this.groupBox12.TabIndex = 3;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Botting Status";
            // 
            // eventStatus
            // 
            this.eventStatus.AutoSize = true;
            this.eventStatus.ForeColor = System.Drawing.Color.Red;
            this.eventStatus.Location = new System.Drawing.Point(91, 43);
            this.eventStatus.Name = "eventStatus";
            this.eventStatus.Size = new System.Drawing.Size(33, 13);
            this.eventStatus.TabIndex = 3;
            this.eventStatus.Text = "None";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Event Running:";
            // 
            // botStatus
            // 
            this.botStatus.AutoSize = true;
            this.botStatus.ForeColor = System.Drawing.Color.Red;
            this.botStatus.Location = new System.Drawing.Point(54, 19);
            this.botStatus.Name = "botStatus";
            this.botStatus.Size = new System.Drawing.Size(67, 13);
            this.botStatus.TabIndex = 1;
            this.botStatus.Text = "Not Running";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Status:";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.otherPlayerInTheMapStatus);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.playerPositionStatus);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Location = new System.Drawing.Point(8, 86);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(319, 73);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Mini-Map Data";
            // 
            // otherPlayerInTheMapStatus
            // 
            this.otherPlayerInTheMapStatus.AutoSize = true;
            this.otherPlayerInTheMapStatus.ForeColor = System.Drawing.Color.Red;
            this.otherPlayerInTheMapStatus.Location = new System.Drawing.Point(138, 49);
            this.otherPlayerInTheMapStatus.Name = "otherPlayerInTheMapStatus";
            this.otherPlayerInTheMapStatus.Size = new System.Drawing.Size(54, 13);
            this.otherPlayerInTheMapStatus.TabIndex = 3;
            this.otherPlayerInTheMapStatus.Text = "NOT SET";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Other Player In The Map:";
            // 
            // playerPositionStatus
            // 
            this.playerPositionStatus.AutoSize = true;
            this.playerPositionStatus.ForeColor = System.Drawing.Color.Red;
            this.playerPositionStatus.Location = new System.Drawing.Point(91, 25);
            this.playerPositionStatus.Name = "playerPositionStatus";
            this.playerPositionStatus.Size = new System.Drawing.Size(54, 13);
            this.playerPositionStatus.TabIndex = 1;
            this.playerPositionStatus.Text = "NOT SET";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Player Position:";
            // 
            // RegularBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(335, 586);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(351, 400);
            this.Name = "RegularBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegularBot_FormClosing);
            this.Load += new System.EventHandler(this.RegularBot_Load);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.tabControl.ResumeLayout(false);
            this.clientDetailsTabPage.ResumeLayout(false);
            this.clientDetailsTabPage.PerformLayout();
            this.pictureDetectSettingsTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hpBarPictureBox)).EndInit();
            this.miniMapGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.keysTabPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keysDataGridView)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.eventsTabPage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.runBotTabPage.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage clientDetailsTabPage;
        private System.Windows.Forms.TabPage pictureDetectSettingsTabPage;
        private System.Windows.Forms.TabPage keysTabPage;
        private System.Windows.Forms.TabPage eventsTabPage;
        private System.Windows.Forms.TabPage runBotTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox hpBarPictureBox;
        private System.Windows.Forms.GroupBox miniMapGroupBox;
        private System.Windows.Forms.PictureBox miniMapPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setImageButton;
        private System.Windows.Forms.ComboBox cropImageComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox keyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.TextBox spamTimeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button keysDeleteButton;
        private System.Windows.Forms.Button keysCopyPasteButton;
        private System.Windows.Forms.Button rowDownButton;
        private System.Windows.Forms.Button rowUpButton;
        private System.Windows.Forms.DataGridView keysDataGridView;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button eventDeleteButton;
        private System.Windows.Forms.Button eventCopyPasteButton;
        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.ComboBox eventTypeComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label otherPlayerInTheMapStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label playerPositionStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label eventStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label botStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button pictureDetectionBot;
        private System.Windows.Forms.Button stopBottingButton;
        private System.Windows.Forms.Button startBottingButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox botNameTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label hpStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label bottingTimeLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button simulatorButton;
        private System.Windows.Forms.Button pauseButton;
    }
}