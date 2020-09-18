namespace Hb.MarsRover.Domain
{
    public class Command
    {
        public string TypeCode { get;  }
        public string Description { get; }
        public static Command Left = new Command("L", "Left");
        public static Command Right = new Command("R", "Right");
        public static Command Move = new Command("M", "Move");
        public static Command UnRecognizedCommand = new Command("U", "Unrecognized Command");
        private Command(string typeCode, string description)
        {
            TypeCode = typeCode;
            Description = description;
        }
    }
}
