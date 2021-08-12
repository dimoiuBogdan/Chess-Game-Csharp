using ChessGame.Pieces;

namespace ChessGame
{
    public class AdaptedAPiece
    {
        public PieceColor Color { get; set; }
        public PieceType Type { get; set; }

        public AdaptedAPiece(PieceColor color, PieceType type)
        {
            Color = color;
            Type = type;
        }
    }
}