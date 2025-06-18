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
    public partial class Timer : Form
    {

        //From1 = Timer
        public Timer()
        {
            InitializeComponent();
        }

        private void Potions_Load(object sender, EventArgs e)
        {
            KeystrokeBot.FillKeys(Key);
            if (Program.EventId != -1)
            {
                AddEvent.Visible = false;
                autoSaveLabel.Visible = true;

                Event eventEdit = new Event(Program.EventId);
                nameTexBox.Text = eventEdit.EventName;
                timerBox.Text = eventEdit.From1.ToString();
            }

            refreshGridView();
        }

        private void EventFormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.EventId != -1)
            {
                if (nameTexBox.Text == "")
                {
                    MessageBox.Show("You didn't name the event.");
                    e.Cancel = true;
                    return;
                }
                if (timerBox.Text == "")
                {
                    MessageBox.Show("You need ot add time.");
                    e.Cancel = true;
                    return;
                }
                double spamTime = 0;
                if (!double.TryParse(timerBox.Text, out spamTime))
                {
                    MessageBox.Show("The time needs to be a number.");
                    e.Cancel = true;
                    return;
                }
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Your keys list has 0 values.");
                    e.Cancel = true;
                    return;
                }
                AddEvent_Click(sender, (EventArgs)e);
                //Try to show event name after save
                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(RegularBot))
                        ((RegularBot)f).RefreshEventDataGridView();
                    else if (f.GetType() == typeof(Script_Bot))
                        ((Script_Bot)f).RefreshEventDataGridView();
                }
                return;
            }
        }

        private void AddEvent_Click(object sender, EventArgs e)
        {
            if (nameTexBox.Text == "")
            {
                MessageBox.Show("You didn't name the event.");
                return;
            }
            if (timerBox.Text == "")
            {
                MessageBox.Show("You need to add time.");
                return;
            }
            double spamTime = 0;
            if (!double.TryParse(timerBox.Text, out spamTime))
            {
                MessageBox.Show("The time needs to be a number.");
                return;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Your keys list has 0 values.");
                return;
            }

            if (Program.EventId != -1)
            {
                Event reSave = new Event(Program.EventId);
                EventDataSave(reSave);
                return;
            }

            Event HpEvent = new Event();
            HpEvent.BotId = Program.BotId;
            EventDataSave(HpEvent);
            //Need to add the event before the keys to get the ID.
            HpEvent.AddEvent();

            Event newEvent = new Event(HpEvent.EventName);
            Program.EventId = newEvent.Id;

            //Setting the event ID for the keys
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Bot b = new Bot(int.Parse(row.Cells[0].Value.ToString()));
                b.EventId = Program.EventId;
            }
            refreshGridView();
            MessageBox.Show("Event has been added.");
            this.Close();

        }

        private void EventDataSave(Event e)
        {
            e.EventName = nameTexBox.Text;
            e.EventType = "timer";
            e.From1 = int.Parse(timerBox.Text); //TODO Make a double 'timer' column?
        }

        private void keysDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot in order to edit this line.");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row.");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("To edit a line, you can only choose 1 row to edit.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            EditLine line = new EditLine(int.Parse(row.Cells[0].Value.ToString()));
            line.FormClosing += new FormClosingEventHandler(refreshGridView);
            Form f = line;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(this.Location.X, this.Location.Y);
            f.ShowDialog();

        }

        private void refreshGridView(object sender, FormClosingEventArgs e)
        {
            refreshGridView();
        }

        private void AddKey_Click(object sender, EventArgs e)
        {
            if (Key.Text != "")
            {
                double spamTime = 0;
                if (!double.TryParse(SpamTime.Text, out spamTime) && SpamTime.Enabled == true)
                {
                    MessageBox.Show("There is a problem with the key information you added.");
                    return;
                }
                //Data is fine

                Connection c = new Connection("program_data");
                String sqlCount = "SELECT COUNT([Position]) FROM [bot]";
                OleDbDataReader r1 = c.getDataReader(sqlCount);
                int count = 0;
                int maxPosition = 0;
                if (r1.Read())
                {
                    count = r1.GetInt32(0);
                }
                c.conClose();
                if (count != 0)
                {
                    String sqlMax = "SELECT MAX([Position]) FROM [bot]";
                    OleDbDataReader r = c.getDataReader(sqlMax);
                    if (r.Read())
                    {
                        maxPosition = r.GetInt32(0) + 1;
                    }
                    c.conClose();
                }
                else
                {
                    maxPosition = 1;
                }
                if (Program.EventId == -1)
                {
                    c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position], [botId], [eventId], [eventType]) VALUES ('" + Key.Text + "', " + spamTime + ", " + maxPosition + ", " + Program.BotId + ", -1, 'player in map')");
                }
                else
                    c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position], [botId], [eventId], [eventType]) VALUES ('" + Key.Text + "', " + spamTime + ", " + maxPosition + ", " + Program.BotId + ", " + Program.EventId + ", 'player in map')");
                MessageBox.Show("Key as been added.");
                Key.Text = "";
                SpamTime.Text = "";
                label2.Visible = true;
                refreshGridView();
            }
            else
            {
                MessageBox.Show("There is a problem with the key information you added.");
            }
        }

        private void refreshGridView()
        {
            String sql1 = "SELECT * FROM [bot] WHERE eventId = -1 ORDER BY [position] ASC";
            if (Program.BotId != 0)
            {
                sql1 = "SELECT * FROM [bot] WHERE botId = " + Program.BotId + " AND [eventId] = " + Program.EventId + " ORDER BY [position] ASC";
            }
            Connection con = new Connection("program_data");
            con.conOpen();
            OleDbCommand cmd = new OleDbCommand(sql1, con.Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false; //id
            dataGridView1.Columns[3].Visible = false; //position
            dataGridView1.Columns[4].Visible = false; //botId
            dataGridView1.Columns[5].Visible = false; //eventId
            dataGridView1.Columns[6].Visible = false; //eventType
            dataGridView1.Columns[2].HeaderText = "timer (Seconds)";
            con.conClose();
            dataGridView1.Update();
            dataGridView1.Refresh();
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedCell.Selected = false;
        }

        private void Key_SelectedIndexChanged(object sender, EventArgs e)
        {
            String keystroke = Key.Text;
            if (Key.SelectedItem != null)
            {
                if (keystroke == "STOP BOTTING" || keystroke == "UP" || keystroke == "DOWN" || keystroke == "RIGHT" || keystroke == "LEFT" || keystroke == "STOP MOVING")
                {
                    SpamTime.Text = "";
                    SpamTime.Enabled = false;
                }
                else
                {
                    SpamTime.Enabled = true;
                }
            }
        }

        private void RowUp_Click(object sender, EventArgs e)
        {
            int rowsSelected = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowsSelected++;
            }
            if (rowsSelected != 1)
            {
                MessageBox.Show("You have to choose 1 row.");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Index == 0)
                {
                    MessageBox.Show("The row you choose is already the first action.");
                    return;
                }
                int rowIndex = row.Index;
                string id = row.Cells[0].Value.ToString();
                string position = row.Cells[3].Value.ToString();
                DataGridViewRow rowUp = this.dataGridView1.Rows[row.Index - 1];
                Bot thisRow = new Bot(int.Parse(id));
                Bot otherRow = new Bot(int.Parse(rowUp.Cells[0].Value.ToString()));
                int thisRowPosition = thisRow.Position;
                thisRow.Position = otherRow.Position;
                otherRow.Position = thisRowPosition;
                refreshGridView();
                dataGridView1.Rows[rowIndex - 1].Selected = true;
                return;
            }
        }

        private void RowDown_Click(object sender, EventArgs e)
        {
            int rowsSelected = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowsSelected++;
            }
            if (rowsSelected != 1)
            {
                MessageBox.Show("You have to choose 1 row.");
                return;
            }
            Connection c = new Connection("program_data");
            int maxPosition = dataGridView1.Rows.Count - 1;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Index == maxPosition)
                {
                    MessageBox.Show("The row you choose is already the last action.");
                    return;
                }
                int rowIndex = row.Index;
                string id = row.Cells[0].Value.ToString();
                string position = row.Cells[3].Value.ToString();
                DataGridViewRow rowUp = this.dataGridView1.Rows[row.Index + 1]; //RowDown, too lazy to change name
                Bot thisRow = new Bot(int.Parse(id));
                Bot otherRow = new Bot(int.Parse(rowUp.Cells[0].Value.ToString()));
                int thisRowPosition = thisRow.Position;
                thisRow.Position = otherRow.Position;
                otherRow.Position = thisRowPosition;
                refreshGridView();
                dataGridView1.Rows[rowIndex + 1].Selected = true;
                return;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any keys to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete this keys?", "Delete Keys", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    Bot b = new Bot(int.Parse(row.Cells[0].Value.ToString()));
                    b.DeleteBot();
                }
                MessageBox.Show("Deleted the selected data successfully.");
                refreshGridView();
            }
            else
            {

            }
        }

        private void CopyPaste_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any rows to copy paste.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to copy paste this rows? They will be added as the last added keys.", "Copy Paste Keys", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[i];
                    RegularBot b = new RegularBot();
                    b.CopyPasteKey(row.Cells[1].Value.ToString(), double.Parse(row.Cells[2].Value.ToString()), Program.EventId);
                }

                MessageBox.Show("Copy paste the selected data successfully.");
                refreshGridView();
            }
            else
            {
                //Close
            }
        }
    }
}
