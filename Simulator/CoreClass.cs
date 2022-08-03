using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulator
{
    public class CoreClass{
        public struct Point
        {
            public char FuledBot;
            public Position Environment;
        }
        public struct Position
        {
            public int x; public int y;
            public Position(int _x, int _y) : this()
            {
                this.x = _x;
                this.y = _y;
            }
        }
        public enum Rotation { LeftUp = 7, Up = 0, RightUp = 1, Right = 2, RightDown = 3, Down = 4, LeftDown = 5, Left = 6 };
    }

}
