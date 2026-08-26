using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetBusinessAccountStarBalanceParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
