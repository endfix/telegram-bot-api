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

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

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

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
