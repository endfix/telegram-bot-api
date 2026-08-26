using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteStickerFromSetParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }
}
