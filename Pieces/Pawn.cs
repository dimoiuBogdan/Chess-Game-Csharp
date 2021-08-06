using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public bool FirstMove = true;

        public Pawn(PieceColor color) : base(color, PieceType.Pawn)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {

                if (initialCoordinates.Y + 1 < 8 && initialCoordinates.X < 8 && initialCoordinates.Y - 1 >= 0 && initialCoordinates.X >= 0)
                {
                    if (Color == PieceColor.Black)
                    {
                        if (FirstMove)
                        {
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y + 2));
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y + 1));
                        }
                        else
                        {
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y + 1));
                        }
                    }
                    else
                    {
                        if (FirstMove)
                        {
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y - 2));
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y - 1));
                        }
                        else
                        {
                            availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, initialCoordinates.Y - 1));
                        }
                    }
                }
            }

            return availableMoves;
        }
    }
}
