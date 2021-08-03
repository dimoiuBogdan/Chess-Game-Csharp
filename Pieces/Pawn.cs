using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public Pawn(PieceColor color) : base(color, PieceType.Pawn)
        {

        }

        /*public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates)
        {
            List<Coordinate> availableMoves = new();

            AvailableMoves.Add(initialCoordinates);
            AvailableMoves.Add(new Coordinate(initialCoordinates.X, initialCoordinates.Y + 2));

            return AvailableMoves;
        }*/
    }
}
