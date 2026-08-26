using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SendLivePhotoParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public EphemeralMessageParameters? EphemeralMessageParameters { get; init; }

    public MediaSource LivePhoto { get; init; }

    public MediaSource Photo { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public long? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
