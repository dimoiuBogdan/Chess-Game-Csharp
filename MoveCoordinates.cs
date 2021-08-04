namespace ChessGame
{
    public class MoveCoordinates
    {
        public Coordinate InitialCoordinate { get; set; }
        public Coordinate MouseOverCoordinate { get; set; }

        public MoveCoordinates(Coordinate initialCoordinate, Coordinate mouseOverCoordinate)
        {
            InitialCoordinate = initialCoordinate;
            MouseOverCoordinate = mouseOverCoordinate;
        }
    }
}
