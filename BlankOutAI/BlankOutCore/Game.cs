using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankOutCore
{
    class Game
    {
        List<Player> Players;

        Random rand;

        Pieces pieces;
        List<int> d6;

        void NewGame(int players)
        {
            if (players < 1 || players > 99)
                throw new ArgumentOutOfRangeException("players", players, "Needs to be between 1 and 99");

            pieces = new Pieces();

            Players = new List<Player>();

            for(int b = 0; b < players; b++)
            {
                Players.Add(new Player(b));
            }
            rand = new Random();
            d6 = new List<int>();
            d6.Add(rand.Next(1, 7));
        }

        List<Field> GetNextPiece(int playerID)
        {
            var player = Players.First(p => p.ID == playerID);

            if (player.PiecesPlaced >= d6.Count)
                throw new InvalidOperationException("Wait for the other players to place their pieces");

            var curd6 = d6[player.PiecesPlaced];
            if (player.PiecesPlaced == 0)
                return pieces.StartingShapes(curd6);
            else
                return pieces.PlayingShapes(curd6);
        }

        void SetPiece(int playerID, int x, int y, int rotations, bool flipped)
        {
            var player = Players.First(p => p.ID == playerID);
            if (player.PiecesPlaced >= d6.Count)
                throw new InvalidOperationException("Wait for the other players to place their pieces");

            var curd6 = d6[player.PiecesPlaced];
            List<Field> shape;
            if (player.PiecesPlaced == 0)
                shape = pieces.StartingShapes(curd6);
            else
                shape = pieces.PlayingShapes(curd6);



        }
    }
}
