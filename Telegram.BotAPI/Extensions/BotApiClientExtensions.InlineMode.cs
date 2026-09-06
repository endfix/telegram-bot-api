using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>Sends results for an inline query.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Inline query identifier, results, caching and pagination options.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> AnswerInlineQueryAsync(
        this IBotApiClient client, 
        AnswerInlineQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerInlineQuery", parameters), cancellationToken);

    /// <summary>Sends results for an inline query.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="inlineQueryId">Unique identifier of the answered inline query.</param>
    /// <param name="results">Results for the query. No more than 50 results can be returned.</param>
    /// <param name="cacheTime">Maximum server-side caching time in seconds. The default is 300.</param>
    /// <param name="isPersonal">Whether results may be cached only for the user who sent the query.</param>
    /// <param name="nextOffset">Offset for the next page. Its length must not exceed 64 bytes.</param>
    /// <param name="button">Optional button shown above the inline results.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Sets the result of a Web App interaction and sends the resulting message on behalf of the user.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Web App query identifier and message result.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The message sent on behalf of the user.</returns>
    public static async Task<SentWebAppMessage> AnswerWebAppQueryAsync(
        this IBotApiClient client, 
        AnswerWebAppQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters), cancellationToken);

    /// <summary>Sets the result of a Web App interaction and sends the resulting message on behalf of the user.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="webAppQueryId">Unique identifier of the Web App query.</param>
    /// <param name="result">Description of the message to send.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The message sent on behalf of the user.</returns>
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

    /// <summary>Stores a message that a Mini App user can send later.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target user, message result and allowed chat types.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The prepared inline message.</returns>
    public static async Task<PreparedInlineMessage> SavePreparedInlineMessageAsync(
        this IBotApiClient client, 
        SavePreparedInlineMessageParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters), cancellationToken);

    /// <summary>Stores a message that a Mini App user can send later.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who can use the prepared message.</param>
    /// <param name="result">Description of the message to save.</param>
    /// <param name="allowUserChats">Whether the message may be sent to private chats with users.</param>
    /// <param name="allowBotChats">Whether the message may be sent to private chats with bots.</param>
    /// <param name="allowGroupChats">Whether the message may be sent to groups and supergroups.</param>
    /// <param name="allowChannelChats">Whether the message may be sent to channels.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The prepared inline message.</returns>
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

    /// <summary>Stores a keyboard button that a Mini App user can use.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Target user and keyboard button.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The prepared keyboard button.</returns>
    public static async Task<PreparedKeyboardButton> SavePreparedKeyboardButtonAsync(
        this IBotApiClient client, 
        SavePreparedKeyboardButtonParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<PreparedKeyboardButton>(new ApiRequest("savePreparedKeyboardButton", parameters), cancellationToken);

    /// <summary>Stores a keyboard button that a Mini App user can use.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user who can use the prepared button.</param>
    /// <param name="button">Button to save. It must be a <c>request_users</c>, <c>request_chat</c>, or <c>request_managed_bot</c> button.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The prepared keyboard button.</returns>
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
