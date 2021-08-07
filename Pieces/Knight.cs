using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Knight : APiece
    {
        public Knight(PieceColor color) : base(color, PieceType.Knight)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                // dreapta sus
                if (source.X + 1 >= 0 && source.X + 1 >= 0 && source.Y - 2 >= 0 && source.Y - 2 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y - 2)))
                    {
                        if (context.Layout[Coordinate.GetInstance(source.X + 1, source.Y - 2)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y - 2));
                        }
                    }
                    else
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y - 2));
                    }
                }
                // dreapta jos
                if (source.X + 1 <= 7 && source.Y + 2 >= 0 && source.X + 1 >= 0 && source.Y + 2 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X + 1, source.Y + 2)))
                    {
                        if (context.Layout[Coordinate.GetInstance(source.X + 1, source.Y + 2)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y + 2));
                        }
                    }
                    else
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y + 2));
                    }
                }
                // stanga sus
                if (source.X - 1 <= 7 && source.Y - 2 >= 0 && source.X - 1 >= 0 && source.Y - 2 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y - 2)))
                    {
                        if (context.Layout[Coordinate.GetInstance(source.X - 1, source.Y - 2)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y - 2));
                        }
                    }
                    else
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y - 2));
                    }
                }
                // stanga jos
                if (source.X - 1 <= 7 && source.Y + 2 >=0 && source.X - 1 >= 0 && source.Y + 2 <= 7)
                {
                    if (context.Layout.ContainsKey(Coordinate.GetInstance(source.X - 1, source.Y + 2)))
                    {
                        if (context.Layout[Coordinate.GetInstance(source.X - 1, source.Y + 2)].Color != context.Layout[Coordinate.GetInstance(source.X, source.Y)].Color)
                        {
                            availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y + 2));
                        }
                    }
                    else
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y + 2));
                    }
                }
            }
            
            return availableMoves;
        }
    }
}
