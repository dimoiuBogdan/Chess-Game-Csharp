using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Knight : APiece
    {
        public Knight(PieceColor color) : base(color, PieceType.Knight)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                // dreapta sus
                if (initialCoordinates.X + 1 >= 0 && initialCoordinates.X + 1 >= 0 && initialCoordinates.Y - 2 >= 0 && initialCoordinates.Y - 2 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X + 1, initialCoordinates.Y - 2));
                }
                // dreapta jos
                if (initialCoordinates.X + 1 <= 7 && initialCoordinates.Y + 2 >= 0 && initialCoordinates.X + 1 >= 0 && initialCoordinates.Y + 2 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X + 1, initialCoordinates.Y + 2));
                }
                // stanga sus
                if (initialCoordinates.X - 1 <= 7 && initialCoordinates.Y - 2 >= 0 && initialCoordinates.X - 1 >= 0 && initialCoordinates.Y - 2 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X - 1, initialCoordinates.Y - 2));
                }
                // stanga jos
                if (initialCoordinates.X - 1 <= 7 && initialCoordinates.Y + 2 >=0 && initialCoordinates.X - 1 >= 0 && initialCoordinates.Y + 2 <= 7)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X - 1, initialCoordinates.Y + 2));
                }
            }
            
            return availableMoves;
        }
    }
}
