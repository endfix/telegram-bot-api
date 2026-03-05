namespace Telegram.BotAPI.Types;

public sealed class ChosenInlineResult
{
    public required string ResultId { get; init; }

    public required User From { get; init; }

    public Location? Location { get; init; }

    public string? InlineMessageId { get; init; }

    public required string Query { get; init; }
}
