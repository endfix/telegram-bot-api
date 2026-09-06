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
    /// Invokes the <c>sendGame</c> method with the specified parameters.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Parameters for the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<Message> SendGameAsync(
        this IBotApiClient client, 
        SendGameParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);

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

    /// <summary>
    /// Invokes the <c>setGameScore</c> method with the specified parameters.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Parameters for the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<Message> SetGameScoreAsync(
        this IBotApiClient client, 
        SetGameScoreParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("setGameScore", parameters), cancellationToken);

    public static async Task<Message> SetGameScoreAsync(
        this IBotApiClient client,
        long userId,
        int score,
        bool? force = null,
        bool? disableEditMessage = null,
        long? chatId = null,
        long? messageId = null,
        string? inlineMessageId = null,
        CancellationToken cancellationToken = default)
        => await client.SetGameScoreAsync(new SetGameScoreParameters
        {
            UserId = userId,
            Score = score,
            Force = force,
            DisableEditMessage = disableEditMessage,
            ChatId = chatId,
            MessageId = messageId,
            InlineMessageId = inlineMessageId
        }, cancellationToken);

    /// <summary>
    /// Invokes the <c>getGameHighScores</c> method with the specified parameters.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Parameters for the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(
        this IBotApiClient client, 
        GetGameHighScoresParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<GameHighScore>>(new ApiRequest("getGameHighScores", parameters), cancellationToken);

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
