namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes delivery options for an ephemeral message.</summary>
public sealed class EphemeralMessageParameters
{
    /// <summary>Identifier of the user who will receive the message; required unless the message is sent as a reply to a callback query.</summary>
    public long? ReceiverUserId { get; init; }

    /// <summary>Identifier of the callback query that triggered the message, if any.</summary>
    public string? CallbackQueryId { get; init; }

    /// <summary>Indicates whether to show the ephemeral message in place of the original callback message.</summary>
    public bool? ReplaceCallbackQueryMessage { get; init; }
}
