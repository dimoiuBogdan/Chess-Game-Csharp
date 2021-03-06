using ChessGame.Pieces;
using System.Windows.Forms;

namespace ChessGame
{
    public class Referee
    {
        private GameContext Context { get; set; }

        // 1. Declaram delegatul si evenimentul ( + clasa de EventArgs )
        public delegate void ChangedContextHandler(object sender, ChangedContextEventArgs e);
        public event ChangedContextHandler ContextChanged;

        private bool RightCastling { get; set; }
        private Coordinate RookPosition { get; set; }

        public Referee()
        {

        }

        public void Initialize()
        {
            Context = new();

            Context.Layout = new();
            Context.Layout.Initialize();

            Context.MoveHistory = new();
        }

        public void StartWithContext(GameContext context)
        {
            Context = context.Clone();
            Start();
        }

        public void Start()
        {
            // 4. Transmitem parametrii
            ChangedContextEventArgs changedContextArgs = new(Context.Clone());

            // 5. Invocam metoda in cazul in care avem ascultatori ( vezi clasa inregistrata ca ascultator )
            ContextChanged?.Invoke(this, changedContextArgs);
        }

        public GameContext GetContext()
        {
            return Context.Clone();
        }

        public void Board_MoveProposed(object sender, MoveProposedEventArgs e)
        {
            try
            {
                if (IsValid(e.Move))
                {
                    if (IsCastling(e.Move))
                    {
                        Move castling = new(RookPosition, Coordinate.GetInstance(RightCastling ? e.Move.Source.X + 1 : e.Move.Source.X - 1, e.Move.Source.Y));
                        Context.Layout.Move(castling);
                    }

                    Context.Layout.Move(e.Move);
                    Context.MoveHistory.Add(e.Move);

                    Context.ColorToMove = Context.ColorToMove == PieceColor.Black ? PieceColor.White : PieceColor.Black;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Could not validate move");
            }

            try
            {
                ChangedContextEventArgs changedContextArgs = new(Context.Clone());

                ContextChanged?.Invoke(this, changedContextArgs);
            }
            catch (System.Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Context could not be sent");
            }
        }

        private bool IsValid(Move move)
        {
            return Context.Layout[move.Source].GetAvailableMoves(move.Source, Context).Contains(move.Target);
        }

        public bool IsCastling(Move move)
        {
            if (Context.Layout[move.Source].Type == PieceType.King)
            {
                RightCastling = move.Target.X == 5;
                RookPosition = Coordinate.GetInstance(RightCastling ? move.Target.X + 2 : move.Target.X - 1, move.Target.Y);

                return Context.Layout.ContainsKey(RookPosition) && Context.Layout[RookPosition].Type == PieceType.Rook && (Context.Layout[move.Source].Color == Context.Layout[RookPosition].Color);
            }
            return false;
        }

        public void Cleanup()
        {
            Context.Layout.Cleanup();
            Context.Layout = null;

            Context.MoveHistory.Clear();
            Context.MoveHistory = null;

            Context = null;
        }
    }
}

// Ce constructor se apeleaza ( in C++ cand dai return din constructor, se returneaza o clona )