namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an attribute of an NFT in the TON blockchain.</summary>
public sealed class TonNftAttribute
{
    /// <summary>Trait type of the attribute.</summary>
    public required string TraitType { get; init; }

    /// <summary>Value of the attribute.</summary>
    public required string Value { get; init; }
}
