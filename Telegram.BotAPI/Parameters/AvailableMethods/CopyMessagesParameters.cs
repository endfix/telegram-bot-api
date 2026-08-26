using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CopyMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public required ChatIdSource FromChatId { get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? RemoveCaption { get; init; }
}
