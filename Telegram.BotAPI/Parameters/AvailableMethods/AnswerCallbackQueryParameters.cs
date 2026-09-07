using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerCallbackQuery</c> method.
/// </summary>
public sealed class AnswerCallbackQueryParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier of the callback query to answer.</summary>
    public required string CallbackQueryId { get; init; }

    /// <summary>Gets the notification text, containing 0-200 characters. When omitted, no text is shown.</summary>
    public string? Text { get; init; }

    /// <summary>Gets whether to show an alert instead of a notification at the top of the chat screen. Defaults to <see langword="false"/>.</summary>
    public bool? ShowAlert { get; init; }

    /// <summary>Gets the URL to open in the user's client.</summary>
    public string? Url { get; init; }

    /// <summary>Gets the maximum number of seconds for which the result may be cached client-side. Defaults to 0.</summary>
    public int? CacheTime { get; init; }
}
