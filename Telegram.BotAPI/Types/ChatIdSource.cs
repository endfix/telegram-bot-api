namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a Telegram chat identifier supplied either as a numeric ID or a username.
/// </summary>
public readonly struct ChatIdSource
{
    private readonly object _value;
    private ChatIdSource(object value) => _value = value;

    /// <summary>Converts a chat username to a chat identifier source.</summary>
    /// <param name="username">Username of the target channel or group, in the format <c>@channelusername</c>.</param>
    /// <returns>A chat identifier source containing the supplied username.</returns>
    public static implicit operator ChatIdSource(string username) => new(username);

    /// <summary>Converts a numeric chat identifier to a chat identifier source.</summary>
    /// <param name="id">Unique identifier of the target chat.</param>
    /// <returns>A chat identifier source containing the supplied identifier.</returns>
    public static implicit operator ChatIdSource(long id) => new(id);

    /// <summary>
    /// Gets the original username or numeric identifier.
    /// </summary>
    public object Value => _value;
}
