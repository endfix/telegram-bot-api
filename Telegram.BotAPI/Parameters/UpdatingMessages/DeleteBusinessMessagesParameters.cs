using System.Collections.Generic;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteBusinessMessagesParameters : ApiRequestParameters
{
    public required string BusinessConnectionId {  get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
