using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public class GameLoader
    {
        public ContextAdapter AdaptedContext = new();

        public string filePath;
        public string fileContent;

        public void Load()
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "Desktop";
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using StreamReader reader = new(fileStream);
                fileContent = reader.ReadToEnd();
            }

            PopulateAdaptedContext();
        }

        public void PopulateAdaptedContext()
        {
            var deserializedContext = JsonConvert.DeserializeObject<ContextAdapter>(fileContent);

            if (deserializedContext != null && deserializedContext.AdaptedLayout != null)
            {
                foreach (var piece in deserializedContext.AdaptedLayout)
                {
                    AdaptedContext.AdaptedLayout.Add(new(new AdaptedCoordinates(piece.Key.X, piece.Key.Y), piece.Value));
                }
                AdaptedContext.ColorToMove = deserializedContext.ColorToMove;
            }
        }
    }
}
