using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>transferBusinessAccountStars</c> method.
/// </summary>
public sealed class TransferBusinessAccountStarsParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Number of Telegram Stars to transfer, from 1 through 10000.</summary>
    public required int StarCount { get; init; }
}
