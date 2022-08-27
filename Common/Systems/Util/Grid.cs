using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luciful.Common.Systems.Util
{
    internal class Grid
    {
        public Point position1;
        public Point position2;
        public Point currentPos;

        public Grid(Point pos1, Point pos2)
        {
            position1 = pos1;
            position2 = pos2;
            currentPos = pos1;
        }
        public Grid(Vector2 pos1, Vector2 pos2)
        {
            position1 = new Point((int)pos1.X, (int)pos1.Y);
            position2 = new Point((int)pos2.X, (int)pos2.Y);
            currentPos = new Point((int)pos1.X, (int)pos1.Y);
        }

        public Point? nextPos(bool wrap = true)
        {
            currentPos.X++;
            if (currentPos.X > position2.X) 
            {
                currentPos.X = position1.X;
                currentPos.Y++;
            }
            if (currentPos.Y > position2.Y)
            {
                if (wrap) currentPos = position1;
                else return null;
            }
            return currentPos;
        }
    }
}
