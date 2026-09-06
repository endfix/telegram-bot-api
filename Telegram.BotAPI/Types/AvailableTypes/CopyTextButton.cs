namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a button that copies text to the clipboard.</summary>
public sealed class CopyTextButton
{
    /// <summary>Text copied when the button is pressed.</summary>
    public required string Text { get; init; }
}
