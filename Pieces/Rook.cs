using System.Collections.Generic;

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
                // dreapta
                for (int i = 1; i <= 7 - source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + i, source.Y));
                }

                // stanga
                for (int i = 1; i <= source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - i, source.Y));
                }

                // sus
                for (int i = 1; i <= source.Y; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X, source.Y - i));
                }

                // jos
                for (int i = 1; i <= 7 - source.Y; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X, source.Y + i));
                }
            }
            return availableMoves;
        }
    }
}
// 3 : 3
// 7 : 7