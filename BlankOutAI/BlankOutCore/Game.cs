using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankOutCore
{
    public class Game
    {
        List<Player> Players;

        Random rand;

        Pieces pieces;
        List<int> d6;

        int Width;
        int Height;

        public void NewGame(int players, int width = 9, int height = 9)
        {
            if (players < 1 || players > 99)
                throw new ArgumentOutOfRangeException("players", players, "Needs to be between 1 and 99");

            if ((((float)width) / 2) == (float)(width / 2))
                throw new ArgumentOutOfRangeException("width", width, "Needs to be an odd number");
            if ((((float)height) / 2) == (float)(height / 2))
                throw new ArgumentOutOfRangeException("height", height, "Needs to be an odd number");


            pieces = new Pieces();

            Players = new List<Player>();

            for(int b = 0; b < players; b++)
            {
                Players.Add(new Player(b, width, height));
            }
            rand = new Random();
            d6 = new List<int>();
            d6.Add(rand.Next(1, 7));
            Width = width;
            Height = height;
        }
        public Board GetBoard(int playerID)
        {
            var player = Players.First(p => p.ID == playerID);
            return player.Board;
        }
        public Player GetPlayer(int playerID)
        {
            var player = Players.First(p => p.ID == playerID);
            return player;
        }
        public Piece GetNextPiece(int playerID)
        {
            var player = Players.First(p => p.ID == playerID);

            if (player.PiecesPlaced >= d6.Count)
                throw new InvalidOperationException("Wait for the other players to place their pieces");

            var curd6 = d6[player.PiecesPlaced];
            return new Piece(player.PiecesPlaced == 0, curd6);
        }

        public void SetPiece(int playerID, int x, int y, int rotations, bool flippedhorizontally, bool flippedvertically)
        {
            var player = Players.First(p => p.ID == playerID);
            if (player.PiecesPlaced >= d6.Count)
                throw new InvalidOperationException("Wait for the other players to place their pieces");

            var curd6 = d6[player.PiecesPlaced];
            Piece shape = new Piece(player.PiecesPlaced == 0, curd6);

            for(int r = 0; r < rotations; r++)
                shape.Rotate();
            if (flippedhorizontally)
                shape.MirrorHorizontal();
            if (flippedvertically)
                shape.MirrorVertical();

            var list = shape.Fields.ToList();
            list.ForEach(f => f.X += x);
            list.ForEach(f => f.Y += y);
            //Pieces should be within the playing field
            //if (x < 0 || x >= Width)
            if (list.Any(f => f.X <0 || f.X >= Width || f.Y < 0 || f.Y >= Height))
                throw new InvalidOperationException("Piece is placed out of bounds.");
            //First piece needs to be on the center block
            if (player.PiecesPlaced == 0)
            {
                var cx = (Width / 2);
                var cy = (Height / 2);
                if(!list.Any(f => f.X == cx && f.Y == cy))
                    throw new InvalidOperationException("First piece needs to be placed on the center");

            }
            else
            {
                //Other pieces need to be placed adjacent to but not on already placed pieces
                foreach(var pp in player.Board.Fields)
                    if(list.Any(f => f.X == pp.X && f.Y == pp.Y))
                        throw new InvalidOperationException("Can't place a piece on top of another piece");

                bool adjacent = false;
                foreach (var pp in player.Board.Fields)
                {
                    if (list.Any(f => f.X == pp.X - 1 && f.Y == pp.Y))
                        adjacent = true;
                    if (list.Any(f => f.X == pp.X + 1 && f.Y == pp.Y))
                        adjacent = true;
                    if (list.Any(f => f.X == pp.X && f.Y == pp.Y - 1))
                        adjacent = true;
                    if (list.Any(f => f.X == pp.X && f.Y == pp.Y + 1))
                        adjacent = true;
                    if (adjacent == true)
                        break;
                }

                if(!adjacent)
                    throw new InvalidOperationException("Pieces need to touch at least one other piece.");

            }
            

            //Then place it
            foreach (var f in list)
            {
                player.Board.SetField(f.X, f.Y);
            }
            player.PiecesPlaced++;

            if (Players.All(p => p.PiecesPlaced == d6.Count))
            {
                d6.Add(rand.Next(1, 7));

                foreach(var p in Players)
                {
                    bool valid = false;
                    for(int rot = 0; rot < 4; rot++)
                    {
                        for (int mx = 0; mx < 2; mx++)
                        {
                            for (int my = 0; my < 2; my++)
                            {
                                for (int py = 0; py < Height; py++)
                                {
                                    for (int px = 0; px < Width; px++)
                                    {

                                        if (valid)
                                            break;
                                    }
                                    if (valid)
                                        break;
                                }
                                if (valid)
                                    break;
                            }
                            if (valid)
                                break;

                        }
                        if (valid)
                            break;
                    }
                }

            }

        }
    }
}
