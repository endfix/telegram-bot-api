namespace Telegram.BotAPI.Types.InlineMode;

// https://core.telegram.org/bots/api#inlinequeryresultsbutton
public sealed class InlineQueryResultsButton
{
    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; }

    public string StartParameter { get; set; }
}
