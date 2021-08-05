﻿using System;

namespace ChessGame
{
    public class MoveProposedEventArgs : EventArgs
    {
        public Move Move { get; set; }

        public MoveProposedEventArgs(Move move)
        {
            Move = move;
        }
    }
}
