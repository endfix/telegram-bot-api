using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendDocumentParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public int? DirectMessagesTopicId { get; init; }

    public required DocumentSource Document { get; init; }

    public object? Thumbnail { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
