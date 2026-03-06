using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetPassportDataErrorsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required IReadOnlyList<PassportElementError> Errors { get; init; }
}
