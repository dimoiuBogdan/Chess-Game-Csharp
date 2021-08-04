using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Bishop : APiece
    {
        public Bishop(PieceColor color) : base(color, PieceType.Bishop)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates)
        {
            List<Coordinate> availableMoves = new();

            return availableMoves;
        }
    }
}
