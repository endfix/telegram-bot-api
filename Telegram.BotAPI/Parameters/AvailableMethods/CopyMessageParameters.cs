using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CopyMessageParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public int? DirectMessagesTopicId { get; init; }

    public required ChatIdSource FromChatId { get; init; }

    public required long MessageId { get; init; }

    public int? VideoStartTimestamp { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
