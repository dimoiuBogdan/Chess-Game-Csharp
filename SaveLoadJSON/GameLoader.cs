using ChessGame.Pieces;
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

        public void Load(GameContext context)
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
            PopulateAdaptedContext(context);
        }

        public void PopulateAdaptedContext(GameContext context)
        {
            var deserializedContext = JsonConvert.DeserializeObject<ContextAdapter>(fileContent);

            if (deserializedContext != null && deserializedContext.AdaptedLayout != null)
            {
                foreach (var piece in deserializedContext.AdaptedLayout)
                {
                    context.Layout.Add(Coordinate.GetInstance(piece.Key.X, piece.Key.Y), PieceFactory.GetInstance(piece.Value.Type, piece.Value.Color));
                }
                AdaptedContext.ColorToMove = deserializedContext.ColorToMove;
            }
        }
    }
}
