using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>Edits text and optional link preview or keyboard of a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and replacement text.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> EditMessageTextAsync(
        this IBotApiClient client, 
        EditMessageTextParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);

    /// <summary>Edits text and optional link preview or keyboard of a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="text">New text of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="parseMode">Mode for parsing entities in the message text.</param>
    /// <param name="entities">Explicit entities in the message text.</param>
    /// <param name="linkPreviewOptions">Options for the link preview.</param>
    /// <param name="richMessage">Rich message content attached to the text.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    /// <summary>Edits the caption of a message containing media.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and replacement caption.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> EditMessageCaptionAsync(
        this IBotApiClient client, 
        EditMessageCaptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);

    /// <summary>Edits the caption of a message containing media.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="caption">New caption of the message.</param>
    /// <param name="parseMode">Mode for parsing entities in the caption.</param>
    /// <param name="captionEntities">Explicit entities in the caption.</param>
    /// <param name="showCaptionAboveMedia">Whether to show the caption above the media.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    /// <summary>Replaces the media content of a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and replacement media.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> EditMessageMediaAsync(
        this IBotApiClient client, 
        EditMessageMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);

    /// <summary>Replaces the media content of a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="media">New media content.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    /// <summary>Updates the live location in a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and new location data.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> EditMessageLiveLocationAsync(
        this IBotApiClient client, 
        EditMessageLiveLocationParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Updates the live location in a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="latitude">Latitude of the new location.</param>
    /// <param name="longitude">Longitude of the new location.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="livePeriod">New period in seconds during which the location can be updated.</param>
    /// <param name="horizontalAccuracy">The radius of uncertainty for the location in meters.</param>
    /// <param name="heading">Direction of travel in degrees.</param>
    /// <param name="proximityAlertRadius">Distance in meters for proximity alerts.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    /// <summary>Stops updating a live location in a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and optional replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> StopMessageLiveLocationAsync(
        this IBotApiClient client, 
        StopMessageLiveLocationParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Stops updating a live location in a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    /// <summary>Edits a checklist message in a business chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Business chat, message and replacement checklist.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static async Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client, 
        EditMessageChecklistParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);

    /// <summary>Edits a checklist message in a business chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Identifier of the business chat.</param>
    /// <param name="messageId">Identifier of the checklist message.</param>
    /// <param name="checklist">Replacement checklist.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static async Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long chatId,
        long messageId,
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

    /// <summary>Edits the inline keyboard attached to a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message identifier and replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
    public static async Task<Message> EditMessageReplyMarkupAsync(
        this IBotApiClient client, 
        EditMessageReplyMarkupParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);

    /// <summary>Edits the inline keyboard attached to a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to edit.</param>
    /// <param name="inlineMessageId">Identifier of the inline message to edit.</param>
    /// <param name="replyMarkup">Replacement inline keyboard; omit it to remove the keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message, or <see langword="true"/> for an inline message.</returns>
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

    public static async Task<Poll> StopPollAsync(
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

    public static async Task<bool> EditEphemeralMessageTextAsync(
        this IBotApiClient client, 
        EditEphemeralMessageTextParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageText", parameters), cancellationToken);

    public static async Task<bool> EditEphemeralMessageTextAsync(
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

    public static async Task<bool> EditEphemeralMessageMediaAsync(
        this IBotApiClient client, 
        EditEphemeralMessageMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageMedia", parameters), cancellationToken);

    public static async Task<bool> EditEphemeralMessageMediaAsync(
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

    public static async Task<bool> EditEphemeralMessageCaptionAsync(
        this IBotApiClient client, 
        EditEphemeralMessageCaptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageCaption", parameters), cancellationToken);

    public static async Task<bool> EditEphemeralMessageCaptionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
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
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<bool> EditEphemeralMessageReplyMarkupAsync(
        this IBotApiClient client, 
        EditEphemeralMessageReplyMarkupParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageReplyMarkup", parameters), cancellationToken);

    public static async Task<bool> EditEphemeralMessageReplyMarkupAsync(
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

    public static async Task<bool> ApproveSuggestedPostAsync(
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

    public static async Task<bool> DeclineSuggestedPostAsync(
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

    public static async Task<bool> DeleteMessageAsync(
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

    public static async Task<bool> DeleteMessagesAsync(
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

    public static async Task<bool> DeleteEphemeralMessageAsync(
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

    public static async Task<bool> DeleteMessageReactionAsync(
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

    public static async Task<bool> DeleteAllMessageReactionsAsync(
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
