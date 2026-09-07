using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteBusinessMessages</c> method.
/// </summary>
public sealed class DeleteBusinessMessagesParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId {  get; init; }

    /// <summary>From 1 through 100 message identifiers, all belonging to the same chat.</summary>
    public required IReadOnlyList<long> MessageIds { get; init; }
}
