namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class Video
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public string FileName { get; set; }

    public string MimeType { get; set; }

    public int FileSize { get; set; }
}
