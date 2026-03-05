namespace Telegram.BotAPI.Types;

public sealed class Document
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public PhotoSize? Thumbnail { get; init; }

    public string? FileName { get; init; }

    public string? MimeType { get; init; }

    public int? FileSize { get; init; }
}
