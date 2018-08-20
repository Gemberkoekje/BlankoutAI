using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankOutCore
{
    public class Piece
    {
        public List<Field> Fields;

        public Piece(bool startingPiece, int d6)
        {
            var Pieces = new Pieces();
            if (startingPiece)
                Fields = Pieces.StartingShapes(d6);
            else
                Fields = Pieces.PlayingShapes(d6);
        }

        public void Rotate()
        {
            int width = Fields.Max(f => f.X)+1;
            int height = Fields.Max(f => f.Y)+1;
            Fields.ForEach(f => f.X = (f.X - (width / 2)));
            Fields.ForEach(f => f.Y = (f.Y - (height / 2)));
            foreach (var field in Fields)
            {

                var tx = field.X;
                field.X = -field.Y;
                field.Y = tx;
            }
            Fields.ForEach(f => f.X = (f.X + (width / 2)));
            Fields.ForEach(f => f.Y = (f.Y + (height / 2)));
        }
        public void MirrorHorizontal()
        {
            int width = Fields.Max(f => f.X);
            Fields.ForEach(f => f.X = (f.X - (width / 2)));
            Fields.ForEach(f => f.X = -f.X);
            Fields.ForEach(f => f.X = (f.X + (width / 2)));
        }
        public void MirrorVertical()
        {
            int height = Fields.Max(f => f.Y);
            Fields.ForEach(f => f.Y = (f.Y - (height / 2)));
            Fields.ForEach(f => f.Y = -f.Y);
            Fields.ForEach(f => f.Y = (f.Y + (height / 2)));
        }
    }
}
