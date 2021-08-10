using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public class GameSaver
    {
        public static void Save(string file)
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
                using StreamWriter sw = new(saveFileWindow.FileName);
                sw.Write(file);
            }
        }
    }
}
