using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;

namespace Telegram.BotAPI.Extensions;

public static partial class BotClientExtensions
{
    public static async Task<ResponseAPI<bool>> SetPassportDataErrorsAsync(this TelegramBotAPIClient api, SetPassportDataErrorsArgs args = null)
    {
        return await api.RequestAsync<bool>("setPassportDataErrors", args);
    }
}
