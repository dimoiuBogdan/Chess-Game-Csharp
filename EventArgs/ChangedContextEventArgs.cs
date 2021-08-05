using System;

namespace ChessGame
{
    public class ChangedContextEventArgs : EventArgs
    {
        // 3. Declaram parametrii transportati
        public GameContext Context { get; set; }

        public ChangedContextEventArgs(GameContext context)
        {
            Context = context;
        }
    }
}
