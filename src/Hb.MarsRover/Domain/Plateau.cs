using Hb.MarsRover.Exceptions;

namespace Hb.MarsRover.Domain
{
    public class Plateau
    {
        public Coordinate Coordinate { get; }

        public Plateau(Coordinate coordinate)
        {
            if (coordinate == null || coordinate.XCoordinate <= 0 || coordinate.YCoordinate <= 0)
                throw new PlateauException("Invalid Coordinates");

            Coordinate = coordinate;
        }
        public override string ToString()
        {
            return $"{Coordinate.XCoordinate} {Coordinate.YCoordinate}";
        }
    }
}
