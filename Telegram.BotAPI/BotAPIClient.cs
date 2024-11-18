using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Core;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI;

public partial class BotAPIClient(string token, HttpClient httpClient = null)
{
    public string Token { get; set; } = token;

    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();

    public delegate void LogEventHandler(LogTypes type, string message);

    public event LogEventHandler OnLog;

    private void LogCallback(LogTypes type, string message)
    {
        OnLog(type, message);
    }

    // TODO: error mode: silent | throw exception?
    public async Task<ResponseAPI<T>> RequestAsync<T>(string methodName, object requestParameters = null)
    {
        var requestId = Guid.NewGuid().ToString();

        try
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException(nameof(Token));
            }

            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            var url = $"https://api.telegram.org/bot{Token}/{methodName}";

            HttpResponseMessage response;

            var propertiesInfo = requestParameters?.GetType().GetProperties().Where(property => property.GetValue(requestParameters) is not null);

            if (propertiesInfo is not null && propertiesInfo.Any())
            {
                HttpContent content = null;
                if (propertiesInfo.Any(propety => propety.PropertyType == typeof(InputFile) || propety.PropertyType.BaseType == typeof(InputFile)))
                {
                    content = new MultipartFormDataContent();
                    foreach (var property in propertiesInfo)
                    {
                        if (property.GetValue(requestParameters) is InputFile inputFile)
                        {
                            ((MultipartFormDataContent)content).Add(new StreamContent(new MemoryStream(inputFile.Bytes)), inputFile.Name, inputFile.FileName);
                        }
                        else
                        {
                            ((MultipartFormDataContent)content).Add(new StringContent(property.GetValue(requestParameters).ToString(), Encoding.UTF8), property.Name.ToSnake());
                        }
                    }
                }
                else
                {
                    content = new StringContent(requestParameters.Serialize(), Encoding.UTF8, "application/json");
                }

                LogCallback(LogTypes.INFO, $"ID: [{requestId}] Method: [{methodName}] Type: POST");
                LogCallback(LogTypes.DEBUG, $"ID: [{requestId}] Parameters RAW: \n{requestParameters.Serialize()}");

                response = await _httpClient.PostAsync(url, content);
            }
            else
            {
                LogCallback(LogTypes.INFO, $"ID: [{requestId}] Method: [{methodName}] Type: GET");

                response = await _httpClient.GetAsync(url);
            }

            var responseApiRaw = await response.Content.ReadAsStringAsync();

            LogCallback(LogTypes.DEBUG, $"ID: [{requestId}] Response RAW: \n{((responseApiRaw).Deserialize<ResponseAPI<T>>()).Serialize()}");

            var responseApi = responseApiRaw.Deserialize<ResponseAPI<T>>();

            LogCallback(LogTypes.INFO, $"ID: {requestId} Result: {(responseApi.Ok ? "OK" : responseApi.Description)}");

            if (responseApi is not null && !responseApi.Ok && responseApi.ErrorCode == 429)
            {
                LogCallback(LogTypes.WARN, $"ID: {requestId} {responseApi.ErrorCode}: {responseApi.Description}");

                //var match = Regex.Match(responseApi.Description ?? "", @"retry after (\d+)");
                //var delay = match.Success ? int.Parse(match.Groups[1].Value) + 60 : 60;
                var delay = responseApi.Parameters?.RetryAfter ?? 60;

                await Task.Delay(delay * 1000);

                return await RequestAsync<T>(methodName, requestParameters);
            }

            return responseApi;
        }
        catch (Exception e)
        {
            LogCallback(LogTypes.FATAL, $"ID: {requestId} Method: [{methodName}] Description: {e.Message}");

            /*
             * TODO: check the next messages? try again request?
             * "Network is unreachable (api.telegram.org:443)"
             * "Name or service not known (api.telegram.org:443)"
             * "An error occurred while sending the request."
             */

            return new ResponseAPI<T>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };
        }
    }

    public async Task<ResponseAPI<byte[]>> GetFileBytesAsync(string filePath)
    {
        try
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException(nameof(Token));
            }

            var response = await _httpClient.GetAsync($"https://api.telegram.org/file/bot{Token}/{filePath}");
            var bytes = await response.Content.ReadAsByteArrayAsync();

            return new ResponseAPI<byte[]>
            {
                Ok = true,
                Result = bytes
            };
        }
        catch (Exception e)
        {
            return new ResponseAPI<byte[]>
            {
                Ok = false,
                ErrorCode = 500,
                Description = e.Message,
                Result = default
            };
        }
    }
}
