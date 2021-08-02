using System.Drawing;

namespace ChessGame.Pieces
{
    public class Bishop : APiece
    {
        public PieceType Type { get { return PieceType.Bishop; } private set { } }

        public Bishop(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
