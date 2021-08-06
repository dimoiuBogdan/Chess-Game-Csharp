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
            var isBlack = Color == PieceColor.Black;

            if (context.ColorToMove == Color)
            {
                if (FirstMove && isBlack ? initialCoordinates.Y + 2 <= 7 : initialCoordinates.Y - 2 <= 7 && isBlack ? initialCoordinates.Y + 2 >= 0 : initialCoordinates.Y - 2 >= 0)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, isBlack ? initialCoordinates.Y + 2 : initialCoordinates.Y - 2));
                }
                if (isBlack ? initialCoordinates.Y + 1 <= 7 : initialCoordinates.Y - 1 <= 7 && isBlack ? initialCoordinates.Y + 1 >= 0 : initialCoordinates.Y - 1 >= 0)
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, isBlack ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1));
                }

                if (isBlack ? initialCoordinates.Y + 1 <= 7 : initialCoordinates.Y - 1 <= 7 && isBlack ? initialCoordinates.Y + 1 >= 0 : initialCoordinates.Y - 1 >= 0)
                {
                    // atac stanga
                    if (initialCoordinates.X - 1 <= 7 && initialCoordinates.X - 1 >= 0)
                    {
                        var LeftAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X - 1, isBlack ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(LeftAttackCoordinate) && context.Layout[LeftAttackCoordinate] != null)
                        {
                            availableMoves.Add(LeftAttackCoordinate);
                        }
                    }

                    // atac dreapta
                    if (initialCoordinates.X + 1 <= 7 && initialCoordinates.X + 1 >= 0)
                    {
                        var rightAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X + 1, isBlack ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(rightAttackCoordinate) && context.Layout[rightAttackCoordinate] != null)
                        {
                            availableMoves.Add(rightAttackCoordinate);
                        }
                    }

                }

            }

            return availableMoves;
        }
    }
}
