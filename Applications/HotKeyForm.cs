using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.Handlers;

namespace AutoKeyBot.Applications
{
    public partial class HotKeyForm : Form
    {
        public HotKeyForm()
        {
            InitializeComponent();
        }

        public static KeyHandler ghk;

        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            if (ghk == null)
            {
                ghk = new KeyHandler((Keys)SendInputHandler.VirtualKeyShort.F10, this);
                ghk.Register();
            }
        }

        private void HandleHotkey()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().Equals(typeof(RegularBot)))
                {
                    ((RegularBot)f).HandleHotkeys();
                    return;
                }
                else if (f.GetType().Equals(typeof(Script_Bot)))
                {
                    ((Script_Bot)f).HandleHotkeys();
                    return;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}
