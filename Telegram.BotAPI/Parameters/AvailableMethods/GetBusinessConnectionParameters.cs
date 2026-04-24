using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetBusinessConnectionParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
