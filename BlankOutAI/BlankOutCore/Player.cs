using System;
using System.Collections.Generic;
using System.Text;

namespace BlankOutCore
{
    public class Player
    {
        public Player(int id, int boardWidth, int boardHeight)
        {
            ID = id;
            Board = new Board(boardWidth, boardHeight);
            PiecesPlaced = 0;
            
        }
        public int ID;
        public Board Board;
        public int PiecesPlaced;

    }
}
