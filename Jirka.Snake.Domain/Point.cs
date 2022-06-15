using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jirka.Snake.Logic
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Enums.PointStatus Status { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Status = Enums.PointStatus.Empty;
        }

        public Point(int x, int y, Enums.PointStatus status)
        {
            X = x;
            Y = y;
            Status = status;
        }


    }
}
