using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteStickerFromSet</c> method.
/// </summary>
public sealed class DeleteStickerFromSetParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }
}
