using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public sealed partial class BotApiClient
{
    public delegate void UpdateHandler(BotApiClient client, Update update);

    public event UpdateHandler? OnUpdate;

    private readonly string _token;

    private readonly HttpClient _httpClient;

    private readonly ILogger<BotApiClient> _logger;

    public BotApiClient(string token, HttpClient? httpClient = null, ILogger<BotApiClient> ? logger = null)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));

        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.telegram.org");

        _logger = logger ?? NullLogger<BotApiClient>.Instance;
    }

    public async Task StartPollingAsync(GetUpdatesParameters? parameters = null, CancellationToken cancellationToken = default)
    {
        var lastUpdateId = 0L;

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var pollingParameters = new GetUpdatesParameters
                {
                    Offset = lastUpdateId,
                    Limit = parameters?.Limit,
                    Timeout = parameters?.Timeout ?? 20,
                    AllowedUpdates = parameters?.AllowedUpdates
                };

                var response = await GetUpdatesAsync(pollingParameters, cancellationToken).ConfigureAwait(false);

                if (response.Ok && response.Result is not null)
                {
                    foreach (var update in response.Result)
                    {
                        _ = Task.Run(() =>
                        {
                            try
                            {
                                OnUpdate?.Invoke(this, update);
                            }
                            catch (Exception e)
                            {
                                _logger.LogError("OnUpdate Id: {UpdateId} Message: {Message}", update.UpdateId, e.Message);
                            }
                        });

                        lastUpdateId = update.UpdateId + 1;
                    }
                }
                else if (!response.Ok)
                {
                    _logger.LogWarning("Long Polling: {Description}", response.Description);
                    await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Critical error loop of Long Polling");
                await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    public async Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request, CancellationToken cancellation = default, int retryCount = 0)
    {
        try
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.MethodName))
            {
                throw new ArgumentNullException("methodName");
            }

            using var responseMessage = await GetResponse(request, cancellation);
            using var responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var apiResponse = await JsonSerializer.DeserializeAsync<ApiResponse<T>>(
                responseStream,
                JsonSerializerExtensions.Options,
                cancellation);

            if (apiResponse is null)
            {
                throw new InvalidOperationException($"Failed to {request.MethodName}: response was empty.");
            }

            if (apiResponse.ErrorCode == 429)
            {
                if (retryCount < 5)
                {
                    var secondsDelay = (apiResponse.Parameters?.RetryAfter ?? 0) + 1;
                    await Task.Delay(secondsDelay * 1000, cancellation);

                    return await RequestAsync<T>(request, cancellation, ++retryCount);
                }
            }

            return apiResponse;
        }
        catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception e)
        {
            if (e is HttpRequestException requestException && requestException.InnerException is SocketException)
            {
                if (retryCount < 5)
                {
                    await Task.Delay(60 * 1000, cancellation);

                    return await RequestAsync<T>(request, cancellation, ++retryCount);
                }
            }
            
            var response = new ApiResponse<T>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };

            return response;
        }
    }

    public async Task<ApiResponse<byte[]>> GetFileBytesAsync(string filePath, CancellationToken cancellation = default)
    {
        try
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new ArgumentNullException(nameof(_token));
            }

            using var response = await _httpClient.GetAsync($"/file/bot{_token}/{filePath}", cancellation);
            var bytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return new ApiResponse<byte[]>
            {
                Ok = true,
                Result = bytes
            };
        }
        catch (Exception e)
        {
            return new ApiResponse<byte[]>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };
        }
    }

    private async Task<HttpResponseMessage> GetResponse(ApiRequest request, CancellationToken cancellation)
    {
        var requestUri = $"/bot{_token}/{request.MethodName}";
        var parameters = request.Parameters;
        

        if (parameters is null)
        {
            return await _httpClient.GetAsync(requestUri, cancellation).ConfigureAwait(false);
        }

        var properties = parameters.GetType().GetProperties();
        var hasParameters = false;
        var httpContent = new MultipartFormDataContent();

        try
        {
            foreach (var property in properties)
            {
                var value = property.GetValue(parameters);
                if (value == null)
                {
                    continue;
                }

                hasParameters = true;

                if (value is InputFile inputFile)
                {
                    httpContent.Add(new StreamContent(inputFile.GetStream()), inputFile.Type.Serialize(), inputFile.FileName);
                }
                else
                {
                    var jsonValue = value is string s ? s : value.Serialize();
                    httpContent.Add(new StringContent(jsonValue, Encoding.UTF8), property.Name.ToSnake());
                }
            }

            if (!hasParameters)
            {
                httpContent.Dispose();
                return await _httpClient.GetAsync(requestUri, cancellation).ConfigureAwait(false);
            }

            return await _httpClient.PostAsync(requestUri, httpContent, cancellation).ConfigureAwait(false);
        }
        catch
        {
            httpContent.Dispose();
            throw;
        }
    }

    public async Task<IReadOnlyDictionary<string, Currency>> GetCurrencies(CancellationToken cancellation = default)
    {
        try
        {
            using var response = await _httpClient.GetAsync("https://core.telegram.org/bots/payments/currencies.json", cancellation);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<Dictionary<string, Currency>>(
                stream,
                JsonSerializerExtensions.Options,
                cancellation);

            return result ?? throw new InvalidOperationException("Failed to deserialize currencies: response was empty or wrong syntax.");
        }
        catch (JsonException ex)
        {
            _logger.LogError("JSON Error: {Message} at {Path}", ex.Message, ex.Path);
            throw;
        }
        catch
        {
            throw;
        }
    }
}
