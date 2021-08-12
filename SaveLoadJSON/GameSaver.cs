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
                    AdaptedContext.AdaptedLayout.Add(new(new AdaptedCoordinates(piece.Key.X, piece.Key.Y), piece.Value));
                }
            }
            AdaptedContext.ColorToMove = receivedContext.ColorToMove;

            foreach (var kvp in AdaptedContext.AdaptedCoordinates)
            {
                Logger.Display(string.Format("X = {0}, Y = {1}", kvp.X, kvp.Y));
            }
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
