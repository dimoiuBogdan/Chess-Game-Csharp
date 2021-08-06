using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Bishop : APiece
    {
        public Bishop(PieceColor color) : base(color, PieceType.Bishop)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                // dreapta sus
                for (int i = 1; i <= source.Y - source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + i, source.Y - i));
                }
                // dreapta jos
                for (int i = 1; i <= 7 - source.Y - source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + i, source.Y + i));
                }
                // stanga sus
                for (int i = 1; i <= source.Y - 7 + source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - i, source.Y - i));
                }
                // stanga jos
                for (int i = 1; i <= 7 - source.Y - (7 - source.X); i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - i, source.Y + i));
                }
            }

            return availableMoves;
        }
    }
}
