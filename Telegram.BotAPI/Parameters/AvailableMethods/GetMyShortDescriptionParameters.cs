using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyShortDescription</c> method.
/// </summary>
public sealed class GetMyShortDescriptionParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
