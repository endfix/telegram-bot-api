using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>Edits text of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageText</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageTextForInlineMessageAsync(IBotApiClient, EditMessageTextParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and replacement text.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageTextForMessageAsync(
        this IBotApiClient client,
        EditMessageTextParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageText", parameters), cancellationToken);

    /// <summary>Edits text of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageText</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageTextForInlineMessageAsync(IBotApiClient, string, string, string?, string?, IReadOnlyList{MessageEntity}?, LinkPreviewOptions?, InputRichMessage?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="text">New text of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="parseMode">Mode for parsing entities in the message text.</param>
    /// <param name="entities">Explicit entities in the message text.</param>
    /// <param name="linkPreviewOptions">Options for the link preview.</param>
    /// <param name="richMessage">Rich message content attached to the text.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageTextForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string text,
        string? businessConnectionId = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        LinkPreviewOptions? linkPreviewOptions = null,
        InputRichMessage? richMessage = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageTextForMessageAsync(new EditMessageTextParameters
        {
            Text = text,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            ParseMode = parseMode,
            Entities = entities,
            LinkPreviewOptions = linkPreviewOptions,
            RichMessage = richMessage,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits text of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageText</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageTextForMessageAsync(IBotApiClient, EditMessageTextParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and replacement text.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageTextForInlineMessageAsync(
        this IBotApiClient client,
        EditMessageTextParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editMessageText", parameters), cancellationToken);

    /// <summary>Edits text of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageText</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageTextForMessageAsync(IBotApiClient, ChatIdSource, long, string, string?, string?, IReadOnlyList{MessageEntity}?, LinkPreviewOptions?, InputRichMessage?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="text">New text of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="parseMode">Mode for parsing entities in the message text.</param>
    /// <param name="entities">Explicit entities in the message text.</param>
    /// <param name="linkPreviewOptions">Options for the link preview.</param>
    /// <param name="richMessage">Rich message content attached to the text.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageTextForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        string text,
        string? businessConnectionId = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        LinkPreviewOptions? linkPreviewOptions = null,
        InputRichMessage? richMessage = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageTextForInlineMessageAsync(new EditMessageTextParameters
        {
            Text = text,
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            ParseMode = parseMode,
            Entities = entities,
            LinkPreviewOptions = linkPreviewOptions,
            RichMessage = richMessage,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the caption of an ordinary chat message containing media.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageCaption</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageCaptionForInlineMessageAsync(IBotApiClient, EditMessageCaptionParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and replacement caption.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageCaptionForMessageAsync(
        this IBotApiClient client,
        EditMessageCaptionParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageCaption", parameters), cancellationToken);

    /// <summary>Edits the caption of an ordinary chat message containing media.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageCaption</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageCaptionForInlineMessageAsync(IBotApiClient, string, string?, string?, string?, IReadOnlyList{MessageEntity}?, bool?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="caption">New caption of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="parseMode">Mode for parsing entities in the caption.</param>
    /// <param name="captionEntities">Explicit entities in the caption.</param>
    /// <param name="showCaptionAboveMedia">Whether to show the caption above the media.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageCaptionForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string? caption = null,
        string? businessConnectionId = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageCaptionForMessageAsync(new EditMessageCaptionParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the caption of an inline message containing media.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageCaption</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageCaptionForMessageAsync(IBotApiClient, EditMessageCaptionParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and replacement caption.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageCaptionForInlineMessageAsync(
        this IBotApiClient client,
        EditMessageCaptionParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editMessageCaption", parameters), cancellationToken);

    /// <summary>Edits the caption of an inline message containing media.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageCaption</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageCaptionForMessageAsync(IBotApiClient, ChatIdSource, long, string?, string?, string?, IReadOnlyList{MessageEntity}?, bool?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="caption">New caption of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="parseMode">Mode for parsing entities in the caption.</param>
    /// <param name="captionEntities">Explicit entities in the caption.</param>
    /// <param name="showCaptionAboveMedia">Whether to show the caption above the media.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageCaptionForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        string? caption = null,
        string? businessConnectionId = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageCaptionForInlineMessageAsync(new EditMessageCaptionParameters
        {
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Replaces the media of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageMedia</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageMediaForInlineMessageAsync(IBotApiClient, EditMessageMediaParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and replacement media.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageMediaForMessageAsync(
        this IBotApiClient client,
        EditMessageMediaParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageMedia", parameters), cancellationToken);

    /// <summary>Replaces the media of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageMedia</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageMediaForInlineMessageAsync(IBotApiClient, string, InputMedia, string?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="media">New media content.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageMediaForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        InputMedia media,
        string? businessConnectionId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageMediaForMessageAsync(new EditMessageMediaParameters
        {
            Media = media,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Replaces the media of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageMedia</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageMediaForMessageAsync(IBotApiClient, EditMessageMediaParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and replacement media.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageMediaForInlineMessageAsync(
        this IBotApiClient client,
        EditMessageMediaParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editMessageMedia", parameters), cancellationToken);

    /// <summary>Replaces the media of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageMedia</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageMediaForMessageAsync(IBotApiClient, ChatIdSource, long, InputMedia, string?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="media">New media content.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageMediaForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        InputMedia media,
        string? businessConnectionId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageMediaForInlineMessageAsync(new EditMessageMediaParameters
        {
            Media = media,
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Updates the live location in an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageLiveLocation</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageLiveLocationForInlineMessageAsync(IBotApiClient, EditMessageLiveLocationParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and new location data.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageLiveLocationForMessageAsync(
        this IBotApiClient client,
        EditMessageLiveLocationParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Updates the live location in an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageLiveLocation</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageLiveLocationForInlineMessageAsync(IBotApiClient, string, double, double, string?, int?, float?, int?, int?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="latitude">Latitude of the new location.</param>
    /// <param name="longitude">Longitude of the new location.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="livePeriod">New period in seconds during which the location can be updated.</param>
    /// <param name="horizontalAccuracy">The radius of uncertainty for the location in meters.</param>
    /// <param name="heading">Direction of travel in degrees.</param>
    /// <param name="proximityAlertRadius">Distance in meters for proximity alerts.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageLiveLocationForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        double latitude,
        double longitude,
        string? businessConnectionId = null,
        int? livePeriod = null,
        float? horizontalAccuracy = null,
        int? heading = null,
        int? proximityAlertRadius = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageLiveLocationForMessageAsync(new EditMessageLiveLocationParameters
        {
            Latitude = latitude,
            Longitude = longitude,
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            LivePeriod = livePeriod,
            HorizontalAccuracy = horizontalAccuracy,
            Heading = heading,
            ProximityAlertRadius = proximityAlertRadius,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Updates the live location in an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageLiveLocation</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageLiveLocationForMessageAsync(IBotApiClient, EditMessageLiveLocationParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and new location data.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageLiveLocationForInlineMessageAsync(
        this IBotApiClient client,
        EditMessageLiveLocationParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Updates the live location in an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageLiveLocation</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageLiveLocationForMessageAsync(IBotApiClient, ChatIdSource, long, double, double, string?, int?, float?, int?, int?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="latitude">Latitude of the new location.</param>
    /// <param name="longitude">Longitude of the new location.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="livePeriod">New period in seconds during which the location can be updated.</param>
    /// <param name="horizontalAccuracy">The radius of uncertainty for the location in meters.</param>
    /// <param name="heading">Direction of travel in degrees.</param>
    /// <param name="proximityAlertRadius">Distance in meters for proximity alerts.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageLiveLocationForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        double latitude,
        double longitude,
        string? businessConnectionId = null,
        int? livePeriod = null,
        float? horizontalAccuracy = null,
        int? heading = null,
        int? proximityAlertRadius = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageLiveLocationForInlineMessageAsync(new EditMessageLiveLocationParameters
        {
            Latitude = latitude,
            Longitude = longitude,
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            LivePeriod = livePeriod,
            HorizontalAccuracy = horizontalAccuracy,
            Heading = heading,
            ProximityAlertRadius = proximityAlertRadius,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Stops updating a live location in an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>stopMessageLiveLocation</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="StopMessageLiveLocationForInlineMessageAsync(IBotApiClient, StopMessageLiveLocationParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and optional replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> StopMessageLiveLocationForMessageAsync(
        this IBotApiClient client,
        StopMessageLiveLocationParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Stops updating a live location in an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>stopMessageLiveLocation</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="StopMessageLiveLocationForInlineMessageAsync(IBotApiClient, string, string?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> StopMessageLiveLocationForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string? businessConnectionId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.StopMessageLiveLocationForMessageAsync(new StopMessageLiveLocationParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Stops updating a live location in an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>stopMessageLiveLocation</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="StopMessageLiveLocationForMessageAsync(IBotApiClient, StopMessageLiveLocationParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and optional replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> StopMessageLiveLocationForInlineMessageAsync(
        this IBotApiClient client,
        StopMessageLiveLocationParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("stopMessageLiveLocation", parameters), cancellationToken);

    /// <summary>Stops updating a live location in an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>stopMessageLiveLocation</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="StopMessageLiveLocationForMessageAsync(IBotApiClient, ChatIdSource, long, string?, InlineKeyboardMarkup?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> StopMessageLiveLocationForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        string? businessConnectionId = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.StopMessageLiveLocationForInlineMessageAsync(new StopMessageLiveLocationParameters
        {
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits a checklist message in a business chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Business chat, message and replacement checklist.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client, 
        EditMessageChecklistParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageChecklist", parameters), cancellationToken);

    /// <summary>Edits a checklist message in a business chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="chatId">Identifier of the business chat.</param>
    /// <param name="messageId">Identifier of the checklist message.</param>
    /// <param name="checklist">Replacement checklist.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageChecklistAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long chatId,
        long messageId,
        InputChecklist checklist,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageChecklistAsync(new EditMessageChecklistParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            Checklist = checklist,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the inline keyboard of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageReplyMarkup</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageReplyMarkupForInlineMessageAsync(IBotApiClient, EditMessageReplyMarkupParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ordinary message identifier and replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageReplyMarkupForMessageAsync(
        this IBotApiClient client,
        EditMessageReplyMarkupParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Message>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);

    /// <summary>Edits the inline keyboard of an ordinary chat message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageReplyMarkup</c> for a chat message identified by
    /// <c>chat_id</c> and <c>message_id</c>. For an inline message, call
    /// <see cref="EditMessageReplyMarkupForInlineMessageAsync(IBotApiClient, string, InlineKeyboardMarkup?, string?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ordinary message.</param>
    /// <param name="messageId">Identifier of the ordinary message.</param>
    /// <param name="replyMarkup">Replacement inline keyboard; omit it to remove the keyboard.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited message.</returns>
    public static Task<Message> EditMessageReplyMarkupForMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        InlineKeyboardMarkup? replyMarkup = null,
        string? businessConnectionId = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageReplyMarkupForMessageAsync(new EditMessageReplyMarkupParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the inline keyboard of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageReplyMarkup</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageReplyMarkupForMessageAsync(IBotApiClient, EditMessageReplyMarkupParameters, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline message identifier and replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageReplyMarkupForInlineMessageAsync(
        this IBotApiClient client,
        EditMessageReplyMarkupParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editMessageReplyMarkup", parameters), cancellationToken);

    /// <summary>Edits the inline keyboard of an inline message.</summary>
    /// <remarks>
    /// Maps to Telegram's <c>editMessageReplyMarkup</c> for an inline message identified by
    /// <c>inline_message_id</c>. Telegram returns <c>true</c> rather than a
    /// <see cref="Message"/>. For an ordinary chat message, call
    /// <see cref="EditMessageReplyMarkupForMessageAsync(IBotApiClient, ChatIdSource, long, InlineKeyboardMarkup?, string?, CancellationToken)"/>.
    /// </remarks>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineMessageId">Identifier of the inline message.</param>
    /// <param name="replyMarkup">Replacement inline keyboard; omit it to remove the keyboard.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditMessageReplyMarkupForInlineMessageAsync(
        this IBotApiClient client,
        string inlineMessageId,
        InlineKeyboardMarkup? replyMarkup = null,
        string? businessConnectionId = null,
        CancellationToken cancellationToken = default)
        => client.EditMessageReplyMarkupForInlineMessageAsync(new EditMessageReplyMarkupParameters
        {
            BusinessConnectionId = businessConnectionId,
            InlineMessageId = inlineMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Stops a poll sent by the bot.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Poll message and optional replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The stopped poll.</returns>
    public static Task<Poll> StopPollAsync(
        this IBotApiClient client, 
        StopPollParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<Poll>(new ApiRequest("stopPoll", parameters), cancellationToken);

    /// <summary>Stops a poll sent by the bot.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the poll.</param>
    /// <param name="messageId">Identifier of the poll message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="replyMarkup">Replacement inline keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The stopped poll.</returns>
    public static Task<Poll> StopPollAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string? businessConnectionId,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.StopPollAsync(new StopPollParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            BusinessConnectionId = businessConnectionId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the text of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ephemeral message identifier and replacement text.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageTextAsync(
        this IBotApiClient client, 
        EditEphemeralMessageTextParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageText", parameters), cancellationToken);

    /// <summary>Edits the text of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ephemeral message.</param>
    /// <param name="receiverUserId">Identifier of the user who received the message.</param>
    /// <param name="ephemeralMessageId">Identifier of the ephemeral message.</param>
    /// <param name="text">New text of the message.</param>
    /// <param name="parseMode">Mode for parsing entities in the message text.</param>
    /// <param name="entities">Explicit entities in the message text.</param>
    /// <param name="linkPreviewOptions">Options for the link preview.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageTextAsync(
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
        => client.EditEphemeralMessageTextAsync(new EditEphemeralMessageTextParameters
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

    /// <summary>Replaces the media of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ephemeral message identifier and replacement media.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageMediaAsync(
        this IBotApiClient client, 
        EditEphemeralMessageMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageMedia", parameters), cancellationToken);

    /// <summary>Replaces the media of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ephemeral message.</param>
    /// <param name="receiverUserId">Identifier of the user who received the message.</param>
    /// <param name="ephemeralMessageId">Identifier of the ephemeral message.</param>
    /// <param name="media">New media content.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageMediaAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        InputMedia media,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditEphemeralMessageMediaAsync(new EditEphemeralMessageMediaParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            Media = media,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Edits the caption of an ephemeral message containing media.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ephemeral message identifier and replacement caption.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageCaptionAsync(
        this IBotApiClient client, 
        EditEphemeralMessageCaptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageCaption", parameters), cancellationToken);

    /// <summary>Edits the caption of an ephemeral message containing media.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ephemeral message.</param>
    /// <param name="receiverUserId">Identifier of the user who received the message.</param>
    /// <param name="ephemeralMessageId">Identifier of the ephemeral message.</param>
    /// <param name="caption">New caption of the message.</param>
    /// <param name="parseMode">Mode for parsing entities in the caption.</param>
    /// <param name="captionEntities">Explicit entities in the caption.</param>
    /// <param name="showCaptionAboveMedia">Whether to show the caption above the media.</param>
    /// <param name="replyMarkup">Inline keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageCaptionAsync(
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
        => client.EditEphemeralMessageCaptionAsync(new EditEphemeralMessageCaptionParameters
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

    /// <summary>Edits the inline keyboard of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ephemeral message identifier and replacement keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageReplyMarkupAsync(
        this IBotApiClient client, 
        EditEphemeralMessageReplyMarkupParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("editEphemeralMessageReplyMarkup", parameters), cancellationToken);

    /// <summary>Edits the inline keyboard of an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ephemeral message.</param>
    /// <param name="receiverUserId">Identifier of the user who received the message.</param>
    /// <param name="ephemeralMessageId">Identifier of the ephemeral message.</param>
    /// <param name="replyMarkup">Replacement inline keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> EditEphemeralMessageReplyMarkupAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => client.EditEphemeralMessageReplyMarkupAsync(new EditEphemeralMessageReplyMarkupParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Approves a suggested post.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Suggested post identifier and optional publication date.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> ApproveSuggestedPostAsync(
        this IBotApiClient client, 
        ApproveSuggestedPostParameters parameters,
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("approveSuggestedPost", parameters), cancellationToken);

    /// <summary>Approves a suggested post.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Channel chat containing the suggested post.</param>
    /// <param name="messageId">Identifier of the suggested post message.</param>
    /// <param name="sendDate">Unix timestamp when the post should be published.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> ApproveSuggestedPostAsync(
        this IBotApiClient client,
        long chatId,
        long messageId,
        int? sendDate = null,
        CancellationToken cancellationToken = default)
        => client.ApproveSuggestedPostAsync(new ApproveSuggestedPostParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            SendDate = sendDate
        }, cancellationToken);

    /// <summary>Declines a suggested post.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Suggested post identifier and optional explanation.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeclineSuggestedPostAsync(
        this IBotApiClient client, 
        DeclineSuggestedPostParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("declineSuggestedPost", parameters), cancellationToken);

    /// <summary>Declines a suggested post.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Channel chat containing the suggested post.</param>
    /// <param name="messageId">Identifier of the suggested post message.</param>
    /// <param name="comment">Optional comment explaining the rejection.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeclineSuggestedPostAsync(
        this IBotApiClient client,
        long chatId,
        long messageId,
        string? comment = null,
        CancellationToken cancellationToken = default)
        => client.DeclineSuggestedPostAsync(new DeclineSuggestedPostParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            Comment = comment
        }, cancellationToken);

    /// <summary>Deletes a message from a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Chat and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessageAsync(
        this IBotApiClient client, DeleteMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("deleteMessage", parameters), cancellationToken);

    /// <summary>Deletes a message from a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message to delete.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        CancellationToken cancellationToken = default)
        => client.DeleteMessageAsync(new DeleteMessageParameters
        {
            ChatId = chatId,
            MessageId = messageId
        }, cancellationToken);

    /// <summary>Deletes several messages from a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Chat and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessagesAsync(
        this IBotApiClient client, 
        DeleteMessagesParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("deleteMessages", parameters), cancellationToken);

    /// <summary>Deletes several messages from a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the messages.</param>
    /// <param name="messageIds">Identifiers of the messages to delete.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        IReadOnlyList<long> messageIds,
        CancellationToken cancellationToken = default)
        => client.DeleteMessagesAsync(new DeleteMessagesParameters
        {
            ChatId = chatId,
            MessageIds = messageIds
        }, cancellationToken);

    /// <summary>Deletes an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Ephemeral message identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteEphemeralMessageAsync(
        this IBotApiClient client, 
        DeleteEphemeralMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("deleteEphemeralMessage", parameters), cancellationToken);

    /// <summary>Deletes an ephemeral message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the ephemeral message.</param>
    /// <param name="receiverUserId">Identifier of the user who received the message.</param>
    /// <param name="ephemeralMessageId">Identifier of the ephemeral message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteEphemeralMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long receiverUserId,
        long ephemeralMessageId,
        CancellationToken cancellationToken = default)
        => client.DeleteEphemeralMessageAsync(new DeleteEphemeralMessageParameters
        {
            ChatId = chatId,
            ReceiverUserId = receiverUserId,
            EphemeralMessageId = ephemeralMessageId
        }, cancellationToken);

    /// <summary>Deletes a reaction from a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message and optional actor identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessageReactionAsync(
        this IBotApiClient client, 
        DeleteMessageReactionParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("deleteMessageReaction", parameters), cancellationToken);

    /// <summary>Deletes a reaction from a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="messageId">Identifier of the message.</param>
    /// <param name="userId">Identifier of the user whose reaction should be deleted.</param>
    /// <param name="actorChatId">Identifier of the chat whose reaction should be deleted.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteMessageReactionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        long? userId = null,
        long? actorChatId = null,
        CancellationToken cancellationToken = default)
        => client.DeleteMessageReactionAsync(new DeleteMessageReactionParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            UserId = userId,
            ActorChatId = actorChatId
        }, cancellationToken);

    /// <summary>Deletes all reactions from a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Message and optional actor identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteAllMessageReactionsAsync(
        this IBotApiClient client, 
        DeleteAllMessageReactionsParameters parameters, 
        CancellationToken cancellationToken = default)
        => client.ExecuteAsync<bool>(new ApiRequest("deleteAllMessageReactions", parameters), cancellationToken);

    /// <summary>Deletes all reactions from a message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Chat containing the message.</param>
    /// <param name="userId">Identifier of the user whose reactions should be deleted.</param>
    /// <param name="actorChatId">Identifier of the chat whose reactions should be deleted.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static Task<bool> DeleteAllMessageReactionsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long? userId = null,
        long? actorChatId = null,
        CancellationToken cancellationToken = default)
        => client.DeleteAllMessageReactionsAsync(new DeleteAllMessageReactionsParameters
        {
            ChatId = chatId,
            UserId = userId,
            ActorChatId = actorChatId
        }, cancellationToken);
}
