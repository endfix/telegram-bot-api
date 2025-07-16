namespace Telegram.BotAPI.Types;

public sealed class InlineQueryResultsButton
{
    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; }

    public string StartParameter { get; set; }
}
