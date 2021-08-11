using Newtonsoft.Json;
using System.IO;

namespace ChessGame
{
    public class GameSaver
    {
        public static void Save(string fileName)
        {
            string serializedContext = JsonConvert.SerializeObject(ContextAdapter.newContext, Formatting.Indented);

            using StreamWriter sw = new(fileName);
            sw.Write(serializedContext);
        }
    }
}
