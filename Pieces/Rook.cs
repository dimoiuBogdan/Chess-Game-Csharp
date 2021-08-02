using System.Drawing;

namespace ChessGame.Pieces
{
    public class Rook : APiece
    {
        public PieceType Type { get { return PieceType.Rook; } private set { } }

        public Rook(PieceColor color) : base(color)
        {

        }
        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(120, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
