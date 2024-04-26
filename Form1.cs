using System;
using System.Collections.Generic;
using System.Drawing;

namespace С__game_of_life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeTimer();
        }

        Pen pen = new Pen(Color.LightGray, 1);

        Life life = new Life();

        bool pause = false;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void InitializeTimer()
        {
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            Pause();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Pause()
        {
            if (pause)
                timer.Start();
            else
                timer.Stop();
            pause = !pause;
        }

        public void FormPaint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < Height; y += 16)
            {
                for (int x = 0; x < Width; x += 16)
                {
                    Point point = new Point(x, y);
                    bool isAlive = false;
                    if (!pause)
                        isAlive = (life.body.Contains(point) &&
                            (life.NeighborCounter(point) == 2 || life.NeighborCounter(point) == 3)) ||
                            (!life.body.Contains(point) && life.NeighborCounter(point) == 3);
                    else if (pause && life.body.Contains(point))
                    {
                        g.FillRectangle(life.black, x, y, 16, 16);
                        life.nextGeneration.Add(point);
                        g.DrawRectangle(pen, x, y, 16, 16);
                        continue;
                    }
                    if (isAlive)
                    {
                        g.FillRectangle(life.black, x, y, 16, 16);
                        life.nextGeneration.Add(point);
                    }
                    g.DrawRectangle(pen, x, y, 16, 16);
                }
            }
            life.body = new List<Point>(life.nextGeneration);
            life.nextGeneration.Clear();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && pause)
            {

                int x = e.X / 16 * 16;
                int y = e.Y / 16 * 16;

                Point clickedPoint = new Point(x, y);

                if (life.body.Contains(clickedPoint))
                {
                    life.body.Remove(clickedPoint);
                }
                else
                {
                    life.body.Add(clickedPoint);
                }
                Invalidate();
            }
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case (Keys.Space):
                    Pause();
                    break;
                case (Keys.C):
                    life.body.Clear();
                    Invalidate();
                    break;
            }
        }
    }
}