namespace Telegram.BotAPI.Parameters;

public sealed class DeleteStickerFromSetParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }
}
