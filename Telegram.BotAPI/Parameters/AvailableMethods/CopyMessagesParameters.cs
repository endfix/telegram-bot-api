using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class CopyMessagesParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public int? DirectMessagesTopicId { get; init; }

    public required object FromChatId { get; init; }

    public required IReadOnlyList<int> MessageIds { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? RemoveCaption { get; init; }
}
