namespace AutoKeyBot.Applications
{
    partial class BotSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.alarmCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botAlarmCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hoursBot = new System.Windows.Forms.TextBox();
            this.minutesBot = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.windowCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBoxScreen = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(5, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regular Bot Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(9, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 93);
            this.panel1.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 60);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(408, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Exit event when player finishes all the keys in the event even if he is out of ra" +
    "nge.";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.anyRadioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(253, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Exit event when player is out of the event range.";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.anyRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose player position events behavior:";
            // 
            // alarmCheckBox
            // 
            this.alarmCheckBox.AutoSize = true;
            this.alarmCheckBox.Location = new System.Drawing.Point(12, 36);
            this.alarmCheckBox.Name = "alarmCheckBox";
            this.alarmCheckBox.Size = new System.Drawing.Size(297, 17);
            this.alarmCheckBox.TabIndex = 2;
            this.alarmCheckBox.Text = "Notification sound while there is another player in the map";
            this.alarmCheckBox.UseVisualStyleBackColor = true;
            this.alarmCheckBox.CheckedChanged += new System.EventHandler(this.alarmCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "(Auto saves to all bots)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bot Settings";
            // 
            // botAlarmCheckBox
            // 
            this.botAlarmCheckBox.AutoSize = true;
            this.botAlarmCheckBox.Location = new System.Drawing.Point(12, 59);
            this.botAlarmCheckBox.Name = "botAlarmCheckBox";
            this.botAlarmCheckBox.Size = new System.Drawing.Size(320, 17);
            this.botAlarmCheckBox.TabIndex = 5;
            this.botAlarmCheckBox.Text = "Notification sound after time passed from when the bot started:";
            this.botAlarmCheckBox.UseVisualStyleBackColor = true;
            this.botAlarmCheckBox.CheckedChanged += new System.EventHandler(this.botAlarmCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hours:";
            // 
            // hoursBot
            // 
            this.hoursBot.Location = new System.Drawing.Point(62, 75);
            this.hoursBot.Name = "hoursBot";
            this.hoursBot.Size = new System.Drawing.Size(36, 20);
            this.hoursBot.TabIndex = 7;
            this.hoursBot.TextChanged += new System.EventHandler(this.TimeTextBox_TextChanged);
            // 
            // minutesBot
            // 
            this.minutesBot.Location = new System.Drawing.Point(154, 75);
            this.minutesBot.Name = "minutesBot";
            this.minutesBot.Size = new System.Drawing.Size(36, 20);
            this.minutesBot.TabIndex = 9;
            this.minutesBot.TextChanged += new System.EventHandler(this.TimeTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = ", Minutes:";
            // 
            // windowCheckBox
            // 
            this.windowCheckBox.AutoSize = true;
            this.windowCheckBox.Location = new System.Drawing.Point(15, 101);
            this.windowCheckBox.Name = "windowCheckBox";
            this.windowCheckBox.Size = new System.Drawing.Size(375, 17);
            this.windowCheckBox.TabIndex = 15;
            this.windowCheckBox.Text = "Set my program window in the most top left side (0, 0) when starting to bot.";
            this.windowCheckBox.UseVisualStyleBackColor = true;
            this.windowCheckBox.CheckedChanged += new System.EventHandler(this.windowCheckBox_CheckedChanged);
            // 
            // comboBoxScreen
            // 
            this.comboBoxScreen.FormattingEnabled = true;
            this.comboBoxScreen.Location = new System.Drawing.Point(116, 124);
            this.comboBoxScreen.Name = "comboBoxScreen";
            this.comboBoxScreen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxScreen.TabIndex = 18;
            this.comboBoxScreen.SelectedIndexChanged += new System.EventHandler(this.comboBoxScreen_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Choose screen used:";
            // 
            // BotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 309);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxScreen);
            this.Controls.Add(this.windowCheckBox);
            this.Controls.Add(this.minutesBot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hoursBot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.botAlarmCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.alarmCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "BotSettings";
            this.Text = "AutoKeyBot";
            this.Load += new System.EventHandler(this.BotSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox alarmCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox botAlarmCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox hoursBot;
        private System.Windows.Forms.TextBox minutesBot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox windowCheckBox;
        private System.Windows.Forms.ComboBox comboBoxScreen;
        private System.Windows.Forms.Label label10;
    }
}