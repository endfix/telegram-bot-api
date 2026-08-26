using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class ConvertGiftToStarsParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required string OwnedGiftId { get; init; }
}
