using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getMyCommands</c> method.
/// </summary>
public sealed class GetMyCommandsParameters : ApiRequestParameters
{
    /// <summary>Scope for which commands are returned. Defaults to the default command scope.</summary>
    public BotCommandScope? Scope { get; init; }

    /// <summary>Two-letter ISO 639-1 language code or an empty string.</summary>
    public string? LanguageCode { get; init; }
}
