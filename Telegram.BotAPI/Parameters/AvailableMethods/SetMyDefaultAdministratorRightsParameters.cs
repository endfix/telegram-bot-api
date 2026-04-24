using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public ChatAdministratorRights? Rights { get; init; }

    public bool? ForChannels { get; init; }
}
