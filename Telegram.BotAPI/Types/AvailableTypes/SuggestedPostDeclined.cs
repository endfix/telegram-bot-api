namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostDeclined
{
    public Message? SuggestedPostMessage { get; init; }

    public string? Comment { get; init; }
}
