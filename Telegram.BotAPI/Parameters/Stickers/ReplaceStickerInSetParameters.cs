using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>replaceStickerInSet</c> method.
/// </summary>
public sealed class ReplaceStickerInSetParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user who owns the sticker set.</summary>
    public required long UserId { get; init; }

    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>File identifier of the sticker to replace.</summary>
    public required string OldSticker { get; init; }

    /// <summary>Replacement sticker.</summary>
    public required InputSticker Sticker { get; init; }
}
