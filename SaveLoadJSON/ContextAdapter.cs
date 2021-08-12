using ChessGame.Pieces;
using System.Collections.Generic;

namespace ChessGame
{
    public class ContextAdapter
    {
        public List<KeyValuePair<AdaptedCoordinates, APiece>> AdaptedLayout = new();
        public List<AdaptedCoordinates> AdaptedCoordinates = new();
        public PieceColor ColorToMove = new();

        public ContextAdapter()
        {

        }

        // Fara static -
        // Fara metode in adaptor -
        // Fara GameContext in adaptor -
        // Metodele se fac in gameSaver si gameLoader -
        // Trebuie sa am BoardLayout de tip Dictionar<AdaptedCoordinate, APiece> -
        // AdaptedCoordinates de tip <AdaptedCoordinate> -
        // Adaptoarele sunt clase in oglina a celor private -
        // Din loader primesc direct ContextAdapter -
    }
}