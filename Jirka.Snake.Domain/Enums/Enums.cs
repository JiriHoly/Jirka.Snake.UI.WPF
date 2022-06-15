using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jirka.Snake.Logic.Enums
{
    public enum SizeOfTheGame 
    {
        small = 10, medium = 20, large = 30, huge = 40
    }

    public enum SpeedOfTheGame
    {
        slow = 80, medium = 120, fast = 160
    }

    public enum PointStatus
    {
        Empty = 0, Food = 1, Snake = 2
    }

    public enum Direction
    {
        Null = 0, Up = 1, Down = -1, Left = 2, Right = -2
    }
}
