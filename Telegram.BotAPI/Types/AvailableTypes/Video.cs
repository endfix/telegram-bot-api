namespace Telegram.BotAPI.Types;

public sealed class Video
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public PhotoSize[] Cover { get; set; }

    public int StartTimestamp { get; set; }

    public string FileName { get; set; }

    public string MimeType { get; set; }

    public int FileSize { get; set; }
}
