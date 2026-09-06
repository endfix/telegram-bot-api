using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getBusinessAccountStarBalance</c> method.
/// </summary>
public sealed class GetBusinessAccountStarBalanceParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
