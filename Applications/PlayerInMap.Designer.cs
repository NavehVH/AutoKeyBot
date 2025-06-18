namespace AutoKeyBot.Applications
{
    partial class PlayerInMap
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
            this.biggerRadio = new System.Windows.Forms.RadioButton();
            this.Event = new System.Windows.Forms.GroupBox();
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
            this.autoSaveLabel = new System.Windows.Forms.Label();
            this.Event.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventTitle
            // 
            this.EventTitle.AutoSize = true;
            this.EventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitle.Location = new System.Drawing.Point(12, 9);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.Size = new System.Drawing.Size(279, 31);
            this.EventTitle.TabIndex = 0;
            this.EventTitle.Text = "Players In Map Event:";
            // 
            // ActiveText
            // 
            this.ActiveText.AutoSize = true;
            this.ActiveText.Location = new System.Drawing.Point(6, 52);
            this.ActiveText.Name = "ActiveText";
            this.ActiveText.Size = new System.Drawing.Size(238, 13);
            this.ActiveText.TabIndex = 1;
            this.ActiveText.Text = "Activate event when there is a Player in the map:";
            // 
            // biggerRadio
            // 
            this.biggerRadio.AutoSize = true;
            this.biggerRadio.Location = new System.Drawing.Point(6, 85);
            this.biggerRadio.Name = "biggerRadio";
            this.biggerRadio.Size = new System.Drawing.Size(47, 17);
            this.biggerRadio.TabIndex = 2;
            this.biggerRadio.TabStop = true;
            this.biggerRadio.Text = "True";
            this.biggerRadio.UseVisualStyleBackColor = true;
            // 
            // Event
            // 
            this.Event.Controls.Add(this.label2);
            this.Event.Controls.Add(this.nameTexBox);
            this.Event.Controls.Add(this.ActiveText);
            this.Event.Controls.Add(this.biggerRadio);
            this.Event.Location = new System.Drawing.Point(18, 43);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(355, 112);
            this.Event.TabIndex = 4;
            this.Event.TabStop = false;
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
            this.nameTexBox.Size = new System.Drawing.Size(250, 20);
            this.nameTexBox.TabIndex = 6;
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.Location = new System.Drawing.Point(476, 271);
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
            this.CopyPaste.Location = new System.Drawing.Point(557, 271);
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
            this.RowDown.Location = new System.Drawing.Point(638, 271);
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
            this.RowUp.Location = new System.Drawing.Point(638, 30);
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
            this.KeysOrder.Location = new System.Drawing.Point(397, 43);
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
            this.dataGridView1.Location = new System.Drawing.Point(400, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(261, 206);
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
            this.groupBox1.Location = new System.Drawing.Point(18, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 145);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding a new Key:";
            // 
            // AddEvent
            // 
            this.AddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEvent.Location = new System.Drawing.Point(586, 300);
            this.AddEvent.Name = "AddEvent";
            this.AddEvent.Size = new System.Drawing.Size(75, 23);
            this.AddEvent.TabIndex = 40;
            this.AddEvent.Text = "Add Event";
            this.AddEvent.UseVisualStyleBackColor = true;
            this.AddEvent.Click += new System.EventHandler(this.AddEvent_Click);
            // 
            // autoSaveLabel
            // 
            this.autoSaveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSaveLabel.AutoSize = true;
            this.autoSaveLabel.Location = new System.Drawing.Point(489, 310);
            this.autoSaveLabel.Name = "autoSaveLabel";
            this.autoSaveLabel.Size = new System.Drawing.Size(91, 13);
            this.autoSaveLabel.TabIndex = 44;
            this.autoSaveLabel.Text = "(Data auto saves)";
            this.autoSaveLabel.Visible = false;
            // 
            // PlayerInMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 332);
            this.Controls.Add(this.autoSaveLabel);
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
            this.Name = "PlayerInMap";
            this.Text = "AutoKeyBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventFormClosing);
            this.Load += new System.EventHandler(this.Potions_Load);
            this.Event.ResumeLayout(false);
            this.Event.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventTitle;
        private System.Windows.Forms.Label ActiveText;
        private System.Windows.Forms.RadioButton biggerRadio;
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
        private System.Windows.Forms.Label autoSaveLabel;
    }
}