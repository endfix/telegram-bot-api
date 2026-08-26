namespace Endfix.Telegram.BotAPI.Types;

public sealed class FileStruct
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public int? FileSize { get; init; }

    public string? FilePath { get; init; }
}
