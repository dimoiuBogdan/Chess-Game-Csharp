using System.Drawing;

namespace ChessGame.Pieces
{
    public class King : APiece
    {
        public PieceType Type { get { return PieceType.King; } private set { } }

        public King(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(0, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
