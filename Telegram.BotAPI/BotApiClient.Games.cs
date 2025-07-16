using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<Message>> SendGameAsync(SendGameParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendGame", parameters));
    }

    public async Task<ApiResponse<Message>> SetGameScoreAsync(SetGameScoreParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("setGameScore", parameters));
    }

    public async Task<ApiResponse<GameHighScore[]>> GetGameHighScoresAsync(GetGameHighScoresParameters parameters)
    {
        return await RequestAsync<GameHighScore[]>(new ApiRequest("getGameHighScores", parameters));
    }
}
