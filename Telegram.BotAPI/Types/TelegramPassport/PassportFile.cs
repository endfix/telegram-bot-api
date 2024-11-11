namespace Telegram.BotAPI.Types.TelegramPassport;

public sealed class PassportFile
{
    public string FileId { get; set; }

    public string FileUniqueId { get; set; }

    public int FileSize { get; set; }

    public int FileDate { get; set; }
}
