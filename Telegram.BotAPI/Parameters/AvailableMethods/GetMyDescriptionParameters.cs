using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyDescription</c> method.
/// </summary>
public sealed class GetMyDescriptionParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
