using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<Message> EditMessageTextAsync(
        this IBotApiClient client, 
        EditMessageTextParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);

    public static async Task<Message> EditMessageTextAsync(
        this IBotApiClient client,
        string text,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        LinkPreviewOptions? linkPreviewOptions = null,
        InputRichMessage? richMessage = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageTextAsync(new EditMessageTextParameters
        {
            Text = text,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            ParseMode = parseMode,
            Entities = entities,
            LinkPreviewOptions = linkPreviewOptions,
            RichMessage = richMessage,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> EditMessageCaptionAsync(
        this IBotApiClient client, 
        EditMessageCaptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);

    public static async Task<Message> EditMessageCaptionAsync(
        this IBotApiClient client,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageCaptionAsync(new EditMessageCaptionParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> EditMessageMediaAsync(
        this IBotApiClient client, 
        EditMessageMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);

    public static async Task<Message> EditMessageMediaAsync(
        this IBotApiClient client,
        InputMedia media,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageMediaAsync(new EditMessageMediaParameters
        {
            Media = media,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> EditMessageLiveLocationAsync(
        this IBotApiClient client, 
        EditMessageLiveLocationParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);

    public static async Task<Message> EditMessageLiveLocationAsync(
        this IBotApiClient client,
        double latitude,
        double longitude,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        int? livePeriod = null,
        float? horizontalAccuracy = null,
        int? heading = null,
        int? proximityAlertRadius = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageLiveLocationAsync(new EditMessageLiveLocationParameters
        {
            Latitude = latitude,
            Longitude = longitude,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            LivePeriod = livePeriod,
            HorizontalAccuracy = horizontalAccuracy,
            Heading = heading,
            ProximityAlertRadius = proximityAlertRadius,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> StopMessageLiveLocationAsync(
        this IBotApiClient client, 
        StopMessageLiveLocationParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);

    public static async Task<Message> StopMessageLiveLocationAsync(
        this IBotApiClient client,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.StopMessageLiveLocationAsync(new StopMessageLiveLocationParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client, 
        EditMessageChecklistParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);

    public static async Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long chatId,
        int messageId,
        InputChecklist checklist,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageChecklistAsync(new EditMessageChecklistParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            Checklist = checklist,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Message> EditMessageReplyMarkupAsync(
        this IBotApiClient client, 
        EditMessageReplyMarkupParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);

    public static async Task<Message> EditMessageReplyMarkupAsync(
        this IBotApiClient client,
        string? businessConnectionId = null,
        ChatIdSource? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditMessageReplyMarkupAsync(new EditMessageReplyMarkupParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Poll> StopPollAsync(
        this IBotApiClient client, 
        StopPollParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("stopPoll", parameters), cancellationToken);

    public static async Task<Poll> StopPollAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string? businessConnectionId,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.StopPollAsync(new StopPollParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            BusinessConnectionId = businessConnectionId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Poll> EditEphemeralMessageTextAsync(
        this IBotApiClient client, 
        EditEphemeralMessageTextParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("editEphemeralMessageText", parameters), cancellationToken);

    public static async Task<Poll> EditEphemeralMessageTextAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        string text,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        LinkPreviewOptions? linkPreviewOptions = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditEphemeralMessageTextAsync(new EditEphemeralMessageTextParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            Text = text,
            ParseMode = parseMode,
            Entities = entities,
            LinkPreviewOptions = linkPreviewOptions,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Poll> EditEphemeralMessageMediaAsync(
        this IBotApiClient client, 
        EditEphemeralMessageMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("editEphemeralMessageMedia", parameters), cancellationToken);

    public static async Task<Poll> EditEphemeralMessageMediaAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        InputMedia media,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditEphemeralMessageMediaAsync(new EditEphemeralMessageMediaParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            Media = media,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Poll> EditEphemeralMessageCaptionAsync(
        this IBotApiClient client, 
        EditEphemeralMessageCaptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("editEphemeralMessageCaption", parameters), cancellationToken);

    public static async Task<Poll> EditEphemeralMessageCaptionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditEphemeralMessageCaptionAsync(new EditEphemeralMessageCaptionParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<Poll> EditEphemeralMessageReplyMarkupAsync(
        this IBotApiClient client, 
        EditEphemeralMessageReplyMarkupParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Poll>(new ApiRequest("editEphemeralMessageReplyMarkup", parameters), cancellationToken);

    public static async Task<Poll> EditEphemeralMessageReplyMarkupAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.EditEphemeralMessageReplyMarkupAsync(new EditEphemeralMessageReplyMarkupParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<bool> ApproveSuggestedPostAsync(
        this IBotApiClient client, 
        ApproveSuggestedPostParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("approveSuggestedPost", parameters), cancellationToken);

    public static async Task<bool> ApproveSuggestedPostAsync(
        this IBotApiClient client,
        long chatId,
        long messageId,
        int? sendDate = null,
        CancellationToken cancellationToken = default)
        => await client.ApproveSuggestedPostAsync(new ApproveSuggestedPostParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            SendDate = sendDate
        }, cancellationToken);

    internal static async Task<bool> DeclineSuggestedPostAsync(
        this IBotApiClient client, 
        DeclineSuggestedPostParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("declineSuggestedPost", parameters), cancellationToken);

    public static async Task<bool> DeclineSuggestedPostAsync(
        this IBotApiClient client,
        long chatId,
        long messageId,
        string? comment = null,
        CancellationToken cancellationToken = default)
        => await client.DeclineSuggestedPostAsync(new DeclineSuggestedPostParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            Comment = comment
        }, cancellationToken);

    internal static async Task<bool> DeleteMessageAsync(
        this IBotApiClient client, DeleteMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessage", parameters), cancellationToken);

    public static async Task<bool> DeleteMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        CancellationToken cancellationToken = default)
        => await client.DeleteMessageAsync(new DeleteMessageParameters
        {
            ChatId = chatId,
            MessageId = messageId
        }, cancellationToken);

    internal static async Task<bool> DeleteMessagesAsync(
        this IBotApiClient client, 
        DeleteMessagesParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessages", parameters), cancellationToken);

    public static async Task<bool> DeleteMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        IReadOnlyList<long> messageIds,
        CancellationToken cancellationToken = default)
        => await client.DeleteMessagesAsync(new DeleteMessagesParameters
        {
            ChatId = chatId,
            MessageIds = messageIds
        }, cancellationToken);

    internal static async Task<bool> DeleteEphemeralMessageAsync(
        this IBotApiClient client, 
        DeleteEphemeralMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteEphemeralMessage", parameters), cancellationToken);

    public static async Task<bool> DeleteEphemeralMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        CancellationToken cancellationToken = default)
        => await client.DeleteEphemeralMessageAsync(new DeleteEphemeralMessageParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId
        }, cancellationToken);

    internal static async Task<bool> DeleteMessageReactionAsync(
        this IBotApiClient client, 
        DeleteMessageReactionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMessageReaction", parameters), cancellationToken);

    public static async Task<bool> DeleteMessageReactionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        long? userId = null,
        long? actorChatId = null,
        CancellationToken cancellationToken = default)
        => await client.DeleteMessageReactionAsync(new DeleteMessageReactionParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            UserId = userId,
            ActorChatId = actorChatId
        }, cancellationToken);

    internal static async Task<bool> DeleteAllMessageReactionsAsync(
        this IBotApiClient client, 
        DeleteAllMessageReactionsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteAllMessageReactions", parameters), cancellationToken);

    public static async Task<bool> DeleteAllMessageReactionsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long? userId = null,
        long? actorChatId = null,
        CancellationToken cancellationToken = default)
        => await client.DeleteAllMessageReactionsAsync(new DeleteAllMessageReactionsParameters
        {
            ChatId = chatId,
            UserId = userId,
            ActorChatId = actorChatId
        }, cancellationToken);
}
