using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Exceptions;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public sealed class BotApiClient : IBotApiClient
{
    public delegate Task UpdateHandler(IBotApiClient client, Update update);

    public event UpdateHandler? OnUpdate;

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _parametersCache = new();

    private static readonly ConcurrentDictionary<string, string> _fieldNamesCache = new();

    private readonly string _token;

    private readonly HttpClient _httpClient;

    private IReadOnlyList<int> _retryDelays;

    private readonly ILogger<IBotApiClient> _logger;

    public BotApiClient(string token, HttpClient? httpClient = null, string? url = null, IReadOnlyList<int>? retryDelays = null, ILogger<IBotApiClient>? logger = null)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));

        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri(url ?? "https://api.telegram.org");

        _retryDelays = retryDelays ?? [5, 10, 25, 30, 60, 120];

        _logger = logger ?? NullLogger<IBotApiClient>.Instance;
    }

    public async Task StartPollingAsync(GetUpdatesParameters? parameters = null, int maxParallel = 10, CancellationToken cancellationToken = default)
    {
        if (maxParallel < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxParallel));
        }

        using var throttling = new SemaphoreSlim(maxParallel, maxParallel);
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

                var tasks = new List<Task>();

                var updates = await this.GetUpdatesAsync(pollingParameters, cancellationToken).ConfigureAwait(false);
                if (updates is { Count: > 0 })
                {
                    foreach (var update in updates)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            await throttling.WaitAsync(cancellationToken);
                            try
                            {
                                if (OnUpdate is not null)
                                {
                                    await OnUpdate.Invoke(this, update);
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.LogError(e, "Error processing update {Id}", update.UpdateId);
                            }
                            finally
                            {
                                throttling.Release();
                            }
                        }, cancellationToken));

                        lastUpdateId = update.UpdateId + 1;
                    }

                    await Task.WhenAll(tasks).ConfigureAwait(false);
                }
            }
            catch (ApiRequestException e)
            {
                _logger.LogWarning("Long Polling: {Message}", e.Message);
                await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
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
                _logger.LogWarning($"RequestAsync: Failed to {request.MethodName}: response was empty.");
                throw new ApiRequestException(500, $"Failed to {request.MethodName}: response was empty.");
            }

            if (apiResponse.ErrorCode == 429)
            {
                if (retryCount < _retryDelays.Count)
                {
                    var secondsDelay = (apiResponse.Parameters?.RetryAfter ?? 0) + 1;
                    await Task.Delay(TimeSpan.FromSeconds(secondsDelay), cancellation);

                    return await RequestAsync<T>(request, cancellation, ++retryCount);
                }
            }

            return apiResponse;
        }
        catch (OperationCanceledException e)
        {
            if (e is TaskCanceledException && !cancellation.IsCancellationRequested && retryCount < _retryDelays.Count)
            {
                return await RequestAsync<T>(request, cancellation, ++retryCount);
            }

            if (!cancellation.IsCancellationRequested)
            {
                _logger.LogWarning("RequestAsync: {Message}", e.Message);
            }

            throw;
        }
        catch (Exception e)
        {
            if (e is HttpRequestException requestException && requestException.InnerException is SocketException)
            {
                if (retryCount < _retryDelays.Count)
                {
                    await Task.Delay(TimeSpan.FromSeconds(_retryDelays[retryCount]), cancellation);

                    return await RequestAsync<T>(request, cancellation, ++retryCount);
                }
            }

            _logger.LogError("RequestAsync: {Message}", e.Message);

            var response = new ApiResponse<T>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default!
            };

            return response;
        }
    }

    public async Task<TResult> ExecuteAsync<TResult>(ApiRequest request, CancellationToken cancellationToken)
    {
        var response = await RequestAsync<TResult>(request, cancellationToken);
        if (!response.Ok)
        {
            throw new ApiRequestException(response.ErrorCode, response.Description, response.Parameters);
        }

        return response.Result;
    }

    public async Task<byte[]> GetFileBytesAsync(string filePath, CancellationToken cancellation = default)
    {
        try
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new ArgumentNullException(nameof(_token));
            }

            using var response = await _httpClient.GetAsync($"/file/bot{_token}/{filePath}", cancellation);
            var bytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return bytes;
        }
        catch (Exception e)
        {
            throw new ApiRequestException(500, e.Message);
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

        var properties = _parametersCache.GetOrAdd(parameters.GetType(), type => type.GetProperties());
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
                else if (value is IEnumerable<InputMedia> mediaList)
                {
                    var jsonArray = PrepareMediaGroup(mediaList, httpContent);
                    httpContent.Add(new StringContent(jsonArray, Encoding.UTF8), _fieldNamesCache.GetOrAdd(property.Name, name => name.ToSnake()));
                }
                else
                {
                    httpContent.Add(new StringContent(value is string s ? s : value.Serialize(), Encoding.UTF8), _fieldNamesCache.GetOrAdd(property.Name, name => name.ToSnake()));
                }
            }

            if (!hasParameters)
            {
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

    private string PrepareMediaGroup(IEnumerable<InputMedia> mediaList, MultipartFormDataContent content)
    {
        var jsonArray = new JsonArray();
        var fileIdx = 0;

        foreach (var inputMedia in mediaList)
        {
            var node = JsonSerializer.SerializeToNode(inputMedia, JsonSerializerExtensions.Options)!.AsObject();
            if (inputMedia.Media.Value is InputFile file)
            {
                var attachName = $"attach_{fileIdx++}";
                content.Add(new StreamContent(file.GetStream()), attachName, file.FileName);

                node["media"] = $"attach://{attachName}";
            }

            jsonArray.Add(node);
        }

        return jsonArray.ToJsonString();
    }
}
