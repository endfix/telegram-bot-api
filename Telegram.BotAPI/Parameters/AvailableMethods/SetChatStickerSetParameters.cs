using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatStickerSet</c> method.
/// </summary>
public sealed class SetChatStickerSetParameters : ApiRequestParameters
{
    /// <summary>Target supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Name of the sticker set to assign.</summary>
    public required string StickerSetName { get; init; }
}
