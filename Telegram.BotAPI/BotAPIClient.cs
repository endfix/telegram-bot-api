using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Log;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    private readonly string _token;

    private static HttpClient _httpClient;

    public event EventHandler<LogEventArgs> OnLogEvent;

    public BotApiClient(string token, HttpClient httpClient = null)
    {
        _token = token;
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.telegram.org");
    }

    public async Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new ArgumentNullException(nameof(_token));
            }

            if (string.IsNullOrEmpty(request.MethodName))
            {
                throw new ArgumentNullException(nameof(request.MethodName));
            }

            OnLogEvent?.Invoke(this, new LogEventArgs
            {
                Level = LogEventLevel.Verbose,
                Message = $"-> {request.MethodName}"
            });

            var responseMessage = await getResponse(request);
            var apiResponse = (await responseMessage.Content.ReadAsStringAsync()).Deserialize<ApiResponse<T>>();

            if (apiResponse.ErrorCode == 429)
            {
                OnLogEvent?.Invoke(this, new LogEventArgs
                {
                    Level = LogEventLevel.Warn,
                    Message = $"<- {request.MethodName} ({apiResponse.Description ?? "Too Many Requests"})"
                });

                await Task.Delay((apiResponse.Parameters?.RetryAfter ?? 0) * 60 * 1000);

                return await RequestAsync<T>(request);
            }

            OnLogEvent?.Invoke(this, new LogEventArgs
            {
                Level = LogEventLevel.Verbose,
                Message = $"<- {request.MethodName} ({(apiResponse.Ok ? "OK" : apiResponse.Description)})"
            });

            return apiResponse;
        }
        catch (Exception e)
        {
            if (e is HttpRequestException requestException && requestException.InnerException is SocketException) {
                OnLogEvent?.Invoke(this, new LogEventArgs
                {
                    Level = LogEventLevel.Error,
                    Message = $"<- {request.MethodName} ({e.Message})"
                });

                await Task.Delay(60 * 1000);
                return await RequestAsync<T>(request);
            }
            
            var response = new ApiResponse<T>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };

            OnLogEvent?.Invoke(this, new LogEventArgs
            {
                Level = LogEventLevel.Error,
                Message = $"<- {request.MethodName} ({e.Message})"
            });

            return response;
        }
    }

    public async Task<ApiResponse<byte[]>> GetFileBytesAsync(string filePath)
    {
        try
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new ArgumentNullException(nameof(_token));
            }

            var response = await _httpClient.GetAsync($"/file/bot{_token}/{filePath}");
            var bytes = await response.Content.ReadAsByteArrayAsync();

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

    private async Task<HttpResponseMessage> getResponse(ApiRequest request)
    {
        var requestUri = $"/bot{_token}/{request.MethodName}";

        var properties = request.Parameters?.GetType().GetProperties().Where(property => property.GetValue(request.Parameters) != null);
        if (properties != null && properties.Any())
        {
            var httpContent = new MultipartFormDataContent();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(request.Parameters);
                if (propertyValue is InputFile inputFile)
                {
                    httpContent.Add(new StreamContent(new MemoryStream(inputFile.Bytes)), inputFile.Name.Serialize(), inputFile.FileName);
                }
                else
                {
                    var propertyType = Type.GetTypeCode(propertyValue.GetType());
                    var content = new StringContent(propertyType is TypeCode.Object ? propertyValue.Serialize() : propertyValue.ToString(), Encoding.UTF8);

                    httpContent.Add(content, property.Name.ToSnake());
                }
            }

            return await _httpClient.PostAsync(requestUri, httpContent);
        }

        return await _httpClient.GetAsync(requestUri);
    }
}
