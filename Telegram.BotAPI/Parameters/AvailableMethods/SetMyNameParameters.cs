using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyName</c> method.
/// </summary>
public sealed class SetMyNameParameters : ApiRequestParameters
{
    public string? Name { get; init; }

    public string? LanguageCode { get; init; }
}
