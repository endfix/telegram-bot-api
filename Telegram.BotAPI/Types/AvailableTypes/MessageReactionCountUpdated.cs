namespace Telegram.BotAPI.Types;

public sealed class MessageReactionCountUpdated
{
    public required Chat Chat { get; init; }

    public required int MessageId { get; init; }

    public required int Date { get; init; }

    public required ReactionCount[] Reactions { get; init; }
}
