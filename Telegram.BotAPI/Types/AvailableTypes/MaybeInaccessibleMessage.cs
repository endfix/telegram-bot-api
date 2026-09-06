namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a message that may be inaccessible to the bot.</summary>
public abstract class MaybeInaccessibleMessage
{
    /// <summary>Chat to which the message belonged.</summary>
    public required virtual Chat Chat { get; init; }

    /// <summary>Unique message identifier inside the chat.</summary>
    public required virtual long MessageId { get; init; }

    /// <summary>Message date in Unix time. For an inaccessible message, this value is always zero.</summary>
    public required virtual long Date { get; init; }
}
