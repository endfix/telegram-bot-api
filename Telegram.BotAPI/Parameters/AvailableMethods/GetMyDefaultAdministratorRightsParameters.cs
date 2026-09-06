using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyDefaultAdministratorRights</c> method.
/// </summary>
public sealed class GetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public bool? ForChannels { get; init; }
}
