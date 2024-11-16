namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class VideoNote
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int Length { get; set; }

    public int Duration { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public int FileSize { get; set; }
}
