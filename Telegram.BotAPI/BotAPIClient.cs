using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using Telegram.BotAPI.Extensions;
using System.Threading.Tasks;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Log;
using System.Diagnostics;

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

            HttpResponseMessage response;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var properties = request.Parameters?.GetType().GetProperties().Where(property => property.GetValue(request.Parameters) is not null);
            if (properties is not null && properties.Any())
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
                        switch (propertyType)
                        {
                            case TypeCode.String:
                            case TypeCode.Boolean:
                            case TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64:
                            case TypeCode.Object:
                                {
                                    var content = new StringContent(propertyType is TypeCode.Object ? propertyValue.Serialize() : propertyValue.ToString(), Encoding.UTF8);
                                    httpContent.Add(content, property.Name.ToSnake());
                                    break;
                                }
                            default:
                                {
                                    throw new NotSupportedException($"Unsupported type: {propertyType}");
                                }
                        }
                    }
                }
                response = await _httpClient.PostAsync($"/bot{_token}/{request.MethodName}", httpContent);
            }
            else
            {
                response = await _httpClient.GetAsync($"/bot{_token}/{request.MethodName}");
            }

            stopwatch.Stop();

            var responseRaw = await response.Content.ReadAsStringAsync();
            var responseApi = responseRaw.Deserialize<ApiResponse<T>>();

            //responseApi.Id = request.Id;
            //responseApi.Raw = responseRaw;
            //responseApi.Elapsed = stopwatch.Elapsed;

            OnLogEvent?.Invoke(this, new LogEventArgs{ 
                Level = LogEventLevel.Info, 
                Request = request, Response = responseApi 
            });

            if (responseApi.ErrorCode == 429)
            {
                OnLogEvent?.Invoke(this, new LogEventArgs
                {
                    Level = LogEventLevel.Warn,
                    Request = request,
                    Response = responseApi
                });
                await Task.Delay((responseApi.Parameters?.RetryAfter ?? 0) * 60 * 1000);

                return await RequestAsync<T>(request);
            }

            return responseApi;
        }
        catch (Exception e)
        {
            /*
             * TODO: check the next messages:
             * "Network is unreachable (api.telegram.org:443)"
             * "Name or service not known (api.telegram.org:443)"
             * "An error occurred while sending the request."
             * 
             * then try again request?
             */

            var response = new ApiResponse<T>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };

            OnLogEvent?.Invoke(this, new LogEventArgs { 
                Level = LogEventLevel.Error,
                Request = request,
                Response = response
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
}
