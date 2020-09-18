namespace Hb.MarsRover.Domain
{
    public class Plateau
    {
        public Coordinate Coordinate { get; }

        public Plateau(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
        public override string ToString()
        {
            return $"{Coordinate.XCoordinate} {Coordinate.YCoordinate}";
        }
    }
}
