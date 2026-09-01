using System.Collections.Concurrent;
using System.Net;
using System.Text;
using Endfix.Telegram.BotAPI.Tests.Infrastructure;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class LongPollingBehaviorTests
{
    [Fact]
    public async Task AllSubscribers_AreInvokedAndAwaitedInRegistrationOrder()
    {
        using var cancellation = new CancellationTokenSource();
        using var context = new PollingContext(new RepeatingUpdateHandler());
        var calls = new List<string>();

        context.Client.OnUpdate += async (_, _, _) =>
        {
            calls.Add("first-started");
            await Task.Delay(100);
            calls.Add("first-completed");
        };
        context.Client.OnUpdate += (_, _, _) =>
        {
            calls.Add("second");
            cancellation.Cancel();
            return Task.CompletedTask;
        };

        await context.Client.StartPollingAsync(cancellationToken: cancellation.Token);

        Assert.Equal(["first-started", "first-completed", "second"], calls);
    }

    [Fact]
    public async Task SubscriberFailure_IsLoggedAndDoesNotSkipLaterSubscribers()
    {
        using var cancellation = new CancellationTokenSource();
        var logger = new RecordingLogger();
        using var context = new PollingContext(new RepeatingUpdateHandler(), logger);
        var laterSubscriberCalled = false;

        context.Client.OnUpdate += async (_, _, _) =>
        {
            await Task.Yield();
            throw new InvalidOperationException("first subscriber failed");
        };
        context.Client.OnUpdate += (_, _, _) =>
        {
            laterSubscriberCalled = true;
            cancellation.Cancel();
            return Task.CompletedTask;
        };

        await context.Client.StartPollingAsync(cancellationToken: cancellation.Token);

        Assert.True(laterSubscriberCalled);
        Assert.Contains(logger.Entries, entry =>
            entry.Level == LogLevel.Error &&
            entry.Exception is InvalidOperationException exception &&
            exception.Message == "first subscriber failed");
    }

    [Fact]
    public async Task SubscriberFailure_IsAcknowledgedByTheNextOffset()
    {
        using var cancellation = new CancellationTokenSource();
        var handler = new AcknowledgementHandler(cancellation);
        using var context = new PollingContext(handler);

        context.Client.OnUpdate += (_, _, _) =>
            Task.FromException(new InvalidOperationException("handler failed"));

        await context.Client.StartPollingAsync(cancellationToken: cancellation.Token);

        Assert.Equal(2, handler.Requests.Count);
        var offset = Assert.Single(handler.Requests[1].Parts, part => part.Name == "offset");
        Assert.Equal("2", offset.Text);
    }

    [Fact]
    public async Task CancellationDuringErrorBackoff_CompletesNormally()
    {
        using var cancellation = new CancellationTokenSource();
        var logger = new RecordingLogger();
        using var context = new PollingContext(new ApiErrorHandler(), logger);

        var polling = context.Client.StartPollingAsync(cancellationToken: cancellation.Token);
        await logger.WarningLogged.Task.WaitAsync(TimeSpan.FromSeconds(2));
        cancellation.Cancel();

        await polling.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.True(polling.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task PollingCancellation_IsForwardedToSubscriberWithoutErrorLog()
    {
        using var cancellation = new CancellationTokenSource();
        var logger = new RecordingLogger();
        using var context = new PollingContext(new RepeatingUpdateHandler(), logger);
        var tokenReceived = new TaskCompletionSource<CancellationToken>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        context.Client.OnUpdate += async (_, _, cancellationToken) =>
        {
            tokenReceived.TrySetResult(cancellationToken);
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        };

        var polling = context.Client.StartPollingAsync(cancellationToken: cancellation.Token);
        var handlerToken = await tokenReceived.Task.WaitAsync(TimeSpan.FromSeconds(2));
        cancellation.Cancel();

        await polling.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Equal(cancellation.Token, handlerToken);
        Assert.True(polling.IsCompletedSuccessfully);
        Assert.DoesNotContain(logger.Entries, entry => entry.Level == LogLevel.Error);
    }

    [Fact]
    public async Task ConcurrentPollingSession_IsRejectedForTheSameClient()
    {
        using var cancellation = new CancellationTokenSource();
        var handler = new BlockingPollingHandler();
        using var context = new PollingContext(handler);

        var firstPolling = context.Client.StartPollingAsync(cancellationToken: cancellation.Token);
        await handler.RequestStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            context.Client.StartPollingAsync(cancellationToken: cancellation.Token));

        Assert.Equal("Long polling is already running for this client.", exception.Message);
        Assert.Equal(1, handler.RequestCount);

        cancellation.Cancel();
        await firstPolling.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Fact]
    public async Task NewPollingSession_StartsWithoutPersistedCheckpoint()
    {
        var handler = new RepeatingUpdateHandler();
        using var context = new PollingContext(handler);

        for (var session = 0; session < 2; session++)
        {
            using var cancellation = new CancellationTokenSource();
            BotApiClient.UpdateHandler stopSession = (_, _, _) =>
            {
                cancellation.Cancel();
                return Task.CompletedTask;
            };

            context.Client.OnUpdate += stopSession;
            await context.Client.StartPollingAsync(cancellationToken: cancellation.Token);
            context.Client.OnUpdate -= stopSession;
        }

        Assert.Equal(2, handler.Requests.Count);
        Assert.All(handler.Requests, request =>
        {
            var offset = Assert.Single(request.Parts, part => part.Name == "offset");
            Assert.Equal("0", offset.Text);
        });
    }

    private sealed class PollingContext : IDisposable
    {
        private readonly HttpClient _httpClient;

        public PollingContext(HttpMessageHandler handler, ILogger<IBotApiClient>? logger = null)
        {
            _httpClient = new HttpClient(handler);
            Client = new BotApiClient("test-token", _httpClient, maxRetryAttempts: 0, logger: logger);
        }

        public BotApiClient Client { get; }

        public void Dispose() => _httpClient.Dispose();
    }

    private sealed class RepeatingUpdateHandler : HttpMessageHandler
    {
        public List<RecordedRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Requests.Add(await RecordedRequest.CreateAsync(request, cancellationToken));
            return JsonResponse("""{"ok":true,"result":[{"update_id":1}]}""");
        }
    }

    private sealed class AcknowledgementHandler(CancellationTokenSource cancellation) : HttpMessageHandler
    {
        public List<RecordedRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Requests.Add(await RecordedRequest.CreateAsync(request, CancellationToken.None));
            if (Requests.Count == 1)
            {
                return JsonResponse("""{"ok":true,"result":[{"update_id":1}]}""");
            }

            cancellation.Cancel();
            return JsonResponse("""{"ok":true,"result":[]}""");
        }
    }

    private sealed class ApiErrorHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
            => Task.FromResult(JsonResponse(
                """{"ok":false,"error_code":500,"description":"test failure"}"""));
    }

    private sealed class BlockingPollingHandler : HttpMessageHandler
    {
        private int _requestCount;

        public int RequestCount => Volatile.Read(ref _requestCount);

        public TaskCompletionSource RequestStarted { get; } = new(
            TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _requestCount);
            RequestStarted.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            throw new InvalidOperationException("The polling request should end through cancellation.");
        }
    }

    private sealed class RecordingLogger : ILogger<IBotApiClient>
    {
        public ConcurrentQueue<LogEntry> Entries { get; } = new();

        public TaskCompletionSource WarningLogged { get; } = new(
            TaskCreationOptions.RunContinuationsAsynchronously);

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Entries.Enqueue(new LogEntry(logLevel, exception, formatter(state, exception)));
            if (logLevel == LogLevel.Warning)
            {
                WarningLogged.TrySetResult();
            }
        }
    }

    private sealed record LogEntry(LogLevel Level, Exception? Exception, string Message);

    private static HttpResponseMessage JsonResponse(string json)
        => new(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
}
