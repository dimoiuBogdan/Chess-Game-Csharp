﻿using System.Drawing;

namespace ChessGame.Pieces
{
    public class Knight : APiece
    {
        public PieceType Type { get { return PieceType.Knight; } private set { } }

        public Knight(PieceColor color) : base(color)
        {

        }

        public override Bitmap GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
