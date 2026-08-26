using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyCommandsParameters : ApiRequestParameters
{
    public required IReadOnlyList<BotCommand> Commands { get; init; }

    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }
}
