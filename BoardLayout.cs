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
                    Add(Coordinate.GetInstance(i, 6), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.White));
                    Add(Coordinate.GetInstance(i, 1), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.Black));
            }
            var enumValues = Enum.GetValues(typeof(PieceType));

            // 2 3 4 0 1 - 4 3 2
            // 0 1 2 3 4 - 5 6 7
            /*
            for (var i = 0; i < 8; i++)
            {
                var test = (PieceType)(i < 5 ? (i + 2) % 5 : i % 4);
                Add(Coordinate.GetInstance(i, 0), PieceFactory.GetInstance(test, PieceColor.Black));
                Add(Coordinate.GetInstance(i, 7), PieceFactory.GetInstance(test, PieceColor.White));
            }
            */

            Add(Coordinate.GetInstance(0, 0), PieceFactory.GetInstance(PieceType.Rook, PieceColor.Black));
            Add(Coordinate.GetInstance(1, 0), PieceFactory.GetInstance(PieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(2, 0), PieceFactory.GetInstance(PieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(3, 0), PieceFactory.GetInstance(PieceType.King, PieceColor.Black));
            Add(Coordinate.GetInstance(4, 0), PieceFactory.GetInstance(PieceType.Queen, PieceColor.Black));
            Add(Coordinate.GetInstance(5, 0), PieceFactory.GetInstance(PieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(6, 0), PieceFactory.GetInstance(PieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(7, 0), PieceFactory.GetInstance(PieceType.Rook, PieceColor.Black));

            Add(Coordinate.GetInstance(0, 7), PieceFactory.GetInstance(PieceType.Rook, PieceColor.White));
            Add(Coordinate.GetInstance(1, 7), PieceFactory.GetInstance(PieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(2, 7), PieceFactory.GetInstance(PieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(3, 7), PieceFactory.GetInstance(PieceType.King, PieceColor.White));
            Add(Coordinate.GetInstance(4, 7), PieceFactory.GetInstance(PieceType.Queen, PieceColor.White));
            Add(Coordinate.GetInstance(5, 7), PieceFactory.GetInstance(PieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(6, 7), PieceFactory.GetInstance(PieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(7, 7), PieceFactory.GetInstance(PieceType.Rook, PieceColor.White));
        }

        public void Cleanup()
        {
            this.Clear();
        }
    }
}