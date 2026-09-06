using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyDescription</c> method.
/// </summary>
public sealed class SetMyDescriptionParameters : ApiRequestParameters
{
    public string? Description { get; init; }

    public string? LanguageCode { get; init; }
}
