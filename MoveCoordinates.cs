using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
