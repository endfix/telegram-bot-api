using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>Sends a rich-formatted message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target chat, rich content and delivery options.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
    public static async Task<Message> SendRichMessageAsync(
        this IBotApiClient client,
        SendRichMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendRichMessage", parameters), cancellationToken);

    /// <summary>Sends a rich-formatted message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Target chat identifier.</param>
    /// <param name="richMessage">Rich message content to send.</param>
    /// <param name="businessConnectionId">Optional business connection identifier.</param>
    /// <param name="messageThreadId">Optional forum topic identifier.</param>
    /// <param name="directMessagesTopicId">Identifier of the direct messages topic, when required.</param>
    /// <param name="ephemeralMessageParameters">Optional parameters for an ephemeral message.</param>
    /// <param name="disableNotification">Whether to send the message silently.</param>
    /// <param name="protectContent">Whether to protect the message from forwarding and saving.</param>
    /// <param name="allowPaidBroadcast">Whether to allow paid high-rate broadcasting.</param>
    /// <param name="messageEffectId">Optional message effect identifier for private chats.</param>
    /// <param name="suggestedPostParameters">Optional suggested-post parameters for direct messages chats.</param>
    /// <param name="replyParameters">Optional description of the message to reply to.</param>
    /// <param name="replyMarkup">Optional interface options such as an inline or reply keyboard.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent message.</returns>
    public static async Task<Message> SendRichMessageAsync(
        this IBotApiClient client,
        ChatIdSource chatId,
        InputRichMessage richMessage,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        EphemeralMessageParameters? ephemeralMessageParameters = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        ReplyMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendRichMessageAsync(new SendRichMessageParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            EphemeralMessageParameters = ephemeralMessageParameters,
            RichMessage = richMessage,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Streams a partial rich message while it is being generated.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target private chat, draft identifier and partial rich content.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SendRichMessageDraftAsync(
        this IBotApiClient client,
        SendRichMessageDraftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendRichMessageDraft", parameters), cancellationToken);

    /// <summary>Streams a partial rich message while it is being generated.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Target private chat identifier.</param>
    /// <param name="draftId">Non-zero draft identifier. Reusing it animates changes to the draft.</param>
    /// <param name="richMessage">Partial rich message to stream. New file uploads are not supported.</param>
    /// <param name="messageThreadId">Optional target message thread identifier.</param>
    /// <param name="canStop">Whether to show the user a button for stopping further drafts.</param>
    /// <param name="keepOnStop">Whether to keep the draft after the user stops generation.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SendRichMessageDraftAsync(
        this IBotApiClient client,
        long chatId,
        long draftId,
        InputRichMessage richMessage,
        long? messageThreadId = null,
        bool? canStop = null,
        bool? keepOnStop = null,
        CancellationToken cancellationToken = default)
        => await client.SendRichMessageDraftAsync(new SendRichMessageDraftParameters
        {
            ChatId = chatId,
            MessageThreadId = messageThreadId,
            DraftId = draftId,
            RichMessage = richMessage,
            CanStop = canStop,
            KeepOnStop = keepOnStop
        }, cancellationToken);
}
