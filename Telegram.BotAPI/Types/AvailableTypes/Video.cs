using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class Video
{
    public required string FileId { get; init; }

    public required string FileUniqueId { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public required int Duration { get; init; }

    public PhotoSize? Thumbnail { get; init; }

    public IReadOnlyList<PhotoSize>? Cover { get; init; }

    public int StartTimestamp { get; init; }

    public IReadOnlyList<VideoQuality>? Qualities { get; init; }

    public string? FileName { get; init; }

    public string? MimeType { get; init; }

    public int FileSize { get; init; }
}
