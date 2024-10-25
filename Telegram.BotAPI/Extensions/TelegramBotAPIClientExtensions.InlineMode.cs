using System;
using System.Threading.Tasks;
using Telegram.BotAPI.MethodArgs;
using Telegram.BotAPI.Types.InlineMode;

namespace Telegram.BotAPI.Extensions;

public static partial class BotClientExtensions
{
    public static async Task<ResponseAPI<bool>> AnswerInlineQueryAsync(this TelegramBotAPIClient api, AnswerInlineQueryArgs args = null)
    {
        if (string.IsNullOrEmpty(args.InlineQueryId))
        {
            throw new ArgumentNullException(nameof(args.InlineQueryId));
        }

        return await api.RequestAsync<bool>("answerInlineQuery", args);
    }

    public static async Task<ResponseAPI<SentWebAppMessage>> AnswerWebAppQueryAsync(this TelegramBotAPIClient api, AnswerWebAppQueryArgs args = null)
    {
        return await api.RequestAsync<SentWebAppMessage>("answerWebAppQuery", args);
    }
}
