namespace Endfix.Telegram.BotAPI.Types;

public sealed class PassportFile
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int FileSize { get; init; }

    public required int FileDate { get; init; }
}
