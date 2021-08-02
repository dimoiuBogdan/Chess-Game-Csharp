using ChessGame.Pieces;

namespace ChessGame
{
    public abstract class APiece
    {
        public PieceColor Color { get; set; }

        public APiece(PieceColor color)
        {
            this.Color = color;
        }
        
    }
}
// Clasa abstracta piece ( culoare si type ) + cele derivate : x
// Enum pentru culoare si type : x
// Piece factory ( pattern factory )
// Bitmap cu poze