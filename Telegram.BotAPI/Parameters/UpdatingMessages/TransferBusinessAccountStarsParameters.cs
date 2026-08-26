using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class TransferBusinessAccountStarsParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required int StarCount { get; init; }
}
