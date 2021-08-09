using ChessGame.Pieces;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;

namespace ChessGame
{
    public abstract class APiece
    {
        private static readonly Bitmap chessPiecesImage = new(Assembly.GetExecutingAssembly()
                  .GetManifestResourceStream("ChessGame.Resources.ChessPiecesArray.png"));

        private static Dictionary<PieceColor, Dictionary<PieceType, Bitmap>> _imagesPool;

        public PieceColor Color { get; set; }
        public PieceType Type { get; set; }

        public APiece(PieceColor color, PieceType type)
        {
            this.Color = color;
            this.Type = type;
        }

        public Bitmap GetImage()
        {
            if(_imagesPool == null)
            {
                _imagesPool = new Dictionary<PieceColor, Dictionary<PieceType, Bitmap>>();
            }

            if (!_imagesPool.ContainsKey(Color))
            {
                _imagesPool.Add(Color, new Dictionary<PieceType, Bitmap>());
            }

            if (!_imagesPool[Color].ContainsKey(Type))
            {
                _imagesPool[Color].Add(Type, chessPiecesImage.Clone(new Rectangle((int)Type * 60, (int)Color == 0 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat));
            }

            return _imagesPool[Color][Type];
        }

        public abstract List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, GameContext context);
    }
}