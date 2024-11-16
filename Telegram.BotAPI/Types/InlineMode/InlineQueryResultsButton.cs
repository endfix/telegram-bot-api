using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.InlineMode;

public sealed class InlineQueryResultsButton
{
    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; }

    public string StartParameter { get; set; }
}
