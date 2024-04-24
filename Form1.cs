using System.Drawing;

namespace С__game_of_life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen pen = new Pen(Color.LightGray, 1);

        SolidBrush black = new SolidBrush(Color.Black);

        List<Point> life = new List<Point>();

        bool pause = false;

        public void FormPaint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < Height; y += 16)
            {
                for (int x = 0; x < Width; x += 16)
                {
                    g.DrawRectangle(pen, x, y, 16, 16);
                    Point point = new Point(x, y);
                    if ( life.Contains(point))
                    {
                        g.FillRectangle(black, x, y, 16, 16);
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                int x = e.X / 16 * 16;
                int y = e.Y / 16 * 16;

                Point clickedPoint = new Point(x, y);

                if (life.Contains(clickedPoint))
                {
                    life.Remove(clickedPoint);
                }
                else
                {
                    life.Add(clickedPoint);
                }

                Invalidate();
            }
        }
    }
}