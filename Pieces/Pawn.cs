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

            if (context.ColorToMove == Color)
            {
                Coordinate moveTwoCells, moveOneCell;
                bool isOneCellEmpty;
                bool isUp = Color == PieceColor.Black;
                bool isFirstMove = isUp ? initialCoordinates.Y == 1 : initialCoordinates.Y == 6;

                moveTwoCells = Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 2 : initialCoordinates.Y - 2);
                moveOneCell = Coordinate.GetInstance(initialCoordinates.X, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                isOneCellEmpty = isUp ? initialCoordinates.Y + 1 <= 7 : initialCoordinates.Y - 1 <= 7 && isUp ? initialCoordinates.Y + 1 >= 0 : initialCoordinates.Y - 1 >= 0;


                if (isFirstMove && !context.Layout.ContainsKey(moveTwoCells) && !context.Layout.ContainsKey(moveOneCell)
                    && (isUp ? initialCoordinates.Y + 2 <= 7 : initialCoordinates.Y - 2 <= 7
                    && isUp ? initialCoordinates.Y + 2 >= 0 : initialCoordinates.Y - 2 >= 0))
                {
                    availableMoves.Add(moveTwoCells);
                }
                if ((isOneCellEmpty) && !context.Layout.ContainsKey(moveOneCell))
                {
                    availableMoves.Add(moveOneCell);
                }

                if (isOneCellEmpty)
                {
                    // atac stanga
                    if (initialCoordinates.X - 1 <= 7 && initialCoordinates.X - 1 >= 0)
                    {
                        var LeftAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X - 1, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(LeftAttackCoordinate) && context.Layout[LeftAttackCoordinate] != null
                            && context.Layout[LeftAttackCoordinate].Color != context.Layout[initialCoordinates].Color)
                        {
                            availableMoves.Add(LeftAttackCoordinate);
                        }
                    }

                    // atac dreapta
                    if (initialCoordinates.X + 1 <= 7 && initialCoordinates.X + 1 >= 0)
                    {
                        var rightAttackCoordinate = Coordinate.GetInstance(initialCoordinates.X + 1, isUp ? initialCoordinates.Y + 1 : initialCoordinates.Y - 1);
                        if (context.Layout.ContainsKey(rightAttackCoordinate) && context.Layout[rightAttackCoordinate] != null
                            && context.Layout[rightAttackCoordinate].Color != context.Layout[initialCoordinates].Color)
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
