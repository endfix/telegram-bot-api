namespace Endfix.Telegram.BotAPI.Types;

public sealed class Currency
{
    public required string Code { get; init; }

    public required string Title { get; init; }

    public required string Symbol { get; init; }

    public required string Native { get; init; }

    public required string ThousandsSep { get; init; }

    public required string DecimalSep { get; init; }

    public required bool SymbolLeft { get; init; }

    public required bool SpaceBetween { get; init; }

    public required bool DropZeros { get; init; }

    public required int Exp { get; init; }

    public required long MinAmount { get; init; }

    public required long MaxAmount { get; init; }
}
