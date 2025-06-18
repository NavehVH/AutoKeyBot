using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.App_Data;
using AutoKeyBot.Classes;
using AutoKeyBot.Handlers;
using System.Media;
using AForge.Imaging;
using AutoKeyBot.Properties;

namespace AutoKeyBot.Applications
{
    public partial class Script_Bot : AutoKeyBot.Master.KeystrokeBot
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx",
  CharSet = CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        uint SWP_NOSIZE = 1;

        public Connection c = new Connection("program_data");
        public static PostMessageHandler P = new PostMessageHandler();
        public static SendInputHandler S = new SendInputHandler();
        public static String ScriptText;


        List<System.Windows.Forms.Timer> Timerlist = new List<System.Windows.Forms.Timer>();
        private DateTime BottingTime = new DateTime();
        private DateTime BottingAlarmTime = new DateTime();

        Thread ThreadBotting;
        Thread ThreadHealthBar;
        Thread ThreadPlayerLocation;
        Thread ThreadOtherPlayer;
        Thread ThreadMouse;

        public int MyHealth = 100;
        public int MyMana = 100;
        public Point MyPosition = new Point(-100, -100);
        public Boolean OtherPeopleInMap = false;

        String ScriptTextChange = "";

        private bool OnScriptTab = false; //Check when he uses script tab
        private bool PauseScript = false;

        public Boolean ConsoleOpen = false;
        public Boolean LiveDataOpen = false;
        LiveData liveData = null;

        private bool ClickedExit = false;

        public Script_Bot() : base("Script_Bot")
        {
            InitializeComponent();
        }

        public OleDbDataAdapter OleDbDataAdapter { get; private set; }
        public object Dispatcher { get; private set; }

        private void Script_Bot_Load(object sender, EventArgs e)
        {
            FillKeys(Key);
            RefreshEventDataGridView();
            cropImageComboBox.Text = cropImageComboBox.Items[0].ToString();

            CheckScreenShots();


            if (Program.BotId == 0)
            {
                ScriptRichTextBox.Text = "" +
                    "public void Main()\n" +
                    "{\n" +
                    "\n" +
                    "}";
            }

            ScriptText = ScriptRichTextBox.Text;

            if (Program.BotId != 0)
            {
                Saved s = new Saved(Program.BotId);

                botNameTextBox.Text = s.Bot;
                ScriptRichTextBox.Text = s.ScriptText;
            }
            ScriptTextChange = ScriptRichTextBox.Text;
            ScriptColorChange();
        }

        //Checking screen shots if pictures are set
        public void CheckScreenShots()
        {
            //Check if there screenshots
            ScreenShot health = new ScreenShot(Program.BotId, "health");
            if (health.Id != 0)
            {
                hpStatus.Text = "SET";
                hpStatus.ForeColor = Color.Green;
            }
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            if (map.Id != 0)
            {
                playerPositionStatus.Text = "SET";
                playerPositionStatus.ForeColor = Color.Green;
                otherPlayerInTheMapStatus.Text = "SET";
                otherPlayerInTheMapStatus.ForeColor = Color.Green;
            }
        }

        //Clicked stop botting button
        private void StopBotting_Click(object sender, EventArgs e)
        {
            BottingStop();
        }

        //Stops the botting action
        public void BottingStop()
        {
            if (botStatus.Text != "Running.")
            {
                MessageBox.Show("The bot isn't running.");
                return;
            }

            foreach (Form f in Application.OpenForms)
                if (f.GetType() == typeof(LiveData))
                {
                    f.Close();
                    break;
                }
            LiveDataOpen = false;

            if (ThreadBotting != null)
                if (ThreadBotting.IsAlive)
                    ThreadBotting.Abort();
            if (ThreadHealthBar != null)
                if (ThreadHealthBar.IsAlive)
                    ThreadHealthBar.Abort();
            if (ThreadPlayerLocation != null)
                if (ThreadPlayerLocation.IsAlive)
                    ThreadPlayerLocation.Abort();
            if (ThreadOtherPlayer != null)
                if (ThreadOtherPlayer.IsAlive)
                    ThreadOtherPlayer.Abort();
            ThreadBotting = new Thread(BottingThread);
            ThreadHealthBar = new Thread(HpThread);
            ThreadPlayerLocation = new Thread(PlayerPositionThread);
            ThreadOtherPlayer = new Thread(OtherPlayerInMapThread);

            if (ThreadMouse != null)
            {
                if (ThreadMouse.IsAlive)
                {
                    ThreadMouse.Abort();
                    MousePositionLabel.Text = "(X, Y)";
                }
            }

            //Stop all timer events
            foreach (var timer in Timerlist)
            {
                timer.Stop();
            }

            //Reset player in map boolean
            OtherPeopleInMap = false;


            StopMoving();

            //if (ConsoleOpen)
            //{
            //    var handle = GetConsoleWindow();
            //
            //    // Hide
            //   ShowWindow(handle, SW_HIDE);
            //    ConsoleOpen = false;
            //}

            if (PauseScript == true)
            {
                PauseScript = false;
                pauseButton.Text = "Pause";
            }

            botStatus.Text = "Botting stopped.";
            botStatus.ForeColor = Color.Red;
            //Reset messages
            CheckScreenShots();
            IntPtr Focus = SendInputHandler.FindWindow(Program.ProgramClass, Program.ProgramName);
            SendInputHandler.SetForegroundWindow(Focus);
        }

