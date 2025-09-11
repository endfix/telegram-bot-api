namespace Telegram.BotAPI.Types;

public sealed class DirectMessagesTopic
{
    public int topic_id { get; set; }

    public User User { get; set; }
}
