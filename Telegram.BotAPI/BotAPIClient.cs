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

public sealed partial class BotApiClient : IBotApiClient
{
    public event UpdateHandler? OnUpdate;

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _parametersCache = new();

    private static readonly ConcurrentDictionary<string, string> _fieldNamesCache = new();

    private readonly string _token;

    private readonly HttpClient _httpClient;

    private IReadOnlyList<int> _retryDelays;
    
    private readonly ILogger<IBotApiClient> _logger;

    public BotApiClient(
        string token, 
        HttpClient? httpClient = null, 
        string? url = null, 
        IReadOnlyList<int>? retryDelays = null, 
        ILogger<IBotApiClient>? logger = null)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));

        _httpClient = httpClient ?? new HttpClient();

        if (url is not null)
        {
            _httpClient.BaseAddress = new Uri(url);
        }
        else
        {
            _httpClient.BaseAddress ??= new Uri("https://api.telegram.org");
        }

        _retryDelays = retryDelays ?? [5, 10, 25, 30, 60, 120];

        _logger = logger ?? NullLogger<IBotApiClient>.Instance;
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
            var apiResponse = await responseStream.DeserializeAsync<ApiResponse<T>>(cancellation);

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
            if (!cancellation.IsCancellationRequested)
            {
                _logger.LogWarning("RequestAsync {Method}: {Message}", request.MethodName, e.Message);
            }

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError("RequestAsync {Method}: {Message}", request.MethodName, e.Message);

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
        catch
        {
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
