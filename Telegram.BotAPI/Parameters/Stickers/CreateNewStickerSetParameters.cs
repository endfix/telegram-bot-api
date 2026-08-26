using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class CreateNewStickerSetParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string Name { get; init; }

    public required string Title { get; init; }

    public required IReadOnlyList<InputSticker> Stickers { get; init; }

    public StickerType? StickerType { get; init; }

    public bool? NeedsRepainting { get; init; }
}
