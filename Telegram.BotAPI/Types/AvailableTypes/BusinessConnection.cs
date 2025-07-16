namespace Telegram.BotAPI.Types;

public sealed class BusinessConnection
{
    public string Id { get; set; }

    public User User { get; set; }

    public int UserChatId { get; set; }

    public int Date { get; set; }

    public BusinessBotRights Rights { get; set; }

    public bool IsEnabled { get; set; }
}
