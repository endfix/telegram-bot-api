using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SendVideoNoteParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    public required VideoNoteSource VideoNote { get; init; }

    public int? Duration { get; init; }

    public int? Length { get; init; }

    public ThumbnailSource? Thumbnail { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
