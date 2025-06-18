using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AutoKeyBot.App_Data;
using AutoKeyBot.Classes;
using AutoKeyBot.Handlers;
using AutoKeyBot.Properties;

namespace AutoKeyBot.Applications
{
    public partial class RegularBot : AutoKeyBot.Master.KeystrokeBot
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        uint SWP_NOSIZE = 1;

        public Connection c = new Connection("program_data");

        public static PostMessageHandler P = new PostMessageHandler();
        public static SendInputHandler S = new SendInputHandler();

        List<System.Windows.Forms.Timer> Timerlist = new List<System.Windows.Forms.Timer>();
        private DateTime BottingTime = new DateTime();
        private DateTime BottingAlarmTime = new DateTime();

        Thread ThreadBotting;
        Thread ThreadHealthBar;
        Thread ThreadPlayerLocation;
        Thread ThreadOtherPlayer;

        int MyHealth = 100;
        int MyMana = 100;
        Point MyPosition = new Point(-100, -100);
        Boolean OtherPeopleInMap = false;

        public Boolean LiveDataOpen = false;
        LiveData liveData = null;

        private bool PauseScript = false;

        private bool ClickedExit = false;

        public Directions CurrentDirection { get; set; }

        public enum Directions
        {
            RIGHT, LEFT, UP, DOWN, STOP_MOVING,
        }

        public RegularBot() : base("RegularBot")
        {
            InitializeComponent();
        }

        public OleDbDataAdapter OleDbDataAdapter { get; private set; }

        private void RegularBot_Load(object sender, EventArgs e)
        {
            FillKeys(keyTextBox);

            RefreshKeysDataGridView();
            RefreshEventDataGridView();

            cropImageComboBox.Text = cropImageComboBox.Items[0].ToString();
            eventTypeComboBox.Text = eventTypeComboBox.Items[0].ToString();

            if (Program.BotId != 0)
            {
                EventControlOnLoad();
            }
            CheckScreenShots();

            this.CurrentDirection = Directions.STOP_MOVING;
        }

