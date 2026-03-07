namespace Telegram.BotAPI.Types;

public sealed class Audio
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }

    public string? FileName { get; init; }

    public string? MimeType { get; init; }

    public int? FileSize { get; init; }

    public PhotoSize? Thumbnail { get; init; }
}
