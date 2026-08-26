using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<Message> SendStickerAsync(
        this IBotApiClient client, 
        SendStickerParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendSticker", parameters), cancellationToken);

    public static async Task<Message> SendStickerAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        StickerSource sticker,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? emoji = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendStickerAsync(new SendStickerParameters
        {
            ChatId = chatId,
            Sticker = sticker,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Emoji = emoji,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<StickerSet> GetStickerSetAsync(
        this IBotApiClient client, 
        GetStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StickerSet>(new ApiRequest("getStickerSet", parameters), cancellationToken);

    public static async Task<StickerSet> GetStickerSetAsync(
        this IBotApiClient client,
        string name,
        CancellationToken cancellationToken = default)
        => await client.GetStickerSetAsync(new GetStickerSetParameters
        {
            Name = name
        }, cancellationToken);

    internal static async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(
        this IBotApiClient client, 
        GetCustomEmojiStickersParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getCustomEmojiStickers", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(
        this IBotApiClient client,
        IReadOnlyList<string> customEmojiIds,
        CancellationToken cancellationToken = default)
        => await client.GetCustomEmojiStickersAsync(new GetCustomEmojiStickersParameters
        {
            CustomEmojiIds = customEmojiIds
        }, cancellationToken);

    internal static async Task<FileStruct> UploadStickerFileAsync(
        this IBotApiClient client, 
        UploadStickerFileParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters), cancellationToken);

    public static async Task<FileStruct> UploadStickerFileAsync(
        this IBotApiClient client,
        long userId,
        InputFile sticker,
        StickerFormat stickerFormat,
        CancellationToken cancellationToken = default)
        => await client.UploadStickerFileAsync(new UploadStickerFileParameters
        {
            UserId = userId,
            Sticker = sticker,
            StickerFormat = stickerFormat
        }, cancellationToken);

    internal static async Task<bool> CreateNewStickerSetAsync(
        this IBotApiClient client, 
        CreateNewStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("createNewStickerSet", parameters), cancellationToken);

    public static async Task<bool> CreateNewStickerSetAsync(
        this IBotApiClient client,
        long userId,
        string name,
        string title,
        IReadOnlyList<InputSticker> stickers,
        StickerType? stickerType = null,
        bool? needsRepainting = null,
        CancellationToken cancellationToken = default)
        => await client.CreateNewStickerSetAsync(new CreateNewStickerSetParameters
        {
            UserId = userId,
            Name = name,
            Title = title,
            Stickers = stickers,
            StickerType = stickerType,
            NeedsRepainting = needsRepainting
        }, cancellationToken);

    internal static async Task<bool> AddStickerToSetAsync(
        this IBotApiClient client, 
        AddStickerToSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("addStickerToSet", parameters), cancellationToken);

    public static async Task<bool> AddStickerToSetAsync(
        this IBotApiClient client,
        long userId,
        string name,
        InputSticker sticker,
        CancellationToken cancellationToken = default)
        => await client.AddStickerToSetAsync(new AddStickerToSetParameters
        {
            UserId = userId, 
            Name = name, 
            Sticker = sticker
        }, cancellationToken);

    internal static async Task<bool> SetStickerPositionInSetAsync(
        this IBotApiClient client, 
        SetStickerPositionInSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters), cancellationToken);

    public static async Task<bool> SetStickerPositionInSetAsync(
        this IBotApiClient client,
        string sticker,
        int position,
        CancellationToken cancellationToken = default)
        => await client.SetStickerPositionInSetAsync(new SetStickerPositionInSetParameters
        {
            Sticker = sticker,
            Position = position
        }, cancellationToken);

    internal static async Task<bool> DeleteStickerFromSetAsync(
        this IBotApiClient client, 
        DeleteStickerFromSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters), cancellationToken);

    public static async Task<bool> DeleteStickerFromSetAsync(
        this IBotApiClient client,
        string sticker,
        CancellationToken cancellationToken = default)
        => await client.DeleteStickerFromSetAsync(new DeleteStickerFromSetParameters
        {
            Sticker = sticker
        }, cancellationToken);

    internal static async Task<bool> ReplaceStickerInSetAsync(
        this IBotApiClient client, 
        ReplaceStickerInSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("replaceStickerInSet", parameters), cancellationToken);

    public static async Task<bool> ReplaceStickerInSetAsync(
        this IBotApiClient client,
        long userId,
        string name,
        string oldSticker,
        InputSticker sticker,
        CancellationToken cancellationToken = default)
        => await client.ReplaceStickerInSetAsync(new ReplaceStickerInSetParameters
        {
            UserId = userId, 
            Name = name, 
            OldSticker = oldSticker, 
            Sticker = sticker
        }, cancellationToken);

    internal static async Task<bool> SetStickerEmojiListAsync
        (this IBotApiClient client, 
        SetStickerEmojiListParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerEmojiList", parameters), cancellationToken);

    public static async Task<bool> SetStickerEmojiListAsync(
        this IBotApiClient client,
        string sticker,
        IReadOnlyList<string> emojiList,
        CancellationToken cancellationToken = default)
        => await client.SetStickerEmojiListAsync(new SetStickerEmojiListParameters
        {
            Sticker = sticker,
            EmojiList = emojiList
        }, cancellationToken);

    internal static async Task<bool> SetStickerKeywordsAsync(
        this IBotApiClient client, 
        SetStickerKeywordsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerKeywords", parameters), cancellationToken);

    public static async Task<bool> SetStickerKeywordsAsync(
        this IBotApiClient client,
        string sticker,
        IReadOnlyList<string>? keywords = null,
        CancellationToken cancellationToken = default)
        => await client.SetStickerKeywordsAsync(new SetStickerKeywordsParameters
        {
            Sticker = sticker,
            Keywords = keywords
        }, cancellationToken);

    internal static async Task<bool> SetStickerMaskPositionAsync(
        this IBotApiClient client, 
        SetStickerMaskPositionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters), cancellationToken);

    public static async Task<bool> SetStickerMaskPositionAsync(
        this IBotApiClient client,
        string sticker,
        MaskPosition? maskPosition = null,
        CancellationToken cancellationToken = default)
        => await client.SetStickerMaskPositionAsync(new SetStickerMaskPositionParameters
        {
            Sticker = sticker,
            MaskPosition = maskPosition
        }, cancellationToken);

    internal static async Task<bool> SetStickerSetTitleAsync(
        this IBotApiClient client, 
        SetStickerSetTitleParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetTitle", parameters), cancellationToken);

    public static async Task<bool> SetStickerSetTitleAsync(
        this IBotApiClient client,
        string name,
        string title,
        CancellationToken cancellationToken = default)
        => await client.SetStickerSetTitleAsync(new SetStickerSetTitleParameters
        {
            Name = name,
            Title = title,
        }, cancellationToken);

    internal static async Task<bool> SetStickerSetThumbnailAsync(
        this IBotApiClient client, 
        SetStickerSetThumbnailParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters), cancellationToken);

    public static async Task<bool> SetStickerSetThumbnailAsync(
        this IBotApiClient client,
        string name,
        long userId,
        StickerFormat format,
        ThumbnailSource? thumbnail = null,
        CancellationToken cancellationToken = default)
        => await client.SetStickerSetThumbnailAsync(new SetStickerSetThumbnailParameters
        {
            Name = name,
            UserId = userId,
            Format = format,
            Thumbnail = thumbnail
        }, cancellationToken);

    internal static async Task<bool> SetCustomEmojiStickerSetThumbnailAsync(
        this IBotApiClient client, 
        SetCustomEmojiStickerSetThumbnailParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters), cancellationToken);

    public static async Task<bool> SetCustomEmojiStickerSetThumbnailAsync(
        this IBotApiClient client,
        string name,
        string? customEmojiId = null,
        CancellationToken cancellationToken = default)
        => await client.SetCustomEmojiStickerSetThumbnailAsync(new SetCustomEmojiStickerSetThumbnailParameters
        {
            Name = name,
            CustomEmojiId = customEmojiId,
        }, cancellationToken);

    internal static async Task<bool> DeleteStickerSetAsync(
        this IBotApiClient client, 
        DeleteStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerSet", parameters), cancellationToken);

    public static async Task<bool> DeleteStickerSetAsync(
        this IBotApiClient client,
        string name,
        CancellationToken cancellationToken = default)
        => await client.DeleteStickerSetAsync(new DeleteStickerSetParameters
        {
            Name = name
        }, cancellationToken);
}
