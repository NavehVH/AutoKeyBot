using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoKeyBot.App_Data;
using AutoKeyBot.Classes;

namespace AutoKeyBot.Applications
{
    public partial class MiniMapEvents : Form
    {
        public MiniMapEvents()
        {
            InitializeComponent();
        }

        private void MiniMapEvents_Load(object sender, EventArgs e)
        {
            if (Program.EventId > 0)
            {
                ShowEventCapture();
            }
            else
            {
                AllEventsButton_Click(null, null);
            }
        }

        public Bitmap CaptureMapScreen()
        {
            ScreenShot s = new ScreenShot(Program.BotId, "map");
            var image = new Bitmap(s.PictureWidth, s.PictureHeight, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            //gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy); //All Screen
            gfx.CopyFromScreen(s.XUpperLeftCornerSource, s.YUpperLeftCornerSource, s.XUpperLeftCornerDestination, s.YUpperLeftCornerDestination, new System.Drawing.Size(s.PictureWidth, s.PictureHeight), CopyPixelOperation.SourceCopy);
            return image;
        }

        private void ShowEventCapture()
        {
            Event e = new Event(Program.EventId);
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            Bitmap mapPic = CaptureMapScreen();
            mapSizeLabel.Text = "(" + mapPic.Width + ", " + mapPic.Height + ").";
            EventNameLabel.Text = e.EventName;
            Point topLeft = new Point(0, 0);
            Point size = new Point(mapPic.Width, mapPic.Height);
            bool isEnabled = false;

            e = new Event(Program.EventId);
            if (e.From1 != -100)
                isEnabled = true;
            if (isEnabled)
            {
                if (e.Bigger1)
                {
                    size.X = mapPic.Width - e.From1;
                    topLeft.X = e.From1;
                }

                if (!e.Bigger1)
                {
                    size.X = e.From1;
                    topLeft.X = 0;
                }

                if (e.Between1)
                {
                    size.X = e.To1 - e.From1;
                    topLeft.X = e.From1;
                }
            }

            isEnabled = false;
            if (e.From2 != -100)
                isEnabled = true;

            if (isEnabled)
            {
                if (e.Bigger2)
                {
                    size.Y = mapPic.Height - e.From2;
                    topLeft.Y = 0;
                }

                if (!e.Bigger2)
                {
                    size.Y = e.From2;
                    topLeft.Y = mapPic.Height - e.From2;
                }

                if (e.Between2)
                {
                    size.Y = e.To2 - e.From2;
                    topLeft.Y = mapPic.Height - e.To2;
                }
            }

            using (Graphics graphics = Graphics.FromImage(mapPic))
            {
                graphics.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(topLeft.X, topLeft.Y, size.X, size.Y));
            }

            miniMapPictureBox.Image = mapPic;
        }

        private void AllEventsButton_Click(object sender, EventArgs eArgs)
        {
            Event e = new Event(Program.EventId);
            ScreenShot map = new ScreenShot(Program.BotId, "map");
            Bitmap mapPic = CaptureMapScreen();

            if (Program.EventId > 0)
            {
                if (AllEventsButton.Text == "Unshow All Events")
                {
                    ShowEventCapture();
                    AllEventsButton.Text = "Show All Events";
                    return;
                }
                else
                {
                    AllEventsButton.Text = "Unshow All Events";
                }
            }
            else
            {
                if (AllEventsButton.Text == "Unshow All Events")
                {
                    miniMapPictureBox.Image = mapPic;
                    EventNameLabel.Text = "None";
                    AllEventsButton.Text = "Show All Events";
                    return;
                }
                else
                {
                    AllEventsButton.Text = "Unshow All Events";
                }
            }

            mapSizeLabel.Text = "(" + mapPic.Width + ", " + mapPic.Height + ").";
            EventNameLabel.Text = "All Events";
            Point topLeft = new Point(0, 0);
            Point size = new Point(mapPic.Width, mapPic.Height);
            bool isEnabled = false;

            Connection c = new Connection("program_data");
            c.conOpen();
            DataSet eventData = c.getDataSet("SELECT * FROM [event] WHERE botId = " + Program.BotId + " AND eventType = 'player position'", "event");
            foreach (DataRow rowEventKey in eventData.Tables["event"].Rows)
            {
                e = new Event(int.Parse(rowEventKey[0].ToString()));
                if (e.From1 != -100)
                    isEnabled = true;
                if (isEnabled)
                {
                    if (e.Bigger1)
                    {
                        size.X = mapPic.Width - e.From1;
                        topLeft.X = e.From1;
                    }

                    if (!e.Bigger1)
                    {
                        size.X = e.From1;
                        topLeft.X = 0;
                    }

                    if (e.Between1)
                    {
                        size.X = e.To1 - e.From1;
                        topLeft.X = e.From1;
                    }
                }

                isEnabled = false;
                if (e.From2 != -100)
                    isEnabled = true;

                if (isEnabled)
                {
                    if (e.Bigger2)
                    {
                        size.Y = mapPic.Height - e.From2;
                        topLeft.Y = 0;
                    }

                    if (!e.Bigger2)
                    {
                        size.Y = e.From2;
                        topLeft.Y = mapPic.Height - e.From2;
                    }

                    if (e.Between2)
                    {
                        size.Y = e.To2 - e.From2;
                        topLeft.Y = mapPic.Height - e.To2;
                    }
                }

                using (Graphics graphics = Graphics.FromImage(mapPic))
                {
                    graphics.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(topLeft.X, topLeft.Y, size.X, size.Y));
                }

                //Refresh 
                topLeft = new Point(0, 0);
                size = new Point(mapPic.Width, mapPic.Height);
                isEnabled = false;
            }
            c.conClose();
            miniMapPictureBox.Image = mapPic;
        }
    }
}
