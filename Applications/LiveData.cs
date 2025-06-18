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

namespace AutoKeyBot.Applications
{
    public partial class LiveData : Form
    {

        public Form bottingForm;

        public LiveData()
        {
            InitializeComponent();
        }

        public LiveData(Form botting)
        {
            InitializeComponent();
            bottingForm = botting;
        }

        public void LabelUse(Label label, String text)
        {
            if (label.InvokeRequired)
                label.Invoke(new Action(() => label.Text = text));
            else
                label.Text = text;
        }

        private void LiveData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bottingForm.GetType() == typeof(RegularBot))
            {
                if (((RegularBot)bottingForm).LiveDataOpen == true)
                {
                    ((RegularBot)bottingForm).LiveDataOpen = false;
                    ((RegularBot)bottingForm).BottingStop();
                }
            }
            else if (bottingForm.GetType() == typeof(Script_Bot))
            {
                if (((Script_Bot)bottingForm).LiveDataOpen == true)
                {
                    ((Script_Bot)bottingForm).LiveDataOpen = false;
                    ((Script_Bot)bottingForm).BottingStop();
                }
            }
        }
    }
}
