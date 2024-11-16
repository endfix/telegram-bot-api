namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class BusinessConnection
{
    public string Id { get; set; }

    public User User { get; set; }

    public int UserChatId { get; set; }

    public int Date { get; set; }

    public bool CanReply { get; set; }

    public bool IsEnabled { get; set; }
}
