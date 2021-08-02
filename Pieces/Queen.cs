using System.Drawing;

namespace ChessGame.Pieces
{
    public class Queen : APiece
    {
        public PieceType Type { get { return PieceType.Queen; } private set { } }

        public Queen(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(60, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
