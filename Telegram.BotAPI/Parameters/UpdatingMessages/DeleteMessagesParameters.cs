using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMessages</c> method.
/// </summary>
public sealed class DeleteMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required IReadOnlyList<long> MessageIds { get; init; }
}
