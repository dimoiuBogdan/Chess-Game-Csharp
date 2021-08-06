﻿using ChessGame.Pieces;

namespace ChessGame
{
    public class Referee
    {
        private GameContext Context { get; set; }

        // 1. Declaram delegatul si evenimentul ( + clasa de EventArgs )
        public delegate void ChangedContextHandler(object sender, ChangedContextEventArgs e);
        public event ChangedContextHandler ContextChanged;

        public Referee()
        {

        }

        public void Initialize()
        {
            Context = new();

            Context.Layout = new();

            Context.Layout.Initialize();
        }

        public void Start()
        {
            // 4. Transmitem parametrii
            ChangedContextEventArgs changedContextArgs = new(Context.Clone());

            // 5. Invocam metoda in cazul in care avem ascultatori ( vezi clasa inregistrata ca ascultator )
            ContextChanged?.Invoke(this, changedContextArgs);
        }

        public void Board_MoveProposed(object sender, MoveProposedEventArgs e)
        {
            if (IsValid(e.Move))
            {
                Context.Layout.Move(e.Move);
                if (Context.ColorToMove == PieceColor.Black)
                {
                    Context.ColorToMove = PieceColor.White;
                }
                else
                {
                    Context.ColorToMove = PieceColor.Black;
                }
            }

            ChangedContextEventArgs changedContextArgs = new(Context.Clone());

            ContextChanged?.Invoke(this, changedContextArgs);
        }

        private bool IsValid(Move move)
        {
            if (Context.Layout.ContainsKey(move.Target) && Context.Layout[move.Target] != null)
            {
                if (Context.Layout[move.Source].Color != Context.Layout[move.Target].Color)
                {
                    return Context.Layout[move.Source].GetAvailableMoves(move.Source, Context).Contains(move.Target);
                }
            }
            else
            {
                return Context.Layout[move.Source].GetAvailableMoves(move.Source, Context).Contains(move.Target);
            }
            return false;
        }

        public void Cleanup()
        {
            Context.Layout.Cleanup();

            Context.Layout = null;

            Context = null;
        }
    }
}

// Ce constructor se apeleaza ( in C++ cand dai return din constructor, se returneaza o clona )