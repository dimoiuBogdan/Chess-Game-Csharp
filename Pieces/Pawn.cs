using System.Drawing;

namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public PieceType Type { get { return PieceType.Bishop; } private set { } }

        public Pawn(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage(int coordinateY)
        {
            return chessPiecesImage.Clone(new Rectangle(300, coordinateY < 2 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat);
        }
    }
}
