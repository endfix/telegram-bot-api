namespace Telegram.BotAPI.Types;

public sealed class Video
{
    public required string FileId { get; set; }

    public required string FileUniqueId { get; set; }

    public required int Width { get; set; }

    public required int Height { get; set; }

    public required int Duration { get; set; }

    public PhotoSize? Thumbnail { get; set; }

    public PhotoSize[]? Cover { get; set; }

    public int StartTimestamp { get; set; }

    public VideoQuality[]? Qualities { get; set; }

    public string? FileName { get; set; }

    public string? MimeType { get; set; }

    public int FileSize { get; set; }
}
