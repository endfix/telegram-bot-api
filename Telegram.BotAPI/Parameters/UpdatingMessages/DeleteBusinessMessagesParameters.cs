using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteBusinessMessagesParameters : ApiRequestParameters
{
    public required string BusinessConnectionId {  get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
