using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetBusinessConnectionParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }
}
