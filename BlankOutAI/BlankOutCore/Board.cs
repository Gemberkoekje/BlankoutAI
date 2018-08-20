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

        public int Height;
        public int Width;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Fields = new List<Field>();
        }

        public void SetField(int x, int y)
        {
            if (x < 0 || x >= Width)
                throw new ArgumentOutOfRangeException("x", x, string.Format("Needs to be between 0 and {0}", Width-1));
            if (y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException("y", y, string.Format("Needs to be between 0 and {0}", Height-1));
            if(Fields.Any(f => f.X == x && f.Y == y))
                throw new InvalidOperationException(string.Format("Field {0}, {1} is already filled", x,y));

            Fields.Add(new Field(x, y));
        }

    }
}
