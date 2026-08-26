using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public bool? ForChannels { get; init; }
}
