using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyDefaultAdministratorRights</c> method.
/// </summary>
public sealed class SetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public ChatAdministratorRights? Rights { get; init; }

    public bool? ForChannels { get; init; }
}
