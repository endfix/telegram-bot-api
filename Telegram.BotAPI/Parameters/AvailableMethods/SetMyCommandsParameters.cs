using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMyCommandsParameters : ApiRequestParameters
{
    public required IReadOnlyList<BotCommand> Commands { get; init; }

    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }
}
