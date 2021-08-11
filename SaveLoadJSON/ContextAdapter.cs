using System.Collections.Generic;

namespace ChessGame
{
    public class ContextAdapter
    {
        public GameContext ReceivedContext;
        public static GameContext newContext;
        public List<Coordinate> AdaptedCoordinates = new();

        public ContextAdapter(GameContext actualContext)
        {
            ReceivedContext = actualContext;
        }

        public void PopulateCoordinates()
        {
            newContext = new();
            newContext.Layout = new();
            newContext.ColorToMove = new();

            if (ReceivedContext != null && ReceivedContext.Layout != null)
            {
                foreach (KeyValuePair<Coordinate, APiece> piece in ReceivedContext.Layout)
                {
                    AdaptedCoordinates.Add(piece.Key);
                }
            }
        }

        public void PopulateLayout()
        {
            PopulateCoordinates();
            if (ReceivedContext != null && ReceivedContext.Layout != null && AdaptedCoordinates != null)
            {
                var i = 0;
                foreach (KeyValuePair<Coordinate, APiece> piece in ReceivedContext.Layout)
                {
                    newContext.Layout.Add(AdaptedCoordinates[i], piece.Value);
                    i++;
                }
            }
            newContext.ColorToMove = ReceivedContext.ColorToMove;

            foreach (KeyValuePair<Coordinate, APiece> kvp in newContext.Layout)
            {
                Logger.Display(string.Format("X = {0}, Y = {1}, Value = {2}", kvp.Key.X, kvp.Key.Y, kvp.Value));
            }
        }

        public void PopulateContext(GameContext context)
        {
            if (ReceivedContext != null && ReceivedContext.Layout != null && AdaptedCoordinates != null)
            {
                foreach (KeyValuePair<Coordinate, APiece> piece in ReceivedContext.Layout)
                {
                    AdaptedCoordinates.Add(piece.Key);
                }

                var i = 0;
                foreach (KeyValuePair<Coordinate, APiece> piece in ReceivedContext.Layout)
                {
                    context.Layout.Add(AdaptedCoordinates[i], piece.Value);
                    i++;
                }
            }
            context.ColorToMove = ReceivedContext.ColorToMove;
        }
    }
}