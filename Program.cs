using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.Applications;
using AutoKeyBot.Classes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace AutoKeyBot
{
    static class Program
    {

        public static String ProgramVersion = "1";

        public static String ProgramName = "";
        public static int BotId = 0;
        public static String Capture = "";
        public static int EventId = -1;
        public static String ProgramClass = null; //The program defined "Class" variable (usually null, check this)

        [DllImport("kernel32")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                EnforceAdminPrivilegesWorkaround();
                AllocConsole();
                var handle = GetConsoleWindow();

                // Hide
                ShowWindow(handle, SW_HIDE);
                Application.Run(new SavedBots());
        }

        public static void EnforceAdminPrivilegesWorkaround()
        {
            RegistryKey rk;
            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";

            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                }
                else
                {
                    rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                }

                rk = rk.OpenSubKey(registryPath, true);
            }
            catch (System.Security.SecurityException ex)
            {
                String error = ex.ToString();
                MessageBox.Show("Please run as an administrator.");
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
