using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class King : APiece
    {
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
                    availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y));
                }
                // stanga
                if (source.X - 1 >= 0 && source.Y >= 0 && source.X - 1 <= 7 && source.Y <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y));
                }
                // sus
                if (source.X >= 0 && source.Y + 1 >= 0 && source.X <= 7 && source.Y + 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X, source.Y + 1));
                }
                // jos
                if (source.X >= 0 && source.Y - 1 >= 0 && source.X <= 7 && source.Y - 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X, source.Y - 1));
                }
                // dreapta sus
                if (source.X + 1 >= 0 && source.Y - 1 >= 0 && source.X + 1 <= 7 && source.Y - 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y - 1));
                }
                // dreapta jos
                if (source.X + 1 >= 0 && source.Y + 1 >= 0 && source.X + 1 <= 7 && source.Y + 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + 1, source.Y + 1));
                }
                // stanga sus
                if (source.X - 1 >= 0 && source.Y - 1 >= 0 && source.X - 1 <= 7 && source.Y - 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y - 1));
                }
                // stanga jos
                if (source.X - 1 >= 0 && source.Y + 1 >= 0 && source.X - 1 <= 7 && source.Y + 1 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - 1, source.Y + 1));
                }
            }

            return availableMoves;
        }
    }
}
