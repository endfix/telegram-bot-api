using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountGiftSettingsParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required bool ShowGiftButton { get; init; }

    public required AcceptedGiftTypes AcceptedGiftTypes { get; init; }
}
