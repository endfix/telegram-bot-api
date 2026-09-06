using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    /// <summary>
    /// Reports errors in Telegram Passport data submitted by a user.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User identifier and Passport validation errors.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetPassportDataErrorsAsync(
        this IBotApiClient client, 
        SetPassportDataErrorsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setPassportDataErrors", parameters), cancellationToken);

    /// <summary>
    /// Reports errors in Telegram Passport data submitted by a user.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">User identifier.</param>
    /// <param name="errors">Passport errors that the user must resolve before resubmitting the data.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> SetPassportDataErrorsAsync(
        this IBotApiClient client,
        long userId,
        IReadOnlyList<PassportElementError> errors,
        CancellationToken cancellationToken = default)
        => await client.SetPassportDataErrorsAsync(new SetPassportDataErrorsParameters
        {
            UserId = userId,
            Errors = errors
        }, cancellationToken);
}
