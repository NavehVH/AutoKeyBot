using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.Classes;
using AutoKeyBot.Master;

namespace AutoKeyBot.Applications
{
    public partial class EditLine : Form
    {

        private int Id = 0;

        public EditLine(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private void EditLine_Load(object sender, EventArgs e)
        {
            KeystrokeBot.FillKeys(Key);
            Bot b = new Bot(Id);
            if (b.Id == 0)
            {
                MessageBox.Show("Error, please report this to the admin of this program #EditLine1#.");
                return;
            }
            Key.Text = b.Keystroke;
            SpamTime.Text = b.Timer.ToString();
        }

        private void Change_Click(object sender, EventArgs e)
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

                Bot b = new Bot(Id);

                b.Keystroke = Key.Text;
                b.Timer = spamTime;
                MessageBox.Show("Key as been edited.");
                this.Close();
            }
            else
            {
                MessageBox.Show("There is a problem with the key information you added.");
            }
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
    }
}
