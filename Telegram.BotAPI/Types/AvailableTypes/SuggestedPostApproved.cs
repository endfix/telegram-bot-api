namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostApproved
{
    public Message? SuggestedPostMessage { get; init; }

    public SuggestedPostPrice? Price { get; init; }

    public required int SendDate { get; init; }
}
