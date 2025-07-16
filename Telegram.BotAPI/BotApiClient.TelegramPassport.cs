using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<bool>> SetPassportDataErrorsAsync(SetPassportDataErrorsParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("setPassportDataErrors", parameters));
    }
}
