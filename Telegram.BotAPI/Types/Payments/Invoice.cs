namespace Endfix.Telegram.BotAPI.Types;

public sealed class Invoice
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required string StartParameter { get; init; }

    public required string Currency { get; init; }

    public required int TotalAmount { get; init; }
}
