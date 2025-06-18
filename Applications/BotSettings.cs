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
using AutoKeyBot.Properties;

namespace AutoKeyBot.Applications
{
    public partial class BotSettings : Form
    {

        public BotSettings()
        {
            InitializeComponent();
        }

        private void BotSettings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PositionEventAll == false)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            } else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (Properties.Settings.Default.AddPlayerAlarm == false)
            {
                alarmCheckBox.Checked = false;
            }
            else
            {
                alarmCheckBox.Checked = true;
            }

            hoursBot.Text = Settings.Default.BotHour.ToString();
            minutesBot.Text = Settings.Default.BotMinutes.ToString();
            if (Settings.Default.BotAlarm == true)
            {
                botAlarmCheckBox.Checked = true;
            }
            else
            {
                botAlarmCheckBox.Checked = false;
            }

            if (Settings.Default.WindowPosition == true)
            {
                windowCheckBox.Checked = true;
            }
            else
            {
                windowCheckBox.Checked = false;
            }

            for (int i = 1; i <= Screen.AllScreens.Length; i++)
                comboBoxScreen.Items.Add("Screen number " + i);
            comboBoxScreen.Text = "Screen number " + (Settings.Default.ScreenUsed + 1);
        }

        private void anyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton.Checked)
            {
                if (radioButton.Name == "radioButton1")
                {
                    Properties.Settings.Default.PositionEventAll = false;
                }
                else if (radioButton.Name == "radioButton2")
                {
                    Properties.Settings.Default.PositionEventAll = true;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void alarmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (alarmCheckBox.Checked)
            {
                Properties.Settings.Default.AddPlayerAlarm = true;
            }
            else
            {
                Properties.Settings.Default.AddPlayerAlarm = false;
            }
            Properties.Settings.Default.Save();
        }

        private void botAlarmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (botAlarmCheckBox.Checked)
                Settings.Default.BotAlarm = true;
            else
                Settings.Default.BotAlarm = false;
            Settings.Default.Save();
        }

        private void TimeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            int num;
            if (!int.TryParse(tb.Text, out num))
            {
                MessageBox.Show("You can only put numbers in notification timer.");
                return;
            }

            num = int.Parse(tb.Text);
            switch(tb.Name)
            {
                case "hoursBot":
                    if (num > 24 || num < 0)
                    {
                        MessageBox.Show("Hours can only be between 0-24 hours.");
                        return;
                    }
                    break;
                case "minutesBot":
                    if (num > 59 || num < 0)
                    {
                        MessageBox.Show("Minutes can only be between 0-59 minutes.");
                        return;
                    }
                    break;
            }
            
            switch(tb.Name)
            {
                case "hoursBot":
                    Settings.Default.BotHour = num;
                    break;
                case "minutesBot":
                    Settings.Default.BotMinutes = num;
                    break;
            }

            Settings.Default.Save();
        }

        private void windowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowCheckBox.Checked)
                Settings.Default.WindowPosition = true;
            else
                Settings.Default.WindowPosition = false;

            Settings.Default.Save();
        }

        private void comboBoxScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ScreenUsed = comboBoxScreen.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
