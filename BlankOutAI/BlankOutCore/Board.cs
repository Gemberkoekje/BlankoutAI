using System;
using System.Collections.Generic;
using System.Linq;

namespace BlankOutCore
{
    public class Field
    {
        public Field(int x,int y)
        {
            X = x;
            Y = y;
        }
        public int X;
        public int Y;
    }
    public class Board
    {
        public List<Field> Fields;

        public int height;
        public int width;

        public void SetField(int x, int y)
        {
            if (x < 1 || x > width)
                throw new ArgumentOutOfRangeException("x", x, string.Format("Needs to be between 1 and {0}", width));
            if (y < 1 || y > height)
                throw new ArgumentOutOfRangeException("y", y, string.Format("Needs to be between 1 and {0}", height));
            if(Fields.Any(f => f.X == x && f.Y == y))
                throw new InvalidOperationException(string.Format("Field {0}, {1} is already filled", x,y));

            Fields.Add(new Field(x, y));
        }

    }
}
