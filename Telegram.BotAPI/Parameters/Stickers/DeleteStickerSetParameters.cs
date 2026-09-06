using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteStickerSet</c> method.
/// </summary>
public sealed class DeleteStickerSetParameters : ApiRequestParameters
{
    public required string Name { get; init; }
}
