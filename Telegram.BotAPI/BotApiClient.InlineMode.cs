using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<bool>> AnswerInlineQueryAsync(AnswerInlineQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerInlineQuery", parameters));
    }

    public async Task<ApiResponse<SentWebAppMessage>> AnswerWebAppQueryAsync(AnswerWebAppQueryParameters parameters)
    {
        return await RequestAsync<SentWebAppMessage>(new ApiRequest("answerWebAppQuery", parameters));
    }

    public async Task<ApiResponse<PreparedInlineMessage>> SavePreparedInlineMessageAsync(SavePreparedInlineMessageParameters parameters)
    {
        return await RequestAsync<PreparedInlineMessage>(new ApiRequest("savePreparedInlineMessage", parameters));
    }
}
