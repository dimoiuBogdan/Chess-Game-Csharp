using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public class GameSaver
    {
        public ContextAdapter AdaptedContext = new();

        public void PopulateLayout(GameContext receivedContext)
        {
            if (receivedContext != null && receivedContext.Layout != null)
            {
                foreach (var piece in receivedContext.Layout)
                {
                    AdaptedContext.AdaptedAPiece = new AdaptedAPiece(piece.Value.Color, piece.Value.Type);
                    AdaptedContext.AdaptedLayout.Add(new(new AdaptedCoordinate(piece.Key.X, piece.Key.Y), new AdaptedAPiece(piece.Value.Color, piece.Value.Type)));
                }
            }
            AdaptedContext.ColorToMove = receivedContext.ColorToMove;
        }

        public void Save()
        {
            SaveFileDialog saveFileWindow = new()
            {
                Filter = "json files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "Chess Game Context"
            };

            if (saveFileWindow.ShowDialog() == DialogResult.OK)
            {
                string serializedContext = JsonConvert.SerializeObject(AdaptedContext, Formatting.Indented);

                using StreamWriter sw = new(saveFileWindow.FileName);
                sw.Write(serializedContext);
            }
        }
    }
}
