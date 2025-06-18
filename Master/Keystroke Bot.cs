using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.App_Data;
using AutoKeyBot.Applications;
using AutoKeyBot.Classes;

namespace AutoKeyBot.Master
{
    public partial class KeystrokeBot : Form
    {

        string FormID = string.Empty;

        public KeystrokeBot()
        {
            InitializeComponent();
        }

        public KeystrokeBot(string id)
        {
            this.FormID = id;
            InitializeComponent();
        }

        private void KeystrokeBot_Load(object sender, EventArgs e)
        {
        }

        public void OpenForm(Form newForm)
        {
            if (this.GetType() == typeof(SavedBots))
                this.Hide();
            Form f = newForm;
            if (newForm.GetType() == typeof(SavedBots))
            {
                f = Application.OpenForms[0];
            }
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(this.Location.X, this.Location.Y);
            f.Show();
            if (this.GetType() != typeof(SavedBots) && this.GetType() != typeof(HotKeyForm))
                this.Close();
        }

        public void OpenHideForm(Form newForm)
        {
            this.Hide();
            Form f = newForm;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(this.Location.X, this.Location.Y);
            f.ShowDialog();

        }

        public void OpenDialogForm(Form newForm)
        {
            Form f = newForm;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(this.Location.X, this.Location.Y);
            f.ShowDialog();
        }

        public virtual void savedBotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new SavedBots());
        }

        public virtual void regularBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.BotId = 0;
            OpenForm(new RegularBot());
        }

        public virtual void scriptBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.BotId = 0;
            OpenForm(new Script_Bot());
        }

        public virtual void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialogForm(new BotSettings());
        }

        public static void FillKeys(ComboBox cb)
        {
            string query = "SELECT [keystroke] FROM [keyshort] ORDER BY [id] DESC";
            Connection c = new Connection("program_data");
            c.conOpen();
            DataSet ds = c.getDataSet(query, "keyshort");
            cb.DataSource = ds.Tables["keyshort"].DefaultView;
            cb.DisplayMember = "keystroke";
            cb.ValueMember = "keystroke";
            c.conClose();
        }
    }
}
