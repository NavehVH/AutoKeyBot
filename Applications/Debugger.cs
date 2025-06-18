using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKeyBot.Applications
{
    public partial class Debugger : Form
    {
        public Debugger()
        {
            InitializeComponent();
        }

        public void Write(String text)
        {
            if (consoleTextBox.InvokeRequired)
                consoleTextBox.Invoke(new Action(() => consoleTextBox.Text += text));
            else
                consoleTextBox.Text = text;
            ScrollToBottom(consoleTextBox);
        }

        public void WriteLine(String text)
        {
            if (consoleTextBox.InvokeRequired)
                consoleTextBox.Invoke(new Action(() => consoleTextBox.Text += "\n" + text));
            else
                consoleTextBox.Text = text;
            ScrollToBottom(consoleTextBox);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        internal void ScrollToBottom(RichTextBox richTextBox)
        {
            consoleTextBox.Invoke(new Action(() => SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero)));
            consoleTextBox.Invoke(new Action(() => consoleTextBox.SelectionStart = richTextBox.Text.Length));
        }
    }
}
