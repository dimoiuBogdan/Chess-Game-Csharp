using ChessGame.Pieces;
using System;
using System.Collections.Generic;

namespace ChessGame
{
    public class BoardLayout : Dictionary<Coordinate, APiece>
    {

        public BoardLayout()
        {

        }

        public void Initialize()
        {
            for (var i = 0; i < 8; i++)
            {
                if(Coordinate.GetInstance(i, 1) != null && Coordinate.GetInstance(i, 6) != null)
                {
                    Add(Coordinate.GetInstance(i, 1), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.White));
                    Add(Coordinate.GetInstance(i, 6), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.Black));
                }
            }
        }

        public void Cleanup()
        {
            this.Clear();
        }
    }
}
// Centrarea tablei
// Throw exception la coordonate
// Piese pe tabla