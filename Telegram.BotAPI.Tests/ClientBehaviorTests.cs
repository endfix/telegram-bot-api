using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Sockets;
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
        using var context = new ClientContext(responses:
        [
            ResponseHandler.ResponseMessage(
                "{\"ok\":false,\"error_code\":400,\"description\":\"Bad request\"}",
                HttpStatusCode.BadRequest)
        ]);

        var action = () => context.Client.ExecuteAsync<User>(
            new ApiRequest("getMe", parameters: null),
            CancellationToken.None);

        var exception = await action.Should().ThrowAsync<ApiRequestException>();
        exception.Which.ErrorCode.Should().Be(400);
        exception.Which.Message.Should().Be("Bad request");
    }

    [Fact]
    public async Task RequestAsync_DoesNotRetry429_WhenMaxRetryAttemptsIsZero()
    {
        using var context = new ClientContext(
            "{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":0}}",
            maxRetryAttempts: 0);

        var response = await context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        response.Ok.Should().BeFalse();
        response.ErrorCode.Should().Be(429);
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task RequestAsync_StopsRetrying429AfterConfiguredAttempts()
    {
        using var context = new ClientContext(
            "{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":0}}",
            maxRetryAttempts: 1);

        var response = await context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        response.Ok.Should().BeFalse();
        response.ErrorCode.Should().Be(429);
        context.Handler.RequestCount.Should().Be(2);
    }

    [Fact]
    public async Task RequestAsync_ObservesCancellationDuringRetryAfterDelay()
    {
        using var context = new ClientContext(
            "{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":30}}",
            maxRetryAttempts: 1);
        using var cancellation = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null),
            cancellation.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
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
    public async Task RequestAsync_DoesNotRetryHttpClientTimeout()
    {
        using var context = new ClientContext(
            responses: [
                new TaskCanceledException("request timed out"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}",
                        Encoding.UTF8,
                        "application/json")
                }
            ],
            maxRetryAttempts: 1);

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        await action.Should().ThrowAsync<TaskCanceledException>();
        context.Handler.RequestCount.Should().Be(1);
    }

    [Theory]
    [InlineData("getMe")]
    [InlineData("sendMessage")]
    public async Task RequestAsync_Retries429RegardlessOfMethod(string methodName)
    {
        using var context = new ClientContext(
            responses: [
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":0}}",
                        Encoding.UTF8,
                        "application/json")
                },
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}",
                        Encoding.UTF8,
                        "application/json")
                }
            ],
            maxRetryAttempts: 1);

        var response = await context.Client.RequestAsync<User>(
            new ApiRequest(methodName, parameters: null));

        response.Ok.Should().BeTrue();
        context.Handler.RequestCount.Should().Be(2);
    }

    [Fact]
    public async Task RequestAsync_DoesNotRetrySerializationFailure()
    {
        using var context = new ClientContext("not-json", maxRetryAttempts: 1);

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        await action.Should().ThrowAsync<JsonException>();
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task RequestAsync_RejectsJsonWithoutTelegramEnvelope()
    {
        using var context = new ClientContext("{}");

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        await action.Should().ThrowAsync<JsonException>();
    }

    [Fact]
    public async Task RequestAsync_RejectsTelegramErrorWithoutErrorCode()
    {
        using var context = new ClientContext("{\"ok\":false,\"description\":\"Broken envelope\"}");

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        await action.Should().ThrowAsync<JsonException>();
    }

    [Fact]
    public async Task RequestAsync_DoesNotRetrySocketFailure()
    {
        using var context = new ClientContext(
            responses: [
                new HttpRequestException("connection reset", new SocketException()),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}",
                        Encoding.UTF8,
                        "application/json")
                }
            ],
            maxRetryAttempts: 1);

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        await action.Should().ThrowAsync<HttpRequestException>();
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task ExecuteAsync_PreservesTransportFailure()
    {
        using var context = new ClientContext(responses:
        [
            new HttpRequestException("connection reset", new SocketException())
        ]);

        var action = () => context.Client.ExecuteAsync<User>(
            new ApiRequest("getMe", parameters: null),
            CancellationToken.None);

        await action.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task ExecuteAsync_PreservesJsonFailure()
    {
        using var context = new ClientContext("not-json");

        var action = () => context.Client.ExecuteAsync<User>(
            new ApiRequest("getMe", parameters: null),
            CancellationToken.None);

        await action.Should().ThrowAsync<JsonException>();
    }

    [Fact]
    public async Task ExecuteAsync_PreservesCallerCancellation()
    {
        using var context = new ClientContext();
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        var action = () => context.Client.ExecuteAsync<User>(
            new ApiRequest("getMe", parameters: null),
            cancellation.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
        context.Handler.RequestCount.Should().Be(0);
    }

    [Fact]
    public void ApiRequest_RejectsEmptyMethodName()
    {
        var action = () => new ApiRequest(string.Empty, parameters: null);

        action.Should().Throw<ArgumentException>()
            .WithParameterName("methodName");
    }

    [Fact]
    public async Task RequestAsync_RejectsNonTelegramHttpError()
    {
        using var context = new ClientContext(responses:
        [
            ResponseHandler.ResponseMessage("gateway error", HttpStatusCode.BadGateway)
        ]);

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        var exception = await action.Should().ThrowAsync<HttpRequestException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.BadGateway);
    }

    [Fact]
    public async Task RequestAsync_DoesNotRetryHttp429WithMalformedBody()
    {
        using var context = new ClientContext(
            maxRetryAttempts: 1,
            responses:
            [
                ResponseHandler.ResponseMessage("gateway rate limit", HttpStatusCode.TooManyRequests),
                ResponseHandler.ResponseMessage(
                    "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}")
            ]);

        var action = () => context.Client.RequestAsync<User>(
            new ApiRequest("getMe", parameters: null));

        var exception = await action.Should().ThrowAsync<HttpRequestException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.TooManyRequests);
        context.Handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task GetFileBytesAsync_ReturnsSuccessfulResponseBody()
    {
        var expected = new byte[] { 1, 2, 3, 4 };
        using var context = new ClientContext(responses:
        [
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(expected)
            }
        ]);

        var bytes = await context.Client.GetFileBytesAsync("documents/file.bin");

        bytes.Should().Equal(expected);
        context.Handler.LastRequestUri.Should().Be(
            "https://api.telegram.org/file/bottest-token/documents/file.bin");
    }

    [Fact]
    public async Task GetFileBytesAsync_RejectsHttpErrorBody()
    {
        using var context = new ClientContext(responses:
        [
            ResponseHandler.ResponseMessage("not found", HttpStatusCode.NotFound)
        ]);

        var action = () => context.Client.GetFileBytesAsync("missing.bin");

        var exception = await action.Should().ThrowAsync<HttpRequestException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetFileBytesAsync_PreservesCallerCancellation()
    {
        using var context = new ClientContext();
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        var action = () => context.Client.GetFileBytesAsync("file.bin", cancellation.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
        context.Handler.RequestCount.Should().Be(0);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task GetFileBytesAsync_RejectsEmptyPath(string? filePath)
    {
        using var context = new ClientContext();

        var action = () => context.Client.GetFileBytesAsync(filePath!);

        await action.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("filePath");
        context.Handler.RequestCount.Should().Be(0);
    }

    [Fact]
    public void Constructor_RejectsNegativeRetryCount()
    {
        var action = () => new BotApiClient("test-token", maxRetryAttempts: -1);

        action.Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("maxRetryAttempts");
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
        context.HttpClientBaseAddress.Should().Be(new Uri("https://custom.example"));
    }

    [Fact]
    public async Task Constructor_DoesNotReconfigurePreviouslyUsedHttpClient()
    {
        var handler = new ResponseHandler(
            "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}");
        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://custom.example")
        };
        await httpClient.GetAsync("warmup");
        using var client = new BotApiClient(
            "test-token",
            httpClient,
            url: "https://explicit.example");

        await client.RequestAsync<User>(new ApiRequest("getMe", parameters: null));

        httpClient.BaseAddress.Should().Be(new Uri("https://custom.example"));
        handler.LastRequestUri.Should().Be("https://explicit.example/bottest-token/getMe");
    }

    [Fact]
    public async Task Dispose_DisposesInternallyCreatedHttpClient()
    {
        var client = new BotApiClient("test-token");

        client.Dispose();

        var action = () => client.RequestAsync<User>(new ApiRequest("getMe", parameters: null));
        await action.Should().ThrowAsync<ObjectDisposedException>();
    }

    [Fact]
    public async Task Dispose_DoesNotDisposeSuppliedHttpClient()
    {
        var handler = new ResponseHandler(
            "{\"ok\":true,\"result\":{\"id\":1,\"is_bot\":true,\"first_name\":\"Test\"}}");
        using var httpClient = new HttpClient(handler);
        var client = new BotApiClient("test-token", httpClient);

        client.Dispose();

        var response = await httpClient.GetAsync("https://api.telegram.org/getMe");
        response.IsSuccessStatusCode.Should().BeTrue();
        handler.RequestCount.Should().Be(1);
    }

    [Fact]
    public async Task RemoveMyProfilePhoto_ReturnsTelegramBooleanResult()
    {
        using var context = new ClientContext("{\"ok\":true,\"result\":true}");

        var result = await context.Client.RemoveMyProfilePhotoAsync();

        result.Should().BeTrue();
        context.Handler.LastRequestUri.Should().Be("https://api.telegram.org/bottest-token/removeMyProfilePhoto");
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
            int maxRetryAttempts = 6,
            string? baseAddress = null,
            string? url = null,
            IReadOnlyList<object>? responses = null)
        {
            Handler = new ResponseHandler(responseJson, responses);
            _httpClient = new HttpClient(Handler);
            if (baseAddress is not null)
            {
                _httpClient.BaseAddress = new Uri(baseAddress);
            }

            Client = new BotApiClient("test-token", _httpClient, url, maxRetryAttempts);
        }

        public ResponseHandler Handler { get; }

        public BotApiClient Client { get; }

        public Uri? HttpClientBaseAddress => _httpClient.BaseAddress;

        public void Dispose()
        {
            Client.Dispose();
            _httpClient.Dispose();
        }
    }

    private sealed class ResponseHandler(string responseJson) : HttpMessageHandler
    {
        private readonly IReadOnlyList<object>? _responses;

        public ResponseHandler(string responseJson, IReadOnlyList<object>? responses = null)
            : this(responseJson)
        {
            _responses = responses;
        }

        public int RequestCount { get; private set; }

        public string? LastRequestUri { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            RequestCount++;
            LastRequestUri = request.RequestUri?.ToString();

            if (_responses is not null && RequestCount <= _responses.Count)
            {
                var response = _responses[RequestCount - 1];
                if (response is Exception exception)
                {
                    return Task.FromException<HttpResponseMessage>(exception);
                }

                return Task.FromResult((HttpResponseMessage)response);
            }

            return Task.FromResult(ResponseMessage(responseJson));
        }

        public static HttpResponseMessage ResponseMessage(
            string json,
            HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(statusCode)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
    }

}