        private void PictureDetectionBotButton_Click(object sender, EventArgs e)
        {

            if (botStatus.Text == "Running.")
            {
                MessageBox.Show("The bot is already running.");
                return;
            }

            IntPtr Focus = SendInputHandler.FindWindow(Program.ProgramClass, Program.ProgramName);
            if (Focus == IntPtr.Zero)
            {
                MessageBox.Show("The program couldn't be found. Program name must be wrong or program isn't running.");
                return;
            }

            if (!LiveDataOpen)
            {
                LiveDataOpen = true;
                liveData = new LiveData(this);
                liveData.StartPosition = FormStartPosition.Manual;
                liveData.Location = new Point(this.Location.X, this.Location.Y);
                liveData.Show();
            }

            ThreadHealthBar = new Thread(HpThread);
            ThreadPlayerLocation = new Thread(PlayerPositionThread);
            ThreadOtherPlayer = new Thread(OtherPlayerInMapThread);

            ThreadMouse = new Thread(GetMousePosition);
            ThreadMouse.Start();

            ScreenShot health = new ScreenShot(Program.BotId, "health");
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            if (health.Id != 0)
                ThreadHealthBar.Start();
            if (map.Id != 0)
            {
                ThreadPlayerLocation.Start();
                ThreadOtherPlayer.Start();
            }
            botStatus.Text = "Running.";
            botStatus.ForeColor = Color.Green;
            SendInputHandler.SetForegroundWindow(Focus);
        }

        //Button to start botting and starting threads
        public void StartBotting_Click(object sender, EventArgs e)
        {

            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the script bot before running it.");
                return;
            }


            ScriptText = ScriptRichTextBox.Text;

            if (botStatus.Text == "Running.")
            {
                MessageBox.Show("The bot is already running.");
                return;
            }

            IntPtr Focus = SendInputHandler.FindWindow(Program.ProgramClass, Program.ProgramName);
            if (Focus == IntPtr.Zero)
            {
                MessageBox.Show("The program couldn't be found. Client name must be wrong or program isn't running.");
                return;
            }
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            if (map.Id == 0)
            {
                MessageBox.Show("Please set your mini-map picture detect settings before botting.");
                return;
            }

            ThreadHealthBar = new Thread(HpThread);
            ThreadPlayerLocation = new Thread(PlayerPositionThread);
            ThreadOtherPlayer = new Thread(OtherPlayerInMapThread);
            ThreadBotting = new Thread(BottingThread);


            ThreadMouse = new Thread(GetMousePosition);
            ThreadMouse.Start();



            //Timer events accour
            BottingTime = DateTime.Now;
            BottingAlarmTime = DateTime.Now.AddHours(Properties.Settings.Default.BotHour);
            BottingAlarmTime = BottingAlarmTime.AddMinutes(Properties.Settings.Default.BotMinutes);

            System.Windows.Forms.Timer timer1;

            //Set botting time
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler((sender2, e2) => Timer_SetTextTimers(sender, e));
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
            Timerlist.Add(timer1);

            foreach (DataGridViewRow row in eventsDataGridView.Rows)
            {
                Event eEdit = new Event(int.Parse(row.Cells[0].Value.ToString()));
                if (eEdit.EventType == "timer")
                {
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler((sender2, e2) => Timer_TickAccour(sender, e, eEdit));
                    timer1.Interval = eEdit.From1 * 1000; // in miliseconds
                    timer1.Start();
                    Timerlist.Add(timer1);
                }
            }

            ScreenShot health = new ScreenShot(Program.BotId, "health");
            ScreenShot mana = new ScreenShot(Program.BotId, "mana");

