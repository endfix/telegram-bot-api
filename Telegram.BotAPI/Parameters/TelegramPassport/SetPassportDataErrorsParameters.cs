using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setPassportDataErrors</c> method.
/// </summary>
public sealed class SetPassportDataErrorsParameters : ApiRequestParameters
{
    /// <summary>User identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Passport errors that the user must resolve before resubmitting the data.</summary>
    public required IReadOnlyList<PassportElementError> Errors { get; init; }
}
