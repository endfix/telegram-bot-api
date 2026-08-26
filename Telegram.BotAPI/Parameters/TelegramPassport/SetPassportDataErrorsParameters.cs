using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetPassportDataErrorsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required IReadOnlyList<PassportElementError> Errors { get; init; }
}
