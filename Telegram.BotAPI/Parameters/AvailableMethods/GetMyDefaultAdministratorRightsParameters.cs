namespace Telegram.BotAPI.Parameters;

public sealed class GetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public bool? ForChannels { get; init; }
}
