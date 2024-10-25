using System.Text.RegularExpressions;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.IO;
using Telegram.BotAPI.Extensions;
using System.Text.Json;
using System.Linq;
using Telegram.BotAPI.MethodArgs;

namespace Telegram.BotAPI;

public partial class TelegramBotAPIClient(HttpClient httpClient)
{
    public string Token { get; set; }

    public HttpClient HttpClient { get; set; } = httpClient ?? new HttpClient();

    public bool IsDebug { get; set; }

    public async Task<ResponseAPI<T>> RequestAsync<T>(string method, RequestArgs args = null)
    {
        try
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException(nameof(Token));
            }

            // TODO: debug method? request args? response?

            var url = $"https://api.telegram.org/bot{Token}/{method}";

            HttpResponseMessage response;

            if (args != null)
            {
                if (args.GetInputFiles().Any())
                {
                    var content = new MultipartFormDataContent();
                    foreach (var inputFile in args.GetInputFiles())
                    {
                        content.Add(new StreamContent(new MemoryStream(inputFile.Bytes)), inputFile.Name, inputFile.FileName);
                    }

                    var properties = args?.ToDictionary();
                    if (properties != null)
                    {
                        foreach (var property in properties)
                        {
                            if (property.Value == null) continue;

                            var element = (JsonElement)property.Value;

                            switch (element.ValueKind)
                            {
                                case JsonValueKind.String:
                                case JsonValueKind.Number:
                                case JsonValueKind.Array:
                                case JsonValueKind.False:
                                case JsonValueKind.True:
                                    {
                                        content.Add(new StringContent(property.Value.ToString()), property.Key);
                                        break;
                                    }

                                /*case JsonValueKind.Object: { break; }*/

                                default: throw new ArgumentOutOfRangeException(element.ValueKind.ToString(), property.Value, property.Key);
                            }
                        }
                    }

                    response = await HttpClient.PostAsync(url, content);
                }
                else
                {
                    response = await HttpClient.PostAsJsonAsync(url, args);
                }
            }
            else
            {
                response = await HttpClient.GetAsync(url);
            }

            var responseApi = await response.Content.ReadAsJsonAsync<ResponseAPI<T>>(); // ReadAsJsonAsync
            if (responseApi != null && !responseApi.Ok && responseApi.ErrorCode == 429)
            {
                var match = Regex.Match(responseApi.Description ?? "", @"retry after (\d+)");
                var delay = match.Success ? int.Parse(match.Groups[1].Value) + 60 : 60;

                await Task.Delay(delay * 1000);

                return await RequestAsync<T>(method, args);
            }

            return responseApi;
        }
        catch (Exception e)
        {
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

            var response = await HttpClient.GetAsync($"https://api.telegram.org/file/bot{Token}/{filePath}");
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
