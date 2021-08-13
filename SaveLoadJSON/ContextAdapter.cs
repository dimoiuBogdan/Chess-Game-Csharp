using ChessGame.Pieces;
using System.Collections.Generic;

namespace ChessGame
{
    public class ContextAdapter
    {
        public List<KeyValuePair<AdaptedCoordinate, AdaptedAPiece>> AdaptedLayout;
        public List<AdaptedCoordinate> AdaptedCoordinate;
        public List<AdaptedMove> AdaptedMoves;
        public AdaptedAPiece AdaptedAPiece;
        public PieceColor ColorToMove;

        public ContextAdapter()
        {

        }
    }
}