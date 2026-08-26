namespace Endfix.Telegram.BotAPI.Types;

public sealed class Animation
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required int Duration { get; init; }

    public PhotoSize? Thumbnail { get; init; }

    public string? FileName { get; init; }

    public string? MimeType { get; init; }

    public int? FileSize { get; init; }
}