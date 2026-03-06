namespace Telegram.BotAPI.Types;

public sealed class InlineQueryResultsButton
{
    public required string Text { get; init; }

    public WebAppInfo? WebApp { get; init; }

    public string? StartParameter { get; init; }
}
