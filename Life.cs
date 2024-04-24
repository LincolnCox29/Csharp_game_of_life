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
            if (body.Contains(neighbor))
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor))
                counter++;

            neighbor.X = point.X + 16;
            neighbor.Y = point.Y;
            if (body.Contains(neighbor))
                counter++;

            neighbor.X = point.X - 16;
            if (body.Contains(neighbor))
                counter++;

            neighbor.X = point.X + 16;
            neighbor.Y = point.Y + 16;
            if (body.Contains(neighbor))
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor))
                counter++;

            neighbor.X = point.X - 16;
            neighbor.Y = point.Y + 16;
            if (body.Contains(neighbor))
                counter++;

            neighbor.Y = point.Y - 16;
            if (body.Contains(neighbor))
                counter++;

            return counter;
        }
    }
}
