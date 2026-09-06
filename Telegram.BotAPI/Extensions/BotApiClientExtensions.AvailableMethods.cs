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
    /// <summary>Returns basic information about the bot.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">The request has no parameters.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's user information.</returns>
    public static async Task<User> GetMeAsync(
        this IBotApiClient client,
        GetMeParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<User>(new ApiRequest("getMe", parameters), cancellationToken);

    /// <summary>Returns basic information about the bot.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's user information.</returns>
    public static async Task<User> GetMeAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.GetMeAsync(new GetMeParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    /// <summary>Logs out the bot before moving it to a local Bot API server.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">The request has no parameters.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> LogOutAsync(
        this IBotApiClient client,
        LogOutParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("logOut", parameters), cancellationToken);

    /// <summary>Logs out the bot before moving it to a local Bot API server.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> LogOutAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.LogOutAsync(new LogOutParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    /// <summary>Closes the bot instance before moving it to a local Bot API server.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">The request has no parameters.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> CloseAsync(
        this IBotApiClient client,
        CloseParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("close", parameters), cancellationToken);

    /// <summary>Closes the bot instance before moving it to a local Bot API server.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> CloseAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.CloseAsync(new CloseParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    /// <summary>Sends a text message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target chat, message text and optional formatting settings.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
    public static async Task<Message> SendMessageAsync(
        this IBotApiClient client,
        SendMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendMessage", parameters), cancellationToken);

    /// <summary>Sends a text message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Target chat.</param>
    /// <param name="text">Text of the message.</param>
    /// <param name="businessConnectionId">Unique identifier of the business connection.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="ephemeralMessageParameters">Options for an ephemeral message.</param>
    /// <param name="parseMode">Mode for parsing entities in the message text.</param>
    /// <param name="entities">Explicit entities in the message text.</param>
    /// <param name="linkPreviewOptions">Options for the link preview.</param>
    /// <param name="disableNotification">Sends the message silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the message from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="allowPaidBroadcast">Allows paid broadcasts using Telegram Stars.</param>
    /// <param name="messageEffectId">Unique identifier of a message effect.</param>
    /// <param name="suggestedPostParameters">Parameters for a suggested post.</param>
    /// <param name="replyParameters">Description of the message to reply to.</param>
    /// <param name="replyMarkup">Inline or reply keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
    public static async Task<Message> SendMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string text,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        LinkPreviewOptions? linkPreviewOptions = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendMessageAsync(new SendMessageParameters
        {
            ChatId = chatId,
            Text = text,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            ParseMode = parseMode,
            Entities = entities,
            LinkPreviewOptions = linkPreviewOptions,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Forwards a message to a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Source, destination and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The forwarded message.</returns>
    public static async Task<Message> ForwardMessageAsync(
        this IBotApiClient client,
        ForwardMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("forwardMessage", parameters), cancellationToken);

    /// <summary>Forwards a message to a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Destination chat.</param>
    /// <param name="fromChatId">Source chat.</param>
    /// <param name="messageId">Identifier of the message to forward.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="videoStartTimestamp">Start timestamp for forwarded video messages.</param>
    /// <param name="disableNotification">Sends the message silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the message from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="suggestedPostParameters">Parameters for a suggested post.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The forwarded message.</returns>
    public static async Task<Message> ForwardMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        ChatIdSource fromChatId,
        long messageId,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        int? videoStartTimestamp = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        CancellationToken cancellationToken = default)
        => await client.ForwardMessageAsync(new ForwardMessageParameters
        {
            ChatId = chatId,
            FromChatId = fromChatId,
            MessageId = messageId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            VideoStartTimestamp = videoStartTimestamp,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            SuggestedPostParameters = suggestedPostParameters
        }, cancellationToken);

    /// <summary>Forwards multiple messages to a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Source, destination and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>Identifiers of the forwarded messages.</returns>
    public static async Task<IReadOnlyList<MessageIdStruct>> ForwardMessagesAsync(
        this IBotApiClient client,
        ForwardMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("forwardMessages", parameters), cancellationToken);

    /// <summary>Forwards multiple messages to a chat.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Destination chat.</param>
    /// <param name="fromChatId">Source chat.</param>
    /// <param name="messageIds">Identifiers of the messages to forward.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="disableNotification">Sends the messages silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the messages from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>Identifiers of the forwarded messages.</returns>
    public static async Task<IReadOnlyList<MessageIdStruct>> ForwardMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        ChatIdSource fromChatId,
        IReadOnlyList<long> messageIds,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        CancellationToken cancellationToken = default)
        => await client.ForwardMessagesAsync(new ForwardMessagesParameters
        {
            ChatId = chatId,
            FromChatId = fromChatId,
            MessageIds = messageIds,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            DisableNotification = disableNotification,
            ProtectContent = protectContent
        }, cancellationToken);

    /// <summary>Copies a message to a chat without a link to the original message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Source, destination and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The identifier of the copied message.</returns>
    public static async Task<MessageIdStruct> CopyMessageAsync(
        this IBotApiClient client,
        CopyMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<MessageIdStruct>(new ApiRequest("copyMessage", parameters), cancellationToken);

    /// <summary>Copies a message to a chat without a link to the original message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Destination chat.</param>
    /// <param name="fromChatId">Source chat.</param>
    /// <param name="messageId">Identifier of the message to copy.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="videoStartTimestamp">Start timestamp for copied video messages.</param>
    /// <param name="caption">New caption for the copied message.</param>
    /// <param name="parseMode">Mode for parsing entities in the caption.</param>
    /// <param name="captionEntities">Explicit entities in the caption.</param>
    /// <param name="showCaptionAboveMedia">Whether to show the caption above the media.</param>
    /// <param name="disableNotification">Sends the message silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the message from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="allowPaidBroadcast">Allows paid broadcasts using Telegram Stars.</param>
    /// <param name="suggestedPostParameters">Parameters for a suggested post.</param>
    /// <param name="replyParameters">Description of the message to reply to.</param>
    /// <param name="replyMarkup">Inline or reply keyboard attached to the message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The identifier of the copied message.</returns>
    public static async Task<MessageIdStruct> CopyMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        ChatIdSource fromChatId,
        long messageId,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        int? videoStartTimestamp = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.CopyMessageAsync(new CopyMessageParameters
        {
            ChatId = chatId,
            FromChatId = fromChatId,
            MessageId = messageId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            VideoStartTimestamp = videoStartTimestamp,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Copies multiple messages to a chat without links to the originals.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Source, destination and message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>Identifiers of the copied messages.</returns>
    public static async Task<IReadOnlyList<MessageIdStruct>> CopyMessagesAsync(
        this IBotApiClient client,
        CopyMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<MessageIdStruct>>(new ApiRequest("copyMessages", parameters), cancellationToken);

    /// <summary>Copies multiple messages to a chat without links to the originals.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Destination chat.</param>
    /// <param name="fromChatId">Source chat.</param>
    /// <param name="messageIds">Identifiers of the messages to copy.</param>
    /// <param name="messageThreadId">Target message thread.</param>
    /// <param name="directMessagesTopicId">Topic identifier in a direct messages chat.</param>
    /// <param name="disableNotification">Sends the messages silently when <see langword="true"/>.</param>
    /// <param name="protectContent">Protects the messages from forwarding and saving when <see langword="true"/>.</param>
    /// <param name="removeCaption">Whether to remove captions from copied messages.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>Identifiers of the copied messages.</returns>
    public static async Task<IReadOnlyList<MessageIdStruct>> CopyMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        ChatIdSource fromChatId,
        IReadOnlyList<long> messageIds,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? removeCaption = null,
        CancellationToken cancellationToken = default)
        => await client.CopyMessagesAsync(new CopyMessagesParameters
        {
            ChatId = chatId,
            FromChatId = fromChatId,
            MessageIds = messageIds,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            RemoveCaption = removeCaption
        }, cancellationToken);

    public static async Task<Message> SendPhotoAsync(
        this IBotApiClient client,
        SendPhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPhoto", parameters), cancellationToken);

    public static async Task<Message> SendPhotoAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        PhotoSource photo,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? CaptionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? hasSpoiler = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendPhotoAsync(new SendPhotoParameters
        {
            ChatId = chatId,
            Photo = photo,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = CaptionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            HasSpoiler = hasSpoiler,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendLivePhotoAsync(
        this IBotApiClient client, 
        SendLivePhotoParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendLivePhoto", parameters), cancellationToken);

    public static async Task<Message> SendLivePhotoAsync(
        this IBotApiClient client,    
        ChatIdSource chatId,
        MediaSource livePhoto,
        MediaSource photo,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? hasSpoiler = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        long? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendLivePhotoAsync(new SendLivePhotoParameters
        {
            ChatId = chatId,
            LivePhoto = livePhoto,
            Photo = photo,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            HasSpoiler = hasSpoiler,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendAudioAsync(
        this IBotApiClient client, 
        SendAudioParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendAudio", parameters), cancellationToken);

    public static async Task<Message> SendAudioAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        AudioSource audio,
        string? businessConnectionId = null,    
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        int? duration = null,
        string? performer = null,
        string? title = null,
        ThumbnailSource? thumbnail = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendAudioAsync(new SendAudioParameters
        {
            ChatId = chatId,
            Audio = audio,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            Duration = duration,
            Performer = performer,
            Title = title,
            Thumbnail = thumbnail,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendDocumentAsync(
        this IBotApiClient client, 
        SendDocumentParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendDocument", parameters), cancellationToken);

    public static async Task<Message> SendDocumentAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        DocumentSource document,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        ThumbnailSource? thumbnail = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? disableContentTypeDetection = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendDocumentAsync(new SendDocumentParameters
        {
            ChatId = chatId,
            Document = document,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Thumbnail = thumbnail,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            DisableContentTypeDetection = disableContentTypeDetection,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendVideoAsync(
        this IBotApiClient client, 
        SendVideoParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVideo", parameters), cancellationToken);

    public static async Task<Message> SendVideoAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        VideoSource video,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        int? duration = null,
        int? width = null,
        int? height = null,
        ThumbnailSource? thumbnail = null,
        CoverSource? cover = null,
        int? startTimestamp = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? hasSpoiler = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendVideoAsync(new SendVideoParameters
        {
            ChatId = chatId,
            Video = video,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Duration = duration,
            Width = width,
            Height = height,
            Thumbnail = thumbnail,
            Cover = cover,
            StartTimestamp = startTimestamp,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            HasSpoiler = hasSpoiler,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendAnimationAsync(
        this IBotApiClient client, 
        SendAnimationParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendAnimation", parameters), cancellationToken);

    public static async Task<Message> SendAnimationAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        AnimationSource animation,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        int? duration = null,
        int? width = null,
        int? height = null,
        ThumbnailSource? thumbnail = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? hasSpoiler = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendAnimationAsync(new SendAnimationParameters
        {
            ChatId = chatId,
            Animation = animation,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Duration = duration,
            Width = width,
            Height = height,
            Thumbnail = thumbnail,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            HasSpoiler = hasSpoiler,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendVoiceAsync(
        this IBotApiClient client, 
        SendVoiceParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVoice", parameters), cancellationToken);

    public static async Task<Message> SendVoiceAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        VoiceSource voice,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        int? duration = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendVoiceAsync(new SendVoiceParameters
        {
            ChatId = chatId,
            Voice = voice,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            Duration = duration,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendVideoNoteAsync(
        this IBotApiClient client, 
        SendVideoNoteParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVideoNote", parameters), cancellationToken);

    public static async Task<Message> SendVideoNoteAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        VideoNoteSource videoNote,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        int? duration = null,
        int? length = null,
        ThumbnailSource? thumbnail = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendVideoNoteAsync(new SendVideoNoteParameters
        {
            ChatId = chatId,
            VideoNote = videoNote,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            Duration = duration,
            Length = length,
            Thumbnail = thumbnail,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendPaidMediaAsync(
        this IBotApiClient client, 
        SendPaidMediaParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPaidMedia", parameters), cancellationToken);

    public static async Task<Message> SendPaidMediaAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        int starCount,
        IReadOnlyList<InputPaidMedia> media,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        string? payload = null,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        bool? showCaptionAboveMedia = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendPaidMediaAsync(new SendPaidMediaParameters
        {
            ChatId = chatId,
            StarCount = starCount,
            Media = media,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            Payload = payload,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            ShowCaptionAboveMedia = showCaptionAboveMedia,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<IReadOnlyList<Message>> SendMediaGroupAsync(
        this IBotApiClient client, 
        SendMediaGroupParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Message>>(new ApiRequest("sendMediaGroup", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Message>> SendMediaGroupAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        IReadOnlyList<InputMedia> media,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        ReplyParameters? replyParameters = null,
        CancellationToken cancellationToken = default)
        => await client.SendMediaGroupAsync(new SendMediaGroupParameters
        {
            ChatId = chatId,
            Media = media,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            ReplyParameters = replyParameters
        }, cancellationToken);

    public static async Task<Message> SendLocationAsync(
        this IBotApiClient client,
        SendLocationParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendLocation", parameters), cancellationToken);

    public static async Task<Message> SendLocationAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        double latitude,
        double longitude,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        float? horizontalAccuracy = null,
        int? livePeriod = null,
        int? heading = null,
        int? proximityAlertRadius = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendLocationAsync(new SendLocationParameters
        {
            ChatId = chatId,
            Latitude = latitude,
            Longitude = longitude,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            HorizontalAccuracy = horizontalAccuracy,
            LivePeriod = livePeriod,
            Heading = heading,
            ProximityAlertRadius = proximityAlertRadius,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendVenueAsync(
        this IBotApiClient client,
        SendVenueParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendVenue", parameters), cancellationToken);

    public static async Task<Message> SendVenueAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        double latitude,
        double longitude,
        string title,
        string address,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? foursquareId = null,
        string? foursquareType = null,
        string? googlePlaceId = null,
        string? googlePlaceType = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendVenueAsync(new SendVenueParameters
        {
            ChatId = chatId,
            Latitude = latitude,
            Longitude = longitude,
            Title = title,
            Address = address,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            FoursquareId = foursquareId,
            FoursquareType = foursquareType,
            GooglePlaceId = googlePlaceId,
            GooglePlaceType = googlePlaceType,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendContactAsync(
        this IBotApiClient client,
        SendContactParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendContact", parameters), cancellationToken);

    public static async Task<Message> SendContactAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string phoneNumber,
        string firstName,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        string? businessConnectionId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        string? lastName = null,
        string? vcard = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendContactAsync(new SendContactParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            PhoneNumber = phoneNumber,
            FirstName = firstName,
            BusinessConnectionId = businessConnectionId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            LastName = lastName,
            Vcard = vcard,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendPollAsync(
        this IBotApiClient client,
        SendPollParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendPoll", parameters), cancellationToken);

    public static async Task<Message> SendPollAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string question,
        IReadOnlyList<InputPollOption> options,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        string? questionParseMode = null,
        IReadOnlyList<MessageEntity>? questionEntities = null,
        bool? isAnonymous = null,
        PollType? type = null,
        bool? allowsMultipleAnswers = null,
        bool? allowsRevoting = null,
        bool? shuffleOptions = null,
        bool? allowAddingOptions = null,
        bool? hideResultsUntilCloses = null,
        bool? membersOnly = null,
        IReadOnlyList<string>? countryCodes = null,
        IReadOnlyList<int>? correctOptionIds = null,
        string? explanation = null,
        string? explanationParseMode = null,
        IReadOnlyList<MessageEntity>? explanationEntities = null,
        IInputPollMedia? explanationMedia = null,
        int? openPeriod = null,
        int? closeDate = null,
        bool? isClosed = null,
        string? description = null,
        string? descriptionParseMode = null,
        IReadOnlyList<MessageEntity>? descriptionEntities = null,
        IInputPollMedia? media = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendPollAsync(new SendPollParameters
        {
            ChatId = chatId,
            Question = question,
            Options = options,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            QuestionParseMode = questionParseMode,
            QuestionEntities = questionEntities,
            IsAnonymous = isAnonymous,
            Type = type,
            AllowsMultipleAnswers = allowsMultipleAnswers,
            AllowsRevoting = allowsRevoting,
            ShuffleOptions = shuffleOptions,
            AllowAddingOptions = allowAddingOptions,
            HideResultsUntilCloses = hideResultsUntilCloses,
            MembersOnly = membersOnly,
            CountryCodes = countryCodes,
            CorrectOptionIds = correctOptionIds,
            Explanation = explanation,
            ExplanationParseMode = explanationParseMode,
            ExplanationEntities = explanationEntities,
            ExplanationMedia = explanationMedia,
            OpenPeriod = openPeriod,
            CloseDate = closeDate,
            IsClosed = isClosed,
            Description = description,
            DescriptionParseMode = descriptionParseMode,
            DescriptionEntities = descriptionEntities,
            Media = media,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendChecklistAsync(
        this IBotApiClient client,
        SendChecklistParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendChecklist", parameters), cancellationToken);

    public static async Task<Message> SendChecklistAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long chatId,
        InputChecklist checklist,
        bool? disableNotification = null,
        bool? protectContent = null,
        string? messageEffectId = null,
        ReplyParameters? replyParameters = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendChecklistAsync(new SendChecklistParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            Checklist = checklist,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            MessageEffectId = messageEffectId,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<Message> SendDiceAsync(
        this IBotApiClient client,
        SendDiceParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendDice", parameters), cancellationToken);

    public static async Task<Message> SendDiceAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        string? emoji = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendDiceAsync(new SendDiceParameters
        {
            ChatId = chatId,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            Emoji = emoji,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    public static async Task<bool> SendMessageDraftAsync(
        this IBotApiClient client,
        SendMessageDraftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendMessageDraft", parameters), cancellationToken);

    public static async Task<bool> SendMessageDraftAsync(
        this IBotApiClient client,
        long chatId,
        long draftId,
        long? messageThreadId = null,
        string? text = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? entities = null,
        bool? canStop = null,
        bool? keepOnStop = null,
        CancellationToken cancellationToken = default)
        => await client.SendMessageDraftAsync(new SendMessageDraftParameters
        {
            ChatId = chatId,
            DraftId = draftId,
            MessageThreadId = messageThreadId,
            Text = text,
            ParseMode = parseMode,
            Entities = entities,
            CanStop = canStop,
            KeepOnStop = keepOnStop
        }, cancellationToken);

    public static async Task<bool> SendChatActionAsync(
        this IBotApiClient client,
        SendChatActionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendChatAction", parameters), cancellationToken);

    public static async Task<bool> SendChatActionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string action,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        CancellationToken cancellationToken = default)
        => await client.SendChatActionAsync(new SendChatActionParameters
        {
            ChatId = chatId,
            Action = action,
            BusinessConnectionId = businessConnectionId,
            MessageThreadId = messageThreadId
        }, cancellationToken);

    public static async Task<bool> SetMessageReactionAsync(
        this IBotApiClient client,
        SetMessageReactionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMessageReaction", parameters), cancellationToken);

    public static async Task<bool> SetMessageReactionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        IReadOnlyList<ReactionType>? reaction = null,
        bool? isBig = null,
        CancellationToken cancellationToken = default)
        => await client.SetMessageReactionAsync(new SetMessageReactionParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            Reaction = reaction,
            IsBig = isBig
        }, cancellationToken);

    public static async Task<UserProfilePhotos> GetUserProfilePhotosAsync(
        this IBotApiClient client,
        GetUserProfilePhotosParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserProfilePhotos>(new ApiRequest("getUserProfilePhotos", parameters), cancellationToken);

    public static async Task<UserProfilePhotos> GetUserProfilePhotosAsync(
        this IBotApiClient client,
        long userId,
        int? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetUserProfilePhotosAsync(new GetUserProfilePhotosParameters
        {
            UserId = userId,
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    public static async Task<UserProfileAudios> GetUserProfileAudiosAsync(
        this IBotApiClient client,
        GetUserProfileAudiosParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserProfileAudios>(new ApiRequest("getUserProfileAudios", parameters), cancellationToken);

    public static async Task<UserProfileAudios> GetUserProfileAudiosAsync(
        this IBotApiClient client,
        long userId,
        int? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetUserProfileAudiosAsync(new GetUserProfileAudiosParameters
        {
            UserId = userId,
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    public static async Task<bool> SetUserEmojiStatusAsync(
        this IBotApiClient client,
        SetUserEmojiStatusParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setUserEmojiStatus", parameters), cancellationToken);

    public static async Task<bool> SetUserEmojiStatusAsync(
        this IBotApiClient client,
        long userId,
        string? emojiStatusCustomEmojiId = null,
        int? emojiStatusExpirationDate = null,
        CancellationToken cancellationToken = default)
        => await client.SetUserEmojiStatusAsync(new SetUserEmojiStatusParameters
        {
            UserId = userId,
            EmojiStatusCustomEmojiId = emojiStatusCustomEmojiId,
            EmojiStatusExpirationDate = emojiStatusExpirationDate
        }, cancellationToken);

    public static async Task<FileStruct> GetFileAsync(
        this IBotApiClient client,
        GetFileParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<FileStruct>(new ApiRequest("getFile", parameters), cancellationToken);

    public static async Task<FileStruct> GetFileAsync(
        this IBotApiClient client,
        string fileId,
        CancellationToken cancellationToken = default)
        => await client.GetFileAsync(new GetFileParameters
        {
            FileId = fileId
        }, cancellationToken);

    public static async Task<bool> BanChatMemberAsync(
        this IBotApiClient client,
        BanChatMemberParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("banChatMember", parameters), cancellationToken);

    public static async Task<bool> BanChatMemberAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        int? untilDate,
        bool? revokeMessages,
        CancellationToken cancellationToken = default)
        => await client.BanChatMemberAsync(new BanChatMemberParameters
        {
            ChatId = chatId,
            UserId = userId,
            UntilDate = untilDate,
            RevokeMessages = revokeMessages
        }, cancellationToken);

    public static async Task<bool> UnbanChatMemberAsync(
        this IBotApiClient client,
        UnbanChatMemberParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unbanChatMember", parameters), cancellationToken);

    public static async Task<bool> UnbanChatMemberAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        bool? onlyIfBanned = null,
        CancellationToken cancellationToken = default)
        => await client.UnbanChatMemberAsync(new UnbanChatMemberParameters
        {
            ChatId = chatId,
            UserId = userId,
            OnlyIfBanned = onlyIfBanned
        }, cancellationToken);

    public static async Task<bool> RestrictChatMemberAsync(
        this IBotApiClient client,
        RestrictChatMemberParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("restrictChatMember", parameters), cancellationToken);

    public static async Task<bool> RestrictChatMemberAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        ChatPermissions permissions,
        bool? useIndependentChatPermissions = null,
        int? untilDate = null,
        CancellationToken cancellationToken = default)
        => await client.RestrictChatMemberAsync(new RestrictChatMemberParameters
        {
            ChatId = chatId,
            UserId = userId,
            Permissions = permissions,
            UseIndependentChatPermissions = useIndependentChatPermissions,
            UntilDate = untilDate
        }, cancellationToken);

    public static async Task<bool> PromoteChatMemberAsync(this IBotApiClient client, PromoteChatMemberParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("promoteChatMember", parameters), cancellationToken);

    public static async Task<bool> PromoteChatMemberAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        bool? isAnonymous = null,
        bool? canManageChat = null,
        bool? canDeleteMessages = null,
        bool? canManageVideoChats = null,
        bool? canRestrictMembers = null,
        bool? canPromoteMembers = null,
        bool? canChangeInfo = null,
        bool? canInviteUsers = null,
        bool? canPostStories = null,
        bool? canEditStories = null,
        bool? canDeleteStories = null,
        bool? canPostMessages = null,
        bool? canEditMessages = null,
        bool? canPinMessages = null,
        bool? canManageTopics = null,
        bool? canManageDirectMessages = null,
        bool? canManageTags = null,
        bool? canSendWelcomeMessages = null,
        CancellationToken cancellationToken = default)
        => await client.PromoteChatMemberAsync(new PromoteChatMemberParameters
        {
            ChatId = chatId,
            UserId = userId,
            IsAnonymous = isAnonymous,
            CanManageChat = canManageChat,
            CanDeleteMessages = canDeleteMessages,
            CanManageVideoChats = canManageVideoChats,
            CanRestrictMembers = canRestrictMembers,
            CanPromoteMembers = canPromoteMembers,
            CanChangeInfo = canChangeInfo,
            CanInviteUsers = canInviteUsers,
            CanPostStories = canPostStories,
            CanEditStories = canEditStories,
            CanDeleteStories = canDeleteStories,
            CanPostMessages = canPostMessages,
            CanEditMessages = canEditMessages,
            CanPinMessages = canPinMessages,
            CanManageTopics = canManageTopics,
            CanManageDirectMessages = canManageDirectMessages,
            CanManageTags = canManageTags,
            CanSendWelcomeMessages = canSendWelcomeMessages
        }, cancellationToken);

    public static async Task<bool> SetChatAdministratorCustomTitleAsync(
        this IBotApiClient client,
        SetChatAdministratorCustomTitleParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatAdministratorCustomTitle", parameters), cancellationToken);

    public static async Task<bool> SetChatAdministratorCustomTitleAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        string customTitle,
        CancellationToken cancellationToken = default)
        => await client.SetChatAdministratorCustomTitleAsync(new SetChatAdministratorCustomTitleParameters
        {
            ChatId = chatId,
            UserId = userId,
            CustomTitle = customTitle
        }, cancellationToken);

    public static async Task<bool> SetChatMemberTagAsync(
        this IBotApiClient client,
        SetChatMemberTagParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatMemberTag", parameters), cancellationToken);

    public static async Task<bool> SetChatMemberTagAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        string? tag = null,
        CancellationToken cancellationToken = default)
        => await client.SetChatMemberTagAsync(new SetChatMemberTagParameters
        {
            ChatId = chatId,
            UserId = userId,
            Tag = tag
        }, cancellationToken);

    public static async Task<bool> BanChatSenderChatAsync(
        this IBotApiClient client,
        BanChatSenderChatParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("banChatSenderChat", parameters), cancellationToken);

    public static async Task<bool> BanChatSenderChatAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long senderChatId,
        CancellationToken cancellationToken = default)
        => await client.BanChatSenderChatAsync(new BanChatSenderChatParameters
        {
            ChatId = chatId,
            SenderChatId = senderChatId
        }, cancellationToken);

    public static async Task<bool> UnbanChatSenderChatAsync(
        this IBotApiClient client,
        UnbanChatSenderChatParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unbanChatSenderChat", parameters), cancellationToken);

    public static async Task<bool> UnbanChatSenderChatAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long senderChatId,
        CancellationToken cancellationToken = default)
        => await client.UnbanChatSenderChatAsync(new UnbanChatSenderChatParameters
        {
            ChatId = chatId,
            SenderChatId = senderChatId
        }, cancellationToken);

    public static async Task<bool> SetChatPermissionsAsync(
        this IBotApiClient client,
        SetChatPermissionsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatPermissions", parameters), cancellationToken);

    public static async Task<bool> SetChatPermissionsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        ChatPermissions permissions,
        bool? useIndependentChatPermissions = null,
        CancellationToken cancellationToken = default)
        => await client.SetChatPermissionsAsync(new SetChatPermissionsParameters
        {
            ChatId = chatId,
            Permissions = permissions,
            UseIndependentChatPermissions = useIndependentChatPermissions
        }, cancellationToken);

    public static async Task<string> ExportChatInviteLinkAsync(
        this IBotApiClient client,
        ExportChatInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("exportChatInviteLink", parameters), cancellationToken);

    public static async Task<string> ExportChatInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.ExportChatInviteLinkAsync(new ExportChatInviteLinkParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<ChatInviteLink> CreateChatInviteLinkAsync(
        this IBotApiClient client,
        CreateChatInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> CreateChatInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string? name = null,
        int? expireDate = null,
        int? memberLimit = null,
        bool? createsJoinRequest = null,
        CancellationToken cancellationToken = default)
        => await client.CreateChatInviteLinkAsync(new CreateChatInviteLinkParameters
        {
            ChatId = chatId,
            Name = name,
            ExpireDate = expireDate,
            MemberLimit = memberLimit,
            CreatesJoinRequest = createsJoinRequest
        }, cancellationToken);

    public static async Task<ChatInviteLink> EditChatInviteLinkAsync(
        this IBotApiClient client,
        EditChatInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> EditChatInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string inviteLink,
        string? name = null,
        int? expireDate = null,
        int? memberLimit = null,
        bool? createsJoinRequest = null,
        CancellationToken cancellationToken = default)
        => await client.EditChatInviteLinkAsync(new EditChatInviteLinkParameters
        {
            ChatId = chatId,
            InviteLink = inviteLink,
            Name = name,
            ExpireDate = expireDate,
            MemberLimit = memberLimit,
            CreatesJoinRequest = createsJoinRequest
        }, cancellationToken);

    public static async Task<ChatInviteLink> CreateChatSubscriptionInviteLinkAsync(
        this IBotApiClient client,
        CreateChatSubscriptionInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("createChatSubscriptionInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> CreateChatSubscriptionInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        int subscriptionPeriod,
        int subscriptionPrice,
        string? name = null,
        CancellationToken cancellationToken = default)
        => await client.CreateChatSubscriptionInviteLinkAsync(new CreateChatSubscriptionInviteLinkParameters
        {
            ChatId = chatId,
            SubscriptionPeriod = subscriptionPeriod,
            SubscriptionPrice = subscriptionPrice,
            Name = name
        }, cancellationToken);

    public static async Task<ChatInviteLink> EditChatSubscriptionInviteLinkAsync(
        this IBotApiClient client,
        EditChatSubscriptionInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("editChatSubscriptionInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> EditChatSubscriptionInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string inviteLink,
        string? name = null,
        CancellationToken cancellationToken = default)
        => await client.EditChatSubscriptionInviteLinkAsync(new EditChatSubscriptionInviteLinkParameters
        {
            ChatId = chatId,
            InviteLink = inviteLink,
            Name = name
        }, cancellationToken);

    public static async Task<ChatInviteLink> RevokeChatInviteLinkAsync(
        this IBotApiClient client,
        RevokeChatInviteLinkParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatInviteLink>(new ApiRequest("revokeChatInviteLink", parameters), cancellationToken);

    public static async Task<ChatInviteLink> RevokeChatInviteLinkAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string inviteLink,
        CancellationToken cancellationToken = default)
        => await client.RevokeChatInviteLinkAsync(new RevokeChatInviteLinkParameters
        {
            ChatId = chatId,
            InviteLink = inviteLink
        }, cancellationToken);

    public static async Task<bool> ApproveChatJoinRequestAsync(
        this IBotApiClient client,
        ApproveChatJoinRequestParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("approveChatJoinRequest", parameters), cancellationToken);

    public static async Task<bool> ApproveChatJoinRequestAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.ApproveChatJoinRequestAsync(new ApproveChatJoinRequestParameters
        {
            ChatId = chatId,
            UserId = userId
        }, cancellationToken);

    public static async Task<bool> DeclineChatJoinRequestAsync(
        this IBotApiClient client,
        DeclineChatJoinRequestParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("declineChatJoinRequest", parameters), cancellationToken);

    public static async Task<bool> DeclineChatJoinRequestAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.DeclineChatJoinRequestAsync(new DeclineChatJoinRequestParameters
        {
            ChatId = chatId,
            UserId = userId
        }, cancellationToken);

    public static async Task<bool> AnswerChatJoinRequestQueryAsync(
        this IBotApiClient client,
        AnswerChatJoinRequestQueryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerChatJoinRequestQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerChatJoinRequestQueryAsync(
        this IBotApiClient client,
        string chatJoinRequestQueryId,
        AnswerChatJoinRequestQueryResult result,
        CancellationToken cancellationToken = default)
        => await client.AnswerChatJoinRequestQueryAsync(new AnswerChatJoinRequestQueryParameters
        {
            ChatJoinRequestQueryId = chatJoinRequestQueryId,
            Result = result
        }, cancellationToken);

    public static async Task<bool> SendChatJoinRequestWebAppAsync(
        this IBotApiClient client,
        SendChatJoinRequestWebAppParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendChatJoinRequestWebApp", parameters), cancellationToken);

    public static async Task<bool> SendChatJoinRequestWebAppAsync(
        this IBotApiClient client,
        string chatJoinRequestQueryId,
        string webAppUrl,
        CancellationToken cancellationToken = default)
        => await client.SendChatJoinRequestWebAppAsync(new SendChatJoinRequestWebAppParameters
        {
            ChatJoinRequestQueryId = chatJoinRequestQueryId,
            WebAppUrl = webAppUrl
        }, cancellationToken);

    public static async Task<bool> SetChatPhotoAsync(
        this IBotApiClient client,
        SetChatPhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatPhoto", parameters), cancellationToken);

    public static async Task<bool> SetChatPhotoAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        InputPhotoFile photo,
        CancellationToken cancellationToken = default)
        => await client.SetChatPhotoAsync(new SetChatPhotoParameters
        {
            ChatId = chatId,
            Photo = photo
        }, cancellationToken);

    public static async Task<bool> DeleteChatPhotoAsync(
        this IBotApiClient client,
        DeleteChatPhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteChatPhoto", parameters), cancellationToken);

    public static async Task<bool> DeleteChatPhotoAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.DeleteChatPhotoAsync(new DeleteChatPhotoParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> SetChatTitleAsync(
        this IBotApiClient client,
        SetChatTitleParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatTitle", parameters), cancellationToken);

    public static async Task<bool> SetChatTitleAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string title,
        CancellationToken cancellationToken = default)
        => await client.SetChatTitleAsync(new SetChatTitleParameters
        {
            ChatId = chatId,
            Title = title
        }, cancellationToken);

    public static async Task<bool> SetChatDescriptionAsync(
        this IBotApiClient client,
        SetChatDescriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatDescription", parameters), cancellationToken);

    public static async Task<bool> SetChatDescriptionAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string? description = null,
        CancellationToken cancellationToken = default)
        => await client.SetChatDescriptionAsync(new SetChatDescriptionParameters
        {
            ChatId = chatId,
            Description = description
        }, cancellationToken);

    public static async Task<bool> PinChatMessageAsync(
        this IBotApiClient client,
        PinChatMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("pinChatMessage", parameters), cancellationToken);

    public static async Task<bool> PinChatMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageId,
        string? businessConnectionId = null,
        bool? disableNotification = null,
        CancellationToken cancellationToken = default)
        => await client.PinChatMessageAsync(new PinChatMessageParameters
        {
            ChatId = chatId,
            MessageId = messageId,
            BusinessConnectionId = businessConnectionId,
            DisableNotification = disableNotification
        }, cancellationToken);

    public static async Task<bool> UnpinChatMessageAsync(
        this IBotApiClient client,
        UnpinChatMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinChatMessage", parameters), cancellationToken);

    public static async Task<bool> UnpinChatMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string? businessConnectionId = null,
        long? messageId = null,
        CancellationToken cancellationToken = default)
        => await client.UnpinChatMessageAsync(new UnpinChatMessageParameters
        {
            ChatId = chatId,
            BusinessConnectionId = businessConnectionId,
            MessageId = messageId
        }, cancellationToken);

    public static async Task<bool> UnpinAllChatMessagesAsync(
        this IBotApiClient client,
        UnpinAllChatMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllChatMessages", parameters), cancellationToken);

    public static async Task<bool> UnpinAllChatMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.UnpinAllChatMessagesAsync(new UnpinAllChatMessagesParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> LeaveChatAsync(
        this IBotApiClient client,
        LeaveChatParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("leaveChat", parameters), cancellationToken);

    public static async Task<bool> LeaveChatAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.LeaveChatAsync(new LeaveChatParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<ChatFullInfo> GetChatAsync(
        this IBotApiClient client,
        GetChatParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatFullInfo>(new ApiRequest("getChat", parameters), cancellationToken);

    public static async Task<ChatFullInfo> GetChatAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.GetChatAsync(new GetChatParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<IReadOnlyList<ChatMember>> GetChatAdministratorsAsync(
        this IBotApiClient client,
        GetChatAdministratorsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<ChatMember>>(new ApiRequest("getChatAdministrators", parameters), cancellationToken);

    public static async Task<IReadOnlyList<ChatMember>> GetChatAdministratorsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        bool? returnBots = null,
        CancellationToken cancellationToken = default)
        => await client.GetChatAdministratorsAsync(new GetChatAdministratorsParameters
        {
            ChatId = chatId,
            ReturnBots = returnBots
        }, cancellationToken);

    public static async Task<int> GetChatMemberCountAsync(
        this IBotApiClient client,
        GetChatMemberCountParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<int>(new ApiRequest("getChatMemberCount", parameters), cancellationToken);

    public static async Task<int> GetChatMemberCountAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.GetChatMemberCountAsync(new GetChatMemberCountParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<ChatMember> GetChatMemberAsync(
        this IBotApiClient client,
        GetChatMemberParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatMember>(new ApiRequest("getChatMember", parameters), cancellationToken);

    public static async Task<ChatMember> GetChatMemberAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.GetChatMemberAsync(new GetChatMemberParameters
        {
            ChatId = chatId,
            UserId = userId
        }, cancellationToken);

    public static async Task<IReadOnlyList<Message>> GetUserPersonalChatMessagesAsync(
        this IBotApiClient client,
        GetUserPersonalChatMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Message>>(new ApiRequest("getUserPersonalChatMessages", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Message>> GetUserPersonalChatMessagesAsync(
        this IBotApiClient client,
        long userId,
        int limit,
        CancellationToken cancellationToken = default)
        => await client.GetUserPersonalChatMessagesAsync(new GetUserPersonalChatMessagesParameters
        {
            UserId = userId,
            Limit = limit
        }, cancellationToken);

    public static async Task<bool> SetChatStickerSetAsync(
        this IBotApiClient client,
        SetChatStickerSetParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatStickerSet", parameters), cancellationToken);

    public static async Task<bool> SetChatStickerSetAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string stickerSetName,
        CancellationToken cancellationToken = default)
        => await client.SetChatStickerSetAsync(new SetChatStickerSetParameters
        {
            ChatId = chatId,
            StickerSetName = stickerSetName
        }, cancellationToken);

    public static async Task<bool> DeleteChatStickerSetAsync(
        this IBotApiClient client,
        DeleteChatStickerSetParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteChatStickerSet", parameters), cancellationToken);

    public static async Task<bool> DeleteChatStickerSetAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.DeleteChatStickerSetAsync(new DeleteChatStickerSetParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<IReadOnlyList<Sticker>> GetForumTopicIconStickersAsync(
        this IBotApiClient client,
        GetForumTopicIconStickersParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Sticker>>(new ApiRequest("getForumTopicIconStickers", parameters), cancellationToken);

    public static async Task<IReadOnlyList<Sticker>> GetForumTopicIconStickersAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.GetForumTopicIconStickersAsync(new GetForumTopicIconStickersParameters
        {
            // No parameters to set for this method
        }, cancellationToken);

    public static async Task<ForumTopic> CreateForumTopicAsync(
        this IBotApiClient client,
        CreateForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ForumTopic>(new ApiRequest("createForumTopic", parameters), cancellationToken);

    public static async Task<ForumTopic> CreateForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string name,
        int? iconColor = null,
        string? iconCustomEmojiId = null,
        CancellationToken cancellationToken = default)
        => await client.CreateForumTopicAsync(new CreateForumTopicParameters
        {
            ChatId = chatId,
            Name = name,
            IconColor = iconColor,
            IconCustomEmojiId = iconCustomEmojiId
        }, cancellationToken);

    public static async Task<bool> EditForumTopicAsync(
        this IBotApiClient client,
        EditForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editForumTopic", parameters), cancellationToken);

    public static async Task<bool> EditForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageThreadId,
        string? name = null,
        string? iconCustomEmojiId = null,
        CancellationToken cancellationToken = default)
        => await client.EditForumTopicAsync(new EditForumTopicParameters
        {
            ChatId = chatId,
            Name = name,
            MessageThreadId = messageThreadId,
            IconCustomEmojiId = iconCustomEmojiId
        }, cancellationToken);

    public static async Task<bool> CloseForumTopicAsync(
        this IBotApiClient client,
        CloseForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("closeForumTopic", parameters), cancellationToken);

    public static async Task<bool> CloseForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageThreadId,
        CancellationToken cancellationToken = default)
        => await client.CloseForumTopicAsync(new CloseForumTopicParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId
        }, cancellationToken);

    public static async Task<bool> ReopenForumTopicAsync(
        this IBotApiClient client,
        ReopenForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("reopenForumTopic", parameters), cancellationToken);

    public static async Task<bool> ReopenForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageThreadId,
        CancellationToken cancellationToken = default)
        => await client.ReopenForumTopicAsync(new ReopenForumTopicParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId
        }, cancellationToken);

    public static async Task<bool> DeleteForumTopicAsync(
        this IBotApiClient client,
        DeleteForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteForumTopic", parameters), cancellationToken);

    public static async Task<bool> DeleteForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageThreadId,
        CancellationToken cancellationToken = default)
        => await client.DeleteForumTopicAsync(new DeleteForumTopicParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId
        }, cancellationToken);

    public static async Task<bool> UnpinAllForumTopicMessagesAsync(
        this IBotApiClient client,
        UnpinAllForumTopicMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllForumTopicMessages", parameters), cancellationToken);

    public static async Task<bool> UnpinAllForumTopicMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long messageThreadId,
        CancellationToken cancellationToken = default)
        => await client.UnpinAllForumTopicMessagesAsync(new UnpinAllForumTopicMessagesParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId
        }, cancellationToken);

    public static async Task<bool> EditGeneralForumTopicAsync(
        this IBotApiClient client,
        EditGeneralForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> EditGeneralForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string name,
        CancellationToken cancellationToken = default)
        => await client.EditGeneralForumTopicAsync(new EditGeneralForumTopicParameters
        {
            ChatId = chatId,
            Name = name
        }, cancellationToken);

    public static async Task<bool> CloseGeneralForumTopicAsync(
        this IBotApiClient client,
        CloseGeneralForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("closeGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> CloseGeneralForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.CloseGeneralForumTopicAsync(new CloseGeneralForumTopicParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> ReopenGeneralForumTopicAsync(
        this IBotApiClient client,
        ReopenGeneralForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("reopenGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> ReopenGeneralForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.ReopenGeneralForumTopicAsync(new ReopenGeneralForumTopicParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> HideGeneralForumTopicAsync(
        this IBotApiClient client,
        HideGeneralForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("hideGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> HideGeneralForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.HideGeneralForumTopicAsync(new HideGeneralForumTopicParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> UnhideGeneralForumTopicAsync(
        this IBotApiClient client,
        UnhideGeneralForumTopicParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unhideGeneralForumTopic", parameters), cancellationToken);

    public static async Task<bool> UnhideGeneralForumTopicAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.UnhideGeneralForumTopicAsync(new UnhideGeneralForumTopicParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> UnpinAllGeneralForumTopicMessagesAsync(
        this IBotApiClient client,
        UnpinAllGeneralForumTopicMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("unpinAllGeneralForumTopicMessages", parameters), cancellationToken);

    public static async Task<bool> UnpinAllGeneralForumTopicMessagesAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.UnpinAllGeneralForumTopicMessagesAsync(new UnpinAllGeneralForumTopicMessagesParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> AnswerCallbackQueryAsync(
        this IBotApiClient client,
        AnswerCallbackQueryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerCallbackQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerCallbackQueryAsync(
        this IBotApiClient client,
        string callbackQueryId,
        string? text = null,
        bool? showAlert = null,
        string? url = null,
        int? cacheTime = null,
        CancellationToken cancellationToken = default)
        => await client.AnswerCallbackQueryAsync(new AnswerCallbackQueryParameters
        {
            CallbackQueryId = callbackQueryId,
            Text = text,
            ShowAlert = showAlert,
            Url = url,
            CacheTime = cacheTime
        }, cancellationToken);

    public static async Task<SentGuestMessage> AnswerGuestQueryAsync(
        this IBotApiClient client,
        AnswerGuestQueryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<SentGuestMessage>(new ApiRequest("answerGuestQuery", parameters), cancellationToken);

    public static async Task<SentGuestMessage> AnswerGuestQueryAsync(
        this IBotApiClient client,
        string guestQueryId,
        InlineQueryResult result,
        CancellationToken cancellationToken = default)
        => await client.AnswerGuestQueryAsync(new AnswerGuestQueryParameters
        {
            GuestQueryId = guestQueryId,
            Result = result
        }, cancellationToken);

    public static async Task<UserChatBoosts> GetUserChatBoostsAsync(
        this IBotApiClient client,
        GetUserChatBoostsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<UserChatBoosts>(new ApiRequest("getUserChatBoosts", parameters), cancellationToken);

    public static async Task<UserChatBoosts> GetUserChatBoostsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.GetUserChatBoostsAsync(new GetUserChatBoostsParameters
        {
            ChatId = chatId,
            UserId = userId
        }, cancellationToken);

    public static async Task<BusinessConnection> GetBusinessConnectionAsync(
        this IBotApiClient client,
        GetBusinessConnectionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BusinessConnection>(new ApiRequest("getBusinessConnection", parameters), cancellationToken);

    public static async Task<BusinessConnection> GetBusinessConnectionAsync(
        this IBotApiClient client,
        string businessConnectionId,
        CancellationToken cancellationToken = default)
        => await client.GetBusinessConnectionAsync(new GetBusinessConnectionParameters
        {
            BusinessConnectionId = businessConnectionId
        }, cancellationToken);

    public static async Task<string> GetManagedBotTokenAsync(
        this IBotApiClient client,
        GetManagedBotTokenParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("getManagedBotToken", parameters), cancellationToken);

    public static async Task<string> GetManagedBotTokenAsync(
        this IBotApiClient client,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.GetManagedBotTokenAsync(new GetManagedBotTokenParameters
        {
            UserId = userId
        }, cancellationToken);

    public static async Task<string> ReplaceManagedBotTokenAsync(
        this IBotApiClient client,
        ReplaceManagedBotTokenParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("replaceManagedBotToken", parameters), cancellationToken);

    public static async Task<string> ReplaceManagedBotTokenAsync(
        this IBotApiClient client,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.ReplaceManagedBotTokenAsync(new ReplaceManagedBotTokenParameters
        {
            UserId = userId
        }, cancellationToken);

    public static async Task<BotAccessSettings> GetManagedBotAccessSettingsAsync(
        this IBotApiClient client,
        GetManagedBotAccessSettingsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotAccessSettings>(new ApiRequest("getManagedBotAccessSettings", parameters), cancellationToken);

    public static async Task<BotAccessSettings> GetManagedBotAccessSettingsAsync(
        this IBotApiClient client,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.GetManagedBotAccessSettingsAsync(new GetManagedBotAccessSettingsParameters
        {
            UserId = userId
        }, cancellationToken);

    public static async Task<bool> SetManagedBotAccessSettingsAsync(
        this IBotApiClient client,
        SetManagedBotAccessSettingsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setManagedBotAccessSettings", parameters), cancellationToken);

    public static async Task<bool> SetManagedBotAccessSettingsAsync(
        this IBotApiClient client,
        long userId,
        bool isAccessRestricted,
        IReadOnlyList<long>? addedUserIds,
        CancellationToken cancellationToken = default)
        => await client.SetManagedBotAccessSettingsAsync(new SetManagedBotAccessSettingsParameters
        {
            UserId = userId,
            IsAccessRestricted = isAccessRestricted,
            AddedUserIds = addedUserIds
        }, cancellationToken);

    public static async Task<bool> SetMyCommandsAsync(
        this IBotApiClient client,
        SetMyCommandsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyCommands", parameters), cancellationToken);

    public static async Task<bool> SetMyCommandsAsync(
        this IBotApiClient client,
        IReadOnlyList<BotCommand> commands,
        BotCommandScope? scope = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.SetMyCommandsAsync(new SetMyCommandsParameters
        {
            Commands = commands,
            Scope = scope,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<bool> DeleteMyCommandsAsync(
        this IBotApiClient client,
        DeleteMyCommandsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteMyCommands", parameters), cancellationToken);

    public static async Task<bool> DeleteMyCommandsAsync(
        this IBotApiClient client,
        BotCommandScope? scope = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.DeleteMyCommandsAsync(new DeleteMyCommandsParameters
        {
            Scope = scope,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<IReadOnlyList<BotCommand>> GetMyCommandsAsync(
        this IBotApiClient client,
        GetMyCommandsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<BotCommand>>(new ApiRequest("getMyCommands", parameters), cancellationToken);

    public static async Task<IReadOnlyList<BotCommand>> GetMyCommandsAsync(
        this IBotApiClient client,
        BotCommandScope? scope = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.GetMyCommandsAsync(new GetMyCommandsParameters
        {
            Scope = scope,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<bool> SetMyNameAsync(
        this IBotApiClient client,
        SetMyNameParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyName", parameters), cancellationToken);

    public static async Task<bool> SetMyNameAsync(
        this IBotApiClient client,
        string? name = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.SetMyNameAsync(new SetMyNameParameters
        {
            Name = name,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<BotName> GetMyNameAsync(
        this IBotApiClient client,
        GetMyNameParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotName>(new ApiRequest("getMyName", parameters), cancellationToken);

    public static async Task<BotName> GetMyNameAsync(
        this IBotApiClient client,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.GetMyNameAsync(new GetMyNameParameters
        {
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<bool> SetMyDescriptionAsync(
        this IBotApiClient client,
        SetMyDescriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyDescription", parameters), cancellationToken);

    public static async Task<bool> SetMyDescriptionAsync(
        this IBotApiClient client,
        string? description = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.SetMyDescriptionAsync(new SetMyDescriptionParameters
        {
            Description = description,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<BotDescription> GetMyDescriptionAsync(
        this IBotApiClient client,
        GetMyDescriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotDescription>(new ApiRequest("getMyDescription", parameters), cancellationToken);

    public static async Task<BotDescription> GetMyDescriptionAsync(
        this IBotApiClient client,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.GetMyDescriptionAsync(new GetMyDescriptionParameters
        {
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<bool> SetMyShortDescriptionAsync(
        this IBotApiClient client,
        SetMyShortDescriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyShortDescription", parameters), cancellationToken);

    public static async Task<bool> SetMyShortDescriptionAsync(
        this IBotApiClient client,
        string? shortDescription = null,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.SetMyShortDescriptionAsync(new SetMyShortDescriptionParameters
        {
            ShortDescription = shortDescription,
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<BotShortDescription> GetMyShortDescriptionAsync(
        this IBotApiClient client,
        GetMyShortDescriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<BotShortDescription>(new ApiRequest("getMyShortDescription", parameters), cancellationToken);

    public static async Task<BotShortDescription> GetMyShortDescriptionAsync(
        this IBotApiClient client,
        string? languageCode = null,
        CancellationToken cancellationToken = default)
        => await client.GetMyShortDescriptionAsync(new GetMyShortDescriptionParameters
        {
            LanguageCode = languageCode
        }, cancellationToken);

    public static async Task<bool> SetMyProfilePhotoAsync(
        this IBotApiClient client,
        SetMyProfilePhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> SetMyProfilePhotoAsync(
        this IBotApiClient client,
        InputProfilePhoto photo,
        CancellationToken cancellationToken = default)
        => await client.SetMyProfilePhotoAsync(new SetMyProfilePhotoParameters
        {
            Photo = photo
        }, cancellationToken);

    public static async Task<bool> RemoveMyProfilePhotoAsync(
        this IBotApiClient client,
        RemoveMyProfilePhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeMyProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> RemoveMyProfilePhotoAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.RemoveMyProfilePhotoAsync(new RemoveMyProfilePhotoParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    public static async Task<bool> SetChatMenuButtonAsync(
        this IBotApiClient client,
        SetChatMenuButtonParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setChatMenuButton", parameters), cancellationToken);

    public static async Task<bool> SetChatMenuButtonAsync(
        this IBotApiClient client,
        long? chatId = null,
        MenuButton? menuButton = null,
        CancellationToken cancellationToken = default)
        => await client.SetChatMenuButtonAsync(new SetChatMenuButtonParameters
        {
            ChatId = chatId,
            MenuButton = menuButton
        }, cancellationToken);

    public static async Task<MenuButton> GetChatMenuButtonAsync(
        this IBotApiClient client,
        GetChatMenuButtonParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<MenuButton>(new ApiRequest("getChatMenuButton", parameters), cancellationToken);

    public static async Task<MenuButton> GetChatMenuButtonAsync(
        this IBotApiClient client,
        long? chatId = null,
        CancellationToken cancellationToken = default)
        => await client.GetChatMenuButtonAsync(new GetChatMenuButtonParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> SetMyDefaultAdministratorRightsAsync(
        this IBotApiClient client,
        SetMyDefaultAdministratorRightsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setMyDefaultAdministratorRights", parameters), cancellationToken);

    public static async Task<bool> SetMyDefaultAdministratorRightsAsync(
        this IBotApiClient client,
        ChatAdministratorRights? rights = null,
        bool? forChannels = null,
        CancellationToken cancellationToken = default)
        => await client.SetMyDefaultAdministratorRightsAsync(new SetMyDefaultAdministratorRightsParameters
        {
            Rights = rights,
            ForChannels = forChannels
        }, cancellationToken);

    public static async Task<ChatAdministratorRights> GetMyDefaultAdministratorRightsAsync(
        this IBotApiClient client,
        GetMyDefaultAdministratorRightsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<ChatAdministratorRights>(new ApiRequest("getMyDefaultAdministratorRights", parameters), cancellationToken);

    public static async Task<ChatAdministratorRights> GetMyDefaultAdministratorRightsAsync(
        this IBotApiClient client,
        bool? forChannels = null,
        CancellationToken cancellationToken = default)
        => await client.GetMyDefaultAdministratorRightsAsync(new GetMyDefaultAdministratorRightsParameters
        {
            ForChannels = forChannels
        }, cancellationToken);

    public static async Task<GiftsStruct> GetAvailableGiftsAsync(
        this IBotApiClient client,
        GetAvailableGiftsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<GiftsStruct>(new ApiRequest("getAvailableGifts", parameters), cancellationToken);

    public static async Task<GiftsStruct> GetAvailableGiftsAsync(
        this IBotApiClient client,
        CancellationToken cancellationToken = default)
        => await client.GetAvailableGiftsAsync(new GetAvailableGiftsParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    public static async Task<bool> SendGiftAsync(
        this IBotApiClient client,
        SendGiftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendGift", parameters), cancellationToken);

    public static async Task<bool> SendGiftAsync(
        this IBotApiClient client,
        long? userId,
        ChatIdSource? chatId,
        string giftId,
        bool? payForUpgrade,
        string? text,
        string? textParseMode,
        IReadOnlyList<MessageEntity>? textEntities,
        CancellationToken cancellationToken = default)
        => await client.SendGiftAsync(new SendGiftParameters
        {
            UserId = userId,
            ChatId = chatId,
            GiftId = giftId,
            PayForUpgrade = payForUpgrade,
            Text = text,
            TextParseMode = textParseMode,
            TextEntities = textEntities
        }, cancellationToken);

    public static async Task<bool> GiftPremiumSubscriptionAsync(
        this IBotApiClient client,
        GiftPremiumSubscriptionParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("giftPremiumSubscription", parameters), cancellationToken);

    public static async Task<bool> GiftPremiumSubscriptionAsync(
        this IBotApiClient client,
        long userId,
        int monthCount,
        int starCount,
        string? text = null,
        string? textParseMode = null,
        IReadOnlyList<MessageEntity>? textEntities = null,
        CancellationToken cancellationToken = default)
        => await client.GiftPremiumSubscriptionAsync(new GiftPremiumSubscriptionParameters
        {
            UserId = userId,
            MonthCount = monthCount,
            StarCount = starCount,
            Text = text,
            TextParseMode = textParseMode,
            TextEntities = textEntities
        }, cancellationToken);

    public static async Task<bool> VerifyUserAsync(
        this IBotApiClient client,
        VerifyUserParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("verifyUser", parameters), cancellationToken);

    public static async Task<bool> VerifyUserAsync(
        this IBotApiClient client,
        long userId,
        string? customDescription = null,
        CancellationToken cancellationToken = default)
        => await client.VerifyUserAsync(new VerifyUserParameters
        {
            UserId = userId,
            CustomDescription = customDescription
        }, cancellationToken);

    public static async Task<bool> VerifyChatAsync(
        this IBotApiClient client,
        VerifyChatParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("verifyChat", parameters), cancellationToken);

    public static async Task<bool> VerifyChatAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        string? customDescription = null,
        CancellationToken cancellationToken = default)
        => await client.VerifyChatAsync(new VerifyChatParameters
        {
            ChatId = chatId,
            CustomDescription = customDescription
        }, cancellationToken);

    public static async Task<bool> RemoveUserVerificationAsync(
        this IBotApiClient client,
        RemoveUserVerificationParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeUserVerification", parameters), cancellationToken);

    public static async Task<bool> RemoveUserVerificationAsync(
        this IBotApiClient client,
        long userId,
        CancellationToken cancellationToken = default)
        => await client.RemoveUserVerificationAsync(new RemoveUserVerificationParameters
        {
            UserId = userId
        }, cancellationToken);

    public static async Task<bool> RemoveChatVerificationAsync(
        this IBotApiClient client,
        RemoveChatVerificationParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeChatVerification", parameters), cancellationToken);

    public static async Task<bool> RemoveChatVerificationAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        CancellationToken cancellationToken = default)
        => await client.RemoveChatVerificationAsync(new RemoveChatVerificationParameters
        {
            ChatId = chatId
        }, cancellationToken);

    public static async Task<bool> ReadBusinessMessageAsync(
        this IBotApiClient client,
        ReadBusinessMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("readBusinessMessage", parameters), cancellationToken);

    public static async Task<bool> ReadBusinessMessageAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long chatId,
        long messageId,
        CancellationToken cancellationToken = default)
        => await client.ReadBusinessMessageAsync(new ReadBusinessMessageParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageId = messageId
        }, cancellationToken);

    public static async Task<bool> DeleteBusinessMessagesAsync(
        this IBotApiClient client,
        DeleteBusinessMessagesParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteBusinessMessages", parameters), cancellationToken);

    public static async Task<bool> DeleteBusinessMessagesAsync(
        this IBotApiClient client,
        string businessConnectionId,
        IReadOnlyList<long> messageIds,
        CancellationToken cancellationToken = default)
        => await client.DeleteBusinessMessagesAsync(new DeleteBusinessMessagesParameters
        {
            BusinessConnectionId = businessConnectionId,
            MessageIds = messageIds
        }, cancellationToken);

    public static async Task<bool> SetBusinessAccountNameAsync(
        this IBotApiClient client,
        SetBusinessAccountNameParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountName", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountNameAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string firstName,
        string? lastName = null,
        CancellationToken cancellationToken = default)
        => await client.SetBusinessAccountNameAsync(new SetBusinessAccountNameParameters
        {
            BusinessConnectionId = businessConnectionId,
            FirstName = firstName,
            LastName = lastName
        }, cancellationToken);

    public static async Task<bool> SetBusinessAccountUsernameAsync(
        this IBotApiClient client,
        SetBusinessAccountUsernameParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountUsername", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountUsernameAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string? username = null,
        CancellationToken cancellationToken = default)
        => await client.SetBusinessAccountUsernameAsync(new SetBusinessAccountUsernameParameters
        {
            BusinessConnectionId = businessConnectionId,
            Username = username,
        }, cancellationToken);

    public static async Task<bool> SetBusinessAccountBioAsync(
        this IBotApiClient client,
        SetBusinessAccountBioParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountBio", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountBioAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string? bio = null,
        CancellationToken cancellationToken = default)
        => await client.SetBusinessAccountBioAsync(new SetBusinessAccountBioParameters
        {
            BusinessConnectionId = businessConnectionId,
            Bio = bio
        }, cancellationToken);

    public static async Task<bool> SetBusinessAccountProfilePhotoAsync(
        this IBotApiClient client,
        SetBusinessAccountProfilePhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountProfilePhotoAsync(
        this IBotApiClient client,
        string businessConnectionId,
        InputProfilePhoto photo,
        bool? isPublic = null,
        CancellationToken cancellationToken = default)
        => await client.SetBusinessAccountProfilePhotoAsync(new SetBusinessAccountProfilePhotoParameters
        {
            BusinessConnectionId = businessConnectionId,
            Photo = photo,
            IsPublic = isPublic
        }, cancellationToken);

    public static async Task<bool> RemoveBusinessAccountProfilePhotoAsync(
        this IBotApiClient client,
        RemoveBusinessAccountProfilePhotoParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("removeBusinessAccountProfilePhoto", parameters), cancellationToken);

    public static async Task<bool> RemoveBusinessAccountProfilePhotoAsync(
        this IBotApiClient client,
        string businessConnectionId,
        bool? isPublic = null,
        CancellationToken cancellationToken = default)
        => await client.RemoveBusinessAccountProfilePhotoAsync(new RemoveBusinessAccountProfilePhotoParameters
        {
            BusinessConnectionId = businessConnectionId,
            IsPublic = isPublic
        }, cancellationToken);

    public static async Task<bool> SetBusinessAccountGiftSettingsAsync(
        this IBotApiClient client,
        SetBusinessAccountGiftSettingsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setBusinessAccountGiftSettings", parameters), cancellationToken);

    public static async Task<bool> SetBusinessAccountGiftSettingsAsync(
        this IBotApiClient client,
        string businessConnectionId,
        bool showGiftButton,
        AcceptedGiftTypes acceptedGiftTypes,
        CancellationToken cancellationToken = default)
        => await client.SetBusinessAccountGiftSettingsAsync(new SetBusinessAccountGiftSettingsParameters
        {
            BusinessConnectionId = businessConnectionId,
            ShowGiftButton = showGiftButton,
            AcceptedGiftTypes = acceptedGiftTypes
        }, cancellationToken);

    public static async Task<StarAmount> GetBusinessAccountStarBalanceAsync(
        this IBotApiClient client,
        GetBusinessAccountStarBalanceParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarAmount>(new ApiRequest("getBusinessAccountStarBalance", parameters), cancellationToken);

    public static async Task<StarAmount> GetBusinessAccountStarBalanceAsync(
        this IBotApiClient client,
        string businessConnectionId,
        CancellationToken cancellationToken = default)
        => await client.GetBusinessAccountStarBalanceAsync(new GetBusinessAccountStarBalanceParameters
        {
            BusinessConnectionId = businessConnectionId
        }, cancellationToken);

    public static async Task<bool> TransferBusinessAccountStarsAsync(
        this IBotApiClient client,
        TransferBusinessAccountStarsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("transferBusinessAccountStars", parameters), cancellationToken);

    public static async Task<bool> TransferBusinessAccountStarsAsync(
        this IBotApiClient client,
        string businessConnectionId,
        int starCount,
        CancellationToken cancellationToken = default)
        => await client.TransferBusinessAccountStarsAsync(new TransferBusinessAccountStarsParameters
        {
            BusinessConnectionId = businessConnectionId,
            StarCount = starCount
        }, cancellationToken);

    public static async Task<OwnedGifts> GetBusinessAccountGiftsAsync(
        this IBotApiClient client,
        GetBusinessAccountGiftsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getBusinessAccountGifts", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetBusinessAccountGiftsAsync(
        this IBotApiClient client,
        string businessConnectionId,
        bool? excludeUnsaved = null,
        bool? excludeSaved = null,
        bool? excludeUnlimited = null,
        bool? excludeLimitedUpgradable = null,
        bool? excludeLimitedNonUpgradable = null,
        bool? excludeUnique = null,
        bool? excludeFromBlockchain = null,
        bool? sortByPrice = null,
        string? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetBusinessAccountGiftsAsync(new GetBusinessAccountGiftsParameters
        {
            BusinessConnectionId = businessConnectionId,
            ExcludeUnsaved = excludeUnsaved,
            ExcludeSaved = excludeSaved,
            ExcludeUnlimited = excludeUnlimited,
            ExcludeLimitedUpgradable = excludeLimitedUpgradable,
            ExcludeLimitedNonUpgradable = excludeLimitedNonUpgradable,
            ExcludeUnique = excludeUnique,
            ExcludeFromBlockchain = excludeFromBlockchain,
            SortByPrice = sortByPrice,
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    public static async Task<OwnedGifts> GetUserGiftsASync(
        this IBotApiClient client,
        GetUserGiftsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getUserGifts", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetUserGiftsASync(
        this IBotApiClient client,
        long userId,
        bool? excludeUnlimited = null,
        bool? excludeLimitedUpgradable = null,
        bool? excludeLimitedNonUpgradable = null,
        bool? excludeFromBlockchain = null,
        bool? excludeUnique = null,
        bool? sortByPrice = null,
        string? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetUserGiftsASync(new GetUserGiftsParameters
        {
            UserId = userId,
            ExcludeUnlimited = excludeUnlimited,
            ExcludeLimitedUpgradable = excludeLimitedUpgradable,
            ExcludeLimitedNonUpgradable = excludeLimitedNonUpgradable,
            ExcludeFromBlockchain = excludeFromBlockchain,
            ExcludeUnique = excludeUnique,
            SortByPrice = sortByPrice,
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    public static async Task<OwnedGifts> GetChatGiftsAsync(
        this IBotApiClient client,
        GetChatGiftsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<OwnedGifts>(new ApiRequest("getChatGifts", parameters), cancellationToken);

    public static async Task<OwnedGifts> GetChatGiftsAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        bool? excludeUnsaved = null,
        bool? excludeSaved = null,
        bool? excludeUnlimited = null,
        bool? excludeLimitedUpgradable = null,
        bool? excludeLimitedNonUpgradable = null,
        bool? excludeFromBlockchain = null,
        bool? excludeUnique = null,
        bool? sortByPrice = null,
        string? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetChatGiftsAsync(new GetChatGiftsParameters
        {
            ChatId = chatId,
            ExcludeUnsaved = excludeUnsaved,
            ExcludeSaved = excludeSaved,
            ExcludeUnlimited = excludeUnlimited,
            ExcludeLimitedUpgradable = excludeLimitedUpgradable,
            ExcludeLimitedNonUpgradable = excludeLimitedNonUpgradable,
            ExcludeFromBlockchain = excludeFromBlockchain,
            ExcludeUnique = excludeUnique,
            SortByPrice = sortByPrice,
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    public static async Task<bool> ConvertGiftToStarsAsync(
        this IBotApiClient client,
        ConvertGiftToStarsParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("convertGiftToStars", parameters), cancellationToken);

    public static async Task<bool> ConvertGiftToStarsAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string ownedGiftId,
        CancellationToken cancellationToken = default)
        => await client.ConvertGiftToStarsAsync(new ConvertGiftToStarsParameters
        {
            BusinessConnectionId = businessConnectionId,
            OwnedGiftId = ownedGiftId
        }, cancellationToken);

    public static async Task<bool> UpgradeGiftAsync(
        this IBotApiClient client,
        UpgradeGiftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("upgradeGift", parameters), cancellationToken);

    public static async Task<bool> UpgradeGiftAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string ownedGiftId,
        bool? keepOriginalDetails = null,
        int? starCount = null,
        CancellationToken cancellationToken = default)
        => await client.UpgradeGiftAsync(new UpgradeGiftParameters
        {
            BusinessConnectionId = businessConnectionId,
            OwnedGiftId = ownedGiftId,
            KeepOriginalDetails = keepOriginalDetails,
            StarCount = starCount
        }, cancellationToken);

    public static async Task<bool> TransferGiftAsync(
        this IBotApiClient client,
        TransferGiftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("transferGift", parameters), cancellationToken);

    public static async Task<bool> TransferGiftAsync(
        this IBotApiClient client,
        string businessConnectionId,
        string ownedGiftId,
        long newOwnerChatId,
        int? starCount = null,
        CancellationToken cancellationToken = default)
        => await client.TransferGiftAsync(new TransferGiftParameters
        {
            BusinessConnectionId = businessConnectionId,
            OwnedGiftId = ownedGiftId,
            NewOwnerChatId = newOwnerChatId,
            StarCount = starCount
        }, cancellationToken);

    public static async Task<Story> PostStoryAsync(
        this IBotApiClient client,
        PostStoryParameters parameters, CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("postStory", parameters), cancellationToken);

    public static async Task<Story> PostStoryAsync(
        this IBotApiClient client,
        string businessConnectionId,
        InputStoryContent content,
        int activePeriod,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        IReadOnlyList<StoryArea>? areas = null,
        bool? postToChatPage = null,
        bool? protectContent = null,
        CancellationToken cancellationToken = default)
        => await client.PostStoryAsync(new PostStoryParameters
        {
            BusinessConnectionId = businessConnectionId,
            Content = content,
            ActivePeriod = activePeriod,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            Areas = areas,
            PostToChatPage = postToChatPage,
            ProtectContent = protectContent
        }, cancellationToken);

    public static async Task<Story> RepostStoryAsync(
        this IBotApiClient client,
        RepostStoryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("repostStory", parameters), cancellationToken);

    public static async Task<Story> RepostStoryAsync(
        this IBotApiClient client,
        string businessConnectionId,
        long fromChatId,
        int fromStoryId,
        int activePeriod,
        bool? postToChatPage = null,
        bool? protectContent = null,
        CancellationToken cancellationToken = default)
        => await client.RepostStoryAsync(new RepostStoryParameters
        {
            BusinessConnectionId = businessConnectionId,
            FromChatId = fromChatId,
            FromStoryId = fromStoryId,
            ActivePeriod = activePeriod,
            PostToChatPage = postToChatPage,
            ProtectContent = protectContent
        }, cancellationToken);

    public static async Task<Story> EditStoryAsync(
        this IBotApiClient client,
        EditStoryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("editStory", parameters), cancellationToken);

    public static async Task<Story> EditStoryAsync(
        this IBotApiClient client,
        string businessConnectionId,
        int storyId,
        InputStoryContent content,
        string? caption = null,
        string? parseMode = null,
        IReadOnlyList<MessageEntity>? captionEntities = null,
        IReadOnlyList<StoryArea>? areas = null,
        CancellationToken cancellationToken = default)
        => await client.EditStoryAsync(new EditStoryParameters
        {
            BusinessConnectionId = businessConnectionId,
            StoryId = storyId,
            Content = content,
            Caption = caption,
            ParseMode = parseMode,
            CaptionEntities = captionEntities,
            Areas = areas
        }, cancellationToken);

    public static async Task<Story> DeleteStoryAsync(
        this IBotApiClient client,
        DeleteStoryParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Story>(new ApiRequest("deleteStory", parameters), cancellationToken);

    public static async Task<Story> DeleteStoryAsync(
        this IBotApiClient client,
        string businessConnectionId,
        int storyId,
        CancellationToken cancellationToken = default)
        => await client.DeleteStoryAsync(new DeleteStoryParameters
        {
            BusinessConnectionId = businessConnectionId,
            StoryId = storyId
        }, cancellationToken);
}
