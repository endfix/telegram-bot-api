using System.Net;
using System.Text;
using BenchmarkDotNet.Attributes;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

[MemoryDiagnoser]
public class MultipartDiagnosticFileBenchmarks
{
    [Params(256, 65_536, 1_048_576)]
    public int FileSize { get; set; }

    private string _filePath = null!;

    [GlobalSetup]
    public void Setup()
    {
        _filePath = MultipartDiagnosticData.CreateFile(FileSize);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_filePath);
    }

    [Benchmark]
    public long OpenLocalFile()
    {
        using var stream = File.OpenRead(_filePath);
        return stream.Length;
    }
}

[MemoryDiagnoser]
public class MultipartDiagnosticStreamBenchmarks
{
    [Params(256, 65_536, 1_048_576)]
    public int FileSize { get; set; }

    [Params(1, 10)]
    public int FileCount { get; set; }

    private byte[] _payload = null!;
    private string _filePath = null!;

    [GlobalSetup]
    public void Setup()
    {
        _payload = new byte[FileSize];
        _filePath = MultipartDiagnosticData.CreateFile(_payload);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_filePath);
    }

    [Benchmark(Baseline = true)]
    public Task<int> WriteFileStreams() =>
        BuildAndWriteAsync(() => File.OpenRead(_filePath));

    [Benchmark]
    public Task<int> WritePreloadedMemoryStreams() =>
        BuildAndWriteAsync(() => new MemoryStream(_payload, writable: false));

    private async Task<int> BuildAndWriteAsync(Func<Stream> createStream)
    {
        using var content = new MultipartFormDataContent();

        for (var index = 0; index < FileCount; index++)
        {
            content.Add(
                new StreamContent(createStream()),
                $"file_{index}",
                $"benchmark-{index}.bin");
        }

        await content.CopyToAsync(Stream.Null).ConfigureAwait(false);
        return FileCount;
    }
}

[MemoryDiagnoser]
public class MultipartDiagnosticPipelineBenchmarks
{
    [Params(256, 65_536, 1_048_576)]
    public int FileSize { get; set; }

    private HttpClient _prepareHttpClient = null!;
    private HttpClient _writeHttpClient = null!;
    private BotApiClient _prepareClient = null!;
    private BotApiClient _writeClient = null!;
    private byte[] _payload = null!;
    private string _filePath = null!;
    private ApiRequest _scalar = null!;
    private ApiRequest _singleFile = null!;
    private ApiRequest _singleMemoryFile = null!;
    private ApiRequest _mediaGroup10 = null!;
    private ApiRequest _memoryMediaGroup10 = null!;
    private ApiRequest _nestedPoll2 = null!;
    private ApiRequest _memoryNestedPoll2 = null!;

