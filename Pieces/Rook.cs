using System.Drawing;

namespace ChessGame.Pieces
{
    public class Rook : APiece
    {
        public PieceType Type { get { return PieceType.Rook; } private set { } }

        public Rook(PieceColor color) : base(color)
        {

        }
        public override Bitmap GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
