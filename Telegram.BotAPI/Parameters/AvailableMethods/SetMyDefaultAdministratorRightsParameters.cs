using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMyDefaultAdministratorRightsParameters : ApiRequestParameters
{
    public ChatAdministratorRights Rights { get; set; }

    public bool ForChannels { get; set; }
}
