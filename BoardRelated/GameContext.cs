using ChessGame.Pieces;

namespace ChessGame
{
    public class GameContext
    {
        public BoardLayout Layout { get; set; }
        public PieceColor ColorToMove = PieceColor.White;

        public GameContext()
        {

        }

        public GameContext Clone()
        {
            var clone = new GameContext
            {
                Layout = Layout.Clone(),
                ColorToMove = ColorToMove
            };

            return clone;
        }
    }
}