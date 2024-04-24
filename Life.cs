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

            if (body.Contains(new Point(point.X, point.Y + 16)))
                counter++;
            if (body.Contains(new Point(point.X, point.Y - 16)))
                counter++;
            if (body.Contains(new Point(point.X + 16, point.Y)))
                counter++;
            if (body.Contains(new Point(point.X - 16, point.Y)))
                counter++;
            if (body.Contains(new Point(point.X + 16, point.Y + 16)))
                counter++;
            if (body.Contains(new Point(point.X + 16, point.Y - 16)))
                counter++;
            if (body.Contains(new Point(point.X - 16, point.Y + 16)))
                counter++;
            if (body.Contains(new Point(point.X - 16, point.Y - 16)))
                counter++;

            return counter;
        }
    }
}
