namespace GiftBagOfBases.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse(false);

        public CommandResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}