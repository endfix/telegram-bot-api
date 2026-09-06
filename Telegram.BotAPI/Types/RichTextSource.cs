namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents rich text supplied as plain text or a typed rich text value.</summary>
public readonly struct RichTextSource
{
    private readonly object _value;
    private RichTextSource(object value) => _value = value;

    /// <summary>Converts plain text to a rich text source.</summary>
    public static implicit operator RichTextSource(string text) => new(text);
    /// <summary>Converts a typed rich text value to a rich text source.</summary>
    public static implicit operator RichTextSource(RichText richText) => new(richText);

    /// <summary>Gets the original text or rich text value.</summary>
    public object Value => _value;
}
