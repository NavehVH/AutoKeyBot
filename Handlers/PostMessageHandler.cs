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

namespace AutoKeyBot.Handlers
{
    public class PostMessageHandler
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int MapVirtualKey(int uCode, uint uMapType);

        const UInt32 WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;

        public void KeySend(int key)
        {
            var hwnd = FindWindow(Program.ProgramClass, Program.ProgramName);
            var param = (MapVirtualKey(key, 0) << 16) + 1;
            PostMessage(hwnd, WM_KEYDOWN, key, param);
            PostMessage(hwnd, WM_KEYUP, key, param);
        }
    }
}
