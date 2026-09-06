using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMessages</c> method.
/// </summary>
public sealed class DeleteMessagesParameters : ApiRequestParameters
{
    /// <summary>Chat containing the messages.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifiers of the messages to delete.</summary>
    public required IReadOnlyList<long> MessageIds { get; init; }
}
