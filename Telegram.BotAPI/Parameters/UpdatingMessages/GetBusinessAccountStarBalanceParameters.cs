using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetBusinessAccountStarBalanceParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
