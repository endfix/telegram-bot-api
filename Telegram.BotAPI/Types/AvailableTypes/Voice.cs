namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class Voice
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int Duration { get; set; }

    public string MimeType { get; set; }

    public int FileSize { get; set; }
}
