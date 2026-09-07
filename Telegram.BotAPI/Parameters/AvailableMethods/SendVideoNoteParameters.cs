using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendVideoNote</c> method.
/// </summary>
public sealed class SendVideoNoteParameters : ApiRequestParameters
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

    /// <summary>Video note to send.</summary>
    public required VideoNoteSource VideoNote { get; init; }

    /// <summary>Video note duration in seconds.</summary>
    public int? Duration { get; init; }

    /// <summary>Video note diameter in pixels.</summary>
    public int? Length { get; init; }

    /// <summary>Video note thumbnail.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

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
