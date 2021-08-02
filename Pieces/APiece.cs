using ChessGame.Pieces;
using System.Drawing;
using System.Reflection;

namespace ChessGame
{
    public abstract class APiece
    {
        protected static Bitmap chessPiecesImage = new(Assembly.GetExecutingAssembly()
                  .GetManifestResourceStream("ChessGame.Resources.ChessPiecesArray.png"));

        public PieceColor Color { get; set; }

        public APiece(PieceColor color)
        {
            this.Color = color;
        }

        public abstract Bitmap GetImage(int coordinateY);

    }
}