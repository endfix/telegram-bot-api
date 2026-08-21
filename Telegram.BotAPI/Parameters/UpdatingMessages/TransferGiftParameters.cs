using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class TransferGiftParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required string OwnedGiftId { get; init; }

    public required long NewOwnerChatId { get; init; }

    public int? StarCount { get; init; }
}
