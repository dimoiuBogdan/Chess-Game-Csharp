using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public Pawn(PieceColor color) : base(color, PieceType.Pawn)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, GameContext context)
        {
            List<Coordinate> availableMoves = new();
            bool isUp = Color == PieceColor.Black;
            bool isFirstMove = isUp ? initialCoordinates.Y == 1 : initialCoordinates.Y == 6;

            if (context.ColorToMove == Color)
            {
                // ceva ciudat la conditie ( ar trebui sa returneze false dupa prima mutare vezi isUp si precedenta operatorilor )
                if (isFirstMove && !context.Layout.ContainsKey(Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 2 : initialCoordinates.Y - 2)) && !context.Layout.ContainsKey(Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1)) && (isUp ? initialCoordinates.Y + 2 <= 7 : initialCoordinates.Y - 2 <= 7 && isUp ? initialCoordinates.Y + 2 >= 0 : initialCoordinates.Y - 2 >= 0))
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 2 : initialCoordinates.Y - 2));
                }
                if (isUp ? initialCoordinates.Y + 1 <= 7 : initialCoordinates.Y - 1 <= 7 && isUp ? initialCoordinates.Y + 1 >= 0 : initialCoordinates.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1)))
                {
                    availableMoves.Add(Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1));
                }

                if (isUp ? initialCoordinates.Y + 1 <= 7 : initialCoordinates.Y - 1 <= 7 && isUp ? initialCoordinates.Y + 1 >= 0 : initialCoordinates.Y - 1 >= 0)
                {
                    // atac stanga
                    if (initialCoordinates.X - 1 <= 7 && initialCoordinates.X - 1 >= 0)
                    {
                        var LeftAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X - 1, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(LeftAttackCoordinate) && context.Layout[LeftAttackCoordinate] != null && context.Layout[LeftAttackCoordinate].Color != context.Layout[initialCoordinates].Color)
                        {
                            availableMoves.Add(LeftAttackCoordinate);
                        }
                    }

                    // atac dreapta
                    if (initialCoordinates.X + 1 <= 7 && initialCoordinates.X + 1 >= 0)
                    {
                        var rightAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X + 1, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(rightAttackCoordinate) && context.Layout[rightAttackCoordinate] != null && context.Layout[rightAttackCoordinate].Color != context.Layout[initialCoordinates].Color)
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
