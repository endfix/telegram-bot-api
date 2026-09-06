namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about the chat owner leaving the chat.
/// </summary>
public sealed class ChatOwnerLeft
{
    /// <summary>
    /// Optional user who will become the new owner of the chat if the previous owner does not return.
    /// </summary>
    public User? NewOwner { get; init; }
}
