namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an inline message to be sent by a user of a Mini App.
/// </summary>
public sealed class PreparedInlineMessage
{
    /// <summary>Unique identifier of the prepared message.</summary>
    public required string Id { get; init; }

    /// <summary>Expiration date of the prepared message, in Unix time.</summary>
    public required int ExpirationDate { get; init; }
}
