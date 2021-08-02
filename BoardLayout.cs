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
            // Downside pawns
            for (var i = 0; i < 8; i++)
            {
                if(Coordinate.GetInstance(i, 1) != null)
                {
                    Add(Coordinate.GetInstance(i, 1), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.White));
                }
            }

            // Upside pawns
            for (var i = 0; i < 8; i++)
            {
                if (Coordinate.GetInstance(i, 6) != null)
                {
                    Add(Coordinate.GetInstance(i, 6), PieceFactory.GetInstance(PieceType.Pawn, PieceColor.Black));
                }
            }

            // Logic to add the backline pieces
            int yCoord, boardSize = 7; // starting from 0
            var pieceTypeValues = Enum.GetValues(typeof(PieceType));
            PieceColor Color;
            for (int xTypeCoord = 0; xTypeCoord < pieceTypeValues.Length - 1; xTypeCoord++)
            {
                for (int i = 0; i < 2; i++)
                {
                    yCoord = i == 0 ? 0 : 7;
                    Color = yCoord == 0 ? PieceColor.White : PieceColor.Black;

                    // Add every piece once
                    if(Coordinate.GetInstance(xTypeCoord, yCoord) != null) 
                    {
                        Add(Coordinate.GetInstance(xTypeCoord, yCoord), PieceFactory.GetInstance((PieceType)xTypeCoord,
                            Color));
                    }

                    // Add every piece again, except King and Queen
                    if ((PieceType)xTypeCoord != PieceType.Queen && (PieceType)xTypeCoord != PieceType.King && Coordinate.GetInstance(boardSize - xTypeCoord, yCoord) != null)
                    {
                        Add(Coordinate.GetInstance(boardSize - xTypeCoord, yCoord), PieceFactory.GetInstance((PieceType)xTypeCoord,
                            Color));
                    }
                }
            }
        }

        public void Cleanup()
        {
            this.Clear();
        }
    }
}