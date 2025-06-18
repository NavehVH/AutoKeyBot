using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.App_Data;
using AutoKeyBot.Classes;
using AutoKeyBot.Master;

namespace AutoKeyBot.Applications
{
    public partial class SavedBots : Master.KeystrokeBot
    {
        public SavedBots() : base("SavedBots")
        {
            InitializeComponent();
        }

        private void SavedBots_Load(object sender, EventArgs e)
        {
            RefreshGridView();
            if (savedBotsDataGridView.Rows.Count > 0)
                savedBotsDataGridView.Rows[0].Selected = true;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().Equals(typeof(HotKeyForm)))
                {
                    return;
                }
            }
            HotKeyForm h = new HotKeyForm();
            OpenForm(h);
            h.Hide();
        }

        private void RefreshGridView()
        {
            String sql1 = "SELECT * FROM [saved]";
            Connection con = new Connection("program_data");
            con.conOpen();
            OleDbCommand cmd = new OleDbCommand(sql1, con.Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            savedBotsDataGridView.DataSource = table;
            savedBotsDataGridView.Columns[0].Visible = false; //id
            savedBotsDataGridView.Columns[3].Visible = false; //version
            savedBotsDataGridView.Columns[4].Visible = false; //script

            savedBotsDataGridView.Columns[2].HeaderText = "program";
            con.conClose();
            savedBotsDataGridView.Update();
            savedBotsDataGridView.Refresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete this row?", "Deleting Bot", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int rowsSelected = 0;
                foreach (DataGridViewRow row in savedBotsDataGridView.SelectedRows)
                {
                    rowsSelected++;
                }
                if (rowsSelected == 0)
                {
                    MessageBox.Show("You didn't choose any row to delete.");
                    return;
                }
                if (rowsSelected == 1)
                {
                    foreach (DataGridViewRow row in savedBotsDataGridView.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        Saved b = new Saved(int.Parse(id));
                        b.DeleteSaved();
                        MessageBox.Show("Bot as been deleted.");
                        RefreshGridView();
                    }
                }
                else
                {
                    MessageBox.Show("You can only choose 1 row to delete each time.");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                //Close
            }
        }

        private void savedBotsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (savedBotsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose a bot to use.");
                return;
            }

            if (savedBotsDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only choose one bot.");
                return;
            }
            Saved s = new Saved();
            foreach (DataGridViewRow row in savedBotsDataGridView.SelectedRows)
            {
                s = new Saved(int.Parse(row.Cells[0].Value.ToString()));
            }
            Program.BotId = s.Id;
            Form newForm = null;

            if (s.ScriptText == "" || s.ScriptText == null)
            {
                newForm = new RegularBot();
            }
            else
            {
                newForm = new Script_Bot();
            }
            OpenForm(newForm);
        }

        private void SavedBots_VisibleChanged(object sender, EventArgs e)
        {
            RefreshGridView();
        }
    }
}
