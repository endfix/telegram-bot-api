using System.Net;
using System.Net.Http;
using System.Text;
using BenchmarkDotNet.Attributes;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

[MemoryDiagnoser]
public class TransportBenchmarks
{
    private BotApiClient _client = null!;
    private ApiRequest _request = null!;

    [GlobalSetup]
    public void Setup()
    {
        var handler = new BenchmarkHandler();
        _client = new BotApiClient("benchmark-token", new HttpClient(handler));
        _request = new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = 989722390L,
            Text = "Benchmark message"
        });
    }

    [Benchmark]
    public async Task<Message> RequestAndDeserialize() =>
        (await _client.RequestAsync<Message>(_request)).Result;

    private sealed class BenchmarkHandler : HttpMessageHandler
    {
        private const string ResponseJson = "{\"ok\":true,\"result\":{\"message_id\":1001,\"date\":1786471241,\"chat\":{\"id\":989722390,\"type\":\"private\",\"first_name\":\"Benchmark\"},\"text\":\"Benchmark response\"}}";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseJson, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        }
    }
}
