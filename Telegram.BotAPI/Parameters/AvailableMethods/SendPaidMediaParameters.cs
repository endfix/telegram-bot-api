using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendPaidMedia</c> method.
/// </summary>
public sealed class SendPaidMediaParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    /// <summary>Price in Telegram Stars.</summary>
    public required int StarCount { get; init; }

    /// <summary>Paid media to send.</summary>
    public required IReadOnlyList<InputPaidMedia> Media { get; init; }

    /// <summary>Bot-defined payload.</summary>
    public string? Payload { get; init; }

    /// <summary>Media caption.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in the caption.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the caption.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
