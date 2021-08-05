using ChessGame.Pieces;

namespace ChessGame
{
    public class GameContext
    {
        public BoardLayout Layout { get; set; }
        public PieceColor ColorToMove { get; set; }

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
// Ref trimite o clona din context ;
// Board primeste clona ;
// Board face o mutare si o trimite la ref ;
// Ref actualizeaza contextul in functie de clona
// Ref trimite o clona din context
// .......