using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerPositionInSet</c> method.
/// </summary>
public sealed class SetStickerPositionInSetParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public required int Position { get; init; }
}
