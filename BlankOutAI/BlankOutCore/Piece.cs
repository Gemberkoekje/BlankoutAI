using System;
using System.Collections.Generic;
using System.Text;

namespace BlankOutCore
{
    class Piece
    {
        List<Field> Fields;

        Piece(bool startingPiece, int d6)
        {
            var Pieces = new Pieces();
            if (startingPiece)
                Fields = Pieces.StartingShapes(d6);
            else
                Fields = Pieces.PlayingShapes(d6);
        }

        void Rotate()
        {

        }
        void Mirror()
        {

        }
    }
}
