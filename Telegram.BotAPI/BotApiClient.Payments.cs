using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Endfix.Telegram.BotAPI;

public sealed partial class BotApiClient
{
    /// <summary>
    /// Downloads the currencies supported by Telegram payments.
    /// </summary>
    public async Task<IReadOnlyDictionary<string, Currency>> GetCurrenciesAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await _httpClient
                .GetAsync("https://core.telegram.org/bots/payments/currencies.json", cancellationToken)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var result = await stream
                .DeserializeAsync<Dictionary<string, Currency>>(cancellationToken)
                .ConfigureAwait(false);

            return result ?? throw new InvalidOperationException(
                "Failed to deserialize currencies: response was empty or wrong syntax.");
        }
        catch (JsonException exception)
        {
            _logger.LogError("JSON Error: {Message} at {Path}", exception.Message, exception.Path);
            throw;
        }
    }
}
