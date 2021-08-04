using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Knight : APiece
    {
        public Knight(PieceColor color) : base(color, PieceType.Knight)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates)
        {
            List<Coordinate> availableMoves = new();

            return availableMoves;
        }
    }
}
