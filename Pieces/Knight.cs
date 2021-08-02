using System.Drawing;

namespace ChessGame.Pieces
{
    public class Knight : APiece
    {
        public PieceType Type { get { return PieceType.Knight; } private set { } }

        public Knight(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(180, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
