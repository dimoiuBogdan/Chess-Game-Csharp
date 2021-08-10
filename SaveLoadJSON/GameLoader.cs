using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public class GameLoader
    {
        public static string filePath;
        public static string fileContent;

        public static void Load()
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

        }
    }
}
