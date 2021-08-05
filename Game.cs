namespace ChessGame
{
    public class Game
    {
        public Board Board;
        public Referee Referee;

        public Game()
        {

        }

        public void Initialize()
        {
            Board = new();
            Referee = new();

            Board.Initialize();
            Referee.Initialize();

            Board.MoveProposed += Referee.Board_MoveProposed;
            // 2. Inregistram ca ascultator Board ( care actioneaza cu Referee_ContextChanged) la Referee.ContextChanged
            Referee.ContextChanged += Board.Referee_ContextChanged;
            // Cand se declanseaza ContextChanged.Invoke() se declanseaza si metoda inregistrata ca ascultator, ez
        }

        public void Start()
        {
            Referee?.Start();
        }

        public void Cleanup()
        {
            Referee.ContextChanged -= Board.Referee_ContextChanged;
            Board.MoveProposed -= Referee.Board_MoveProposed;

            Referee.Cleanup();
            Board.Cleanup();

            Referee = null;
            Board = null;
        }
    }
}
