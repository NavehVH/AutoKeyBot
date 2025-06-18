namespace AutoKeyBot.Applications
{
    partial class EditLine
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
            this.Key = new System.Windows.Forms.ComboBox();
            this.SpamTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TopLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Key
            // 
            this.Key.FormattingEnabled = true;
            this.Key.Location = new System.Drawing.Point(46, 25);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(121, 21);
            this.Key.TabIndex = 20;
            this.Key.SelectedIndexChanged += new System.EventHandler(this.Key_SelectedIndexChanged);
            // 
            // SpamTime
            // 
            this.SpamTime.Location = new System.Drawing.Point(244, 50);
            this.SpamTime.Name = "SpamTime";
            this.SpamTime.Size = new System.Drawing.Size(100, 20);
            this.SpamTime.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Spam Time (Put 0 if to press one time the key):";
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(12, 9);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(72, 13);
            this.TopLabel.TabIndex = 17;
            this.TopLabel.Text = "Editing a Key;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Key:";
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(293, 84);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 21;
            this.Change.Text = "Change";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // EditLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 119);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.SpamTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.label1);
            this.Name = "EditLine";
            this.Text = "AutoKeyBot";
            this.Load += new System.EventHandler(this.EditLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Key;
        private System.Windows.Forms.TextBox SpamTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Change;
    }
}