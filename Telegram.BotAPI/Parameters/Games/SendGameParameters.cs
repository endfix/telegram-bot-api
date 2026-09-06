using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendGame</c> method.
/// </summary>
public sealed class SendGameParameters : ApiRequestParameters
{
    /// <summary>Optional business connection identifier on behalf of which the message is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Unique identifier of the target chat.</summary>
    public required long ChatId { get; init; }

    /// <summary>Optional identifier of the target forum topic.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Short name of the game configured through BotFather.</summary>
    public required string GameShortName { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid high-rate broadcasting.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Optional message effect identifier for private chats.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Optional description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Optional inline keyboard. If empty, Telegram shows a Play Game button.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
