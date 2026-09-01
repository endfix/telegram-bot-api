using System.Net;
using System.Text;
using BenchmarkDotNet.Attributes;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

[MemoryDiagnoser]
public class MultipartBenchmarks
{
    private BotApiClient _client = null!;
    private HttpClient _httpClient = null!;
    private string _filePath = null!;
    private ApiRequest _sendMessage = null!;
    private ApiRequest _sendPhotoByFileId = null!;
    private ApiRequest _sendPhotoByLocalFile = null!;
    private ApiRequest _sendMediaGroupByFileId = null!;
    private ApiRequest _sendMediaGroupByLocalFile = null!;
    private ApiRequest _sendPollWithLocalFiles = null!;
    private ApiRequest _sendRichMessageWithLocalFiles = null!;

    [GlobalSetup]
    public void Setup()
    {
        _filePath = Path.Combine(Path.GetTempPath(), $"telegram-bot-api-benchmark-{Guid.NewGuid():N}.bin");
        File.WriteAllBytes(_filePath, new byte[256]);

        _httpClient = new HttpClient(new BenchmarkHandler());
        _client = new BotApiClient("benchmark-token", _httpClient);

        _sendMessage = new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = 989722390L,
            Text = "Benchmark message"
        });
        _sendPhotoByFileId = new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 989722390L,
            Photo = "telegram-photo-file-id"
        });
        _sendPhotoByLocalFile = new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 989722390L,
            Photo = new InputPhotoFile(_filePath)
        });
        _sendMediaGroupByFileId = new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 989722390L,
            Media = Enumerable.Range(0, 10)
                .Select(index => (InputMedia)new InputMediaPhoto
                {
                    Media = $"telegram-photo-file-id-{index}",
                    Caption = $"Photo {index}"
                })
                .ToArray()
        });
        _sendMediaGroupByLocalFile = new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 989722390L,
            Media = Enumerable.Range(0, 10)
                .Select(index => (InputMedia)new InputMediaPhoto
                {
                    Media = new InputPhotoFile(_filePath),
                    Caption = $"Photo {index}"
                })
                .ToArray()
        });
        _sendPollWithLocalFiles = new ApiRequest("sendPoll", new SendPollParameters
        {
            ChatId = 989722390L,
            Question = "Multipart benchmark?",
            Options =
            [
                new InputPollOption
                {
                    Text = "Nested file",
                    Media = new InputMediaPhoto
                    {
                        Media = new InputPhotoFile(_filePath)
                    }
                },
                new InputPollOption { Text = "Plain option" }
            ],
            Description = "Nested poll media",
            Media = new InputMediaPhoto
            {
                Media = new InputPhotoFile(_filePath)
            }
        });
        _sendRichMessageWithLocalFiles = new ApiRequest("sendRichMessage", new SendRichMessageParameters
        {
            ChatId = 989722390L,
            RichMessage = new InputRichMessage
            {
                Blocks =
                [
                    new InputRichBlockPhoto
                    {
                        Photo = new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(_filePath)
                        }
                    }
                ],
                Media =
                [
                    new InputRichMessageMedia
                    {
                        Id = "photo",
                        Media = new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(_filePath)
                        }
                    }
                ]
            }
        });
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _httpClient.Dispose();
        File.Delete(_filePath);
    }

    [Benchmark(Baseline = true)]
    public Task<bool> SendMessage() => ExecuteAsync(_sendMessage);

    [Benchmark]
    public Task<bool> SendPhotoByFileId() => ExecuteAsync(_sendPhotoByFileId);

    [Benchmark]
    public Task<bool> SendPhotoByLocalFile() => ExecuteAsync(_sendPhotoByLocalFile);

    [Benchmark]
    public Task<bool> SendMediaGroupByFileId10() => ExecuteAsync(_sendMediaGroupByFileId);

    [Benchmark]
    public Task<bool> SendMediaGroupByLocalFile10() => ExecuteAsync(_sendMediaGroupByLocalFile);

    [Benchmark]
    public Task<bool> SendPollWithNestedLocalFiles() => ExecuteAsync(_sendPollWithLocalFiles);

    [Benchmark]
    public Task<bool> SendRichMessageWithNestedLocalFiles() => ExecuteAsync(_sendRichMessageWithLocalFiles);

    private async Task<bool> ExecuteAsync(ApiRequest request) =>
        (await _client.RequestAsync<bool>(request).ConfigureAwait(false)).Result;

    private sealed class BenchmarkHandler : HttpMessageHandler
    {
        private const string ResponseJson = "{\"ok\":true,\"result\":true}";

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseJson, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        }
    }
}
