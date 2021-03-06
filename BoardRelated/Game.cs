using System.Windows.Forms;

namespace ChessGame
{
    public class Game
    {
        public Board Board;
        public Referee Referee;
        public GameLoader Loader;

        public Game()
        {

        }

        public void Initialize()
        {
            Board = new();
            Referee = new();
            Loader = new();

            Board.Initialize();
            Referee.Initialize();

            Board.MoveProposed += Referee.Board_MoveProposed;
            // 2. Inregistram ca ascultator Board ( care actioneaza cu Referee_ContextChanged) la Referee.ContextChanged
            Referee.ContextChanged += Board.Referee_ContextChanged;
            // Cand se declanseaza ContextChanged.Invoke() se declanseaza si metoda inregistrata ca ascultator
        }

        public void Start()
        {
            Referee?.Start();
        }

        public void Save(string fileName)
        {
            GameSaver gameSaver = new();
            gameSaver.Save(Referee.GetContext(), fileName);
        }

        public void Load(string fileName)
        {
            GameLoader gameLoader = new();
            GameContext deserializedContext = gameLoader.Load(fileName);

            Referee.StartWithContext(deserializedContext);
        }

        public void Replay(string fileName)
        {
            GameLoader gameLoader = new();
            GameContext deserializedContext = gameLoader.Load(fileName);
            MovePlayer movePlayer = new(deserializedContext, Referee);

            movePlayer.ReplayMoves();
        }

        public void Cleanup()
        {
            Referee.ContextChanged -= Board.Referee_ContextChanged;
            Board.MoveProposed -= Referee.Board_MoveProposed;

            Referee.Cleanup();
            Board.Cleanup();

            Loader = null;
            Referee = null;
            Board = null;
        }
    }
}
