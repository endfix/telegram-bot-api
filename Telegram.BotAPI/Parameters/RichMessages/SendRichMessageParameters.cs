using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendRichMessage</c> method.
/// </summary>
public sealed class SendRichMessageParameters : ApiRequestParameters
{
    /// <summary>Optional business connection identifier on behalf of which the message is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Optional target forum topic identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Identifier of the direct messages topic, when required.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Optional parameters for an ephemeral message.</summary>
    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    /// <summary>Rich message content to send.</summary>
    public required InputRichMessage RichMessage { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid high-rate broadcasting.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Optional message effect identifier for private chats.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Optional suggested-post parameters for direct messages chats.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Optional description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Optional interface options such as an inline or reply keyboard.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
