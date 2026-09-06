namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about an ownership change in the chat.
/// </summary>
public sealed class ChatOwnerChanged
{
    /// <summary>The new owner of the chat.</summary>
    public required User NewOwner { get; init; }
}
