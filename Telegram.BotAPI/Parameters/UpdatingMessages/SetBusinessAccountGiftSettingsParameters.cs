using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountGiftSettings</c> method.
/// </summary>
public sealed class SetBusinessAccountGiftSettingsParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required bool ShowGiftButton { get; init; }

    public required AcceptedGiftTypes AcceptedGiftTypes { get; init; }
}
