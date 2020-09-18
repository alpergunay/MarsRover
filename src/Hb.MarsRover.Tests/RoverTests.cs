using FluentAssertions;
using Hb.MarsRover.Domain;
using System.Collections.Generic;
using Xunit;

namespace Hb.MarsRover.Tests
{
    public class RoverTests
    {
        [Theory]
        [MemberData(nameof(RotateLeftCommandData.Data), MemberType = typeof(RotateLeftCommandData))]
        public void RotateLeftCommand_ShouldRun_Correct(Rover rover, Direction expectedDirection)
        {
            rover.ProcessCommand(Command.Left);
            Assert.Equal(rover.CurrentDirection, expectedDirection);
        }

        [Theory]
        [MemberData(nameof(RotateRightCommandData.Data), MemberType = typeof(RotateRightCommandData))]
        public void RotateRightCommand_ShouldRun_Correct(Rover rover, Direction expectedDirection)
        {
            rover.ProcessCommand(Command.Right);

            Assert.Equal(rover.CurrentDirection, expectedDirection);
        }

        [Theory]
        [MemberData(nameof(MoveCommandData.Data), MemberType = typeof(MoveCommandData))]
        public void MoveCommand_ShouldRun_Correct(Rover rover, Direction expectedDirection, Coordinate expectedCoordinate)
        {
            rover.ProcessCommand(Command.Move);
            Assert.Equal(rover.CurrentDirection, expectedDirection);
            Assert.Equal(rover.CurrentCoordinate.XCoordinate, expectedCoordinate.XCoordinate);
            Assert.Equal(rover.CurrentCoordinate.YCoordinate, expectedCoordinate.YCoordinate);
        }

        [Theory]
        [MemberData(nameof(CanMoveCommandData.Data), MemberType = typeof(CanMoveCommandData))]
        public void CanRoverMove_ShouldReturn_True(Rover rover)
        {
            var actual = rover.CanRoverMove();
            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(CannotMoveCommandData.Data), MemberType = typeof(CannotMoveCommandData))]
        public void CanRoverMove_ShouldReturn_False(Rover rover)
        {
            var actual = rover.CanRoverMove();
            Assert.False(actual);
        }

        [Theory]
        [MemberData(nameof(RoversData))]
        public void ProcessInstructions_ShouldRun_Correct(Rover rover, string instructions, string lastPosition)
        {
            rover.ProcessInstructions(instructions);
            rover.DisplayPosition().Should().Be(lastPosition);
        }

        public class RotateLeftCommandData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { new Rover(new Coordinate(4,2), Direction.E, new Plateau(new Coordinate(9,9))),  Direction.N },
                    new object[] { new Rover(new Coordinate(4,2), Direction.N, new Plateau(new Coordinate(9,9))),  Direction.W },
                    new object[] { new Rover(new Coordinate(4,2), Direction.W, new Plateau(new Coordinate(9,9))),  Direction.S },
                    new object[] { new Rover(new Coordinate(4,2), Direction.S, new Plateau(new Coordinate(9,9))),  Direction.E },
                };
        }

        public class RotateRightCommandData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { new Rover(new Coordinate(4,2), Direction.E, new Plateau(new Coordinate(9,9))),  Direction.S },
                    new object[] { new Rover(new Coordinate(4,2), Direction.S, new Plateau(new Coordinate(9,9))),  Direction.W },
                    new object[] { new Rover(new Coordinate(4,2), Direction.W, new Plateau(new Coordinate(9,9))),  Direction.N },
                    new object[] { new Rover(new Coordinate(4,2), Direction.N, new Plateau(new Coordinate(9,9))),  Direction.E },
                };
        }

        public class MoveCommandData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { new Rover(new Coordinate(4,2), Direction.E, new Plateau(new Coordinate(9,9))),  Direction.E, new Coordinate(5,2) },
                    new object[] { new Rover(new Coordinate(4,2), Direction.S, new Plateau(new Coordinate(9,9))),  Direction.S, new Coordinate(4, 1)},
                    new object[] { new Rover(new Coordinate(4,2), Direction.W, new Plateau(new Coordinate(9,9))),  Direction.W, new Coordinate(3,2)},
                    new object[] { new Rover(new Coordinate(4,2), Direction.N, new Plateau(new Coordinate(9,9))),  Direction.N, new Coordinate(4,3)},
                };
        }

        public class CanMoveCommandData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { new Rover(new Coordinate(2,1), Direction.S, new Plateau(new Coordinate(9,9))) },
                    new object[] { new Rover(new Coordinate(6,8), Direction.E, new Plateau(new Coordinate(9,9)))},
                };
        }

        public class CannotMoveCommandData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { new Rover(new Coordinate(1,0), Direction.S, new Plateau(new Coordinate(9,9))) },
                    new object[] { new Rover(new Coordinate(0,1), Direction.W, new Plateau(new Coordinate(9,9)))},
                    new object[] { new Rover(new Coordinate(8,9), Direction.N, new Plateau(new Coordinate(9,9))) },
                    new object[] { new Rover(new Coordinate(9,8), Direction.E, new Plateau(new Coordinate(9,9)))},
                };
        }
        public static IEnumerable<object[]> RoversData()
        {
            return new[]
            {
                new object[] { new Rover(new Coordinate(1,2), Direction.N, new Plateau(new Coordinate(5,5))), "LMLMLMLMM", "1 3 N" },
                new object[] { new Rover(new Coordinate(3,3), Direction.E, new Plateau(new Coordinate(5,5))), "MMRMMRMRRM", "5 1 E"},
            };
        }
    }
}
