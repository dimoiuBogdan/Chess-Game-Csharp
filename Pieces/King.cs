using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class King : APiece
    {
        private bool EmptyBetweenRookAndKing = true;

        public King(PieceColor color) : base(color, PieceType.King)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                // dreapta
                if (source.X + 1 >= 0 && source.Y >= 0 && source.X + 1 <= 7 && source.Y <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y)) && context.Layout[Coordinate.GetInstance(source.X + 1, source.Y)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y));
                        }
                    }
                }
                // stanga
                if (source.X - 1 >= 0 && source.Y >= 0 && source.X - 1 <= 7 && source.Y <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y)) && context.Layout[Coordinate.GetInstance(source.X - 1, source.Y)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y));
                        }
                    }
                }
                // sus
                if (source.X >= 0 && source.Y + 1 >= 0 && source.X <= 7 && source.Y + 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X, source.Y + 1)) && context.Layout[Coordinate.GetInstance(source.X, source.Y + 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X, source.Y + 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X, source.Y + 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X, source.Y + 1));
                        }
                    }
                }
                // jos
                if (source.X >= 0 && source.Y - 1 >= 0 && source.X <= 7 && source.Y - 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X, source.Y - 1)) && context.Layout[Coordinate.GetInstance(source.X, source.Y - 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X, source.Y - 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X, source.Y - 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X, source.Y - 1));
                        }
                    }
                }
                // dreapta sus
                if (source.X + 1 >= 0 && source.Y - 1 >= 0 && source.X + 1 <= 7 && source.Y - 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y - 1)) && context.Layout[Coordinate.GetInstance(source.X + 1, source.Y - 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y - 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y - 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y - 1));
                        }
                    }
                }
                // dreapta jos
                if (source.X + 1 >= 0 && source.Y + 1 >= 0 && source.X + 1 <= 7 && source.Y + 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y + 1)) && context.Layout[Coordinate.GetInstance(source.X + 1, source.Y + 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y + 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y + 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y + 1));
                        }
                    }
                }
                // stanga sus
                if (source.X - 1 >= 0 && source.Y - 1 >= 0 && source.X - 1 <= 7 && source.Y - 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y - 1)) && context.Layout[Coordinate.GetInstance(source.X - 1, source.Y - 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y - 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y - 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y - 1));
                        }
                    }
                }
                // stanga jos
                if (source.X - 1 >= 0 && source.Y + 1 >= 0 && source.X - 1 <= 7 && source.Y + 1 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y + 1)) && context.Layout[Coordinate.GetInstance(source.X - 1, source.Y + 1)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y + 1));
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y + 1)))
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y + 1));
                        }
                    }
                }
                // rocada mica
                if (source.X - 3 >= 0 && source.Y >= 0 && source.X - 3 <= 7 && source.Y <= 7)
                {
                    EmptyBetweenRookAndKing = true;
                    for (int i = 1; i < 3; i++)
                    {
                        if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - i, source.Y)) && context.Layout[Coordinate.GetInstance(source.X - i, source.Y)] != null)
                        {
                            EmptyBetweenRookAndKing = false;
                            break;
                        }
                    }

                    if (EmptyBetweenRookAndKing && (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 3, source.Y)) && context.Layout[Coordinate.GetInstance(source.X - 3, source.Y)].Color == context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color && context.Layout[Coordinate.GetInstance(source.X - 3, source.Y)] != null && context.Layout[Coordinate.GetInstance(source.X - 3, source.Y)].Type == PieceType.Rook))
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 2, source.Y));
                    }
                }
                // rocada mica
                if (source.X + 4 >= 0 && source.Y >= 0 && source.X + 4 <= 7 && source.Y <= 7)
                {
                    EmptyBetweenRookAndKing = true;
                    for (int i = 1; i <= 3; i++)
                    {
                        if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + i, source.Y)) && context.Layout[Coordinate.GetInstance(source.X + i, source.Y)] != null)
                        {
                            EmptyBetweenRookAndKing = false;
                            break;
                        }
                    }

                    if (EmptyBetweenRookAndKing && (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 4, source.Y)) && context.Layout[Coordinate.GetInstance(source.X + 4, source.Y)].Color == context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color && context.Layout[Coordinate.GetInstance(source.X + 4, source.Y)] != null && context.Layout[Coordinate.GetInstance(source.X + 4, source.Y)].Type == PieceType.Rook))
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 2, source.Y));
                    }
                }
            }

            return availableMoves;
        }
    }
}
