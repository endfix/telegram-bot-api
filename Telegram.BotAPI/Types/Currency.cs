namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a currency supported by Telegram payments.
/// </summary>
public sealed class Currency
{
    /// <summary>Gets the ISO currency code.</summary>
    public required string Code { get; init; }

    /// <summary>Gets the localized currency title.</summary>
    public required string Title { get; init; }

    /// <summary>Gets the currency symbol.</summary>
    public required string Symbol { get; init; }

    /// <summary>Gets the native currency symbol or representation.</summary>
    public required string Native { get; init; }

    /// <summary>Gets the thousands separator used when formatting amounts.</summary>
    public required string ThousandsSep { get; init; }

    /// <summary>Gets the decimal separator used when formatting amounts.</summary>
    public required string DecimalSep { get; init; }

    /// <summary>Gets whether the symbol is placed before the amount.</summary>
    public required bool SymbolLeft { get; init; }

    /// <summary>Gets whether a space is placed between the symbol and amount.</summary>
    public required bool SpaceBetween { get; init; }

    /// <summary>Gets whether trailing zeroes may be omitted when formatting amounts.</summary>
    public required bool DropZeros { get; init; }

    /// <summary>Gets the number of minor currency units per major unit.</summary>
    public required int Exp { get; init; }

    /// <summary>Gets the minimum amount accepted by Telegram for this currency.</summary>
    public required long MinAmount { get; init; }

    /// <summary>Gets the maximum amount accepted by Telegram for this currency.</summary>
    public required long MaxAmount { get; init; }
}
