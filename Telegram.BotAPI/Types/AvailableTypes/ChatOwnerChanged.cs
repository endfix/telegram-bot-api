namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatOwnerChanged
{
    public required User NewOwner { get; init; }
}
