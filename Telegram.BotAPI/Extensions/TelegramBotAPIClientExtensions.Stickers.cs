using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Types.Stickers;
using Telegram.BotAPI.MethodArgs;

namespace Telegram.BotAPI.Extensions;

public static partial class TelegramBotAPIClientExtensions
{
    public static async Task<ResponseAPI<Message>> SendStickerAsync(this TelegramBotAPIClient api, SendStickerArgs args = null)
    {
        if (string.IsNullOrEmpty(args.Sticker) || !args.GetInputFiles().Any(file => file.Name == "sticker"))
        {
            throw new ArgumentNullException(nameof(args.Sticker));
        }

        return await api.RequestAsync<Message>("sendSticker", args);
    }

    public static async Task<ResponseAPI<StickerSet>> GetStickerSetAsync(this TelegramBotAPIClient api, GetStickerSetArgs args = null)
    {
        return await api.RequestAsync<StickerSet>("getStickerSet", args);
    }

    public static async Task<ResponseAPI<List<Sticker>>> GetCustomEmojiStickersAsync(this TelegramBotAPIClient api, GetCustomEmojiStickersArgs args = null)
    {
        return await api.RequestAsync<List<Sticker>>("getCustomEmojiStickers", args);
    }

    public static async Task<ResponseAPI<FileStruct>> UploadStickerFileAsync(this TelegramBotAPIClient api, UploadStickerFileArgs args = null)
    {
        if (!args.GetInputFiles().Any(file => file.Name == "sticker"))
        {
            throw new ArgumentNullException("sticker");
        }

        return await api.RequestAsync<FileStruct>("uploadStickerFile", args);
    }

    public static async Task<ResponseAPI<bool>> CreateNewStickerSetAsync(this TelegramBotAPIClient api, CreateNewStickerSetArgs args = null)
    {
        return await api.RequestAsync<bool>("createNewStickerSet", args);
    }

    public static async Task<ResponseAPI<bool>> AddStickerToSetAsync(this TelegramBotAPIClient api, AddStickerToSetArgs args = null)
    {
        return await api.RequestAsync<bool>("addStickerToSet", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerPositionInSetAsync(this TelegramBotAPIClient api, SetStickerPositionInSetArgs args = null)
    {
        return await api.RequestAsync<bool>("setStickerPositionInSet", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteStickerFromSetAsync(this TelegramBotAPIClient api, DeleteStickerFromSetArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteStickerFromSet", args);
    }

    public static async Task<ResponseAPI<bool>> ReplaceStickerInSetAsync(this TelegramBotAPIClient api, ReplaceStickerInSetArgs args = null)
    {
        return await api.RequestAsync<bool>("replaceStickerInSet", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerEmojiListAsync(this TelegramBotAPIClient api, SetStickerEmojiListArgs args = null)
    {
        return await api.RequestAsync<bool>("setStickerEmojiList", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerKeywordsAsync(this TelegramBotAPIClient api, SetStickerKeywordsArgs args = null)
    {
        return await api.RequestAsync<bool>("setStickerKeywords", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerMaskPositionAsync(this TelegramBotAPIClient api, SetStickerMaskPositionArgs args = null)
    {
        return await api.RequestAsync<bool>("setStickerMaskPosition", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerSetTitleAsync(this TelegramBotAPIClient api, SetStickerSetTitleArgs args = null)
    {
        return await api.RequestAsync<bool>("setStickerSetTitle", args);
    }

    public static async Task<ResponseAPI<bool>> SetStickerSetThumbnailAsync(this TelegramBotAPIClient api, SetStickerSetThumbnailArgs args = null)
    {
        if (string.IsNullOrEmpty(args.Thumbnail) || !args.GetInputFiles().Any(file => file.Name == "thumbnail"))
        {
            throw new ArgumentNullException(nameof(args.Thumbnail));
        }

        return await api.RequestAsync<bool>("setStickerSetThumbnail", args);
    }

    public static async Task<ResponseAPI<bool>> SetCustomEmojiStickerSetThumbnailAsync(this TelegramBotAPIClient api, SetCustomEmojiStickerSetThumbnailArgs args = null)
    {
        return await api.RequestAsync<bool>("setCustomEmojiStickerSetThumbnail", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteStickerSetAsync(this TelegramBotAPIClient api, DeleteStickerSetArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteStickerSet", args);
    }
}
