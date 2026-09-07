using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountGiftSettings</c> method.
/// </summary>
public sealed class SetBusinessAccountGiftSettingsParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Whether to always show the gift button in the input field.</summary>
    public required bool ShowGiftButton { get; init; }

    /// <summary>Gift types accepted by the business account.</summary>
    public required AcceptedGiftTypes AcceptedGiftTypes { get; init; }
}
