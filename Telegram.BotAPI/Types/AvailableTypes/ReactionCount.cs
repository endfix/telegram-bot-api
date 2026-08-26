namespace Endfix.Telegram.BotAPI.Types;

public sealed class ReactionCount
{
    public required ReactionType Type { get; init; }

    public required int TotalCount { get; init; }
}
