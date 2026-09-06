using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getStickerSet</c> method.
/// </summary>
public sealed class GetStickerSetParameters : ApiRequestParameters
{
    public required string Name { get; init; }
}
