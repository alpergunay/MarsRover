using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.MarsRover.Domain
{
    public class Rover
    {
        public Direction CurrentDirection { get; set; }
        public Coordinate CurrentCoordinate { get; }
        public Plateau Plateau { get; }

        public Rover(Coordinate coordinate, Direction direction, Plateau plateau)
        {
            CurrentCoordinate = coordinate;
            Plateau = plateau;
            CurrentDirection = direction;
        }

        public void Move()
        {
            if(!CanRoverMove())
                throw new Exception("Rover cannot move to outside of the Plateau");

            switch (CurrentDirection)
            {
                case Direction.E:
                    this.CurrentCoordinate.XCoordinate++;
                    break;
                case Direction.W:
                    this.CurrentCoordinate.XCoordinate--;
                    break;
                case Direction.N:
                    this.CurrentCoordinate.YCoordinate++;
                    break;
                case Direction.S:
                    this.CurrentCoordinate.YCoordinate--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ProcessCommand(Command command)
        {
            if (command == Command.Left)
            {
                RotateLeft();
            }
            else if (command == Command.Right)
            {
                RotateRight();
            }
            else if (command == Command.Move)
            {
                Move();
            }
            else
            {
                throw new Exception($"Invalid Command. Command Type {command.Description}");
            }
        }

        private void RotateLeft()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentDirection = Direction.W;
                    break;
                case Direction.W:
                    CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    CurrentDirection = Direction.E;
                    break;
                case Direction.E:
                    CurrentDirection = Direction.N;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentDirection = Direction.E;
                    break;
                case Direction.E:
                    CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    CurrentDirection = Direction.W;
                    break;
                case Direction.W:
                    CurrentDirection = Direction.N;
                    break;

            }
        }
        public bool CanRoverMove()
        {
            switch (CurrentDirection)
            {
                case Direction.N when CurrentCoordinate.YCoordinate + 1 > Plateau.Coordinate.YCoordinate:
                case Direction.W when CurrentCoordinate.XCoordinate - 1 < 0:
                case Direction.S when CurrentCoordinate.YCoordinate - 1 < 0:
                case Direction.E when CurrentCoordinate.XCoordinate + 1 > Plateau.Coordinate.YCoordinate:
                    return false;
                default:
                    return true;
            }
        }

        public void ProcessInstructions(string instruction)
        {
            foreach (var c in instruction)
            {
                ProcessCommand(c.ToMotionType());
            }
        }
        public string DisplayPosition()
        {
            return $"{CurrentCoordinate.ToString()} {CurrentDirection}";
        }
    }
}
