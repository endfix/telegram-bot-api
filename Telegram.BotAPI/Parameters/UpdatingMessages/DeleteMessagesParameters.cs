using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessagesParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
