using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using Telegram.BotAPI.Extensions;
using System.Threading.Tasks;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Core;

namespace Telegram.BotAPI;

public partial class BotApiClient(string token, HttpClient httpClient = null)
{
    public string Token { get; set; } = token;

    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();

    public event EventHandler<DebugEventArgs> OnDebug;

    // TODO: error mode: silent (event) | throw exception?
    public async Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request, ApiContext<T> context = null)
    {
        context ??= new ApiContext<T>();
        context.Request ??= request;

        try
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException(nameof(Token));
            }

            if (string.IsNullOrEmpty(request.MethodName))
            {
                throw new ArgumentNullException(nameof(request.MethodName));
            }

            var url = $"https://api.telegram.org/bot{Token}/{request.MethodName}";

            HttpResponseMessage response;

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
                                    Console.WriteLine($"Unsupported type: {propertyType}");
                                    break;
                                }
                        }
                    }
                }

                response = await _httpClient.PostAsync(url, httpContent);

                OnDebug?.Invoke(context, new DebugEventArgs("Request POST"));
            }
            else
            {
                response = await _httpClient.GetAsync(url);

                OnDebug?.Invoke(context, new DebugEventArgs("Request GET"));
            }

            var responseRaw = await response.Content.ReadAsStringAsync();
            var responseApi = responseRaw.Deserialize<ApiResponse<T>>();

            responseApi.Raw = responseRaw;
            context.Response = responseApi;

            OnDebug?.Invoke(context, new DebugEventArgs("Response"));

            if (responseApi is not null && !responseApi.Ok && responseApi.ErrorCode == 429)
            {
                await Task.Delay((responseApi.Parameters?.RetryAfter ?? 60) * 1000);

                return await RequestAsync<T>(request, context);
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

            context.Response = response;

            OnDebug?.Invoke(context, new DebugEventArgs("Exception"));

            return response;
        }
    }

    public async Task<ApiResponse<byte[]>> GetFileBytesAsync(string filePath)
    {
        try
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException(nameof(Token));
            }

            var response = await _httpClient.GetAsync($"https://api.telegram.org/file/bot{Token}/{filePath}");
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
