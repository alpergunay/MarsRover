using Hb.MarsRover.Domain;
using Hb.MarsRover.Exceptions;
using Xunit;

namespace Hb.MarsRover.Tests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void Create_X_Y_CoordinateLessThanOrEqualZero_ShouldThrowPlateauException(int x, int y)
        {
            Assert.Throws<PlateauException>(() => new Plateau(new Coordinate(x, y)));
        }
    }
}
