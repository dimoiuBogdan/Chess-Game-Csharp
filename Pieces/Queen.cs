using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Queen : APiece
    {
        public Queen(PieceColor color) : base(color, PieceType.Queen)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            return availableMoves;
        }
    }
}
