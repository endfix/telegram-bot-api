using System.Collections.Concurrent;
using System.Net;
using System.Text;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Types;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class LongPollingOrderingTests
{
    private readonly ITestOutputHelper _output;

    public LongPollingOrderingTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task MaxParallelOne_ProcessesUpdatesInDeliveryOrder()
    {
        var updateIds = Enumerable.Range(1, 5).Select(static value => (long)value).ToArray();
        using var context = new PollingContext(updateIds);
        using var cancellation = new CancellationTokenSource();
        var started = new List<long>();
        var completed = new List<long>();
        var sync = new object();

        context.Client.OnUpdate += async (_, update, _) =>
        {
            lock (sync)
            {
                started.Add(update.UpdateId);
            }

            await Task.Delay((int)(6 - update.UpdateId) * 10);

            lock (sync)
            {
                completed.Add(update.UpdateId);
                if (completed.Count == updateIds.Length)
                {
                    cancellation.Cancel();
                }
            }
        };

        await context.Client.StartPollingAsync(maxParallel: 1, cancellationToken: cancellation.Token);

        started.Should().Equal(updateIds);
        completed.Should().Equal(updateIds);

        _output.WriteLine($"maxParallel=1; started=[{string.Join(", ", started)}]; completed=[{string.Join(", ", completed)}]");
    }

    [Theory]
    [InlineData(2)]
    [InlineData(10)]
    public async Task MaxParallelGreaterThanOne_AllowsConcurrentAndOutOfOrderProcessing(int maxParallel)
    {
        var updateIds = Enumerable.Range(1, 5).Select(static value => (long)value).ToArray();
        using var context = new PollingContext(updateIds);
        using var cancellation = new CancellationTokenSource();
        var started = new ConcurrentQueue<long>();
        var completed = new ConcurrentQueue<long>();
        var active = 0;
        var maximumActive = 0;

        context.Client.OnUpdate += async (_, update, _) =>
        {
            started.Enqueue(update.UpdateId);
            var currentActive = Interlocked.Increment(ref active);
            UpdateMaximum(ref maximumActive, currentActive);

            try
            {
                await Task.Delay(update.UpdateId == 1 ? 100 : 1);
                completed.Enqueue(update.UpdateId);
            }
            finally
            {
                if (Interlocked.Decrement(ref active) == 0 && completed.Count == updateIds.Length)
                {
                    cancellation.Cancel();
                }
            }
        };

        await context.Client.StartPollingAsync(maxParallel: maxParallel, cancellationToken: cancellation.Token);

        started.Should().BeEquivalentTo(updateIds);
        maximumActive.Should().BeGreaterThan(1);
        completed.Should().NotEqual(updateIds);
        completed.Should().Contain(1);

        _output.WriteLine($"maxParallel={maxParallel}; started=[{string.Join(", ", started)}]; completed=[{string.Join(", ", completed)}]; maximumActive={maximumActive}");
    }

    [Fact]
    public async Task MaxParallelOneHundred_DoesNotExceedConfiguredConcurrency()
    {
        const int maxParallel = 100;
        const int updateCount = 200;
        var updateIds = Enumerable.Range(1, updateCount).Select(static value => (long)value).ToArray();
        using var context = new PollingContext(updateIds);
        using var cancellation = new CancellationTokenSource();
        var capacityReached = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandlers = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var active = 0;
        var maximumActive = 0;
        var completed = 0;

        context.Client.OnUpdate += async (_, _, _) =>
        {
            var currentActive = Interlocked.Increment(ref active);
            UpdateMaximum(ref maximumActive, currentActive);
            if (currentActive == maxParallel)
            {
                capacityReached.TrySetResult();
            }

            try
            {
                await releaseHandlers.Task;
            }
            finally
            {
                Interlocked.Decrement(ref active);
                if (Interlocked.Increment(ref completed) == updateCount)
                {
                    cancellation.Cancel();
                }
            }
        };

        var polling = context.Client.StartPollingAsync(
            maxParallel: maxParallel,
            cancellationToken: cancellation.Token);
        await capacityReached.Task.WaitAsync(TimeSpan.FromSeconds(5));

        maximumActive.Should().Be(maxParallel);

        releaseHandlers.TrySetResult();
        await polling.WaitAsync(TimeSpan.FromSeconds(5));

        completed.Should().Be(updateCount);
        maximumActive.Should().Be(maxParallel);
    }

    private static void UpdateMaximum(ref int maximum, int value)
    {
        while (true)
        {
            var current = Volatile.Read(ref maximum);
            if (value <= current || Interlocked.CompareExchange(ref maximum, value, current) == current)
            {
                return;
            }
        }
    }

    private sealed class PollingContext : IDisposable
    {
        private readonly HttpClient _httpClient;

        public PollingContext(IReadOnlyList<long> updateIds)
        {
            _httpClient = new HttpClient(new UpdatesResponseHandler(updateIds));
            Client = new BotApiClient("test-token", _httpClient, maxRetryAttempts: 0);
        }

        public BotApiClient Client { get; }

        public void Dispose() => _httpClient.Dispose();
    }

    private sealed class UpdatesResponseHandler(IReadOnlyList<long> updateIds) : HttpMessageHandler
    {
        private readonly string _responseJson = $"{{\"ok\":true,\"result\":[{string.Join(',', updateIds.Select(static id => $"{{\"update_id\":{id}}}"))}]}}";

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_responseJson, Encoding.UTF8, "application/json")
            });
        }
    }
}
