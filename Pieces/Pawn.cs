using System.Drawing;

namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public PieceType Type { get { return PieceType.Bishop; } private set { } }

        public Pawn(PieceColor color) : base(color)
        {
            
        }

        public override Bitmap GetImage()
        {
            Bitmap b = new Bitmap(60, 60);
            Graphics.FromImage(b).FillRectangle(Brushes.Green, 10, 10, 40, 40);
            return b;
        }
    }
}
