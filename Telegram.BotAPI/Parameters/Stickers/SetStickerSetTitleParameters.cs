using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerSetTitle</c> method.
/// </summary>
public sealed class SetStickerSetTitleParameters : ApiRequestParameters
{
    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>New sticker set title.</summary>
    public required string Title { get; init; }
}
