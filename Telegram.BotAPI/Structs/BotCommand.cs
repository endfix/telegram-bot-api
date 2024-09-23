namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#botcommand
    public class BotCommand
    {
        // Text of the command; 1-32 characters. Can contain only lowercase English letters, digits and underscores.
        public string Command { get; set; }

        // Description of the command; 1-256 characters
        public string Description { get; set; }
    }
}
