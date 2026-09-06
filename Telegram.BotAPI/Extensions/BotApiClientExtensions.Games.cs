using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>
    /// Sends a game to a target chat.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Game message and delivery options.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent game message.</returns>
    public static async Task<Message> SendGameAsync(
        this IBotApiClient client, 
        SendGameParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);

    /// <summary>
    /// Sends a game to a target chat.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="chatId">Unique identifier of the target chat or the username of the target bot.</param>
    /// <param name="gameShortName">Short name of the game configured through BotFather.</param>
    /// <param name="businessConnectionId">Optional business connection identifier.</param>
    /// <param name="messageThreadId">Optional forum topic identifier.</param>
    /// <param name="disableNotification">Whether to send the message silently.</param>
    /// <param name="protectContent">Whether to protect the message from forwarding and saving.</param>
    /// <param name="allowPaidBroadcast">Whether to allow paid high-rate broadcasting.</param>
    /// <param name="messageEffectId">Optional message effect identifier for private chats.</param>
    /// <param name="replyParameters">Optional description of the message to reply to.</param>
    /// <param name="replyMarkup">Optional inline keyboard. If empty, Telegram shows a Play Game button.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The sent game message.</returns>
    public static async Task<Message> SendGameAsync(
        this IBotApiClient client,
        long chatId,
        string gameShortName,
        string? businessConnectionId = null,
        long? messageThreadId = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        ReplyParameters? replyParameters = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendGameAsync(new SendGameParameters
        {
            BusinessConnectionId = businessConnectionId,
            ChatId = chatId,
            MessageThreadId = messageThreadId,
            GameShortName = gameShortName,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    /// <summary>Sets the score of a user in an ordinary game message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User, score and ordinary message identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited game message.</returns>
    public static async Task<Message> SetGameScoreForMessageAsync(
        this IBotApiClient client, 
        SetGameScoreParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("setGameScore", parameters), cancellationToken);

    /// <summary>Sets the score of a user in an ordinary game message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">User whose score should be set.</param>
    /// <param name="chatId">Chat containing the game message.</param>
    /// <param name="messageId">Identifier of the game message.</param>
    /// <param name="score">New non-negative score.</param>
    /// <param name="force">Whether to allow decreasing the user's high score.</param>
    /// <param name="disableEditMessage">Whether to prevent automatic scoreboard updates.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The edited game message.</returns>
    public static async Task<Message> SetGameScoreForMessageAsync(
        this IBotApiClient client,
        long userId,
        long chatId,
        long messageId,
        int score,
        bool? force = null,
        bool? disableEditMessage = null,
        CancellationToken cancellationToken = default)
        => await client.SetGameScoreForMessageAsync(new SetGameScoreParameters
        {
            UserId = userId,
            ChatId = chatId,
            Score = score,
            Force = force,
            DisableEditMessage = disableEditMessage,
            MessageId = messageId
        }, cancellationToken);

    /// <summary>Sets the score of a user in an inline game message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User, score and inline message identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetGameScoreInlineAsync(
        this IBotApiClient client,
        SetGameScoreParameters parameters,
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setGameScore", parameters), cancellationToken);

    /// <summary>Sets the score of a user in an inline game message.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">User whose score should be set.</param>
    /// <param name="inlineMessageId">Identifier of the inline game message.</param>
    /// <param name="score">New non-negative score.</param>
    /// <param name="force">Whether to allow decreasing the user's high score.</param>
    /// <param name="disableEditMessage">Whether to prevent automatic scoreboard updates.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetGameScoreInlineAsync(
        this IBotApiClient client,
        long userId,
        string inlineMessageId,
        int score,
        bool? force = null,
        bool? disableEditMessage = null,
        CancellationToken cancellationToken = default)
        => await client.SetGameScoreInlineAsync(new SetGameScoreParameters
        {
            UserId = userId,
            Score = score,
            Force = force,
            DisableEditMessage = disableEditMessage,
            InlineMessageId = inlineMessageId
        }, cancellationToken);

    /// <summary>
    /// Retrieves the specified user's score and nearby scores for a game.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Identifiers of the user and game message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The requested rows from the game's high-score table.</returns>
    public static async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(
        this IBotApiClient client, 
        GetGameHighScoresParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<GameHighScore>>(new ApiRequest("getGameHighScores", parameters), cancellationToken);

    /// <summary>
    /// Retrieves the specified user's score and nearby scores for a game.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Target user identifier.</param>
    /// <param name="chatId">Chat identifier, required when <paramref name="inlineMessageId"/> is not specified.</param>
    /// <param name="messageId">Message identifier, required when <paramref name="inlineMessageId"/> is not specified.</param>
    /// <param name="inlineMessageId">Inline message identifier, required when <paramref name="chatId"/> and <paramref name="messageId"/> are not specified.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The requested rows from the game's high-score table.</returns>
    public static async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(
        this IBotApiClient client,
        long userId,
        long? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        CancellationToken cancellationToken = default)
        => await client.GetGameHighScoresAsync(new GetGameHighScoresParameters
        { 
            UserId = userId,
            ChatId = chatId, 
            MessageId = messageId,
            InlineMessageId = inlineMessageId
        }, cancellationToken);
}
