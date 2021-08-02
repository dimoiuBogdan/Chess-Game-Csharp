using System.Drawing;

namespace ChessGame.Pieces
{
    public class Bishop : APiece
    {
        public PieceType Type { get { return PieceType.Bishop; } private set { } }

        public Bishop(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(240, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
