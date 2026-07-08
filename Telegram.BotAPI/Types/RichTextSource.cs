namespace Telegram.BotAPI.Types;

public readonly struct RichTextSource
{
    private readonly object _value;
    private RichTextSource(object value) => _value = value;

    public static implicit operator RichTextSource(string text) => new(text);
    public static implicit operator RichTextSource(RichText obj) => new(obj);

    public object Value => _value;
}
