using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
