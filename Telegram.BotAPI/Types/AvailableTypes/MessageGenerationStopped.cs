namespace Endfix.Telegram.BotAPI.Types;

public sealed class MessageGenerationStopped
{
    public required Chat Chat { get; init; }

    public long? MessageThreadId { get; init; }

    public required long DraftId { get; init; }
}
