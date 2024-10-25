using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class TelegramBotAPIClientExtensions
{
    public static async Task<ResponseAPI<Message>> EditMessageTextAsync(this TelegramBotAPIClient api, EditMessageTextArgs args = null)
    {
        return await api.RequestAsync<Message>("editMessageText", args);
    }

    public static async Task<ResponseAPI<Message>> EditMessageCaptionAsync(this TelegramBotAPIClient api, EditMessageCaptionArgs args = null)
    {
        return await api.RequestAsync<Message>("editMessageCaption", args);
    }

    public static async Task<ResponseAPI<Message>> EditMessageMediaAsync(this TelegramBotAPIClient api, EditMessageMediaArgs args = null)
    {
        return await api.RequestAsync<Message>("editMessageMedia", args);
    }

    public static async Task<ResponseAPI<Message>> EditMessageLiveLocationAsync(this TelegramBotAPIClient api, EditMessageLiveLocationArgs args = null)
    {
        return await api.RequestAsync<Message>("editMessageLiveLocation", args);
    }

    public static async Task<ResponseAPI<Message>> StopMessageLiveLocationAsync(this TelegramBotAPIClient api, StopMessageLiveLocationArgs args = null)
    {
        return await api.RequestAsync<Message>("stopMessageLiveLocation", args);
    }

    public static async Task<ResponseAPI<Message>> EditMessageReplyMarkupAsync(this TelegramBotAPIClient api, EditMessageReplyMarkupArgs args = null)
    {
        return await api.RequestAsync<Message>("editMessageReplyMarkup", args);
    }

    public static async Task<ResponseAPI<Poll>> StopPollAsync(this TelegramBotAPIClient api, StopPollArgs args = null)
    {
        return await api.RequestAsync<Poll>("stopPoll", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteMessageAsync(this TelegramBotAPIClient api, DeleteMessageArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteMessage", args);
    }

    public static async Task<ResponseAPI<bool>> DeleteMessagesAsync(this TelegramBotAPIClient api, DeleteMessagesArgs args = null)
    {
        return await api.RequestAsync<bool>("deleteMessages", args);
    }
}
