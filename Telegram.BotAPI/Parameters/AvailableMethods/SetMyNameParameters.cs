using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyName</c> method.
/// </summary>
public sealed class SetMyNameParameters : ApiRequestParameters
{
    /// <summary>New name, from 0 through 64 characters. Pass an empty string to remove the name for the selected language.</summary>
    public string? Name { get; init; }

    /// <summary>Two-letter ISO 639-1 language code. An empty value changes the fallback name.</summary>
    public string? LanguageCode { get; init; }
}
