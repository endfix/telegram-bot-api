using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteStickerSetParameters : ApiRequestParameters
{
    public required string Name { get; init; }
}
