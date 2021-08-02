using System.Drawing;

namespace ChessGame.Pieces
{
    public class Queen : APiece
    {
        public PieceType Type { get { return PieceType.Queen; } private set { } }

        public Queen(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
