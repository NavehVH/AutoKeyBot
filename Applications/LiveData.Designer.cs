namespace AutoKeyBot.Applications
{
    partial class LiveData
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.hpStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.otherPlayerInTheMapStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.playerPositionStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(101, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Player Data";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.hpStatus);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Location = new System.Drawing.Point(12, 161);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(332, 56);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Potions Data";
            // 
            // hpStatus
            // 
            this.hpStatus.AutoSize = true;
            this.hpStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hpStatus.Location = new System.Drawing.Point(73, 26);
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
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.otherPlayerInTheMapStatus);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.playerPositionStatus);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Location = new System.Drawing.Point(12, 77);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(332, 78);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Mini-Map Data";
            // 
            // otherPlayerInTheMapStatus
            // 
            this.otherPlayerInTheMapStatus.AutoSize = true;
            this.otherPlayerInTheMapStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.otherPlayerInTheMapStatus.Location = new System.Drawing.Point(138, 52);
            this.otherPlayerInTheMapStatus.Name = "otherPlayerInTheMapStatus";
            this.otherPlayerInTheMapStatus.Size = new System.Drawing.Size(54, 13);
            this.otherPlayerInTheMapStatus.TabIndex = 3;
            this.otherPlayerInTheMapStatus.Text = "NOT SET";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Other Player In The Map:";
            // 
            // playerPositionStatus
            // 
            this.playerPositionStatus.AutoSize = true;
            this.playerPositionStatus.ForeColor = System.Drawing.SystemColors.ControlText;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Watch the player data while editing the bot.";
            // 
            // LiveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.label1);
            this.Name = "LiveData";
            this.Text = "AutoKeyBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveData_FormClosing);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label hpStatus;
        public System.Windows.Forms.Label otherPlayerInTheMapStatus;
        public System.Windows.Forms.Label playerPositionStatus;
    }
}