        //Do 1 action of keystroke as bot
        private void KeyPressBot(String keystroke, double timer, Event playerPosition)
        {
            Random r = new Random();
            int sleepTime = 30;
            double random = r.NextDouble() * (1 - 0.9) + 1;
            Keyshort k;
            k = new Keyshort(keystroke);

            if (PauseScript)
                return;

            if (keystroke != "UP" && keystroke != "DOWN" && keystroke != "RIGHT" && keystroke != "LEFT" && keystroke != "STOP MOVING")
            {
                if (timer != 0)
                {
                    if (keystroke != "DELAY")
                    {
                        //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        while (s.Elapsed < TimeSpan.FromSeconds(timer))
                        {
                            if (keystroke != "DELAY")
                            {
                                if (playerPosition != null)
                                    if (Properties.Settings.Default.PositionEventAll == false && !PlayerPositionEventHappened(playerPosition))
                                        break;
                                int shorter = Convert.ToInt32(k.Shorter, 16);
                                P.KeySend(shorter);
                                System.Threading.Thread.Sleep((int)(sleepTime * random));
                            }
                        }
                        s.Stop();
                    }
                    else if (keystroke == "DELAY")
                    {
                        //Debug.WriteLine("Key: DELAY, Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
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
                        //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                        System.Threading.Thread.Sleep((int)(sleepTime * random));
                    }
                }
            }
            else if (keystroke == "STOP MOVING")
            {
                StopMoving();
                //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
            }
            else if (keystroke == "STOP BOTTING")
            {
                stopBottingButton.Invoke(new Action(() => stopBottingButton.PerformClick()));
            }
            else //Locations;
            {
                var hwnd = FindWindow(Program.ProgramClass, Program.ProgramName);
                var currentWindow = GetForegroundWindow();

                if (hwnd == currentWindow)
                {
                    switch (keystroke)
                    {
                        case "DOWN":
                            //Debug.WriteLine("DOWN: " + CurrentDirection.ToString());
                            if (CurrentDirection != Directions.DOWN)
                            {
                                StopMoving();
                                S.KeySend(SendInputHandler.VirtualKeyShort.DOWN);
                            }
                            CurrentDirection = Directions.DOWN;
                            //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                            break;
                        case "UP":
                            //Debug.WriteLine("UP: " + CurrentDirection.ToString());
                            if (CurrentDirection != Directions.UP)
                            {
                                StopMoving();
                                S.KeySend(SendInputHandler.VirtualKeyShort.UP);
                            }
                            CurrentDirection = Directions.UP;
                            //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                            break;
                        case "RIGHT":
                            //Debug.WriteLine("RIGHT: " + CurrentDirection.ToString());
                            if (CurrentDirection != Directions.RIGHT)
                            {
                                StopMoving();
                                S.KeySend(SendInputHandler.VirtualKeyShort.RIGHT);
                            }
                            CurrentDirection = Directions.RIGHT;
                            //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                            break;
                        case "LEFT":
                            //Debug.WriteLine("LEFT: " + CurrentDirection.ToString());
                            if (CurrentDirection != Directions.LEFT)
                            {
                                StopMoving();
                                S.KeySend(SendInputHandler.VirtualKeyShort.LEFT);
                            }
                            CurrentDirection = Directions.LEFT;
                            //Debug.WriteLine("Key: " + keystroke + ", Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                            break;
                    }
                }
                else
                {
                    //Debug.WriteLine("Key: OFF SCREEN DELAY, Spam: " + timer + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                    System.Threading.Thread.Sleep((int)(500 * random));
                }
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
            {
                ThreadBotting.Abort();
            }
            ThreadHealthBar.Abort();
            ThreadPlayerLocation.Abort();
            ThreadOtherPlayer.Abort();
            ThreadBotting = new Thread(BottingThread);
            ThreadHealthBar = new Thread(HpThread);
            ThreadPlayerLocation = new Thread(PlayerPositionThread);
            ThreadOtherPlayer = new Thread(OtherPlayerInMapThread);

            //Stop all timer events
            foreach (var timer in Timerlist)
            {
                timer.Stop();
            }


            //Clear timers
            bottingTimeLabel.Text = "00:00";

            //Reset player in map boolean
            OtherPeopleInMap = false;


            foreach (DataGridViewRow row in keysDataGridView.Rows)
            {
                string keystroke = row.Cells[1].Value.ToString();
                if (!(keystroke == "UP" || keystroke == "DOWN" || keystroke == "RIGHT" || keystroke == "LEFT" || keystroke == "STOP MOVING" || keystroke == "DELAY"))
                {
                    //KeyUp clicked once actions(?)
                }
            }
            StopMoving();

            if (PauseScript == true)
            {
                PauseScript = false;
                pauseButton.Text = "Pause";
            }

            botStatus.Text = "Botting stopped.";
            botStatus.ForeColor = Color.Red;
            eventStatus.Text = "Botting stopped.";
            eventStatus.ForeColor = Color.Red;
            //Reset messages
            CheckScreenShots();
            this.CurrentDirection = Directions.STOP_MOVING;
            IntPtr Focus = SendInputHandler.FindWindow(Program.ProgramClass, Program.ProgramName);
            SendInputHandler.SetForegroundWindow(Focus);
        }

        //Button to start botting and starting threads
        public void StartBotting_Click(object sender, EventArgs e)
        {
            /* //Don't need it?
            if (keysDataGridView.Rows.Count == 0 && eventsDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("You need to have at list 1 key or 1 event.");
                return;
            }
            */
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
            ThreadPlayerLocation = new Thread(PlayerPositionThread);
            ThreadHealthBar = new Thread(HpThread);
            ThreadOtherPlayer = new Thread(OtherPlayerInMapThread);
            ThreadBotting = new Thread(BottingThread);

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
            ScreenShot map = new ScreenShot(Program.BotId, "map");

            if (health.Id != 0)
                ThreadHealthBar.Start();
            if (map.Id != 0)
            {
                ThreadPlayerLocation.Start();
                ThreadOtherPlayer.Start();
            }
            ThreadBotting.Start();
            botStatus.Text = "Running.";
            botStatus.ForeColor = Color.Green;

            if (Properties.Settings.Default.WindowPosition == true)
                SetWindowPos(Focus, (IntPtr)0, 0, 0, 240, 26, SWP_NOSIZE);
            SendInputHandler.SetForegroundWindow(Focus);
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

        //SIH Moving, PMH Keys
        //The main thread for the botting to work
        private void BottingThread()
        {
            Random rnd = new Random();

            while (true)
            {
                foreach (DataGridViewRow row in keysDataGridView.Rows)
                {
                    eventAccour();
                    eventStatus.Invoke(new Action(() => eventStatus.Text = "None"));
                    eventStatus.ForeColor = Color.Red;
                    string keystroke = row.Cells[1].Value.ToString();
                    double timer = double.Parse(row.Cells[2].Value.ToString());
                    //Checking events if accour
                    KeyPressBot(keystroke, timer); //The actual keybot.. 
                }
                if (keysDataGridView.RowCount == 0)
                {
                    eventAccour();
                    eventStatus.Invoke(new Action(() => eventStatus.Text = "None"));
                    eventStatus.ForeColor = Color.Red;
                }
            }
        }

        private void eventAccour()
        {
            string keystroke;
            double timer;
            Event eEdit = null;
            DataSet eventData;
            Boolean eventHappened = false;
            foreach (DataGridViewRow rowEvent in eventsDataGridView.Rows)
            {
                eEdit = new Event(int.Parse(rowEvent.Cells[0].Value.ToString()));
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
                        Bitmap map = CaptureScreen("map");
                        Point location = PlayerPosition();
                        MyPosition = new Point(location.X, location.Y);
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
                    break;
                }
            }
            if (eventHappened == true)
            {
                //Debug.WriteLine("Event Started: " + eEdit.EventName + ", Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                eventStatus.Invoke(new Action(() => eventStatus.Text = eEdit.EventName));
                eventStatus.ForeColor = Color.Green;
                Connection c = new Connection("program_data");
                c.conOpen();
                eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + eEdit.Id + " ORDER BY [position] ASC", "bot");
                foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
                {
                    //Debug.WriteLine("ROW KEY: " + rowEventKey[1].ToString() + ", TIMER: " + rowEventKey[2].ToString());
                    //Debug.WriteLine("My X: " + MyPosition.X + ", My Y: " + MyPosition.Y + ". Happened: " + PlayerPositionEventHappened(eEdit));
                    if (eEdit.EventType == "player position")
                        if (Properties.Settings.Default.PositionEventAll == false && !PlayerPositionEventHappened(eEdit))
                            break;
                    keystroke = rowEventKey[1].ToString();
                    timer = double.Parse(rowEventKey[2].ToString());
                    KeyPressBot(keystroke, timer, eEdit);
                }
                c.conClose();
            }
        }

