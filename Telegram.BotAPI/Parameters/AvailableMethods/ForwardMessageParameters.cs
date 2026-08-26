using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ForwardMessageParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public required ChatIdSource FromChatId { get; init; }

    public int? VideoStartTimestamp { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public required long MessageId { get; init; }
}