            if (health.Id != 0)
                ThreadHealthBar.Start();;
            if (map.Id != 0)
            {
                ThreadPlayerLocation.Start();
                ThreadOtherPlayer.Start();
            }
            botStatus.Text = "Running.";
            botStatus.ForeColor = Color.Green;
            ThreadBotting.Start();
            if (Properties.Settings.Default.WindowPosition == true)
            {
                Rectangle screen = Screen.AllScreens[Settings.Default.ScreenUsed].WorkingArea;
                SetWindowPos(Focus, (IntPtr)0, screen.X, screen.Y, 240, 26, SWP_NOSIZE);
            }
            SendInputHandler.SetForegroundWindow(Focus);
        }

        private void PlayNotificationSound()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                SoundPlayer simpleSound = new SoundPlayer(path + @"Media\MessageTone.wav");
                simpleSound.Play();
            }
            catch
            {
                if (botStatus.Text == "Running.")
                {
                    stopBottingButton.PerformClick();
                }
                MessageBox.Show("An error with the notification has happenened.");
            }
        }

        private void PlayNotificationSound2()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                SoundPlayer simpleSound = new SoundPlayer(path + @"Media\MessageTone2.wav");
                simpleSound.Play();
            }
            catch
            {
                if (botStatus.Text == "Running.")
                {
                    stopBottingButton.PerformClick();
                }
                MessageBox.Show("An error with the notification has happenened.");
            }
        }

        private void Timer_SetTextTimers(object sender, EventArgs e)
        {
            var diff = DateTime.Now.Subtract(BottingTime);
            if (diff.Hours == 0)
            {
                bottingTimeLabel.Text = string.Format("{0:D2}:{1:D2}",
                                   diff.Minutes, diff.Seconds);
            }
            else
            {
                bottingTimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                       diff.Hours, diff.Minutes, diff.Seconds);
            }

            if (DateTime.Now > BottingAlarmTime && Properties.Settings.Default.BotAlarm == true)
                PlayNotificationSound();
        }

        //TODO Check if it works good with regular botting...
        private void Timer_TickAccour(object sender, EventArgs e, Event eEdit)
        {
            if (PauseScript)
                return;

            Connection c = new Connection("program_data");
            c.conOpen();
            DataSet eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + eEdit.Id + "", "bot");
            foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
            {
                string keystroke = rowEventKey[1].ToString();
                double timer = double.Parse(rowEventKey[2].ToString());
                KeyPressBot(keystroke, timer);
            }
            c.conClose();
        }

        //The HP thread, updates the HP of the player based on screenshots
        private void HpThread()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(250);
                Bitmap health = CaptureScreen("health");
                //HpbotStatus.Text = DetectBar("health").ToString() + "%";
                String hpString = DetectBar("health").ToString();
                MyHealth = int.Parse(hpString);
                if (LiveDataOpen)
                {
                    liveData.LabelUse(liveData.hpStatus, hpString + "%");
                }
                hpStatus.Invoke(new Action(() => hpStatus.Text = hpString + "%"));
            }
        }

        //Player position thread, checks the player position based on map screenshots
        private void PlayerPositionThread()
        {
            Point location;
            Bitmap map;
            while (true)
            {
                map = CaptureScreen("map");
                location = PlayerPosition();
                MyPosition = new Point(location.X, location.Y);
                playerPositionStatus.Invoke(new Action(() => playerPositionStatus.Text = "(" + location.X.ToString() + ", " + location.Y.ToString() + ")"));
                if (LiveDataOpen)
                {
                    liveData.LabelUse(liveData.playerPositionStatus, "(" + location.X.ToString() + ", " + location.Y.ToString() + ")");
                }

                System.Threading.Thread.Sleep(20);
            }
        }

        //Other player in map thread, checks if there other player in the map based on the red player dot color in the mini map
        private void OtherPlayerInMapThread()
        {
            Bitmap map;
            String otherPlayerInMap;
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                map = CaptureScreen("map");
                otherPlayerInMap = OtherPlayerInMap().ToString();
                otherPlayerInTheMapStatus.Invoke(new Action(() => otherPlayerInTheMapStatus.Text = otherPlayerInMap));
                if (LiveDataOpen)
                {
                    liveData.LabelUse(liveData.otherPlayerInTheMapStatus, otherPlayerInMap);
                }
                OtherPeopleInMap = Boolean.Parse(otherPlayerInMap);
                if (Properties.Settings.Default.AddPlayerAlarm == true && OtherPeopleInMap)
                    PlayNotificationSound();
            }
        }

        /*
        private void eventAccour()
        {
            string keystroke;
            double timer;
            foreach (DataGridViewRow rowEvent in dataGridView2.Rows)
            {
                Event eEdit = new Event(int.Parse(rowEvent.Cells[0].Value.ToString()));
                DataSet eventData;
                Boolean eventHappened = false;
                switch (eEdit.EventType) //Check type of event and if happened
                {
                    case "health":
                        if (eEdit.Bigger1 == true && eEdit.From1 < MyHealth)
                        {
                            eventHappened = true;
                        }
                        else if (eEdit.Bigger1 == false && eEdit.From1 > MyHealth)
                        {
                            eventHappened = true;
                        }
                        break;
                    case "player position":
                        eventHappened = PlayerPositionEventHappened(eEdit);
                        break;
                    case "player in map":
                        if (OtherPeopleInMap == true)
                        {
                            eventHappened = true;
                        }
                        break;
                    case "mana":
                        if (eEdit.Bigger1 == true && eEdit.From1 < MyMana)
                        {
                            eventHappened = true;
                        }
                        else if (eEdit.Bigger1 == false && eEdit.From1 > MyMana)
                        {
                            eventHappened = true;
                        }
                        break;
                }
                if (eventHappened == true)
                {
                    EventRunningText.Invoke(new Action(() => EventRunningText.Text = eEdit.EventName));
                    EventRunningText.ForeColor = Color.Green;
                    if (MiniOpen == true)
                    {
                        MiniB.LabelUse(MiniB.EventRunningText, eEdit.EventName);
                        MiniB.LabelColor(MiniB.EventRunningText, Color.Green);
                    }
                    Connection c = new Connection("program_data");
                    c.conOpen();
                    eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + eEdit.Id + "", "bot");
                    foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
                    {
                        keystroke = rowEventKey[1].ToString();
                        timer = double.Parse(rowEventKey[2].ToString());
                        KeyPressBot(keystroke, timer);
                    }
                    c.conClose();
                }
            }
        }
        */

        //Do 1 action of keystroke as bot
        public void KeyPressBot(String keystroke, double timer)
        {
            Random r = new Random();
            double random = r.NextDouble() * (1 - 0.9) + 0.9;
            Keyshort k;
            k = new Keyshort(keystroke);

            if (keystroke != "STOP BOTTING" && keystroke != "UP" && keystroke != "DOWN" && keystroke != "RIGHT" && keystroke != "LEFT" && keystroke != "STOP MOVING")
            {
                if (timer != 0)
                {
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    while (s.Elapsed < TimeSpan.FromSeconds(timer))
                    {
                        if (keystroke != "DELAY")
                        {
                            int shorter = Convert.ToInt32(k.Shorter, 16);
                            P.KeySend(shorter);
                            System.Threading.Thread.Sleep((int)(100 * random));
                        }
                    }
                    s.Stop();
                    if (keystroke == "DELAY")
                    {
                        int time = (int)(timer * 1000 * random);
                        System.Threading.Thread.Sleep(time);
                    }
                }
                else
                {
                    if (keystroke != "DELAY")
                    {
                        int shorter = Convert.ToInt32(k.Shorter, 16);
                        P.KeySend(shorter);
                        System.Threading.Thread.Sleep((int)(100 * random));
                    }
                }
            }
            else if (keystroke == "STOP MOVING")
            {
                StopMoving();
            }
            else if (keystroke == "STOP BOTTING")
            {
                stopBottingButton.Invoke(new Action(() => stopBottingButton.PerformClick()));
            }
            else
            {
                StopMoving();
                var hwnd = FindWindow(Program.ProgramClass, Program.ProgramName);
                var currentWindow = GetForegroundWindow();

                if (hwnd == currentWindow)
                {
                    switch (keystroke)
                    {
                        case "UP":
                            S.KeySend(SendInputHandler.VirtualKeyShort.UP);
                            break;
                        case "DOWN":
                            S.KeySend(SendInputHandler.VirtualKeyShort.DOWN);
                            break;
                        case "RIGHT":
                            S.KeySend(SendInputHandler.VirtualKeyShort.RIGHT);
                            break;
                        case "LEFT":
                            S.KeySend(SendInputHandler.VirtualKeyShort.LEFT);
                            break;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep((int)(1000 * random));
                }
            }
        }

        //Stop moving action
        public void StopMoving()
        {
            S.KeyUp(SendInputHandler.VirtualKeyShort.UP);
            S.KeyUp(SendInputHandler.VirtualKeyShort.DOWN);
            S.KeyUp(SendInputHandler.VirtualKeyShort.RIGHT);
            S.KeyUp(SendInputHandler.VirtualKeyShort.LEFT);
        }

        //Saving bot
        private void Save_Click(object sender, EventArgs e)
        {
            if (botNameTextBox.Text == "")
            {
                MessageBox.Show("You didn't add a name to the bot.");
                return;
            }

            if (ScriptRichTextBox.Text == "")
            {
                MessageBox.Show("You didn't write a script.");
                return;
            }

            Boolean noId = false;

            Connection c = new Connection("program_data");
            String botNameSql = "SELECT bot FROM saved WHERE bot = '" + botNameTextBox.Text + "'";
            OleDbDataReader r = c.getDataReader(botNameSql);
            if (r.Read())
            {
                Saved s = new Saved(botNameTextBox.Text);
                if (!(s.Bot == botNameTextBox.Text && s.Id.ToString() == Program.BotId.ToString()))
                {
                    MessageBox.Show("There is already a bot with that name.");
                    return;
                }
                c.conClose();
            }
            else
            {
                c.conClose();
                if (Program.BotId == 0)
                {
                    c.NonQuery("INSERT INTO saved (bot, client, version, scriptText) VALUES ('" + botNameTextBox.Text + "', '', 0, '')");
                    noId = true;
                }
            }

            if (noId == true)
            {
                String maxIdSql = "SELECT MAX(id) FROM saved";
                OleDbDataReader r1 = c.getDataReader(maxIdSql);
                int maxId = 1;
                if (r1.Read())
                {
                    maxId = r1.GetInt32(0);
                }
                c.conClose();
                c.NonQuery("UPDATE bot SET botId = " + maxId + " WHERE botId IS NULL");
            }

            if (Program.BotId != 0)
            {
                string sqlUpdate = "UPDATE saved SET bot = '" + botNameTextBox.Text + "', client = '', version = 0, scriptText = '' WHERE id = " + Program.BotId + "";
                c.NonQuery(sqlUpdate);
            }

            if (Program.BotId == 0)
                MessageBox.Show("Bot saved.");
            else
                MessageBox.Show("Updated bot data.");

            //Add bot ID to saved screenshots.
            if (Program.BotId == 0)
            {
                String maxIdSql = "SELECT MAX(id) FROM saved";
                OleDbDataReader r1 = c.getDataReader(maxIdSql);
                int maxId = 1;
                if (r1.Read())
                {
                    maxId = r1.GetInt32(0);
                }
                c.conClose();
                c.NonQuery("UPDATE screenshot SET botId = " + maxId + " WHERE botId = 0");
                Program.BotId = maxId;
            }
        }

        //i don't remember why i need this ??
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            CheckScreenShots();
        }

        //capture specific location of screen
        public Bitmap CaptureScreen(String Capture)
        {
            if (Capture == "player position" || Capture == "player in map")
                Capture = "map";
            ScreenShot s = new ScreenShot(Program.BotId, Capture);
            var image = new Bitmap(s.PictureWidth, s.PictureHeight, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            //gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy); //All Screen
            gfx.CopyFromScreen(s.XUpperLeftCornerSource, s.YUpperLeftCornerSource, s.XUpperLeftCornerDestination, s.YUpperLeftCornerDestination, new System.Drawing.Size(s.PictureWidth, s.PictureHeight), CopyPixelOperation.SourceCopy);
            return image;
        }

        //detects HP true data
        private int DetectBar(String Capture)
        {
            Saved s = new Saved(Program.BotId);
            int percent = 0;
            Bitmap bmp = CaptureScreen(Capture);
                percent = 0;
                for (int i = 0; i < 100; i++)
                {
                    double color = ((double)bmp.Width / 100) * i;
                    Color now_color = bmp.GetPixel((int)color, bmp.Height / 2);
                    String nC = now_color.Name;
                    if (nC.Equals("ff68656b"))
                        break;
                    percent++;
            }
            return percent;
        }

        //detect player position
        private Point PlayerPosition()
        {
            String PlayerDot = ""; //Player

            Saved s = new Saved(Program.BotId);

            Bitmap bmp = CaptureScreen("map");
            Point Position = new Point();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //System.Diagnostics.Debug.WriteLine(bmp.GetPixel(i, j).Name + ", " + PlayerDot);
                    if (bmp.GetPixel(i, j).Name.Equals(PlayerDot))
                    {
                        Position = new Point(i, bmp.Height - j);
                        return Position;
                    }
                }
            }
            return Position;
        }

        //detect other player in map
        private Boolean OtherPlayerInMap()
        {
            String OtherPlayer = ""; //Other player

            Bitmap bmp = CaptureScreen("map");
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (bmp.GetPixel(i, j).Name.Equals(OtherPlayer))
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        private void SetTypeButton_Click(object sender, EventArgs e)
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot first.");
                return;
            }
            if (cropImageComboBox.Text == "")
            {
                MessageBox.Show("You didn't choose type of image.");
                return;
            }
            switch (cropImageComboBox.Text)
            {
                case "HP Bar":
                    Program.Capture = "health";
                    break;
                case "Mini-Map":
                    Program.Capture = "map";
                    break;
            }
            ChooseImageBtn_Click();
        }

        //EVENT CONTROL 
        //Capture the specific picture based on the location the user gives.
        public Bitmap CaptureScreen()
        {
            ScreenShot s = new ScreenShot(Program.BotId, Program.Capture);
            var image = new Bitmap(s.PictureWidth, s.PictureHeight, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            //gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy); //All Screen
            gfx.CopyFromScreen(s.XUpperLeftCornerSource, s.YUpperLeftCornerSource, s.XUpperLeftCornerDestination, s.YUpperLeftCornerDestination, new System.Drawing.Size(s.PictureWidth, s.PictureHeight), CopyPixelOperation.SourceCopy);
            return image;
        }

        public void EventControlOnLoad()
        {
            ScreenShot s;
            Program.Capture = "map";
            s = new ScreenShot(Program.BotId, Program.Capture);
            if (s.Id != 0)
            {
                miniMapPictureBox.Image = CaptureScreen();
                miniMapGroupBox.Text = "Mini-Map Position, Map size: (" + miniMapPictureBox.Image.Width + ", " + miniMapPictureBox.Image.Height + ").";
            }
            else
                miniMapGroupBox.Text = "Mini-Map Position";

            Program.Capture = "health";
            s = new ScreenShot(Program.BotId, Program.Capture);
            if (s.Id != 0)
                hpBarPictureBox.Image = CaptureScreen();
        }

        private void ChooseImageBtn_Click()
        {
            CapturedScreen f = new CapturedScreen();
            f.InstanceRef = this;

            f.Show();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.BotId != 0 && OnScriptTab) //Save script every time he leaves the tab
            {
                Saved s = new Saved(Program.BotId);
                if (ScriptRichTextBox.Text != "")
                    s.ScriptText = ScriptRichTextBox.Text;
                OnScriptTab = false;
            }

            if ((sender as TabControl).SelectedIndex == 1) //Picture Detection
            {
                EventControlOnLoad();
            }
            else if ((sender as TabControl).SelectedIndex == 2) //Script
            {
                OnScriptTab = true;
            }
        }


        //SIH Moving, PMH Keys
        //The main thread for the botting to work
        private void BottingThread()
        {
            Random rnd = new Random();

            Saved s = new Saved(Program.BotId);

            String extraCode = "";

            String text = @"
                using System;
                using System.Drawing;
                using ScriptManagerHandler;

                namespace RoslynCompileSample
                {
                    public class Writer
                    {
                        public bool _StopMovingBecauseOfPauseBool = false;
                        public ScriptManagerHandler.ScriptHandler cm = new ScriptManagerHandler.ScriptHandler(""" + Program.ProgramClass + @""", """ + Program.ProgramName + @""", " + Program.BotId + @", false);
                        public Point MyPosition = new Point(-100, -100);
                        public int MyHealth = 100;
                        public Boolean OtherPeopleInMap = false;

                        public void UpdateMyPosition() {
                            Point location = cm._UpdatePlayerPosition();
                            MyPosition = new Point(location.X, location.Y);
                        }

                        public void _StopMovingBecuaseOfPause() {
                            if (_StopMovingBecauseOfPauseBool == false)
                            {
                                cm.StopMoving();
                                _StopMovingBecauseOfPauseBool = true;
                            }
                        }

                        public void Write(Point MyPositionR, int MyHealthR, int MyManaR, Boolean OtherPeopleInMapR)
                        {
                            if (_StopMovingBecauseOfPauseBool == true)
                                _StopMovingBecauseOfPauseBool = false;
                            this.MyPosition = new Point(MyPositionR.X, MyPositionR.Y);
                            this.MyHealth = MyHealthR;
                            this.OtherPeopleInMap = OtherPeopleInMapR;
                            Main();
                        }

                        " + ScriptText + extraCode + @"
                    }
                }";
            while (true)
            {
                ExecuteUserCode(text);
            }
        }

        public void ExecuteUserCode(String text)
        {
            // define source code, then parse it (to the type used for compilation)
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(text);
            // define other necessary objects for compilation
            string assemblyName = Path.GetRandomFileName();
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Drawing.Point).Assembly.Location),
                MetadataReference.CreateFromFile(typeof (ScriptManagerHandler.ScriptHandler).Assembly.Location),
            };

            // analyse and generate IL code from syntax tree
            CSharpCompilation compilation = CSharpCompilation.Create(
            assemblyName,
            syntaxTrees: new[] { syntaxTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                // write IL code into memory
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    // handle exceptions
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    String error = "";
                    foreach (Diagnostic diagnostic in failures)
                    {
                        error += "" + diagnostic.Id + ", " + diagnostic.GetMessage() + "\n";
                    }
                    if (error != "")
                    {
                        MessageBox.Show(error);
                        BottingStop();
                    }
                }
                else
                {
                    // load this 'virtual' DLL so that we can use
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());

                    // create instance of the desired class and call the desired function
                    Type type = assembly.GetType("RoslynCompileSample.Writer");
                    object obj = Activator.CreateInstance(type);
                    while (true)
                    {
                        if (PauseScript)
                        {
                            type.InvokeMember("_StopMovingBecuaseOfPause", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });
                        }
                        else
                        {
                            Bitmap map = CaptureScreen("map");
                            Point location = PlayerPosition();
                            MyPosition = new Point(location.X, location.Y);
                            type.InvokeMember("Write", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { MyPosition, MyHealth, MyMana, OtherPeopleInMap, false, new Point(-100, -100) });
                        }
                    }
                }
            }
        }

        public void GetMousePosition()
        {
            //Cursor.Position.X
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                String text = "(" + Cursor.Position.X + ", " + Cursor.Position.Y + ")";
                MousePositionLabel.Invoke(new Action(() => MousePositionLabel.Text = text));
            }
        }

        private void ScriptApiButton_Click(object sender, EventArgs e)
        {
            String text = @"
AutoKeyBot Script API:

* Methods to write code:
- void Main(): Your main method, here you write the script code.


* Actions:
- cm.ClickMouseDown(int x, int y, bool left): Clicking of the mouse down.
+ Parameters: X position, Y position of the position you want to be clicked down, bool for left or right.

- cm.ClickMouseUp(int x, int y, bool left): Clicking the left side of the mouse up.
+ Parameters: X position, Y position of the position you want to be clicked up.

- cm.PressKey(String keystroke, double timer): Clicking a key on the keyboard.
+ Parameters: keystroke name that can be found on the 'Keys's Names' list, timer (Seconds) time to fast spam the keyboard (Putting 0 will do one click).

- cm.StopMoving(): Making the character stop moving.
+ Parameters: NULL.

- cm.Delay(double timer): Making the program not click anything for X timer.
+ Parameters: timer (Seconds) time to not click anything.

- cm.GoRight() \ cm.GoLeft() \ cm.GoUp() \ cm.GoDown(): Go to a specific direction, player wont stop until a different location will be set or action StopMoving().
+ Parameters: NULL.

- cm.Write(String text): Write text into the debug console.
+ Parameters: Your message into the console.

- cm.WriteLine(String text): Write line of text into the debug console.
+ Parameters: Your message into the console.

- UpdateMyPosition(): a void method, updates MyPosition values when called.
+ Parameters: NULL.


*Enums:
- Directions: Can be STOP_MOVING\RIGHT\LEFT\UP\DOWN.

* Variables:
- cm.MousePosition(): Returns a Point of the mouse position.
- CurrentDirection: Returns the direction the players moves as enum.
- LastHorizontalDirection: Returns the last horizontal direction the player used as enum, LEFT\RIGHT.
- LastVerticalDirection: Returns the last vertical direction the player used as enum, UP\DOWN.


*Variables that need you need to set Picture Detection in order to work:
- MyPosition: Returns a Point of the player position.
- MyHealth: Returns Int of HP of the player.(By % 1 - 100).
- OtherPeopleInMap: Returns Boolean if there other people in the map.

";
            MessageBox.Show(text);
        }

        //Timer methods
        //Refresh event grid view
        public void RefreshEventDataGridView()
        {
            if (Program.BotId == 0)
                return;

            String sql1 = "SELECT * FROM [event] WHERE botId = " + Program.BotId + " AND [eventType] IS NOT NULL";
            Saved s = new Saved(Program.BotId);
            botNameTextBox.Text = s.Bot;
            Connection con = new Connection("program_data");
            con.conOpen();
            OleDbCommand cmd = new OleDbCommand(sql1, con.Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            eventsDataGridView.DataSource = table;
            eventsDataGridView.Columns[0].Visible = false; //id
            eventsDataGridView.Columns[1].Visible = false; //botid
            eventsDataGridView.Columns[4].Visible = false;
            eventsDataGridView.Columns[5].Visible = false;
            eventsDataGridView.Columns[6].Visible = false;
            eventsDataGridView.Columns[7].Visible = false;
            eventsDataGridView.Columns[8].Visible = false;
            eventsDataGridView.Columns[9].Visible = false;
            eventsDataGridView.Columns[10].Visible = false;
            eventsDataGridView.Columns[11].Visible = false;
            eventsDataGridView.Columns[12].Visible = false;

            eventsDataGridView.Columns[2].HeaderText = "Event Name";
            eventsDataGridView.Columns[3].HeaderText = "Event Type";
            con.conClose();
            eventsDataGridView.Update();
            eventsDataGridView.Refresh();
        }

        private void eventsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (eventsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose a event to use.");
                return;
            }

            if (eventsDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only choose one event.");
                return;
            }
            Event eEdit = new Event();
            foreach (DataGridViewRow row in eventsDataGridView.SelectedRows)
            {
                eEdit = new Event(int.Parse(row.Cells[0].Value.ToString()));
            }
            Program.EventId = eEdit.Id;

            if (eEdit.EventType == "timer")
            {
                Timer newForm = new Timer();
                OpenDialogForm(newForm);
            }
        }

        private void TimerButton_Click()
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot before you make an event.");
                return;
            }
            Connection con = new Connection("program_data");
            con.NonQuery("DELETE FROM [bot] WHERE eventid = -1"); //Delete unsaved keys...

            Program.Capture = "timer";
            Program.EventId = -1;
            Form timer = new Timer();
            timer.FormClosing += new FormClosingEventHandler(RefreshEventGridView);
            timer.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            OpenDialogForm(timer);
        }

        private void RefreshEventGridView(object sender, FormClosingEventArgs e)
        {
            RefreshEventDataGridView();
        }

        private void eventDeleteButton_Click(object sender, EventArgs e)
        {
            if (eventsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any rows to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete this rows?", "Delete Events", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in eventsDataGridView.SelectedRows)
                {
                    Event eEvent = new Event(int.Parse(row.Cells[0].Value.ToString()));
                    Connection c = new Connection("program_data");
                    c.conOpen();
                    DataSet eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + eEvent.Id + "", "bot");
                    foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
                    {
                        Bot b = new Bot(int.Parse(rowEventKey[0].ToString()));
                        b.DeleteBot();
                    }
                    c.conClose();
                    eEvent.DeleteEvent();
                }
                MessageBox.Show("Deleted the selected data successfully.");
                RefreshEventDataGridView();
            }
            else
            {
                //Close
            }
        }

        private void eventCopyPasteButton_Click(object sender, EventArgs e)
        {
            if (eventsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any events to copy paste.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to copy paste this events?", "Copy Paste Events", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = eventsDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = eventsDataGridView.SelectedRows[i]; //Event
                    Event thisEvent = new Event(int.Parse(row.Cells[0].Value.ToString()));
                    Event newEvent = (Event)thisEvent.ShallowCopy();
                    newEvent.Id = 0;
                    newEvent.EventName = newEvent.EventName + " - Copy";
                    newEvent.AddEvent();

                    //Bot keys
                    Connection c = new Connection("program_data");
                    c.conOpen();
                    DataSet eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + int.Parse(row.Cells[0].Value.ToString()) + "", "bot");
                    foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
                    {
                        CopyPasteKey(rowEventKey[1].ToString(), double.Parse(rowEventKey[2].ToString()), newEvent.Id);
                    }
                    c.conClose();
                }

                MessageBox.Show("Copy paste the selected data successfully.");
                RefreshEventDataGridView();
            }
            else
            {
                //Close
            }
        }

        //copy paste key function
        public void CopyPasteKey(String key, double spamTime, int eventId)
        {
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
            if (Program.BotId == 0)
                c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position]) VALUES ('" + key + "', " + spamTime + ", " + maxPosition + ")");
            else
                c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position], [botId], [eventId]) VALUES ('" + key + "', " + spamTime + ", " + maxPosition + ", " + Program.BotId + ", " + eventId + ")");
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            TimerButton_Click();
        }

        private void RegularBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.BotId != 0)
            {
                Saved s = new Saved(Program.BotId);
                s.ScriptText = ScriptRichTextBox.Text;
            }
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
                this.Close();
            }
            if (ClickedExit == false)
                Application.Exit();
        }

        public override void savedBotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickedExit = true;
            if (Program.BotId != 0)
            {
                Saved s = new Saved(Program.BotId);
                s.ScriptText = ScriptRichTextBox.Text;
            }
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            OpenForm(new SavedBots());
        }

        public override void regularBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickedExit = true;
            if (Program.BotId != 0)
            {
                Saved s = new Saved(Program.BotId);
                s.ScriptText = ScriptRichTextBox.Text;
            }
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            Program.BotId = 0;
            OpenForm(new RegularBot());
        }

        public override void scriptBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickedExit = true;
            if (Program.BotId != 0)
            {
                Saved s = new Saved(Program.BotId);
                s.ScriptText = ScriptRichTextBox.Text;
            }
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            Program.BotId = 0;
            OpenForm(new Script_Bot());
        }

        private void FindStringsInCurrentWord()
        {
            RichTextBox script = ScriptRichTextBox;
            String finalWord, forwards, backwards;
            int saveLastSelectionStart = script.SelectionStart;
            int index = script.SelectionStart;

            String[] coloredNames = { "Main", "ClickMouseDown", "ClickMouseUp", "PressKey", "StopMoving", "Delay", "GoRight", "GoLeft", "GoUp", "GoDown", "MousePosition", "LastHorizontalDirection", "LastVerticalDirections", "CurrentDirection", "Directions", "Write", "WriteLine" };
            String[] coloredNames2 = { "cm.", "if", "else", "while", "switch", "case", "break", "return", "new" };
            String[] coloredNames3 = { "MyPosition", "MyHealth", "OtherPeopleInMap", ".RIGHT", ".LEFT", ".UP", ".DOWN", ".STOP_MOVING", "UpdateMyPosition" };

            String[] arr2 = coloredNames.Union(coloredNames2).ToArray();
            Array arrAll = arr2.Union(coloredNames3).ToArray(); //Gets all arrays together
            Array[] wordsArray = { coloredNames, coloredNames2, coloredNames3 }; //All found strings in the word
            List<String> wordsFoundList = new List<String>();
            int foundChangedColor = 0;
            int wordsFound = 0;


            char current = (char)script.GetCharFromPosition(script.GetPositionFromCharIndex(index)); //Where the editor thingy is
            //Check forward text where he uses space and save text
            while (!System.Char.IsWhiteSpace(current) && index < script.Text.Length)
            {
                index++;
                current = (char)script.GetCharFromPosition(script.GetPositionFromCharIndex(index));
            }
            int lengthForward = index - saveLastSelectionStart;
            script.Select(script.SelectionStart, lengthForward);
            forwards = script.SelectedText;
            //Debug.WriteLine("Forwards: " + forwards);
            script.SelectionStart = saveLastSelectionStart;
            this.ScriptRichTextBox.Select(script.SelectionStart, 0);
            index = script.SelectionStart;
            current = (char)script.GetCharFromPosition(script.GetPositionFromCharIndex(index));
            int length = 0;
            //Check backwords where he uses space and save text
            while ((!System.Char.IsWhiteSpace(current) || length == 0) && index > 0 && index <= script.Text.Length)
            {
                index--;
                length++;
                current = (char)script.GetCharFromPosition(script.GetPositionFromCharIndex(index));
            }
            script.SelectionStart -= length;
            script.Select(script.SelectionStart + 1, length - 1);
            backwards = script.SelectedText;
            script.SelectionStart = saveLastSelectionStart;
            this.ScriptRichTextBox.Select(saveLastSelectionStart, 0);
            this.ScriptRichTextBox.SelectionColor = Color.Black;
            finalWord = backwards + forwards; //Our all word!

            //Setting all of the word black, after it coloring the right places
            script.Select(index + 1, length + lengthForward);
            script.SelectionColor = Color.Black;
            foreach (string word in arrAll)
            {
                if (finalWord.IndexOf(word) != -1)
                {
                    wordsFound++;
                    wordsFoundList.Add(word);
                    script.Select(index + 1 + finalWord.IndexOf(word), word.Length);
                    if (coloredNames.Any(word.Contains))
                    {
                        script.SelectionColor = Color.LightSkyBlue;
                        foundChangedColor++;
                    }
                    else if (coloredNames2.Any(word.Contains))
                    {
                        script.SelectionColor = Color.Blue;
                        foundChangedColor++;
                    }
                    else if (coloredNames3.Any(word.Contains))
                    {
                        script.SelectionColor = Color.DarkGreen;
                        foundChangedColor++;
                    }
                    this.ScriptRichTextBox.Select(saveLastSelectionStart, 0);
                    this.ScriptRichTextBox.SelectionColor = Color.Black;
                }
            }

            //No strings found, color it black
            if (wordsFound == 0)
            {
                script.Select(index + 1, length + lengthForward);
                script.SelectionColor = Color.Black;
                this.ScriptRichTextBox.Select(saveLastSelectionStart, 0);
                this.ScriptRichTextBox.SelectionColor = Color.Black;
            }
        }

        private void ScriptColorChange()
        {
            int index = ScriptRichTextBox.SelectionStart;
            ScriptRichTextBox.Text = ScriptTextChange; //Only way I found to make the all current text black again, SelectAll() didn't work well.
            ScriptRichTextBox.SelectionStart = index;
            String[] coloredNames = { "Main", "ClickMouseDown", "ClickMouseUp", "PressKey", "StopMoving", "Delay", "GoRight", "GoLeft", "GoUp", "GoDown", "MousePosition", "LastHorizontalDirection", "LastVerticalDirections", "CurrentDirection", "Directions", "Write", "WriteLine" };
            String[] coloredNames2 = { "cm.", "if", "else", "while", "switch", "case", "break", "return", "new" };
            String[] coloredNames3 = { "MyPosition", "MyHealth", "OtherPeopleInMap", ".RIGHT", ".LEFT", ".UP", ".DOWN", ".STOP_MOVING", "UpdateMyPosition" };
            foreach (String s in coloredNames)
                this.CheckKeyword(s, Color.LightSkyBlue, 0);
            foreach (String s in coloredNames2)
                this.CheckKeyword(s, Color.Blue, 0);
            foreach (String s in coloredNames3)
                this.CheckKeyword(s, Color.DarkGreen, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.ScriptRichTextBox.Text.Contains(word))
            {
                int index = 0;
                int selectStart = this.ScriptRichTextBox.SelectionStart;

                while ((index = this.ScriptRichTextBox.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.ScriptRichTextBox.Select((index + startIndex), word.Length);
                    this.ScriptRichTextBox.SelectionColor = color;
                    this.ScriptRichTextBox.Select(selectStart, 0);
                    this.ScriptRichTextBox.SelectionColor = Color.Black;
                }
            }
        }

        int scriptLength = 0;
        private void ScriptRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ScriptRichTextBox.Text.Length > scriptLength + 2 && scriptLength != 0) //Copy paste?
            {
                ScriptTextChange = ScriptRichTextBox.Text;
                ScriptColorChange();
            }
            FindStringsInCurrentWord();
            scriptLength = ScriptRichTextBox.Text.Length;
        }

        public void HandleHotkeys()
        {
            runBotTabPage.Show();
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
            }
            else
            {
                startBottingButton.PerformClick();
            }
        }

        public override void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            OpenDialogForm(new BotSettings());
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            if (ConsoleOpen == false)
            {
                var handle = GetConsoleWindow();
                // Hide
                ShowWindow(handle, SW_SHOW);
                ConsoleOpen = true;
            }
            else if (ConsoleOpen == true)
            {
                var handle = GetConsoleWindow();
                // Hide
                ShowWindow(handle, SW_HIDE);
                ConsoleOpen = false;
            }
        }

        public Bitmap CaptureAllScreen(int screenIndex)
        {
            Rectangle screen = Screen.AllScreens[screenIndex].WorkingArea;
            var image = new Bitmap(screen.Width, screen.Height, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            gfx.CopyFromScreen(screen.X, screen.Y, 0, 0, screen.Size, CopyPixelOperation.SourceCopy); //All Screen
            return image;
        }

        public static Bitmap ConvertToFormat(Bitmap image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (botStatus.Text != "Running.")
            {
                MessageBox.Show("Bot isn't running.");
                return;
            }

            if (PauseScript == false)
            {

                StopMoving();
                PauseScript = true; //Paused the script
                pauseButton.Text = "Resume";
            }
            else
            {

                if (Program.BotId == 0)
                {
                    MessageBox.Show("You need to save the script bot before running it.");
                    return;
                }
                IntPtr Focus = SendInputHandler.FindWindow(Program.ProgramClass, Program.ProgramName);
                if (Focus == IntPtr.Zero)
                {
                    MessageBox.Show("The program couldn't be found. Client name must be wrong or program isn't running.");
                    return;
                }
                ScreenShot map = new ScreenShot(Program.BotId, "map");
                if (map.Id == 0)
                {
                    MessageBox.Show("Please set your mini-map picture detect settings before botting.");
                    return;
                }

                if (Properties.Settings.Default.WindowPosition == true)
                    SetWindowPos(Focus, (IntPtr)0, 0, 0, 240, 26, SWP_NOSIZE);
                SendInputHandler.SetForegroundWindow(Focus);

                PauseScript = false;
                pauseButton.Text = "Pause";
            }
        }
    }
}
