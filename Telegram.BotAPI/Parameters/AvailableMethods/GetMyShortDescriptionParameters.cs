using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyShortDescription</c> method.
/// </summary>
public sealed class GetMyShortDescriptionParameters : ApiRequestParameters
{
    /// <summary>Two-letter ISO 639-1 language code or an empty string.</summary>
    public string? LanguageCode { get; init; }
}
