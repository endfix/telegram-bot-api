using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyName</c> method.
/// </summary>
public class GetMyNameParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
