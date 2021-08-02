using System;

namespace ChessGame.Pieces
{
    public class PieceFactory
    {
        public static APiece GetInstance(PieceType type, PieceColor color)
        {
            return type switch
            {
                PieceType.Queen => new Queen(color),
                PieceType.King => new King(color),
                PieceType.Rook => new Rook(color),
                PieceType.Knight => new Knight(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Pawn => new Pawn(color),
                _ => throw new Exception("Invalid argument exception"),
            };
        }
    }
}
