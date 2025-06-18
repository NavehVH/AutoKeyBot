namespace AutoKeyBot.Master
{
    partial class KeystrokeBot
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedBotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pageToolStripMenuItem
            // 
            this.pageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savedBotsToolStripMenuItem,
            this.newBotToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.pageToolStripMenuItem.Name = "pageToolStripMenuItem";
            this.pageToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pageToolStripMenuItem.Text = "Pages";
            // 
            // savedBotsToolStripMenuItem
            // 
            this.savedBotsToolStripMenuItem.Name = "savedBotsToolStripMenuItem";
            this.savedBotsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.savedBotsToolStripMenuItem.Text = "Saved Bots";
            this.savedBotsToolStripMenuItem.Click += new System.EventHandler(this.savedBotsToolStripMenuItem_Click);
            // 
            // newBotToolStripMenuItem
            // 
            this.newBotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularBotToolStripMenuItem,
            this.scriptBotToolStripMenuItem});
            this.newBotToolStripMenuItem.Name = "newBotToolStripMenuItem";
            this.newBotToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newBotToolStripMenuItem.Text = "New Bot";
            // 
            // regularBotToolStripMenuItem
            // 
            this.regularBotToolStripMenuItem.Name = "regularBotToolStripMenuItem";
            this.regularBotToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.regularBotToolStripMenuItem.Text = "Regular Bot";
            this.regularBotToolStripMenuItem.Click += new System.EventHandler(this.regularBotToolStripMenuItem_Click);
            // 
            // scriptBotToolStripMenuItem
            // 
            this.scriptBotToolStripMenuItem.Name = "scriptBotToolStripMenuItem";
            this.scriptBotToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.scriptBotToolStripMenuItem.Text = "Script Bot";
            this.scriptBotToolStripMenuItem.Click += new System.EventHandler(this.scriptBotToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // KeystrokeBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KeystrokeBot";
            this.Text = "AutoKeyBot";
            this.Load += new System.EventHandler(this.KeystrokeBot_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savedBotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

