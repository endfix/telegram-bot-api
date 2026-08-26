namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatPhoto
{
    public required string SmallFileId { get; init; }

    public required string SmallFileUniqueId { get; init; }

    public required string BigFileId { get; init; }

    public required string BigFileUniqueId { get; init; }
}
