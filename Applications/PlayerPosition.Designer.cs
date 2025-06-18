namespace AutoKeyBot.Applications
{
    partial class PlayerPosition
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
            this.EventTitle = new System.Windows.Forms.Label();
            this.ActiveText = new System.Windows.Forms.Label();
            this.widthChoice = new System.Windows.Forms.RadioButton();
            this.Event = new System.Windows.Forms.GroupBox();
            this.bothChoice = new System.Windows.Forms.RadioButton();
            this.heightChoice = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTexBox = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.CopyPaste = new System.Windows.Forms.Button();
            this.RowDown = new System.Windows.Forms.Button();
            this.RowUp = new System.Windows.Forms.Button();
            this.KeysOrder = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.ComboBox();
            this.AddKey = new System.Windows.Forms.Button();
            this.SpamTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddEvent = new System.Windows.Forms.Button();
            this.WidthGroupBox = new System.Windows.Forms.GroupBox();
            this.widthToBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.widthFromBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.widthBetween = new System.Windows.Forms.RadioButton();
            this.widthSmaller = new System.Windows.Forms.RadioButton();
            this.widthBigger = new System.Windows.Forms.RadioButton();
            this.HeightGroupBox = new System.Windows.Forms.GroupBox();
            this.heightToBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.heightFromBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.heightBetween = new System.Windows.Forms.RadioButton();
            this.heightSmaller = new System.Windows.Forms.RadioButton();
            this.heightBigger = new System.Windows.Forms.RadioButton();
            this.autoSaveLabel = new System.Windows.Forms.Label();
            this.simulatorButton = new System.Windows.Forms.Button();
            this.Event.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.WidthGroupBox.SuspendLayout();
            this.HeightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventTitle
            // 
            this.EventTitle.AutoSize = true;
            this.EventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitle.Location = new System.Drawing.Point(12, 9);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.Size = new System.Drawing.Size(280, 31);
            this.EventTitle.TabIndex = 0;
            this.EventTitle.Text = "Player Position Event:";
            // 
            // ActiveText
            // 
            this.ActiveText.AutoSize = true;
            this.ActiveText.Location = new System.Drawing.Point(6, 52);
            this.ActiveText.Name = "ActiveText";
            this.ActiveText.Size = new System.Drawing.Size(213, 13);
            this.ActiveText.TabIndex = 1;
            this.ActiveText.Text = "Activate event based width, height or both?";
            // 
            // widthChoice
            // 
            this.widthChoice.AutoSize = true;
            this.widthChoice.Location = new System.Drawing.Point(6, 85);
            this.widthChoice.Name = "widthChoice";
            this.widthChoice.Size = new System.Drawing.Size(69, 17);
            this.widthChoice.TabIndex = 2;
            this.widthChoice.TabStop = true;
            this.widthChoice.Text = "Width (X)";
            this.widthChoice.UseVisualStyleBackColor = true;
            this.widthChoice.CheckedChanged += new System.EventHandler(this.widthChoice_CheckedChanged);
            // 
            // Event
            // 
            this.Event.Controls.Add(this.bothChoice);
            this.Event.Controls.Add(this.heightChoice);
            this.Event.Controls.Add(this.label2);
            this.Event.Controls.Add(this.nameTexBox);
            this.Event.Controls.Add(this.ActiveText);
            this.Event.Controls.Add(this.widthChoice);
            this.Event.Location = new System.Drawing.Point(18, 43);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(355, 158);
            this.Event.TabIndex = 4;
            this.Event.TabStop = false;
            // 
            // bothChoice
            // 
            this.bothChoice.AutoSize = true;
            this.bothChoice.Location = new System.Drawing.Point(6, 131);
            this.bothChoice.Name = "bothChoice";
            this.bothChoice.Size = new System.Drawing.Size(76, 17);
            this.bothChoice.TabIndex = 9;
            this.bothChoice.TabStop = true;
            this.bothChoice.Text = "Both (X, Y)";
            this.bothChoice.UseVisualStyleBackColor = true;
            this.bothChoice.CheckedChanged += new System.EventHandler(this.bothChoice_CheckedChanged);
            // 
            // heightChoice
            // 
            this.heightChoice.AutoSize = true;
            this.heightChoice.Location = new System.Drawing.Point(6, 108);
            this.heightChoice.Name = "heightChoice";
            this.heightChoice.Size = new System.Drawing.Size(72, 17);
            this.heightChoice.TabIndex = 8;
            this.heightChoice.TabStop = true;
            this.heightChoice.Text = "Height (Y)";
            this.heightChoice.UseVisualStyleBackColor = true;
            this.heightChoice.CheckedChanged += new System.EventHandler(this.heightChoice_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name of Event:";
            // 
            // nameTexBox
            // 
            this.nameTexBox.Location = new System.Drawing.Point(93, 23);
            this.nameTexBox.Name = "nameTexBox";
            this.nameTexBox.Size = new System.Drawing.Size(256, 20);
            this.nameTexBox.TabIndex = 6;
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.Location = new System.Drawing.Point(476, 483);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 32;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // CopyPaste
            // 
            this.CopyPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyPaste.Location = new System.Drawing.Point(557, 483);
            this.CopyPaste.Name = "CopyPaste";
            this.CopyPaste.Size = new System.Drawing.Size(75, 23);
            this.CopyPaste.TabIndex = 31;
            this.CopyPaste.Text = "Copy Paste";
            this.CopyPaste.UseVisualStyleBackColor = true;
            this.CopyPaste.Click += new System.EventHandler(this.CopyPaste_Click);
            // 
            // RowDown
            // 
            this.RowDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RowDown.Location = new System.Drawing.Point(638, 483);
            this.RowDown.Name = "RowDown";
            this.RowDown.Size = new System.Drawing.Size(23, 23);
            this.RowDown.TabIndex = 30;
            this.RowDown.Text = "↓";
            this.RowDown.UseVisualStyleBackColor = true;
            this.RowDown.Click += new System.EventHandler(this.RowDown_Click);
            // 
            // RowUp
            // 
            this.RowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RowUp.Location = new System.Drawing.Point(638, 37);
            this.RowUp.Name = "RowUp";
            this.RowUp.Size = new System.Drawing.Size(23, 23);
            this.RowUp.TabIndex = 29;
            this.RowUp.Text = "↑";
            this.RowUp.UseVisualStyleBackColor = true;
            this.RowUp.Click += new System.EventHandler(this.RowUp_Click);
            // 
            // KeysOrder
            // 
            this.KeysOrder.AutoSize = true;
            this.KeysOrder.Location = new System.Drawing.Point(397, 45);
            this.KeysOrder.Name = "KeysOrder";
            this.KeysOrder.Size = new System.Drawing.Size(95, 13);
            this.KeysOrder.TabIndex = 28;
            this.KeysOrder.Text = "Action Keys Order:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(261, 411);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Key
            // 
            this.Key.FormattingEnabled = true;
            this.Key.Location = new System.Drawing.Point(45, 29);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(121, 21);
            this.Key.TabIndex = 39;
            this.Key.SelectedIndexChanged += new System.EventHandler(this.Key_SelectedIndexChanged);
            // 
            // AddKey
            // 
            this.AddKey.Location = new System.Drawing.Point(14, 87);
            this.AddKey.Name = "AddKey";
            this.AddKey.Size = new System.Drawing.Size(75, 23);
            this.AddKey.TabIndex = 38;
            this.AddKey.Text = "Add Key";
            this.AddKey.UseVisualStyleBackColor = true;
            this.AddKey.Click += new System.EventHandler(this.AddKey_Click);
            // 
            // SpamTime
            // 
            this.SpamTime.Location = new System.Drawing.Point(243, 54);
            this.SpamTime.Name = "SpamTime";
            this.SpamTime.Size = new System.Drawing.Size(100, 20);
            this.SpamTime.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Spam Time (Put 0 if to press one time the key):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Key:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Key);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AddKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SpamTime);
            this.groupBox1.Location = new System.Drawing.Point(18, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 145);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding a new Key:";
            // 
            // AddEvent
            // 
            this.AddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEvent.Location = new System.Drawing.Point(586, 512);
            this.AddEvent.Name = "AddEvent";
            this.AddEvent.Size = new System.Drawing.Size(75, 23);
            this.AddEvent.TabIndex = 40;
            this.AddEvent.Text = "Add Event";
            this.AddEvent.UseVisualStyleBackColor = true;
            this.AddEvent.Click += new System.EventHandler(this.AddEvent_Click);
            // 
            // WidthGroupBox
            // 
            this.WidthGroupBox.Controls.Add(this.widthToBox);
            this.WidthGroupBox.Controls.Add(this.label6);
            this.WidthGroupBox.Controls.Add(this.widthFromBox);
            this.WidthGroupBox.Controls.Add(this.label3);
            this.WidthGroupBox.Controls.Add(this.widthBetween);
            this.WidthGroupBox.Controls.Add(this.widthSmaller);
            this.WidthGroupBox.Controls.Add(this.widthBigger);
            this.WidthGroupBox.Location = new System.Drawing.Point(18, 207);
            this.WidthGroupBox.Name = "WidthGroupBox";
            this.WidthGroupBox.Size = new System.Drawing.Size(174, 149);
            this.WidthGroupBox.TabIndex = 41;
            this.WidthGroupBox.TabStop = false;
            this.WidthGroupBox.Text = "Width (Your X Position)";
            // 
            // widthToBox
            // 
            this.widthToBox.Enabled = false;
            this.widthToBox.Location = new System.Drawing.Point(66, 120);
            this.widthToBox.Name = "widthToBox";
            this.widthToBox.Size = new System.Drawing.Size(100, 20);
            this.widthToBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "To:";
            // 
            // widthFromBox
            // 
            this.widthFromBox.Location = new System.Drawing.Point(66, 94);
            this.widthFromBox.Name = "widthFromBox";
            this.widthFromBox.Size = new System.Drawing.Size(100, 20);
            this.widthFromBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "From:";
            // 
            // widthBetween
            // 
            this.widthBetween.AutoSize = true;
            this.widthBetween.Location = new System.Drawing.Point(8, 67);
            this.widthBetween.Name = "widthBetween";
            this.widthBetween.Size = new System.Drawing.Size(67, 17);
            this.widthBetween.TabIndex = 2;
            this.widthBetween.TabStop = true;
            this.widthBetween.Text = "Between";
            this.widthBetween.UseVisualStyleBackColor = true;
            this.widthBetween.CheckedChanged += new System.EventHandler(this.widthBetween_CheckedChanged);
            // 
            // widthSmaller
            // 
            this.widthSmaller.AutoSize = true;
            this.widthSmaller.Location = new System.Drawing.Point(8, 43);
            this.widthSmaller.Name = "widthSmaller";
            this.widthSmaller.Size = new System.Drawing.Size(74, 17);
            this.widthSmaller.TabIndex = 1;
            this.widthSmaller.TabStop = true;
            this.widthSmaller.Text = "Smaller (<)";
            this.widthSmaller.UseVisualStyleBackColor = true;
            // 
            // widthBigger
            // 
            this.widthBigger.AutoSize = true;
            this.widthBigger.Location = new System.Drawing.Point(8, 20);
            this.widthBigger.Name = "widthBigger";
            this.widthBigger.Size = new System.Drawing.Size(70, 17);
            this.widthBigger.TabIndex = 0;
            this.widthBigger.TabStop = true;
            this.widthBigger.Text = "Bigger (>)";
            this.widthBigger.UseVisualStyleBackColor = true;
            // 
            // HeightGroupBox
            // 
            this.HeightGroupBox.Controls.Add(this.heightToBox);
            this.HeightGroupBox.Controls.Add(this.label4);
            this.HeightGroupBox.Controls.Add(this.heightFromBox);
            this.HeightGroupBox.Controls.Add(this.label7);
            this.HeightGroupBox.Controls.Add(this.heightBetween);
            this.HeightGroupBox.Controls.Add(this.heightSmaller);
            this.HeightGroupBox.Controls.Add(this.heightBigger);
            this.HeightGroupBox.Location = new System.Drawing.Point(199, 207);
            this.HeightGroupBox.Name = "HeightGroupBox";
            this.HeightGroupBox.Size = new System.Drawing.Size(174, 149);
            this.HeightGroupBox.TabIndex = 42;
            this.HeightGroupBox.TabStop = false;
            this.HeightGroupBox.Text = "Height (Your Y Position)";
            // 
            // heightToBox
            // 
            this.heightToBox.Enabled = false;
            this.heightToBox.Location = new System.Drawing.Point(66, 120);
            this.heightToBox.Name = "heightToBox";
            this.heightToBox.Size = new System.Drawing.Size(100, 20);
            this.heightToBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To:";
            // 
            // heightFromBox
            // 
            this.heightFromBox.Location = new System.Drawing.Point(66, 94);
            this.heightFromBox.Name = "heightFromBox";
            this.heightFromBox.Size = new System.Drawing.Size(100, 20);
            this.heightFromBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "From:";
            // 
            // heightBetween
            // 
            this.heightBetween.AutoSize = true;
            this.heightBetween.Location = new System.Drawing.Point(8, 67);
            this.heightBetween.Name = "heightBetween";
            this.heightBetween.Size = new System.Drawing.Size(67, 17);
            this.heightBetween.TabIndex = 2;
            this.heightBetween.TabStop = true;
            this.heightBetween.Text = "Between";
            this.heightBetween.UseVisualStyleBackColor = true;
            this.heightBetween.CheckedChanged += new System.EventHandler(this.heightBetween_CheckedChanged);
            // 
            // heightSmaller
            // 
            this.heightSmaller.AutoSize = true;
            this.heightSmaller.Location = new System.Drawing.Point(8, 43);
            this.heightSmaller.Name = "heightSmaller";
            this.heightSmaller.Size = new System.Drawing.Size(74, 17);
            this.heightSmaller.TabIndex = 1;
            this.heightSmaller.TabStop = true;
            this.heightSmaller.Text = "Smaller (<)";
            this.heightSmaller.UseVisualStyleBackColor = true;
            // 
            // heightBigger
            // 
            this.heightBigger.AutoSize = true;
            this.heightBigger.Location = new System.Drawing.Point(8, 20);
            this.heightBigger.Name = "heightBigger";
            this.heightBigger.Size = new System.Drawing.Size(70, 17);
            this.heightBigger.TabIndex = 0;
            this.heightBigger.TabStop = true;
            this.heightBigger.Text = "Bigger (>)";
            this.heightBigger.UseVisualStyleBackColor = true;
            // 
            // autoSaveLabel
            // 
            this.autoSaveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSaveLabel.AutoSize = true;
            this.autoSaveLabel.Location = new System.Drawing.Point(489, 522);
            this.autoSaveLabel.Name = "autoSaveLabel";
            this.autoSaveLabel.Size = new System.Drawing.Size(91, 13);
            this.autoSaveLabel.TabIndex = 43;
            this.autoSaveLabel.Text = "(Data auto saves)";
            this.autoSaveLabel.Visible = false;
            // 
            // simulatorButton
            // 
            this.simulatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simulatorButton.Location = new System.Drawing.Point(400, 483);
            this.simulatorButton.Name = "simulatorButton";
            this.simulatorButton.Size = new System.Drawing.Size(70, 23);
            this.simulatorButton.TabIndex = 46;
            this.simulatorButton.Text = "Simulator";
            this.simulatorButton.UseVisualStyleBackColor = true;
            this.simulatorButton.Click += new System.EventHandler(this.simulatorButton_Click);
            // 
            // PlayerPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 540);
            this.Controls.Add(this.simulatorButton);
            this.Controls.Add(this.autoSaveLabel);
            this.Controls.Add(this.HeightGroupBox);
            this.Controls.Add(this.WidthGroupBox);
            this.Controls.Add(this.AddEvent);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.CopyPaste);
            this.Controls.Add(this.RowDown);
            this.Controls.Add(this.RowUp);
            this.Controls.Add(this.KeysOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Event);
            this.Controls.Add(this.EventTitle);
            this.Name = "PlayerPosition";
            this.Text = "AutoKeyBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerPosition_FormClosing);
            this.Load += new System.EventHandler(this.Potions_Load);
            this.Event.ResumeLayout(false);
            this.Event.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.WidthGroupBox.ResumeLayout(false);
            this.WidthGroupBox.PerformLayout();
            this.HeightGroupBox.ResumeLayout(false);
            this.HeightGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventTitle;
        private System.Windows.Forms.Label ActiveText;
        private System.Windows.Forms.RadioButton widthChoice;
        private System.Windows.Forms.GroupBox Event;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button CopyPaste;
        private System.Windows.Forms.Button RowDown;
        private System.Windows.Forms.Button RowUp;
        private System.Windows.Forms.Label KeysOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox Key;
        private System.Windows.Forms.Button AddKey;
        private System.Windows.Forms.TextBox SpamTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTexBox;
        private System.Windows.Forms.RadioButton bothChoice;
        private System.Windows.Forms.RadioButton heightChoice;
        private System.Windows.Forms.GroupBox WidthGroupBox;
        private System.Windows.Forms.TextBox widthToBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthFromBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton widthBetween;
        private System.Windows.Forms.RadioButton widthSmaller;
        private System.Windows.Forms.RadioButton widthBigger;
        private System.Windows.Forms.GroupBox HeightGroupBox;
        private System.Windows.Forms.TextBox heightToBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox heightFromBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton heightBetween;
        private System.Windows.Forms.RadioButton heightSmaller;
        private System.Windows.Forms.RadioButton heightBigger;
        private System.Windows.Forms.Label autoSaveLabel;
        private System.Windows.Forms.Button simulatorButton;
    }
}