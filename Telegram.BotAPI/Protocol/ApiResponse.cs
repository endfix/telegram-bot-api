using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Protocol;

/// <summary>
/// Represents the standard response envelope returned by the Telegram Bot API.
/// </summary>
/// <typeparam name="T">The expected type of the successful result.</typeparam>
public sealed class ApiResponse<T>
{
    /// <summary>
    /// Gets or sets whether the API request succeeded.
    /// </summary>
    [JsonRequired]
    public bool Ok { get; set; }

    /// <summary>
    /// Gets or sets the Telegram error code when <see cref="Ok"/> is <see langword="false"/>.
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the human-readable error description, if supplied.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets additional response parameters such as retry or migration data.
    /// </summary>
    public ApiResponseParameters? Parameters { get; set; }

    /// <summary>
    /// Gets or sets the successful result value.
    /// </summary>
    public T Result { get; set; } = default!;
}
