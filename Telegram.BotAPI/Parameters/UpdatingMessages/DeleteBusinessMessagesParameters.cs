using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteBusinessMessagesParameters : ApiRequestParameters
{
    public required string BusinessConnectionId {  get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