        private Boolean PlayerPositionEventHappened(Event e)
        {
            String basedOn = "", width = "", height = "", resultX = "none", resultY = "none";
            int x = MyPosition.X, y = MyPosition.Y;
            if (e.From1 == -100)
                basedOn = "height";
            if (e.From2 == -100)
                basedOn = "width";
            if (e.From1 != -100 && e.From2 != -100)
                basedOn = "both";

            if (e.Bigger1)
                width = "bigger";
            else
                width = "smaller";
            if (e.Bigger2)
                height = "bigger";
            else
                height = "smaller";
            if (e.Between1)
                width = "between";
            if (e.Between2)
                height = "between";


            if (width == "bigger")
                if (x > e.From1)
                    resultX = "bigger";
            if (width == "smaller")
                if (x < e.From1)
                    resultX = "smaller";
            if (width == "between")
                if (e.From1 <= x && e.To1 >= x)
                    resultX = "between";

            if (height == "bigger")
                if (y > e.From2)
                    resultY = "bigger";
            if (height == "smaller")
                if (y < e.From2)
                    resultY = "smaller";
            if (height == "between")
                if (e.From2 <= y && e.To2 >= y)
                    resultY = "between";

            //System.Diagnostics.Debug.WriteLine("basedOn: '" + basedOn + "', width: '" + width + "', height: '" + height + "', resultX: '" + resultX + "'" + ", resultY: '" + resultY + "', x: '" + x + "', y: '" + y + "'");

            switch (basedOn)
            {
                case "width":
                    if (resultX == width)
                        return true;
                    break;
                case "height":
                    if (resultY == height)
                        return true;
                    break;

                case "both":
                    if (resultX == width && resultY == height)
                        return true;
                    break;
            }
            return false;
        }

