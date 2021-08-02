using System.Drawing;

namespace ChessGame.Pieces
{
    public class King : APiece
    {
        public PieceType Type { get { return PieceType.King; } private set { } }

        public King(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
