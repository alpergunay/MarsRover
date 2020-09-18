using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Hb.MarsRover.Domain;
using Xunit;

namespace Hb.MarsRover.Tests
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(9, 6)]
        [InlineData(100, 100)]
        public void Create_Coordinates_X_Y_ShouldReturnSameValue(int x, int y)
        {
            var coordinate = new Coordinate(x, y);
            coordinate.XCoordinate.Should().Equals(x);
            coordinate.YCoordinate.Should().Equals(y);
        }
    }
}
