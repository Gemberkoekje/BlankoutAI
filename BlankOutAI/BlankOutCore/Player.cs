using System;
using System.Collections.Generic;
using System.Text;

namespace BlankOutCore
{
    public class Player
    {
        public Player(int id)
        {
            ID = id;
            Board = new Board();
            PiecesPlaced = 0;
            
        }
        public int ID;
        public Board Board;
        public int PiecesPlaced;

    }
}
