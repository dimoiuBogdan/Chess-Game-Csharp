using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class King : APiece
    {
        public King(PieceColor color) : base(color, PieceType.King)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates)
        {
            List<Coordinate> availableMoves = new();

            return availableMoves;
        }
    }
}
