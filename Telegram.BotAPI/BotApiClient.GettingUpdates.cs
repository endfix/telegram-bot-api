using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<Update[]>> GetUpdatesAsync(GetUpdatesParameters parameters = null)
    {
        return await RequestAsync<Update[]>(new ApiRequest("getUpdates", parameters));
    }

    public async Task<ApiResponse<bool>> SetWebhookAsync(SetWebhookParameters parameters = null)
    {
        return await RequestAsync<bool>(new ApiRequest("setWebhook", parameters));
    }

    public async Task<ApiResponse<bool>> DeleteWebhookAsync(DeleteWebhookParameters parameters = null)
    {
        return await RequestAsync<bool>(new ApiRequest("deleteWebhook", parameters));
    }

    public async Task<ApiResponse<WebhookInfo>> GetWebhookInfoAsync(GetWebhookInfoParameters parameters = null)
    {
        return await RequestAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters));
    }
}
