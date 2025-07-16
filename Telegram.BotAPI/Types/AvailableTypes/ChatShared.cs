namespace Telegram.BotAPI.Types;

public sealed class ChatShared
{
    public int RequestId { get; set; }

    public long ChatId { get; set; }

    public string Title { get; set; }

    public string Username { get; set; }

    public PhotoSize[] Photo { get; set; }
}
