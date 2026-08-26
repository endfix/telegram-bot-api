using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<bool> AnswerInlineQueryAsync(
        this IBotApiClient client, 
        AnswerInlineQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerInlineQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerInlineQueryAsync(
        this IBotApiClient client,
        string inlineQueryId,
        IReadOnlyList<InlineQueryResult> results,
        int? cacheTime = null,
        bool? isPersonal = null,
        string? nextOffset = null,
        InlineQueryResultsButton? button = null,
        CancellationToken cancellationToken = default)
        => await client.AnswerInlineQueryAsync(new AnswerInlineQueryParameters
        {
            InlineQueryId = inlineQueryId,
            Results = results,
            CacheTime = cacheTime,
            IsPersonal = isPersonal,
            NextOffset = nextOffset,
            Button = button
        }, cancellationToken);

    internal static async Task<SentWebAppMessage> AnswerWebAppQueryAsync(
        this IBotApiClient client, 
        AnswerWebAppQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters), cancellationToken);

    public static async Task<SentWebAppMessage> AnswerWebAppQueryAsync(
        this IBotApiClient client,
        string webAppQueryId,
        InlineQueryResult result,
        CancellationToken cancellationToken = default)
        => await client.AnswerWebAppQueryAsync(new AnswerWebAppQueryParameters
        {
            WebAppQueryId = webAppQueryId,
            Result = result
        }, cancellationToken);

    internal static async Task<PreparedInlineMessage> SavePreparedInlineMessageAsync(
        this IBotApiClient client, 
        SavePreparedInlineMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters), cancellationToken);

    public static async Task<PreparedInlineMessage> SavePreparedInlineMessageAsync(
        this IBotApiClient client,
        long userId,
        InlineQueryResult result,
        bool? allowUserChats = null,
        bool? allowBotChats = null,
        bool? allowGroupChats = null,
        bool? allowChannelChats = null,
        CancellationToken cancellationToken = default)
        => await client.SavePreparedInlineMessageAsync(new SavePreparedInlineMessageParameters
        {
            UserId = userId,
            Result = result,
            AllowUserChats = allowUserChats,
            AllowBotChats = allowBotChats,
            AllowGroupChats = allowGroupChats,
            AllowChannelChats = allowChannelChats
        }, cancellationToken);

    internal static async Task<PreparedKeyboardButton> SavePreparedKeyboardButtonAsync(
        this IBotApiClient client, 
        SavePreparedKeyboardButtonParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedKeyboardButton>(new ApiRequest("savePreparedKeyboardButton", parameters), cancellationToken);

    public static async Task<PreparedKeyboardButton> SavePreparedKeyboardButtonAsync(
        this IBotApiClient client,
        long userId,
        KeyboardButton button,
        CancellationToken cancellationToken = default)
        => await client.SavePreparedKeyboardButtonAsync(new SavePreparedKeyboardButtonParameters
        {
            UserId = userId,
            Button = button
        }, cancellationToken);
}
