using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyShortDescription</c> method.
/// </summary>
public sealed class SetMyShortDescriptionParameters : ApiRequestParameters
{
    public string? ShortDescription { get; init; }

    public string? LanguageCode { get; init; }
}
