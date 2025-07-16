using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountGiftSettingsParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public bool ShowGiftButton { get; set; }

    public AcceptedGiftTypes AcceptedGiftTypes { get; set; }
}
