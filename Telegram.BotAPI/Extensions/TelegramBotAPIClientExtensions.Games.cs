using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class BotClientExtensions
{
    public static async Task<ResponseAPI<Message>> SendGameAsync(this TelegramBotAPIClient api, SendGameArgs args = null)
    {
        return await api.RequestAsync<Message>("sendGame", args);
    }

    public static async Task<ResponseAPI<Message>> SetGameScoreAsync(this TelegramBotAPIClient api, SetGameScoreArgs args = null)
    {
        return await api.RequestAsync<Message>("setGameScore", args);
    }

    public static async Task<ResponseAPI<List<GameHighScore>>> GetGameHighScoresAsync(this TelegramBotAPIClient api, GetGameHighScoresArgs args = null)
    {
        return await api.RequestAsync<List<GameHighScore>>("getGameHighScores", args);
    }
}
