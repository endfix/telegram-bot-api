using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<Message>> SendStickerAsync(SendStickerParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendSticker", parameters));
    }

    public async Task<ApiResponse<StickerSet>> GetStickerSetAsync(GetStickerSetParameters parameters)
    {
        return await RequestAsync<StickerSet>(new ApiRequest("getStickerSet", parameters));
    }

    public async Task<ApiResponse<Sticker[]>> GetCustomEmojiStickersAsync(GetCustomEmojiStickersParameters parameters)
    {
        return await RequestAsync<Sticker[]>(new ApiRequest("getCustomEmojiStickers", parameters));
    }

    public async Task<ApiResponse<File>> UploadStickerFileAsync(UploadStickerFileParameters parameters)
    {
        return await RequestAsync<File>(new ApiRequest("uploadStickerFile", parameters));
    }

    public async Task<ApiResponse<bool>> CreateNewStickerSetAsync(CreateNewStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("createNewStickerSet", parameters));
    }

    public async Task<ApiResponse<bool>> AddStickerToSetAsync(AddStickerToSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("addStickerToSet", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerPositionInSetAsync(SetStickerPositionInSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteStickerFromSetAsync(DeleteStickerFromSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters));
    }

    public async Task<ApiResponse<bool>> ReplaceStickerInSetAsync(ReplaceStickerInSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("replaceStickerInSet", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerEmojiListAsync(SetStickerEmojiListParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerEmojiList", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerKeywordsAsync(SetStickerKeywordsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerKeywords", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerMaskPositionAsync(SetStickerMaskPositionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerSetTitleAsync(SetStickerSetTitleParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetTitle", parameters));
    }

    public async Task<ApiResponse<bool>> SetStickerSetThumbnailAsync(SetStickerSetThumbnailParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters));
    }

    public async Task<ApiResponse<bool>> SetCustomEmojiStickerSetThumbnailAsync(SetCustomEmojiStickerSetThumbnailParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteStickerSetAsync(DeleteStickerSetParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteStickerSet", parameters));
    }
}
