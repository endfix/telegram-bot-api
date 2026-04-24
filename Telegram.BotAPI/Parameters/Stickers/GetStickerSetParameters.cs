using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetStickerSetParameters : ApiRequestParameters
{
    public required string Name { get; init; }
}
