namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ReactionCount
{
    public ReactionType Type { get; set; }

    public int TotalCount { get; set; }
}
