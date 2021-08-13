using ChessGame.Pieces;
using Newtonsoft.Json;
using System.IO;

namespace ChessGame
{
    public class GameLoader
    {
        private string fileContent;

        public GameLoader()
        {

        }

        public GameContext Load(string fileName)
        {
            using StreamReader reader = new(File.OpenRead(fileName));

            fileContent = reader.ReadToEnd();

            return PopulateNewContext();
        }

        private GameContext PopulateNewContext()
        {
            var deserializedContext = JsonConvert.DeserializeObject<ContextAdapter>(fileContent);

            GameContext context = new();
            context.Layout = new();
            context.MoveHistory = new();

            foreach (var piece in deserializedContext.AdaptedLayout)
            {
                context.Layout.Add(Coordinate.GetInstance(piece.Key.X, piece.Key.Y), PieceFactory.GetInstance(piece.Value.Type, piece.Value.Color));
            }

            foreach (var move in deserializedContext.AdaptedMoves)
            {
                context.MoveHistory.Add(new Move(Coordinate.GetInstance(move.Source.X, move.Source.Y), Coordinate.GetInstance(move.Target.X, move.Target.Y)));
            }

            context.ColorToMove = deserializedContext.ColorToMove;

            return context;
        }
    }
}