        //Player position thread, checks the player position based on mini map screenshots
        private void PlayerPositionThread()
        {
            Point location;
            Bitmap map;
            while (true)
            {
                System.Threading.Thread.Sleep(30);

                map = CaptureScreen("map");
                location = PlayerPosition();
                MyPosition = new Point(location.X, location.Y);
                //Debug.WriteLine("New Player Position: (" + MyPosition.X + ", " + MyPosition.Y + ").");
                playerPositionStatus.Invoke(new Action(() => playerPositionStatus.Text = "(" + location.X.ToString() + ", " + location.Y.ToString() + ")"));
                if (LiveDataOpen)
                {
                    liveData.LabelUse(liveData.playerPositionStatus, "(" + location.X.ToString() + ", " + location.Y.ToString() + ")");
                }
            }
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

        //Adding keystroke event
        private void AddKey_Click(object sender, EventArgs e)
        {
            AddKey(keyTextBox.Text, spamTimeTextBox.Text);
        }

        private void AddKey(String key, String spamTimeText)
        {
            if (botStatus.Text == "Running.")
            {
                MessageBox.Show("You can't add a key while botting is running.");
                return;
            }

            if (key != "")
            {
                double spamTime = 0;
                if (!double.TryParse(spamTimeText, out spamTime) && spamTimeTextBox.Enabled == true)
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
                if (Program.BotId == 0)
                    c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position]) VALUES ('" + key + "', " + spamTime + ", " + maxPosition + ")");
                else
                    c.NonQuery("INSERT INTO bot ([keystroke], [timer], [position], [botId]) VALUES ('" + key + "', " + spamTime + ", " + maxPosition + ", " + Program.BotId + ")");
                MessageBox.Show("Key as been added.");
                key = "";
                spamTimeText = "";
                botStatus.Text = "Not running.";
                RefreshKeysDataGridView();
            }
            else
            {
                MessageBox.Show("There is a problem with the key information you added.");
            }
        }

        //'bot' table gridview refresh
        private void RefreshKeysDataGridView()
        {
            String sql1 = "SELECT * FROM [bot] WHERE botId IS NULL AND (eventType = '' OR eventType IS NULL) ORDER BY [position] ASC";
            if (Program.BotId != 0)
            {
                sql1 = "SELECT * FROM [bot] WHERE botId = " + Program.BotId + " AND ([eventType] = '' OR [eventType] IS NULL) AND eventId = 0 ORDER BY [position] ASC";
                Saved s = new Saved(Program.BotId);
                botNameTextBox.Text = s.Bot;
            }
            Connection con = new Connection("program_data");
            con.conOpen();
            OleDbCommand cmd = new OleDbCommand(sql1, con.Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            keysDataGridView.DataSource = table;
            keysDataGridView.Columns[0].Visible = false; //id
            keysDataGridView.Columns[3].Visible = false; //position
            keysDataGridView.Columns[4].Visible = false; //botId
            keysDataGridView.Columns[5].Visible = false; //eventId
            keysDataGridView.Columns[6].Visible = false; //eventType
            keysDataGridView.Columns[2].HeaderText = "timer (Seconds)";
            con.conClose();
            keysDataGridView.Update();
            keysDataGridView.Refresh();
            if (keysDataGridView.SelectedCells.Count > 0)
                keysDataGridView.FirstDisplayedCell.Selected = false;
        }

        private void RefreshEventGridView(object sender, FormClosingEventArgs e)
        {
            RefreshEventDataGridView();
        }

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

        //Take the key choosen one row up
        private void RowUp_Click(object sender, EventArgs e)
        {
            int rowsSelected = 0;
            foreach (DataGridViewRow row in keysDataGridView.SelectedRows)
            {
                rowsSelected++;
            }
            if (rowsSelected != 1)
            {
                MessageBox.Show("You have to choose 1 row.");
                return;
            }
            foreach (DataGridViewRow row in keysDataGridView.SelectedRows)
            {
                if (row.Index == 0)
                {
                    MessageBox.Show("The row you choose is already the first action.");
                    return;
                }
                int rowIndex = row.Index;
                string id = row.Cells[0].Value.ToString();
                string position = row.Cells[3].Value.ToString();
                DataGridViewRow rowUp = this.keysDataGridView.Rows[row.Index - 1];
                Bot thisRow = new Bot(int.Parse(id));
                Bot otherRow = new Bot(int.Parse(rowUp.Cells[0].Value.ToString()));
                int thisRowPosition = thisRow.Position;
                thisRow.Position = otherRow.Position;
                otherRow.Position = thisRowPosition;
                RefreshKeysDataGridView();
                keysDataGridView.Rows[rowIndex - 1].Selected = true;
                return;
            }
        }


        //Takes the key choosen one row down
        private void RowDown_Click(object sender, EventArgs e)
        {
            int rowsSelected = 0;
            foreach (DataGridViewRow row in keysDataGridView.SelectedRows)
            {
                rowsSelected++;
            }
            if (rowsSelected != 1)
            {
                MessageBox.Show("You have to choose 1 row.");
                return;
            }
            Connection c = new Connection("program_data");
            int maxPosition = keysDataGridView.Rows.Count - 1;
            foreach (DataGridViewRow row in keysDataGridView.SelectedRows)
            {
                if (row.Index == maxPosition)
                {
                    MessageBox.Show("The row you choose is already the last action.");
                    return;
                }
                int rowIndex = row.Index;
                string id = row.Cells[0].Value.ToString();
                string position = row.Cells[3].Value.ToString();
                DataGridViewRow rowUp = this.keysDataGridView.Rows[row.Index + 1]; //RowDown, too lazy to change name
                Bot thisRow = new Bot(int.Parse(id));
                Bot otherRow = new Bot(int.Parse(rowUp.Cells[0].Value.ToString()));
                int thisRowPosition = thisRow.Position;
                thisRow.Position = otherRow.Position;
                otherRow.Position = thisRowPosition;
                RefreshKeysDataGridView();
                keysDataGridView.Rows[rowIndex + 1].Selected = true;
                return;
            }
        }

        //The HP thread, updates the HP of the player based on screenshots
        private void HpThread()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(250);
                Bitmap health = CaptureScreen("health");
                String hpString = DetectBar("health").ToString();
                MyHealth = int.Parse(hpString);
                hpStatus.Invoke(new Action(() => hpStatus.Text = hpString + "%"));
                if (LiveDataOpen)
                {
                    liveData.LabelUse(liveData.hpStatus, hpString + "%");
                }
            }
        }

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

        //TODO Check if it works good with regular botting...
        private void Timer_TickAccour(object sender, EventArgs e, Event eEdit)
        {
            if (PauseScript)
                return;

            eventStatus.Invoke(new Action(() => eventStatus.Text = eEdit.EventName));
            eventStatus.ForeColor = Color.Green;
            Connection c = new Connection("program_data");
            c.conOpen();
            DataSet eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + eEdit.Id + " ORDER BY [position] ASC", "bot");
            foreach (DataRow rowEventKey in eventData.Tables["bot"].Rows)
            {
                string keystroke = rowEventKey[1].ToString();
                double timer = double.Parse(rowEventKey[2].ToString());
                KeyPressBot(keystroke, timer);
            }
            c.conClose();
        }

        private void KeyPressBot(String keystroke, double timer)
        {
            KeyPressBot(keystroke, timer, null);
        }

        //Changing textbox enabled\disabled and all that when key choosen changes
        private void Key_SelectedIndexChanged(object sender, EventArgs e)
        {
            String keystroke = keyTextBox.Text;
            if (keyTextBox.SelectedItem != null)
            {
                Debug.WriteLine(keystroke);
                if (keystroke == "STOP BOTTING" || keystroke == "UP" || keystroke == "DOWN" || keystroke == "RIGHT" || keystroke == "LEFT" || keystroke == "STOP MOVING")
                {
                    spamTimeTextBox.Text = "";
                    spamTimeTextBox.Enabled = false;
                }
                else
                {
                    spamTimeTextBox.Enabled = true;
                    if (botStatus.Text != "Running.")
                    {
                        botStatus.Text = "Not running.";
                    }
                }
            }
        }

        private void keysDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot in order to edit this line.");
                return;
            }

            if (keysDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row.");
                return;
            }
            if (keysDataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("To edit a line, you can only choose 1 row to edit.");
                return;
            }

            DataGridViewRow row = keysDataGridView.SelectedRows[0];
            EditLine line = new EditLine(int.Parse(row.Cells[0].Value.ToString()));
            line.FormClosing += new FormClosingEventHandler(RefreshKeysDataGridView);
            OpenDialogForm(line);

        }

        private void RefreshKeysDataGridView(object sender, FormClosingEventArgs e)
        {
            RefreshKeysDataGridView();
        }

        //Stop moving action
        private void StopMoving()
        {
            S.KeyUp(SendInputHandler.VirtualKeyShort.UP);
            S.KeyUp(SendInputHandler.VirtualKeyShort.DOWN);
            S.KeyUp(SendInputHandler.VirtualKeyShort.RIGHT);
            S.KeyUp(SendInputHandler.VirtualKeyShort.LEFT);
            CurrentDirection = Directions.STOP_MOVING;
        }

        //Saving bot
        private void Save_Click(object sender, EventArgs e)
        {
            if (botNameTextBox.Text == "")
            {
                MessageBox.Show("You didn't add a name to the bot.");
                return;
            }

            if (Program.BotId == 0)
            {
                Saved s = new Saved(botNameTextBox.Text);
                if (s.Id != 0)
                {
                    MessageBox.Show("There is already a bot with that name");
                    return;
                }
            }
            else
            {
                Saved s = new Saved(botNameTextBox.Text);
                Saved sThis = new Saved(Program.BotId);
                if (sThis.Id != 0 && s.Id != sThis.Id)
                {
                    MessageBox.Show("There is already a bot with that name");
                    return;
                }
            }

            //Enter default key
            if (keysDataGridView.RowCount == 0 && eventsDataGridView.RowCount == 0)
            {
                AddKey("DELAY", "0");
            }

            Boolean noId = false;
            if (Program.BotId == 0)
            {
                foreach (DataGridViewRow row in keysDataGridView.Rows)
                {
                    string botId = row.Cells[4].Value.ToString();
                    if (botId == "")
                    {
                        c.NonQuery("INSERT INTO saved (bot, client, version) VALUES ('" + botNameTextBox.Text + "', 'null', -1)"); //#TODO change the saved table
                        noId = true;
                        break;
                    }
                }
            }
            if (noId == true)
            {
                foreach (DataGridViewRow row in keysDataGridView.Rows)
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
            }

            if (Program.BotId != 0)
            {
                string sqlUpdate = "UPDATE saved SET bot = '" + botNameTextBox.Text + "', client = 'null', version = 0 WHERE id = " + Program.BotId + ""; //#TODO change this
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

        //copy paste keys
        private void CopyPaste_Click(object sender, EventArgs e)
        {
            if (keysDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any rows to copy paste.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to copy paste this rows? They will be added as the last added keys.", "Copy Paste Keys", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = keysDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = keysDataGridView.SelectedRows[i];
                    CopyPasteKey(row.Cells[1].Value.ToString(), double.Parse(row.Cells[2].Value.ToString()), 0);
                }

                MessageBox.Show("Copy paste the selected data successfully.");
                RefreshKeysDataGridView();
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

        //Delete button of keys
        private void Delete_Click(object sender, EventArgs e)
        {
            if (keysDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You didn't choose any rows to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete this rows?", "Delete Keys", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in keysDataGridView.SelectedRows)
                {
                    Bot b = new Bot(int.Parse(row.Cells[0].Value.ToString()));
                    b.DeleteBot();
                }
                MessageBox.Show("Deleted the selected data successfully.");
                RefreshKeysDataGridView();
            }
            else
            {
                //Close
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            if (eventTypeComboBox.Text == "Player Position")
                PlayerLocationEvent_Click();
            else if (eventTypeComboBox.Text == "Other Players In The Map")
                OtherPlayer_Click();
            else if (eventTypeComboBox.Text == "HP")
                HpEvent_Click();
            else if (eventTypeComboBox.Text == "Timer")
                TimerButton_Click();
        }

        //Open new HP event application
        private void HpEvent_Click()
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot before you make an event.");
                return;
            }
            Connection con = new Connection("program_data");
            con.NonQuery("DELETE FROM [bot] WHERE eventid = -1"); //Delete unsaved keys...

            Program.Capture = "health";
            Program.EventId = -1;
            Form Potions = new Potions("health");
            Potions.FormClosing += new FormClosingEventHandler(RefreshEventGridView);
            Potions.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            OpenDialogForm(Potions);

        }

        //open new player location event application
        private void PlayerLocationEvent_Click()
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot before you make an event.");
                return;
            }
            Connection con = new Connection("program_data");
            con.NonQuery("DELETE FROM [bot] WHERE eventid = -1"); //Delete unsaved keys...

            Program.Capture = "player location";
            Program.EventId = -1;
            Form playerPosition = new PlayerPosition();
            playerPosition.FormClosing += new FormClosingEventHandler(RefreshEventGridView);
            playerPosition.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            OpenDialogForm(playerPosition);
        }

        //open other player in map event application
        private void OtherPlayer_Click()
        {
            if (Program.BotId == 0)
            {
                MessageBox.Show("You need to save the bot before you make an event.");
                return;
            }
            Connection con = new Connection("program_data");
            con.NonQuery("DELETE FROM [bot] WHERE eventid = -1"); //Delete unsaved keys...

            Program.Capture = "player in map";
            Program.EventId = -1;
            Form playerInMap = new PlayerInMap();
            playerInMap.FormClosing += new FormClosingEventHandler(RefreshEventGridView);
            playerInMap.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            OpenDialogForm(playerInMap);
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
            PlayerDot = "";

            Bitmap bmp = CaptureScreen("map");
            Point Position = new Point();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
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

        private void eventsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UseEdit_Click();
        }

        //edit event
        private void UseEdit_Click()
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
            if (eEdit.EventType == "health")
            {
                Potions newForm = new Potions("health");
                OpenDialogForm(newForm);
            }
            if (eEdit.EventType == "mana")
            {
                Potions newForm = new Potions("mana");
                OpenDialogForm(newForm);
            }
            if (eEdit.EventType == "player position")
            {
                PlayerPosition newForm = new PlayerPosition();
                OpenDialogForm(newForm);
            }
            if (eEdit.EventType == "player in map")
            {
                PlayerInMap newForm = new PlayerInMap();
                OpenDialogForm(newForm);
            }
            if (eEdit.EventType == "timer")
            {
                Timer newForm = new Timer();
                OpenDialogForm(newForm);
            }
        }

        //delete event
        private void DeleteEvent_Click(object sender, EventArgs e)
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

        //copy paste event
        private void CopyPasteEvent_Click(object sender, EventArgs e)
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
                    DataSet eventData = c.getDataSet("SELECT * FROM [bot] WHERE eventId = " + int.Parse(row.Cells[0].Value.ToString()) + " ORDER BY [position] ASC", "bot");
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

        public void PictureDetectionBotButton_Click(object sender, EventArgs e)
        {

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

            ScreenShot health = new ScreenShot(Program.BotId, "health");
            ScreenShot mana = new ScreenShot(Program.BotId, "mana");
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
            CapturedScreen form1 = new CapturedScreen();
            form1.InstanceRef = this;
            OpenHideForm(form1);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1) //Picture Detection
            {
                EventControlOnLoad();
            }
        }

        private void RegularBot_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            Program.BotId = 0;
            OpenForm(new Script_Bot());
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

        public override void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (botStatus.Text == "Running.")
            {
                stopBottingButton.PerformClick();
                MessageBox.Show("The bot is still running, we will stop it for you.");
            }
            OpenDialogForm(new BotSettings());
        }

        private void simulatorButton_Click(object sender, EventArgs e)
        {
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            if (map.Id == 0)
            {
                MessageBox.Show("The mini-map picture isn't set.");
                return;
            }
            Program.EventId = 0;
            OpenDialogForm(new MiniMapEvents());
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
