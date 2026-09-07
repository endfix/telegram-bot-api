using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyShortDescription</c> method.
/// </summary>
public sealed class SetMyShortDescriptionParameters : ApiRequestParameters
{
    /// <summary>New short description, from 0 through 120 characters. Pass an empty string to remove it for the selected language.</summary>
    public string? ShortDescription { get; init; }

    /// <summary>Two-letter ISO 639-1 language code. An empty value changes the fallback short description.</summary>
    public string? LanguageCode { get; init; }
}
