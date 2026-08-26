using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public ChatAdministratorRights? Rights { get; init; }

    public bool? ForChannels { get; init; }
}
