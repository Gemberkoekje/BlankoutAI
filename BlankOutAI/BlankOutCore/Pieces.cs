using System;
using System.Collections.Generic;
using System.Text;

namespace BlankOutCore
{
    public class Pieces
    {
        public List<Field> StartingShapes(int d6)
        {
            if (d6 < 1 || d6 > 6)
                throw new ArgumentOutOfRangeException("d6", d6, "Needs to be between 1 and 6");

            var shape = new List<Field>();
            switch(d6)
            {
                case 1:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(1, 2));
                    break;
                case 2:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(1, 2));
                    shape.Add(new Field(1, 3));

                    break;
                case 3:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(2, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(1, 2));

                    break;
                case 4:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(2, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(1, 2));
                    shape.Add(new Field(2, 2));

                    break;
                case 5:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(2, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(2, 1));
                    shape.Add(new Field(2, 2));

                    break;
                case 6:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(2, 1));
                    shape.Add(new Field(1, 2));
                    shape.Add(new Field(2, 2));

                    break;
            }

            return shape;
        }
        public List<Field> PlayingShapes(int d6)
        {
            if (d6 < 1 || d6 > 6)
                throw new ArgumentOutOfRangeException("d6", d6, "Needs to be between 1 and 6");

            var shape = new List<Field>();
            switch (d6)
            {
                case 1:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    break;
                case 2:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(2, 1));
                    shape.Add(new Field(1, 2));

                    break;
                case 3:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(1, 2));
                    shape.Add(new Field(0, 3));

                    break;
                case 4:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(1, 2));

                    break;
                case 5:
                    shape.Add(new Field(0, 0));
                    shape.Add(new Field(0, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(0, 3));

                    break;
                case 6:
                    shape.Add(new Field(1, 0));
                    shape.Add(new Field(1, 1));
                    shape.Add(new Field(0, 2));
                    shape.Add(new Field(1, 2));
                    shape.Add(new Field(2, 2));

                    break;
            }

            return shape;
        }
    }
}
