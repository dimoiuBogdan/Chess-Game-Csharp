using ChessGame.Pieces;
using System.Collections.Generic;

namespace ChessGame
{
    public class GameContext
    {
        public BoardLayout Layout { get; set; }
        public List<Move> MoveHistory { get; set; }
        public PieceColor ColorToMove = PieceColor.White;

        public GameContext()
        {

        }

        public GameContext Clone()
        {
            var clone = new GameContext
            {
                Layout = Layout.Clone(),
                ColorToMove = ColorToMove,
                MoveHistory = MoveHistory
            };

            return clone;
        }
    }
}