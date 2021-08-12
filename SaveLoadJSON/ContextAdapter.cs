using ChessGame.Pieces;
using System.Collections.Generic;

namespace ChessGame
{
    public class ContextAdapter
    {
        public List<KeyValuePair<AdaptedCoordinate, AdaptedAPiece>> AdaptedLayout = new();
        public List<AdaptedCoordinate> AdaptedCoordinate;
        public AdaptedMove AdaptedMove;
        public AdaptedAPiece AdaptedAPiece;
        public PieceColor ColorToMove = new();

        public ContextAdapter()
        {

        }
    }
}