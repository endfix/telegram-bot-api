using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<Message> SendGameAsync(
        this IBotApiClient client, 
        SendGameParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendGame", parameters), cancellationToken);

    public static async Task<Message> SendGameAsync(
        this IBotApiClient client,
        long chatId,
        string gameShortName,
        string? businessConnectionId = null,
        int? messageThreadId = null,
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

    internal static async Task<Message> SetGameScoreAsync(
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

    internal static async Task<IReadOnlyList<GameHighScore>> GetGameHighScoresAsync(
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
