namespace Telegram.BotAPI.Types;

public sealed class ChatOwnerLeft
{
    public required User NewOwner { get; set; }
}
