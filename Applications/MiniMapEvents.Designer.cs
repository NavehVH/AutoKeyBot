namespace AutoKeyBot.Applications
{
    partial class MiniMapEvents
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
            this.miniMapPictureBox = new System.Windows.Forms.PictureBox();
            this.AllEventsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mapSizeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EventNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // miniMapPictureBox
            // 
            this.miniMapPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miniMapPictureBox.Location = new System.Drawing.Point(12, 60);
            this.miniMapPictureBox.Name = "miniMapPictureBox";
            this.miniMapPictureBox.Size = new System.Drawing.Size(445, 222);
            this.miniMapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.miniMapPictureBox.TabIndex = 0;
            this.miniMapPictureBox.TabStop = false;
            // 
            // AllEventsButton
            // 
            this.AllEventsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllEventsButton.Location = new System.Drawing.Point(346, 288);
            this.AllEventsButton.Name = "AllEventsButton";
            this.AllEventsButton.Size = new System.Drawing.Size(111, 23);
            this.AllEventsButton.TabIndex = 1;
            this.AllEventsButton.Text = "Show All Events";
            this.AllEventsButton.UseVisualStyleBackColor = true;
            this.AllEventsButton.Click += new System.EventHandler(this.AllEventsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Map Size: ";
            // 
            // mapSizeLabel
            // 
            this.mapSizeLabel.AutoSize = true;
            this.mapSizeLabel.Location = new System.Drawing.Point(66, 13);
            this.mapSizeLabel.Name = "mapSizeLabel";
            this.mapSizeLabel.Size = new System.Drawing.Size(34, 13);
            this.mapSizeLabel.TabIndex = 3;
            this.mapSizeLabel.Text = "(0, 0).";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position Event:";
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.AutoSize = true;
            this.EventNameLabel.Location = new System.Drawing.Point(91, 35);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(57, 13);
            this.EventNameLabel.TabIndex = 5;
            this.EventNameLabel.Text = "All Events.";
            // 
            // MiniMapEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 319);
            this.Controls.Add(this.EventNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapSizeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllEventsButton);
            this.Controls.Add(this.miniMapPictureBox);
            this.MinimumSize = new System.Drawing.Size(484, 358);
            this.Name = "AutoKeyBot";
            this.Text = "AutoKeyBot";
            this.Load += new System.EventHandler(this.MiniMapEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox miniMapPictureBox;
        private System.Windows.Forms.Button AllEventsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mapSizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EventNameLabel;
    }
}