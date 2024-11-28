using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.BotAPI.Core;
using Telegram.BotAPI.Requests.Games;
using Telegram.BotAPI.Types.AvailableTypes;
using Telegram.BotAPI.Types.Games;

namespace Telegram.BotAPI;

public partial class BotAPIClient
{
    /// <summary>
    /// Use this method to send a game. 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>On success, the sent <see cref="Message">Message</see> is returned.</returns>
    public async Task<ResponseAPI<Message>> SendGameAsync(SendGameParameters parameters)
    {
        return await RequestAsync<Message>("sendGame", parameters);
    }

    /// <summary>
    /// Use this method to set the score of the specified user in a game message. 
    /// On success, if the message is not an inline message, the Message is returned, otherwise True is returned. 
    /// Returns an error, if the new score is not greater than the user's current score in the chat and force is False.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<ResponseAPI<Message>> SetGameScoreAsync(SetGameScoreParameters parameters)
    {
        return await RequestAsync<Message>("setGameScore", parameters);
    }

    /// <summary>
    /// Use this method to get data for high score tables. 
    /// Will return the score of the specified user and several of their neighbors in a game.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>Returns an Array of <see cref="GameHighScore">GameHighScore</see> objects.</returns>
    public async Task<ResponseAPI<List<GameHighScore>>> GetGameHighScoresAsync(GetGameHighScoresParameters parameters)
    {
        return await RequestAsync<List<GameHighScore>>("getGameHighScores", parameters);
    }
}
