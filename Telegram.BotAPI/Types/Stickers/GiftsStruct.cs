using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Stickers;

/// <summary>
/// This object represent a list of gifts.
/// </summary>
public sealed class GiftsStruct
{
    /// <summary>
    /// The list of gifts
    /// </summary>
    public List<Gift> Gifts { get; set; }
}
