using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendAnimation</c> method.
/// </summary>
public sealed class SendAnimationParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    /// <summary>Animation to send.</summary>
    public required AnimationSource Animation { get; init; }

    /// <summary>Animation duration in seconds.</summary>
    public int? Duration { get; init; }

    /// <summary>Animation width.</summary>
    public int? Width { get; init; }

    /// <summary>Animation height.</summary>
    public int? Height { get; init; }

    /// <summary>Animation thumbnail.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Animation caption.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in the caption.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the caption.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the animation.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Whether to cover the animation with a spoiler animation.</summary>
    public bool? HasSpoiler { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
