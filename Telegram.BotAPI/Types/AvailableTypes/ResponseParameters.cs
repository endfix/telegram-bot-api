namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes why a request was unsuccessful.
/// </summary>
public sealed class ResponseParameters
{
    /// <summary>
    /// Optional identifier of the group migrated to a supergroup.
    /// </summary>
    public long? MigrateToChatId { get; init; }

    /// <summary>
    /// Optional number of seconds left to wait before the request can be repeated after exceeding flood control.
    /// </summary>
    public int? RetryAfter { get; init; }
}
