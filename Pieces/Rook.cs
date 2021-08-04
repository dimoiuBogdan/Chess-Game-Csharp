using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Rook : APiece
    {
        public Rook(PieceColor color) : base(color, PieceType.Rook)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates)
        {
            List<Coordinate> availableMoves = new();

            return availableMoves;
        }
    }
}
