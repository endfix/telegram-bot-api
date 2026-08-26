using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class MessageReactionCountUpdated
{
    public required Chat Chat { get; init; }

    public required long MessageId { get; init; }

    public required long Date { get; init; }

    public required IReadOnlyList<ReactionCount> Reactions { get; init; }
}
