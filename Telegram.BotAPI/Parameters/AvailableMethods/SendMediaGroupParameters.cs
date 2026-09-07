using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendMediaGroup</c> method.
/// </summary>
public sealed class SendMediaGroupParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Unique identifier of the target forum topic; for forum supergroups and private chats with forum topic mode enabled only.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Identifier of the target direct messages topic; required when sending to a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Media items to send as an album.</summary>
    public required IReadOnlyList<InputMedia> Media { get; init; }

    /// <summary>Sends the messages silently when <see langword="true"/>.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Protects the messages from forwarding and saving when <see langword="true"/>.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Allows paid broadcasts using Telegram Stars.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Unique identifier of a message effect.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }
}
