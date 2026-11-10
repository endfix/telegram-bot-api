using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteBusinessAccountGift</c> method.
/// </summary>
/// <remarks>
/// Requires the <c>can_convert_gifts_to_stars</c> business bot right. The gift can be deleted
/// only if it is not limited (<see cref="Gift.TotalCount"/> is omitted) and was not refunded.
/// </remarks>
public sealed class DeleteBusinessAccountGiftParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Unique identifier of the regular gift to delete.</summary>
    public required string OwnedGiftId { get; init; }
}
