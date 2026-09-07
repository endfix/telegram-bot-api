using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMyCommands</c> method.
/// </summary>
public sealed class DeleteMyCommandsParameters : ApiRequestParameters
{
    /// <summary>Scope from which commands are removed. Defaults to the default command scope.</summary>
    public BotCommandScope? Scope { get; init; }

    /// <summary>Two-letter ISO 639-1 language code. An empty value targets the fallback list for the scope.</summary>
    public string? LanguageCode { get; init; }
}
