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

    /// <summary>Unique identifier of the target forum topic; for forum supergroups and private chats with forum topic mode enabled only.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Identifier of the target direct messages topic; required when sending to a direct messages chat.</summary>
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

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Whether to allow paid broadcasting at up to 1000 messages per second for 0.1 Telegram Stars per message.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Parameters of a suggested post; for direct messages chats only.</summary>
    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Additional interface options for the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
