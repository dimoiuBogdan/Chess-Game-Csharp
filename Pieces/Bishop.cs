using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public class Bishop : APiece
    {
        public Bishop(PieceColor color) : base(color, PieceType.Bishop)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, GameContext context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                Coordinate c;

                // dreapta sus
                for (int i = 1; i <= 6; i++)
                {
                    if (source.X + i < 0 || source.X + i > 7 || source.Y - i < 0 || source.Y - i > 7)
                    {
                        break;
                    }
                       
                    c = Coordinate.GetInstance(source.X + i, source.Y - i);
                    
                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
                // dreapta jos
                for (int i = 1; i <= 7 - source.Y - source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X + i, source.Y + i));
                }
                // stanga sus
                for (int i = 1; i <= source.Y - 7 + source.X; i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - i, source.Y - i));
                }
                // stanga jos
                for (int i = 1; i <= 7 - source.Y - (7 - source.X); i++)
                {
                    availableMoves.Add(Coordinate.GetInstance(source.X - i, source.Y + i));
                }
            }

            return availableMoves;
        }
    }
}
