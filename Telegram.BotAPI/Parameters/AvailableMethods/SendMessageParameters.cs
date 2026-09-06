using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendMessage</c> method.
/// </summary>
public sealed class SendMessageParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Topic identifier in a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Options for an ephemeral message.</summary>
    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    /// <summary>Text of the message.</summary>
    public required string Text { get; init; }

    /// <summary>Mode for parsing entities in the message text.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the message text.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Options for the link preview.</summary>
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    /// <summary>Sends the message silently when <see langword="true"/>.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Protects the message from forwarding and saving when <see langword="true"/>.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Allows paid broadcasts using Telegram Stars.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Unique identifier of a message effect.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Parameters for a suggested post.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Inline or reply keyboard attached to the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
