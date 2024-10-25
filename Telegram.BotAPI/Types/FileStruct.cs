namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#file
public sealed class FileStruct
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int FileSize { get; set; }

    public string FilePath { get; set; }
}
