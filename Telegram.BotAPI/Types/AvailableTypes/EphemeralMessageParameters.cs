namespace Endfix.Telegram.BotAPI.Types;

public sealed class EphemeralMessageParameters
{
    public required long ReceiverUserId { get; init; }

    public string? CallbackQueryId { get; init; }

    public bool? ReplaceCallbackQueryMessage { get; init; }
}
