using System;
using System.Collections.Generic;
using System.Text;
using Hb.MarsRover.Domain;

namespace Hb.MarsRover
{
    public static class Extension
    {
        public static Command ToMotionType(this char c)
        {
            switch (c)
            {
                case 'L':
                    return Command.Left;
                case 'R':
                    return Command.Right;
                case 'M':
                    return Command.Move;
            }
            return Command.UnRecognizedCommand;
        }
    }
}
