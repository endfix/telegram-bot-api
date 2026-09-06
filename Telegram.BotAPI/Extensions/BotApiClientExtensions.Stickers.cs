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
    /// <summary>Sends a sticker message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target chat, sticker and optional message settings.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
    public static async Task<Message> SendStickerAsync(
        this IBotApiClient client, 
        SendStickerParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendSticker", parameters), cancellationToken);

    /// <summary>Sends a sticker message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Target chat.</param>
    /// <param name="sticker">Sticker to send.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="ephemeralMessageParameters">Options for an ephemeral message.</param>
    /// <param name="emoji">Emoji associated with the sticker.</param>
    /// <param name="disableNotification">Sends the message silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the message from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="allowPaidBroadcast">Allows paid broadcasts using Telegram Stars.</param>
    /// <param name="messageEffectId">Unique identifier of a message effect.</param>
    /// <param name="suggestedPostParameters">Parameters for a suggested post.</param>
    /// <param name="replyParameters">Description of the message to reply to.</param>
    /// <param name="replyMarkup">Inline or reply keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
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

    /// <summary>Returns an installed sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set name.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sticker set.</returns>
    public static async Task<StickerSet> GetStickerSetAsync(
        this IBotApiClient client, 
        GetStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StickerSet>(new ApiRequest("getStickerSet", parameters), cancellationToken);

    /// <summary>Returns an installed sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sticker set.</returns>
    public static async Task<StickerSet> GetStickerSetAsync(
        this IBotApiClient client,
        string name,
        CancellationToken cancellationToken = default)
        => await client.GetStickerSetAsync(new GetStickerSetParameters
        {
            Name = name
        }, cancellationToken);

    /// <summary>Returns custom emoji stickers by their identifiers.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Custom emoji identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The matching stickers.</returns>
    public static async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(
        this IBotApiClient client, 
        GetCustomEmojiStickersParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getCustomEmojiStickers", parameters), cancellationToken);

    /// <summary>Returns custom emoji stickers by their identifiers.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="customEmojiIds">Identifiers of the custom emoji.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The matching stickers.</returns>
    public static async Task<IReadOnlyList<Sticker>> GetCustomEmojiStickersAsync(
        this IBotApiClient client,
        IReadOnlyList<string> customEmojiIds,
        CancellationToken cancellationToken = default)
        => await client.GetCustomEmojiStickersAsync(new GetCustomEmojiStickersParameters
        {
            CustomEmojiIds = customEmojiIds
        }, cancellationToken);

    /// <summary>Uploads a sticker file for later use in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User, file and sticker format.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The uploaded file descriptor.</returns>
    public static async Task<FileStruct> UploadStickerFileAsync(
        this IBotApiClient client, 
        UploadStickerFileParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<FileStruct>(new ApiRequest("uploadStickerFile", parameters), cancellationToken);

    /// <summary>Uploads a sticker file for later use in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who owns the sticker set.</param>
    /// <param name="sticker">Sticker file to upload.</param>
    /// <param name="stickerFormat">Sticker format.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The uploaded file descriptor.</returns>
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

    /// <summary>Creates a new sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Owner, set metadata and initial stickers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> CreateNewStickerSetAsync(
        this IBotApiClient client, 
        CreateNewStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("createNewStickerSet", parameters), cancellationToken);

    /// <summary>Creates a new sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who owns the sticker set.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="title">Sticker set title.</param>
    /// <param name="stickers">Initial stickers in the set.</param>
    /// <param name="stickerType">Type of stickers in the set.</param>
    /// <param name="needsRepainting">Whether stickers should be recolored for dark and light themes.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Adds a sticker to an existing sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set owner, name and sticker.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> AddStickerToSetAsync(
        this IBotApiClient client, 
        AddStickerToSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("addStickerToSet", parameters), cancellationToken);

    /// <summary>Adds a sticker to an existing sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who owns the sticker set.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="sticker">Sticker to add.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Moves a sticker to a position in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker file identifier and destination position.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerPositionInSetAsync(
        this IBotApiClient client, 
        SetStickerPositionInSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerPositionInSet", parameters), cancellationToken);

    /// <summary>Moves a sticker to a position in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="sticker">File identifier of the sticker.</param>
    /// <param name="position">Zero-based destination position.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Deletes a sticker from a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker file identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> DeleteStickerFromSetAsync(
        this IBotApiClient client, 
        DeleteStickerFromSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerFromSet", parameters), cancellationToken);

    /// <summary>Deletes a sticker from a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="sticker">File identifier of the sticker.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> DeleteStickerFromSetAsync(
        this IBotApiClient client,
        string sticker,
        CancellationToken cancellationToken = default)
        => await client.DeleteStickerFromSetAsync(new DeleteStickerFromSetParameters
        {
            Sticker = sticker
        }, cancellationToken);

    /// <summary>Replaces a sticker in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Owner, set name, old sticker and replacement sticker.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> ReplaceStickerInSetAsync(
        this IBotApiClient client, 
        ReplaceStickerInSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("replaceStickerInSet", parameters), cancellationToken);

    /// <summary>Replaces a sticker in a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who owns the sticker set.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="oldSticker">File identifier of the sticker to replace.</param>
    /// <param name="sticker">Replacement sticker.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the emoji associated with a sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker identifier and emoji list.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerEmojiListAsync
        (this IBotApiClient client, 
        SetStickerEmojiListParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerEmojiList", parameters), cancellationToken);

    /// <summary>Changes the emoji associated with a sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="sticker">File identifier of the sticker.</param>
    /// <param name="emojiList">Emoji associated with the sticker.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the search keywords associated with a sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker identifier and keywords.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerKeywordsAsync(
        this IBotApiClient client, 
        SetStickerKeywordsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerKeywords", parameters), cancellationToken);

    /// <summary>Changes the search keywords associated with a sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="sticker">File identifier of the sticker.</param>
    /// <param name="keywords">Search keywords; omit to remove them.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the mask position associated with a mask sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker identifier and mask position.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerMaskPositionAsync(
        this IBotApiClient client, 
        SetStickerMaskPositionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerMaskPosition", parameters), cancellationToken);

    /// <summary>Changes the mask position associated with a mask sticker.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="sticker">File identifier of the sticker.</param>
    /// <param name="maskPosition">New mask position; omit to remove it.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the title of a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set name and new title.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerSetTitleAsync(
        this IBotApiClient client, 
        SetStickerSetTitleParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetTitle", parameters), cancellationToken);

    /// <summary>Changes the title of a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="title">New sticker set title.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the thumbnail of a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set, owner, format and thumbnail.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetStickerSetThumbnailAsync(
        this IBotApiClient client, 
        SetStickerSetThumbnailParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setStickerSetThumbnail", parameters), cancellationToken);

    /// <summary>Changes the thumbnail of a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="userId">Identifier of the user who owns the sticker set.</param>
    /// <param name="format">Sticker format.</param>
    /// <param name="thumbnail">New thumbnail; omit to remove it.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes the thumbnail of a custom emoji sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set name and optional custom emoji.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetCustomEmojiStickerSetThumbnailAsync(
        this IBotApiClient client, 
        SetCustomEmojiStickerSetThumbnailParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setCustomEmojiStickerSetThumbnail", parameters), cancellationToken);

    /// <summary>Changes the thumbnail of a custom emoji sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="customEmojiId">Custom emoji identifier; omit to remove the thumbnail.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Deletes a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Sticker set name.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> DeleteStickerSetAsync(
        this IBotApiClient client, 
        DeleteStickerSetParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteStickerSet", parameters), cancellationToken);

    /// <summary>Deletes a sticker set.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="name">Sticker set name.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> DeleteStickerSetAsync(
        this IBotApiClient client,
        string name,
        CancellationToken cancellationToken = default)
        => await client.DeleteStickerSetAsync(new DeleteStickerSetParameters
        {
            Name = name
        }, cancellationToken);
}
