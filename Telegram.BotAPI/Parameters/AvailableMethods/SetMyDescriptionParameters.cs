using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyDescription</c> method.
/// </summary>
public sealed class SetMyDescriptionParameters : ApiRequestParameters
{
    /// <summary>New description, from 0 through 512 characters. Pass an empty string to remove it for the selected language.</summary>
    public string? Description { get; init; }

    /// <summary>Two-letter ISO 639-1 language code. An empty value changes the fallback description.</summary>
    public string? LanguageCode { get; init; }
}
