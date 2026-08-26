namespace Endfix.Telegram.BotAPI.Types;

public sealed class DirectMessagesTopic
{
    public required int TopicId { get; init; }

    public User? User { get; init; }
}
