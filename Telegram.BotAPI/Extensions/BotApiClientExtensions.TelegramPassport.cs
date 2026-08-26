using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<bool> SetPassportDataErrorsAsync(
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
