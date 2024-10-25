namespace Telegram.BotAPI.Types.InlineMode;

// https://core.telegram.org/bots/api#inlinequery
public sealed class InlineQuery
{
    public string Id { get; set; }

    public User From { get; set; }

    public string Query { get; set; }

    public string Offset { get; set; }

    public string ChatType { get; set; }

    public Location Location { get; set; }
}
