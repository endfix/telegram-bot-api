using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;
using Telegram.BotAPI.Types.Updates;

namespace Telegram.BotAPI.Extensions;

public static partial class TelegramBotAPIClientExtensions
{
    public static async Task<ResponseAPI<List<Update>>> GetUpdatesAsync(this TelegramBotAPIClient api, GetUpdatesArgs args = null)
    {
        return await api.RequestAsync<List<Update>>("getUpdates", args);
    }

    public static async Task<ResponseAPI<bool>> SetWebhookAsync(this TelegramBotAPIClient api, SetWebhookArgs args = null)
    {
        return await api.RequestAsync<bool>("setWebhook", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteWebhookAsync(this TelegramBotAPIClient api, DeleteWebhookArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteWebhook", args ?? new DeleteWebhookArgs());
    }

    public static async Task<ResponseAPI<WebhookInfo>> GetWebhookInfoAsync(this TelegramBotAPIClient api, GetWebhookInfoArgs args = null)
    {
        return await api.RequestAsync<WebhookInfo>("getWebhookInfo", args);
    }
}
