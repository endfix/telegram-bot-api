namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#document
public sealed class Document
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public string FileName { get; set; }

    public string MimeType { get; set; }

    public int FileSize { get; set; }
}
