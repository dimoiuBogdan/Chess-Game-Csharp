﻿using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Rook : APiece
    {
        public Rook(PieceColor color) : base(color, PieceType.Rook)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, GameContext context)
        {
            List<Coordinate> availableMoves = new();
            var sourcePiece = context.Layout[Coordinate.GetInstance(source.X, source.Y)];

            if (context.ColorToMove == Color)
            {
                Coordinate c;

                // dreapta
                for (int i = 1; i < 7; i++)
                {
                    if (source.X + i < 0 || source.X + i > 7 || source.Y < 0 || source.Y > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X + i, source.Y);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }

                // stanga
                for (int i = 1; i < 7; i++)
                {
                    if (source.X - i < 0 || source.X - i > 7 || source.Y < 0 || source.Y > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X - i, source.Y);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }

                // sus
                for (int i = 1; i < 7; i++)
                {
                    if (source.X < 0 || source.X > 7 || source.Y - i < 0 || source.Y - i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X, source.Y - i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }

                // jos
                for (int i = 1; i < 7; i++)
                {
                    if (source.X < 0 || source.X  > 7 || source.Y + i < 0 || source.Y + i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X, source.Y + i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
            }
            return availableMoves;
        }
    }
}