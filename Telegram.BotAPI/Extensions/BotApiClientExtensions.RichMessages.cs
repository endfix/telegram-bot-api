using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<Message> SendRichMessageAsync(
        this IBotApiClient client,
        SendRichMessageParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendRichMessage", parameters), cancellationToken);

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

    internal static async Task<bool> SendRichMessageDraftAsync(
        this IBotApiClient client,
        SendRichMessageDraftParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("sendRichMessageDraft", parameters), cancellationToken);

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
