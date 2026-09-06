namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a button to be shown above inline query results.
/// </summary>
public sealed class InlineQueryResultsButton
{
    /// <summary>Label text on the button.</summary>
    public required string Text { get; init; }

    /// <summary>Optional Web App to be launched when the button is pressed.</summary>
    public WebAppInfo? WebApp { get; init; }

    /// <summary>Optional deep-linking parameter for the bot.</summary>
    public string? StartParameter { get; init; }
}
