using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>transferGift</c> method.
/// </summary>
public sealed class TransferGiftParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the unique gift to transfer.</summary>
    public required string OwnedGiftId { get; init; }

    /// <summary>Identifier of the new owner's chat, which must have been active within the last 24 hours.</summary>
    public required long NewOwnerChatId { get; init; }

    /// <summary>Stars paid from the business account for the transfer. A positive value requires the <c>can_transfer_stars</c> business bot right.</summary>
    public int? StarCount { get; init; }
}
