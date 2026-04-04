using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ForwardMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public int? DirectMessagesTopicId { get; init; }

    public required ChatIdSource FromChatId { get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }
}
