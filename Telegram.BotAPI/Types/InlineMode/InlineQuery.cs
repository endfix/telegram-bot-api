using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class InlineQuery
{
    public required string Id { get; set; }

    public required User From { get; set; }

    public required string Query { get; set; }

    public required string Offset { get; set; }

    public ChatTypes? ChatType { get; set; }

    public Location? Location { get; set; }
}
