using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>convertGiftToStars</c> method.
/// </summary>
public sealed class ConvertGiftToStarsParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the regular gift to convert.</summary>
    public required string OwnedGiftId { get; init; }
}
