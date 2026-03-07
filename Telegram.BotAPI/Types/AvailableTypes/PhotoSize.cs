namespace Telegram.BotAPI.Types;

public sealed class PhotoSize
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public int? FileSize { get; init; }
}
