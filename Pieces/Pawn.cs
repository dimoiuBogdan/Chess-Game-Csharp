namespace ChessGame.Pieces
{
    public class Pawn : APiece
    {
        public PieceType Type { get { return PieceType.Bishop; } private set { } }

        public Pawn(PieceColor color) : base(color)
        {
            
        }

    }
}
