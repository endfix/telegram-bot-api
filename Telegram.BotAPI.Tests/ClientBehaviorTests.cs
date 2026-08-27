using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class ClientBehaviorTests
{
    [Fact]
    public async Task RequestAsync_ReturnsDeserializedResult()
    {
        using var context = new ClientContext("{\"ok\":true,\"result\":{\"id\":5601506620,\"is_bot\":true,\"first_name\":\"Test Bot\",\"username\":\"test_bot\"}}");

        var response = await context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        response.Ok.Should().BeTrue();
        response.Result.Should().NotBeNull();
        response.Result.Id.Should().Be(5601506620L);
        response.Result.IsBot.Should().BeTrue();
        response.Result.Username.Should().Be("test_bot");
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsForApiError()
    {
        using var context = new ClientContext("{\"ok\":false,\"error_code\":400,\"description\":\"Bad request\"}");

        var action = () => context.Client.ExecuteAsync<User>(
            new ApiRequest("getMe", parameters: null),
            CancellationToken.None);

        var exception = await action.Should().ThrowAsync<ApiRequestException>();
        exception.Which.ErrorCode.Should().Be(400);
        exception.Which.Message.Should().Be("Bad request");
    }

    [Fact]
    public async Task RequestAsync_DoesNotRetry429_WhenRetryDelaysAreEmpty()
    {
        using var context = new ClientContext("{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":0}}", retryDelays: []);

        var response = await context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        response.Ok.Should().BeFalse();
        response.ErrorCode.Should().Be(429);
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task RequestAsync_ObservesCancellation()
    {
        using var context = new ClientContext();
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null),
            cancellation.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
        context.Handler.RequestCount.Should().Be(0);
    }

    [Fact]
    public async Task Constructor_PreservesExistingHttpClientBaseAddress()
    {
        using var context = new ClientContext(baseAddress: "https://custom.example");

        await context.Client.RequestAsync<User>(new ApiRequest("getMe", parameters: null));

        context.Handler.LastRequestUri.Should().Be("https://custom.example/bottest-token/getMe");
    }

    [Fact]
    public async Task Constructor_UsesExplicitUrlOverHttpClientBaseAddress()
    {
        using var context = new ClientContext(
            baseAddress: "https://custom.example",
            url: "https://explicit.example");

        await context.Client.RequestAsync<User>(new ApiRequest("getMe", parameters: null));

        context.Handler.LastRequestUri.Should().Be("https://explicit.example/bottest-token/getMe");
    }

    [Fact]
    public void Parameters_UseSnakeCaseNames()
    {
        var parameters = new SendMessageParameters
        {
            ChatId = 989722390L,
            MessageThreadId = 42,
            DirectMessagesTopicId = 7,
            Text = "contract"
        };

        using var document = JsonDocument.Parse(parameters.Serialize());
        var names = document.RootElement.EnumerateObject().Select(property => property.Name).ToArray();

        names.Should().BeEquivalentTo(
            ["chat_id", "message_thread_id", "direct_messages_topic_id", "text"],
            options => options.WithStrictOrdering());
    }

    private sealed class ClientContext : IDisposable
    {
        private readonly HttpClient _httpClient;

        public ClientContext(
            string responseJson = "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}",
            IReadOnlyList<int>? retryDelays = null,
            string? baseAddress = null,
            string? url = null)
        {
            Handler = new ResponseHandler(responseJson);
            _httpClient = new HttpClient(Handler);
            if (baseAddress is not null)
            {
                _httpClient.BaseAddress = new Uri(baseAddress);
            }

            Client = new BotApiClient("test-token", _httpClient, url, retryDelays);
        }

        public ResponseHandler Handler { get; }

        public BotApiClient Client { get; }

        public void Dispose() => _httpClient.Dispose();
    }

    private sealed class ResponseHandler(string responseJson) : HttpMessageHandler
    {
        public int RequestCount { get; private set; }

        public string? LastRequestUri { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            RequestCount++;
            LastRequestUri = request.RequestUri?.ToString();

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            });
        }
    }
}
