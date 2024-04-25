using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С__game_of_life
{
    internal class Life
    {
        public SolidBrush black = new SolidBrush(Color.Black);

        public List<Point> body = new List<Point>();

        public List<Point> nextGeneration = new List<Point>();

        public int NeighborCounter(Point point)
        {
            int counter = 0;

            Point neighbor = new Point();

            neighbor.X = point.X;
            neighbor.Y = point.Y + 16;
            if (body.Contains(neighbor) && neighbor.Y < 800)
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor) && neighbor.Y > 0)
                counter++;

            neighbor.X = point.X + 16;
            neighbor.Y = point.Y;
            if (body.Contains(neighbor) && neighbor.X < 800)
                counter++;

            neighbor.X = point.X - 16;
            if (body.Contains(neighbor) && neighbor.X > 0)
                counter++;

            neighbor.X = point.X + 16;
            neighbor.Y = point.Y + 16;
            if (body.Contains(neighbor) && neighbor.X < 800)
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor) && neighbor.X < 800 && neighbor.Y > 0)
                counter++;

            neighbor.X = point.X - 16;
            neighbor.Y = point.Y + 16;
            if (body.Contains(neighbor) && neighbor.Y < 800 && neighbor.X > 0)
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor) && neighbor.X > 0 && neighbor.Y > 0)
                counter++;

            return counter;
        }
    }
}
