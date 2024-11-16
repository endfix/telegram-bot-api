using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.InlineMode;

public sealed class InlineQuery
{
    public string Id { get; set; }

    public User From { get; set; }

    public string Query { get; set; }

    public string Offset { get; set; }

    public string ChatType { get; set; }

    public Location Location { get; set; }
}
