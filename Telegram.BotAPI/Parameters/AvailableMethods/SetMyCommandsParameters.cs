using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyCommands</c> method.
/// </summary>
public sealed class SetMyCommandsParameters : ApiRequestParameters
{
    /// <summary>Commands to set; at most 100 items.</summary>
    public required IReadOnlyList<BotCommand> Commands { get; init; }

    /// <summary>Scope in which the commands apply. Defaults to the default command scope.</summary>
    public BotCommandScope? Scope { get; init; }

    /// <summary>Two-letter ISO 639-1 language code. An empty value defines the fallback list for the scope.</summary>
    public string? LanguageCode { get; init; }
}
