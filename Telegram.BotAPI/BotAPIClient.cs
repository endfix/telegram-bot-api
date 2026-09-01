using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Endfix.Telegram.BotAPI;

public sealed partial class BotApiClient : IBotApiClient, IDisposable
{
    /// <summary>
    /// Raised for each update received by long polling. Subscribers are invoked
    /// in registration order and each returned task is awaited. The cancellation
    /// token signals that the active polling session is stopping.
    /// </summary>
    public event UpdateHandler? OnUpdate;

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _parametersCache = new();

    private static readonly ConcurrentDictionary<string, string> _fieldNamesCache = new();

    private static readonly Uri _defaultBaseAddress = new("https://api.telegram.org");

    private readonly string _token;

    private readonly HttpClient _httpClient;

    private readonly bool _ownsHttpClient;

    private readonly Uri _baseAddress;

    private readonly int _maxRetryAttempts;
    
    private readonly ILogger<IBotApiClient> _logger;

    /// <summary>
    /// Creates a Telegram Bot API client.
    /// </summary>
    /// <param name="token">The bot token issued by BotFather.</param>
    /// <param name="httpClient">
    /// The HTTP client used for API requests. The caller retains ownership of a supplied instance.
    /// </param>
    /// <param name="url">An optional Bot API base URL.</param>
    /// <param name="maxRetryAttempts">The maximum number of automatic retries for Telegram rate-limit responses.</param>
    /// <param name="logger">An optional client logger.</param>
    public BotApiClient(
        string token, 
        HttpClient? httpClient = null, 
        string? url = null, 
        int maxRetryAttempts = 6,
        ILogger<IBotApiClient>? logger = null)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));

        if (maxRetryAttempts < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxRetryAttempts));
        }

        var explicitBaseAddress = url is null ? null : new Uri(url, UriKind.Absolute);

        _ownsHttpClient = httpClient is null;
        _httpClient = httpClient ?? new HttpClient();

        _baseAddress = explicitBaseAddress ?? _httpClient.BaseAddress ?? _defaultBaseAddress;

        _maxRetryAttempts = maxRetryAttempts;

        _logger = logger ?? NullLogger<IBotApiClient>.Instance;
    }

    /// <summary>
    /// Releases the HTTP client created internally by this instance.
    /// A client supplied to the constructor is not disposed.
    /// </summary>
    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
    
    /// <summary>
    /// Sends a request and returns the Telegram API response envelope.
    /// </summary>
    /// <remarks>
    /// Telegram errors are returned with <c>Ok = false</c>. Argument, cancellation,
    /// transport, HTTP, and JSON failures retain their standard .NET exception types.
    /// Only Telegram rate-limit responses are retried automatically.
    /// </remarks>
    public async Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request, CancellationToken cancellation = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        for (var retryCount = 0; ; retryCount++)
        {
            using var responseMessage = await GetResponse(request, cancellation).ConfigureAwait(false);

            ApiResponse<T>? apiResponse;
            try
            {
                using var responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                apiResponse = await responseStream.DeserializeAsync<ApiResponse<T>>(cancellation).ConfigureAwait(false);
            }
            catch (JsonException) when (!responseMessage.IsSuccessStatusCode)
            {
                responseMessage.EnsureSuccessStatusCode();
                throw;
            }

            if (apiResponse is null)
            {
                responseMessage.EnsureSuccessStatusCode();
                throw new JsonException($"Failed to deserialize the response from {request.MethodName}: response was empty.");
            }

            if (!apiResponse.Ok && apiResponse.ErrorCode <= 0)
            {
                responseMessage.EnsureSuccessStatusCode();
                throw new JsonException($"The response from {request.MethodName} does not contain a valid Telegram error code.");
            }

            if (apiResponse.Ok && !responseMessage.IsSuccessStatusCode)
            {
                responseMessage.EnsureSuccessStatusCode();
            }

            if (apiResponse.Ok || apiResponse.ErrorCode != 429 || retryCount >= _maxRetryAttempts)
            {
                return apiResponse;
            }

            var retryAfter = Math.Max(apiResponse.Parameters?.RetryAfter ?? 1, 0);
            _logger.LogWarning(
                "RequestAsync {Method}: Telegram rate limit, retrying after {RetryAfter} seconds ({Attempt}/{MaxAttempts}).",
                request.MethodName,
                retryAfter,
                retryCount + 1,
                _maxRetryAttempts);

            await Task.Delay(TimeSpan.FromSeconds(retryAfter), cancellation).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Sends a request and returns its result, throwing <see cref="ApiRequestException"/>
    /// when Telegram returns an unsuccessful API response.
    /// </summary>
    public async Task<TResult> ExecuteAsync<TResult>(ApiRequest request, CancellationToken cancellationToken)
    {
        var response = await RequestAsync<TResult>(request, cancellationToken);
        if (!response.Ok)
        {
            throw new ApiRequestException(response.ErrorCode, response.Description, response.Parameters);
        }

        return response.Result;
    }

    /// <summary>
    /// Downloads a Telegram file and rejects unsuccessful HTTP responses.
    /// </summary>
    public async Task<byte[]> GetFileBytesAsync(string filePath, CancellationToken cancellation = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(filePath));
        }

        using var response = await _httpClient
            .GetAsync(new Uri(_baseAddress, $"/file/bot{_token}/{filePath}"), cancellation)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
    }

    private async Task<HttpResponseMessage> GetResponse(ApiRequest request, CancellationToken cancellation)
    {
        var requestUri = new Uri(_baseAddress, $"/bot{_token}/{request.MethodName}");
        var parameters = request.Parameters;
        

        if (parameters is null)
        {
            return await _httpClient.GetAsync(requestUri, cancellation).ConfigureAwait(false);
        }

        var properties = _parametersCache.GetOrAdd(parameters.GetType(), type => type.GetProperties());
        var hasParameters = false;
        var fileIdx = 0;
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

                if (value is IFileSource source)
                {
                    value = source.Value;
                }

                if (value is InputFile inputFile)
                {
                    httpContent.Add(
                        new StreamContent(inputFile.GetStream()),
                        _fieldNamesCache.GetOrAdd(property.Name, name => name.ToSnake()),
                        inputFile.FileName);
                }
                else
                {
                    var serializedValue = SerializeMultipartValue(
                        value,
                        httpContent,
                        ref fileIdx);

                    httpContent.Add(
                        new StringContent(serializedValue, Encoding.UTF8),
                        _fieldNamesCache.GetOrAdd(property.Name, name => name.ToSnake()));
                }
            }

            if (!hasParameters)
            {
                return await _httpClient.GetAsync(requestUri, cancellation).ConfigureAwait(false);
            }

            return await _httpClient.PostAsync(requestUri, httpContent, cancellation).ConfigureAwait(false);
        }
        finally
        {
            httpContent.Dispose();
        }
    }

    public async Task<IReadOnlyDictionary<string, Currency>> GetCurrencies(CancellationToken cancellation = default)
    {
        try
        {
            using var response = await _httpClient.GetAsync("https://core.telegram.org/bots/payments/currencies.json", cancellation);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var result = await stream.DeserializeAsync<Dictionary<string, Currency>>(cancellation);

            return result ?? throw new InvalidOperationException("Failed to deserialize currencies: response was empty or wrong syntax.");
        }
        catch (JsonException ex)
        {
            _logger.LogError("JSON Error: {Message} at {Path}", ex.Message, ex.Path);
            throw;
        }
    }

    private static JsonNode PrepareJsonValue(
        object value,
        MultipartFormDataContent content,
        ref int fileIdx)
    {
        var node = JsonSerializer.SerializeToNode(
            value,
            value.GetType(),
            JsonSerializerExtensions.Options)
            ?? throw new JsonException($"Failed to serialize {value.GetType().Name}.");

        return ReplaceNestedFiles(value, node, content, ref fileIdx)
            ?? throw new JsonException($"Failed to prepare {value.GetType().Name}.");
    }

    private static string SerializeMultipartValue(
        object value,
        MultipartFormDataContent content,
        ref int fileIdx)
    {
        if (value is string text)
        {
            return text;
        }

        if (value is ChatIdSource chatId)
        {
            return SerializeMultipartValue(chatId.Value, content, ref fileIdx);
        }

        var valueType = value.GetType();
        if ((valueType.IsPrimitive && value is not char) || value is decimal)
        {
            return JsonSerializer.Serialize(
                value,
                valueType,
                JsonSerializerExtensions.Options);
        }

        var node = PrepareJsonValue(value, content, ref fileIdx);
        return node is JsonValue jsonValue && jsonValue.TryGetValue<string>(out var stringValue)
            ? stringValue
            : node.ToJsonString();
    }

    private static JsonNode? ReplaceNestedFiles(
        object value,
        JsonNode? node,
        MultipartFormDataContent content,
        ref int fileIdx)
    {
        if (value is IFileSource source)
        {
            value = source.Value;
        }

        if (value is InputFile file)
        {
            var attachName = $"attach_{fileIdx++}";
            content.Add(new StreamContent(file.GetStream()), attachName, file.FileName);
            return JsonValue.Create($"attach://{attachName}");
        }

        if (value is IEnumerable values and not string && node is JsonArray array)
        {
            var index = 0;
            foreach (var item in values)
            {
                if (item is not null && index < array.Count)
                {
                    var itemNode = array[index];
                    var preparedNode = ReplaceNestedFiles(item, itemNode, content, ref fileIdx);
                    if (!ReferenceEquals(itemNode, preparedNode))
                    {
                        array[index] = preparedNode;
                    }
                }

                index++;
            }

            return array;
        }

        if (node is JsonObject jsonObject)
        {
            var properties = _parametersCache
                .GetOrAdd(value.GetType(), type => type.GetProperties())
                .OrderBy(property => GetFilePropertyPriority(property.Name));

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value);
                if (propertyValue is null)
                {
                    continue;
                }

                var propertyName = JsonSerializerExtensions.Options.PropertyNamingPolicy?.ConvertName(property.Name)
                    ?? property.Name;
                if (jsonObject.TryGetPropertyValue(propertyName, out var propertyNode))
                {
                    var preparedNode = ReplaceNestedFiles(
                        propertyValue,
                        propertyNode,
                        content,
                        ref fileIdx);

                    if (!ReferenceEquals(propertyNode, preparedNode))
                    {
                        jsonObject[propertyName] = preparedNode;
                    }
                }
            }
        }

        return node;
    }

    private static int GetFilePropertyPriority(string propertyName)
        => propertyName switch
        {
            "Media" => 0,
            "Photo" => 1,
            "Video" => 2,
            "Animation" => 3,
            "Sticker" => 4,
            "Thumbnail" => 5,
            "Cover" => 6,
            _ => 7
        };
}
