namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes an amount of Telegram Stars.</summary>
public sealed class StarAmount
{
    /// <summary>Integer amount of Telegram Stars, rounded to zero; can be negative.</summary>
    public required int Amount {  get; init; }

    /// <summary>Optional. Number of 1/1000000000 shares of Telegram Stars, from -999999999 to 999999999; can be negative only when <see cref="Amount"/> is non-positive.</summary>
    public int? NanostarAmount { get; init; }
}
