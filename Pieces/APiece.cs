using ChessGame.Pieces;
using System;
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

        public abstract Bitmap GetImage();

    }
}
// Clasa abstracta piece ( culoare si type ) + cele derivate : x
// Enum pentru culoare si type : x
// Piece factory ( pattern factory )
// Bitmap cu poze