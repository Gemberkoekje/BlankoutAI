using BlankOutCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlankOutConsole
{
    public class curPieceDone
    {
        public int X;
        public int Y;
        public int Rot;
        public bool MirrorX;
        public bool MirrorY;
    }

    class Program
    {
        static curPieceDone curPieceDone;
        static string mostRecentErrorMessage;
        static void Main(string[] args)
        {
            var game = new Game();
            game.NewGame(1);
            curPieceDone = new curPieceDone();
            curPieceDone.X = 3;
            curPieceDone.Y = 3;
            curPieceDone.Rot = 0;
            curPieceDone.MirrorX = false;
            curPieceDone.MirrorY = false;
            mostRecentErrorMessage = "";
            bool quit = false;

            while (!quit)
            {
                try
                {
                    Console.Clear();
                    var board = game.GetBoard(0);
                    var currentPiece = game.GetNextPiece(0);
                    for (int r = 0; r < curPieceDone.Rot; r++)
                        currentPiece.Rotate();
                    if (curPieceDone.MirrorX)
                        currentPiece.MirrorHorizontal();
                    if (curPieceDone.MirrorY)
                        currentPiece.MirrorVertical();
                    var pieceleft = currentPiece.Fields.Min(f => f.X) + 1;
                    var piecetop = currentPiece.Fields.Min(f => f.Y) + 1;

                    var piecewidth = currentPiece.Fields.Max(f => f.X)+1;
                    var pieceheight = currentPiece.Fields.Max(f => f.Y)+1;

                    var pieces = currentPiece.Fields.ToList();
                    pieces.ForEach(p => p.X += curPieceDone.X);
                    pieces.ForEach(p => p.Y += curPieceDone.Y);

                    bool isValid = false;
                    if(game.GetPlayer(0).PiecesPlaced==0)
                    {
                        if (pieces.Any(p => p.X == 4 && p.Y == 4))
                            isValid = true;
                    }
                    else
                    {
                        foreach (var piece in board.Fields)
                        {
                            if (pieces.Any(p => p.X == piece.X - 1 && p.Y == piece.Y))
                                isValid = true;
                            if (pieces.Any(p => p.X == piece.X + 1 && p.Y == piece.Y))
                                isValid = true;
                            if (pieces.Any(p => p.X == piece.X && p.Y == piece.Y + 1))
                                isValid = true;
                            if (pieces.Any(p => p.X == piece.X && p.Y == piece.Y - 1))
                                isValid = true;
                        }

                    }

                    for (int y = 0; y < board.Height; y++)
                    {
                        for (int x = 0; x < board.Width; x++)
                        {
                            Console.CursorLeft = (x * 2) + 2;
                            Console.CursorTop = (y * 2) + 2;
                            Console.Write("+-+");
                            Console.CursorLeft = (x * 2) + 2;
                            Console.CursorTop = (y * 2) + 3;
                            if (board.Fields.Any(f => f.X == x && f.Y == y) && pieces.Any(f => f.X == x && f.Y == y))
                                Console.Write("|x|");
                            else if (board.Fields.Any(f => f.X == x && f.Y == y))
                                Console.Write("|#|");
                            else if (pieces.Any(f => f.X == x && f.Y == y) && isValid)
                                Console.Write("|o|");
                            else if (pieces.Any(f => f.X == x && f.Y == y) && !isValid)
                                Console.Write("|x|");
                            else
                                Console.Write("| |");
                            Console.CursorLeft = (x * 2) + 2;
                            Console.CursorTop = (y * 2) + 4;
                            Console.Write("+-+");
                        }
                    }
                    Console.CursorLeft = (0 * 2) + 2;
                    Console.CursorTop = (board.Height * 2) + 3;
                    Console.Write(mostRecentErrorMessage);

                    var k = Console.ReadKey();
                    if (k.Key == ConsoleKey.Escape)
                        quit = true;
                    if (k.Key == ConsoleKey.W || k.Key == ConsoleKey.UpArrow)
                        curPieceDone.Y -= 1;
                    if (k.Key == ConsoleKey.S || k.Key == ConsoleKey.DownArrow)
                        curPieceDone.Y += 1;
                    if (k.Key == ConsoleKey.A || k.Key == ConsoleKey.LeftArrow)
                        curPieceDone.X -= 1;
                    if (k.Key == ConsoleKey.D || k.Key == ConsoleKey.RightArrow)
                        curPieceDone.X += 1;
                    if (curPieceDone.X < 0) curPieceDone.X = 0;
                    if (curPieceDone.Y < 0) curPieceDone.Y = 0;
                    if (curPieceDone.X + piecewidth > 9) curPieceDone.X = 9 - piecewidth;
                    if (curPieceDone.Y + pieceheight > 9) curPieceDone.Y = 9 - pieceheight;

                    if (k.Key == ConsoleKey.R || k.Key == ConsoleKey.Spacebar)
                    {
                        curPieceDone.Rot += 1;
                        if (curPieceDone.Rot > 3)
                            curPieceDone.Rot = 0;
                    }
                    if (k.Key == ConsoleKey.X)
                        curPieceDone.MirrorX = !curPieceDone.MirrorX;
                    if (k.Key == ConsoleKey.Y)
                        curPieceDone.MirrorY = !curPieceDone.MirrorY;

                    if (k.Key == ConsoleKey.Enter)
                        game.SetPiece(0, curPieceDone.X, curPieceDone.Y, curPieceDone.Rot, curPieceDone.MirrorX, curPieceDone.MirrorY);
                    mostRecentErrorMessage = "";
                }catch (Exception e )
                {
                    mostRecentErrorMessage = e.Message;
                }
            }
        }
    }
}
