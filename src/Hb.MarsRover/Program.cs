using System;
using Hb.MarsRover.Domain;

namespace Hb.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateauBoundryInputLine = Console.ReadLine();

            var coordinate = plateauBoundryInputLine.Split(' ');
            var plateau = new Plateau(new Coordinate(int.Parse(coordinate[0]), int.Parse(coordinate[1])));

            var rover1InputLine = Console.ReadLine();
            var rover1Inputs = rover1InputLine.Split(' ');
            var rover1 = new Rover(new Coordinate(int.Parse(rover1Inputs[0]), int.Parse(rover1Inputs[1])),
                Enum.Parse<Direction>(rover1Inputs[2]), plateau);
            var rover1InstructionsLine = Console.ReadLine();



            var rover2InputLine = Console.ReadLine();
            var rover2Inputs = rover2InputLine.Split(' ');
            var rover2 = new Rover(new Coordinate(int.Parse(rover2Inputs[0]), int.Parse(rover2Inputs[1])),
                Enum.Parse<Direction>(rover2Inputs[2]), plateau);
            var rover2InstructionsLine = Console.ReadLine();

            rover1.ProcessInstructions(rover1InstructionsLine);
            rover2.ProcessInstructions(rover2InstructionsLine);

            Console.WriteLine(rover1.DisplayPosition());
            Console.WriteLine(rover2.DisplayPosition());
            Console.ReadLine();

        }
    }
}
