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
    /// Invokes the <c>setPassportDataErrors</c> method with the specified parameters.
    /// </summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Parameters for the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<bool> SetPassportDataErrorsAsync(
        this IBotApiClient client, 
        SetPassportDataErrorsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setPassportDataErrors", parameters), cancellationToken);

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
