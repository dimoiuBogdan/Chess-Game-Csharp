namespace ChessGame
{
    public class Game
    {
        public Board Board;
        public Referee Referee;

        public Game()
        {
            Board = new();
            Referee = new();
        }
    }
}
