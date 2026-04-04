namespace Telegram.BotAPI.Types;

public readonly struct ChatIdSource
{
    private readonly object _value;
    private ChatIdSource(object value) => _value = value;

    public static implicit operator ChatIdSource(string username) => new(username);
    public static implicit operator ChatIdSource(long id) => new(id);

    public object Value => _value;
}
