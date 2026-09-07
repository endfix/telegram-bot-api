using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendVideo</c> method.
/// </summary>
public sealed class SendVideoParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Unique identifier of the target forum topic; for forum supergroups and private chats with forum topic mode enabled only.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Identifier of the target direct messages topic; required when sending to a direct messages chat.</summary>
    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Parameters of the ephemeral message to send.</summary>
    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    /// <summary>Video to send.</summary>
    public required VideoSource Video { get; init; }

    /// <summary>Video duration in seconds.</summary>
    public int? Duration { get; init; }

    /// <summary>Video width.</summary>
    public int? Width { get; init; }

    /// <summary>Video height.</summary>
    public int? Height { get; init; }

    /// <summary>Video thumbnail.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Video cover.</summary>
    public CoverSource? Cover { get; init; }

    /// <summary>Timestamp from which the video should start playing.</summary>
    public int? StartTimestamp { get; init; }

    /// <summary>Video caption.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in the caption.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the caption.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the video.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Whether to cover the video with a spoiler animation.</summary>
    public bool? HasSpoiler { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid broadcasting at up to 1000 messages per second for 0.1 Telegram Stars per message.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Unique identifier of the message effect to add; for private chats only.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Parameters of a suggested post; for direct messages chats only.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Additional interface options for the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
