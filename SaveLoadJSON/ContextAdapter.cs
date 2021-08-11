using System.Collections.Generic;

namespace ChessGame
{
    public class ContextAdapter
    {
        public GameContext Context;
        public List<Coordinate> AdaptedCoordinates = new();
        public Dictionary<Coordinate, APiece> AdaptedLayout = new();

        public ContextAdapter(GameContext actualContext)
        {
            Context = actualContext;
        }

        public void PopulateCoordinates()
        {
            if (Context != null && Context.Layout != null)
            {
                foreach (KeyValuePair<Coordinate, APiece> piece in Context.Layout)
                {
                    AdaptedCoordinates.Add(piece.Key);
                }
            }
        }

        public void PopulateLayout()
        {
            PopulateCoordinates();
            if (Context != null && Context.Layout != null && AdaptedCoordinates != null)
            {
                var i = 0;
                foreach (KeyValuePair<Coordinate, APiece> piece in Context.Layout)
                {
                    AdaptedLayout.Add(AdaptedCoordinates[i], piece.Value);
                    i++;
                }
            }

            foreach (KeyValuePair<Coordinate, APiece> kvp in AdaptedLayout)
            {
                Logger.Display(string.Format("X = {0}, Y = {1}, Value = {2}", kvp.Key.X, kvp.Key.Y, kvp.Value));
            }
        }
    }
}