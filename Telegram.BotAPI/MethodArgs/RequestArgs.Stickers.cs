using System.Collections.Generic;
using Telegram.BotAPI.Types.Stickers;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.MethodArgs;

public sealed class SendStickerArgs : RequestArgs
{
    public string BusinessConnectionId { get; set; }

    public string ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Sticker { get; set; }

    public string Emoji { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}

// https://core.telegram.org/bots/api#getstickerset
public sealed class GetStickerSetArgs : RequestArgs
{
    public string Name { get; set; }
}

public sealed class GetCustomEmojiStickersArgs : RequestArgs
{
    public List<string> CustomEmojiIds { get; set; }
}

// https://core.telegram.org/bots/api#uploadstickerfile
public sealed class UploadStickerFileArgs : RequestArgs
{
    public long UserId { get; set; }

    public string StickerFormat { get; set; }
}

public sealed class CreateNewStickerSetArgs : RequestArgs
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public List<InputSticker> Stickers { get; set; }

    public string StickerType { get; set; }

    public bool NeedsRepainting { get; set; }
}

public sealed class AddStickerToSetArgs : RequestArgs
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public InputSticker Sticker { get; set; }
}

public sealed class SetStickerPositionInSetArgs : RequestArgs
{
    public string Sticker { get; set; }

    public string Position { get; set; }
}

public sealed class DeleteStickerFromSetArgs : RequestArgs
{
    public string Sticker { get; set; }
}

public sealed class ReplaceStickerInSetArgs : RequestArgs
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public string OldSticker { get; set; }

    public InputSticker Sticker { get; set; }
}

public sealed class SetStickerEmojiListArgs : RequestArgs
{
    public string Sticker { get; set; }

    public List<string> EmojiList { get; set; }
}

public sealed class SetStickerKeywordsArgs : RequestArgs
{
    public string Sticker { get; set; }

    public List<string> Keywords { get; set; }
}

public sealed class SetStickerMaskPositionArgs : RequestArgs
{
    public string Sticker { get; set; }

    public MaskPosition MaskPosition { get; set; }
}

public sealed class SetStickerSetTitleArgs : RequestArgs
{
    public string Name { get; set; }

    public string Title { get; set; }
}

public sealed class SetStickerSetThumbnailArgs : RequestArgs
{
    public string Name { get; set; }

    public long UserId { get; set; }

    public string Thumbnail { get; set; }

    public string Format { get; set; }
}

public sealed class SetCustomEmojiStickerSetThumbnailArgs : RequestArgs
{
    public string Name { get; set; }

    public string CustomEmojiId { get; set; }
}

public sealed class DeleteStickerSetArgs : RequestArgs
{
    public string Name { get; set; }
}