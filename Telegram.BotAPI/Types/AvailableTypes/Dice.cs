namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an animated emoji that displays a random value.</summary>
public sealed class Dice
{
    /// <summary>Emoji on which the dice throw animation is based.</summary>
    public required string Emoji { get; init; }

    /// <summary>Value shown by the animation.</summary>
    public required int Value { get; init; }
}
