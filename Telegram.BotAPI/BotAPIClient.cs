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

public sealed partial class BotApiClient
{
    public delegate void UpdateHandler(BotApiClient client, Update update);

    public event UpdateHandler? OnUpdate;

    private readonly string _token;

    private readonly HttpClient _httpClient;

    private readonly ILogger<BotApiClient> _logger;

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _parametersCache = new();

    private static readonly ConcurrentDictionary<string, string> _fieldNamesCache = new();

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

                var tasks = new List<Task>();

                var updates = await GetUpdatesAsync(pollingParameters, cancellationToken).ConfigureAwait(false);
                if (updates is { Count: > 0 })
                {
                    foreach (var update in updates)
                    {
                        tasks.Add(Task.Run(() =>
                        {
                            try
                            {
                                OnUpdate?.Invoke(this, update);
                            }
                            catch (Exception e)
                            {
                                _logger.LogError("OnUpdate Id: {UpdateId} Message: {Message}", update.UpdateId, e.Message);
                            }
                        }));

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
                Result = default!
            };

            return response;
        }
    }

    private async Task<TResult> ExecuteAsync<TResult>(ApiRequest request, CancellationToken cancellationToken)
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
