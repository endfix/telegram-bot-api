namespace Endfix.Telegram.BotAPI.Protocol;

/// <summary>
/// Contains optional parameters returned with an unsuccessful Telegram response.
/// </summary>
public sealed class ApiResponseParameters
{
    /// <summary>
    /// Gets or sets the identifier of the chat to which a migrated group moved.
    /// </summary>
    public long MigrateToChatId { get; set; }

    /// <summary>
    /// Gets or sets the number of seconds to wait before retrying after a rate limit response.
    /// </summary>
    public int RetryAfter { get; set; }
}
