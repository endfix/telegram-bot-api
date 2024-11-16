namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class File
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int FileSize { get; set; }

    public string FilePath { get; set; }
}
