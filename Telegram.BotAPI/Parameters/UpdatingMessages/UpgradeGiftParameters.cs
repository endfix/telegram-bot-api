using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class UpgradeGiftParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required string OwnedGiftId { get; init; }

    public bool? KeepOriginalDetails { get; init; }

    public int? StarCount { get; init; }
}