    [GlobalSetup]
    public void Setup()
    {
        _payload = new byte[FileSize];
        _filePath = MultipartDiagnosticData.CreateFile(_payload);

        _prepareHttpClient = new HttpClient(new DiagnosticHandler(writeRequestBody: false));
        _writeHttpClient = new HttpClient(new DiagnosticHandler(writeRequestBody: true));
        _prepareClient = new BotApiClient("benchmark-token", _prepareHttpClient);
        _writeClient = new BotApiClient("benchmark-token", _writeHttpClient);

        _scalar = new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = 989722390L,
            Text = "Diagnostic benchmark"
        });
        _singleFile = new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 989722390L,
            Photo = new InputPhotoFile(_filePath)
        });
        _singleMemoryFile = new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 989722390L,
            Photo = MemoryPhoto("single-photo.jpg")
        });
        _mediaGroup10 = new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
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
        _memoryMediaGroup10 = new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 989722390L,
            Media = Enumerable.Range(0, 10)
                .Select(index => (InputMedia)new InputMediaPhoto
                {
                    Media = MemoryPhoto($"photo-{index}.jpg"),
                    Caption = $"Photo {index}"
                })
                .ToArray()
        });
        _nestedPoll2 = new ApiRequest("sendPoll", new SendPollParameters
        {
            ChatId = 989722390L,
            Question = "Diagnostic multipart benchmark?",
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
        _memoryNestedPoll2 = new ApiRequest("sendPoll", new SendPollParameters
        {
            ChatId = 989722390L,
            Question = "Diagnostic memory multipart benchmark?",
            Options =
            [
                new InputPollOption
                {
                    Text = "Nested file",
                    Media = new InputMediaPhoto
                    {
                        Media = MemoryPhoto("option-photo.jpg")
                    }
                },
                new InputPollOption { Text = "Plain option" }
            ],
            Description = "Nested memory poll media",
            Media = new InputMediaPhoto
            {
                Media = MemoryPhoto("poll-photo.jpg")
            }
        });
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _prepareHttpClient.Dispose();
        _writeHttpClient.Dispose();
        File.Delete(_filePath);
    }

    [Benchmark(Baseline = true)]
    public Task<bool> PrepareScalar() => ExecuteAsync(_prepareClient, _scalar);

    [Benchmark]
    public Task<bool> WriteScalar() => ExecuteAsync(_writeClient, _scalar);

    [Benchmark]
    public Task<bool> PrepareSingleFile() => ExecuteAsync(_prepareClient, _singleFile);

    [Benchmark]
    public Task<bool> WriteSingleFile() => ExecuteAsync(_writeClient, _singleFile);

    [Benchmark]
    public Task<bool> PrepareSingleMemoryFile() => ExecuteAsync(_prepareClient, _singleMemoryFile);

    [Benchmark]
    public Task<bool> WriteSingleMemoryFile() => ExecuteAsync(_writeClient, _singleMemoryFile);

    [Benchmark]
    public Task<bool> PrepareMediaGroup10() => ExecuteAsync(_prepareClient, _mediaGroup10);

    [Benchmark]
    public Task<bool> WriteMediaGroup10() => ExecuteAsync(_writeClient, _mediaGroup10);

    [Benchmark]
    public Task<bool> PrepareMemoryMediaGroup10() => ExecuteAsync(_prepareClient, _memoryMediaGroup10);

    [Benchmark]
    public Task<bool> WriteMemoryMediaGroup10() => ExecuteAsync(_writeClient, _memoryMediaGroup10);

    [Benchmark]
    public Task<bool> PrepareNestedPoll2() => ExecuteAsync(_prepareClient, _nestedPoll2);

    [Benchmark]
    public Task<bool> WriteNestedPoll2() => ExecuteAsync(_writeClient, _nestedPoll2);

    [Benchmark]
    public Task<bool> PrepareMemoryNestedPoll2() => ExecuteAsync(_prepareClient, _memoryNestedPoll2);

    [Benchmark]
    public Task<bool> WriteMemoryNestedPoll2() => ExecuteAsync(_writeClient, _memoryNestedPoll2);

    private InputPhotoFile MemoryPhoto(string fileName) =>
        new(InputFileSource.FromMemory(_payload, fileName));

    private static async Task<bool> ExecuteAsync(BotApiClient client, ApiRequest request) =>
        (await client.RequestAsync<bool>(request).ConfigureAwait(false)).Result;

    private sealed class DiagnosticHandler(bool writeRequestBody) : HttpMessageHandler
    {
        private const string ResponseJson = "{\"ok\":true,\"result\":true}";

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (writeRequestBody && request.Content is not null)
            {
                await request.Content
                    .CopyToAsync(Stream.Null, cancellationToken)
                    .ConfigureAwait(false);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseJson, Encoding.UTF8, "application/json")
            };
        }
    }
}

internal static class MultipartDiagnosticData
{
    public static string CreateFile(int size) => CreateFile(new byte[size]);

    public static string CreateFile(byte[] content)
    {
        var path = Path.Combine(
            Path.GetTempPath(),
            $"telegram-bot-api-diagnostic-{Guid.NewGuid():N}.bin");

        File.WriteAllBytes(path, content);
        return path;
    }
}
