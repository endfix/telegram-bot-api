using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

internal static class PollingStressRunner
{
    private const string Token = "polling-stress-token";
    private const int BotApiUpdateLimit = 100;
    private const int WatchdogSeconds = 180;

    private static readonly int[] BatchSizes = [10, 100, 1_000, 10_000];
    private static readonly int[] ParallelismLevels = [1, 4, 10, 32];

    public static async Task RunAsync(int updatesPerConfiguration, int repetitions)
    {
        if (updatesPerConfiguration < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(updatesPerConfiguration));
        }

        if (repetitions < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(repetitions));
        }

        var total = Stopwatch.StartNew();

        Console.WriteLine("Polling stress harness (in-process fake getUpdates, no network).");
        Console.WriteLine($"Updates per configuration: {Format(updatesPerConfiguration, "N0")}");
        Console.WriteLine(
            $"Repetitions: {repetitions} reported for throughput and cancellation");
        Console.WriteLine(
            "Throughput cells also run one discarded priming repetition before the reported runs.");
        Console.WriteLine(
            $"Runtime: {RuntimeInformation.FrameworkDescription} " +
            $"({RuntimeInformation.ProcessArchitecture})");
        Console.WriteLine(
            $"GC: {(GCSettings.IsServerGC ? "Server" : "Workstation")}; " +
            $"logical processors: {Environment.ProcessorCount}");
        Console.WriteLine();

        var payloads = new Dictionary<int, byte[][]>(BatchSizes.Length);
        foreach (var batchSize in BatchSizes)
        {
            payloads[batchSize] = BuildPayloads(updatesPerConfiguration, batchSize);
        }

        await WarmUpAsync().ConfigureAwait(false);

        await RunThroughputAsync(payloads, updatesPerConfiguration, repetitions)
            .ConfigureAwait(false);
        await RunConcurrencyAsync().ConfigureAwait(false);
        await RunOrderingAsync().ConfigureAwait(false);
        await RunExceptionIsolationAsync().ConfigureAwait(false);
        await RunCancellationAsync(repetitions).ConfigureAwait(false);

        Console.WriteLine($"Total harness time: {total.Elapsed.ToString("g", CultureInfo.InvariantCulture)}");
    }

    private static async Task WarmUpAsync()
    {
        foreach (var batchSize in new[] { 100, 1_000 })
        {
            var payloads = BuildPayloads(20_000, batchSize);

            foreach (var maxParallel in new[] { 1, 32 })
            {
                using var session = new PollingSession(payloads, captureOrder: false, capacity: 0);
                await session.RunAsync(
                    limit: Math.Min(batchSize, BotApiUpdateLimit),
                    maxParallel,
                    expectedUpdates: 20_000,
                    static (_, _) => Task.CompletedTask).ConfigureAwait(false);
            }
        }

        ForceCollection();
    }

    private static async Task RunThroughputAsync(
        IReadOnlyDictionary<int, byte[][]> payloads,
        int updates,
        int repetitions)
    {
        Console.WriteLine("## Throughput and allocations");
        Console.WriteLine();
        Console.WriteLine(
            $"Fast handler; median of {Counted(repetitions, "reported repetition", "reported repetitions")}. " +
            $"Batches above {BotApiUpdateLimit} exceed " +
            "Telegram's getUpdates limit and only characterize the client loop.");
        Console.WriteLine();
        Console.WriteLine(
            "| Batch | Max parallel | Requests | us/update | Updates/s | Allocated B/update | " +
            "Working set delta | Gen0 / Gen1 / Gen2 |");
        Console.WriteLine(
            "| ---: | ---: | ---: | ---: | ---: | ---: | ---: | --- |");

        // The first timed cell decays from roughly three times its steady cost
        // across its first repetitions (375, 356, 336, 269, 135 ms for the same
        // cell that later holds ~116 ms). One discarded pass over the whole
        // matrix absorbs that one-time runtime work before anything is reported.
        await MeasureAsync(repetitions: 1, emit: false).ConfigureAwait(false);
        await MeasureAsync(repetitions, emit: true).ConfigureAwait(false);

        Console.WriteLine();

        async Task MeasureAsync(int repetitions, bool emit)
        {
            foreach (var batchSize in BatchSizes)
            {
                foreach (var maxParallel in ParallelismLevels)
                {
                    var runs = new List<SessionMetrics>(repetitions);

                    for (var repetition = 0; repetition < repetitions; repetition++)
                    {
                        using var session = new PollingSession(
                            payloads[batchSize],
                            captureOrder: false,
                            capacity: 0);

                        runs.Add(await session.RunAsync(
                            limit: Math.Min(batchSize, BotApiUpdateLimit),
                            maxParallel,
                            updates,
                            static (_, _) => Task.CompletedTask).ConfigureAwait(false));
                    }

                    if (!emit)
                    {
                        continue;
                    }

                    var median = runs.OrderBy(static run => run.Elapsed).ElementAt(repetitions / 2);
                    var microsecondsPerUpdate = median.Elapsed.TotalMilliseconds * 1_000 / updates;
                    var updatesPerSecond = updates / median.Elapsed.TotalSeconds;
                    var bytesPerUpdate = median.AllocatedBytes / (double)updates;

                    Console.WriteLine(
                        $"| {Format(batchSize, "N0"),5} | {maxParallel,4} | {Format(median.Requests, "N0"),8} | " +
                        $"{Format(microsecondsPerUpdate, "N2"),9} | {Format(updatesPerSecond, "N0"),9} | " +
                        $"{Format(bytesPerUpdate, "N0"),18} | " +
                        $"{Format(median.WorkingSetDelta / 1024.0 / 1024.0, "N1"),17} MB | " +
                        $"{median.Gen0} / {median.Gen1} / {median.Gen2} |");
                }
            }
        }
    }

    private static async Task RunConcurrencyAsync()
    {
        Console.WriteLine("## Concurrency ceiling");
        Console.WriteLine();
        Console.WriteLine(
            "Gated handler; the observed peak equals min(maxParallel, batch) without timing noise.");
        Console.WriteLine();
        Console.WriteLine("| Batch | Max parallel | Expected peak | Observed peak | Status |");
        Console.WriteLine("| ---: | ---: | ---: | ---: | --- |");

        foreach (var batchSize in BatchSizes)
        {
            foreach (var maxParallel in ParallelismLevels)
            {
                var expected = Math.Min(batchSize, maxParallel);
                using var session = new PollingSession(
                    BuildPayloads(expected, expected),
                    captureOrder: false,
                    capacity: 0);

                var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                var reached = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                var run = session.RunAsync(
                    limit: Math.Min(expected, BotApiUpdateLimit),
                    maxParallel,
                    expected,
                    async (_, cancellationToken) =>
                    {
                        if (session.PeakConcurrency >= expected)
                        {
                            reached.TrySetResult();
                        }

                        await gate.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
                    });

                await reached.Task.WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                var observed = session.PeakConcurrency;
                gate.TrySetResult();
                await run.ConfigureAwait(false);

                var status = observed == expected ? "ok" : "mismatch";
                Console.WriteLine(
                    $"| {Format(batchSize, "N0"),5} | {maxParallel,4} | {Format(expected, "N0"),13} | " +
                    $"{Format(observed, "N0"),13} | {status} |");
            }
        }

        Console.WriteLine();
    }

    private static async Task RunOrderingAsync()
    {
        const int batchSize = 100;

        Console.WriteLine("## Ordering and completeness");
        Console.WriteLine();
        Console.WriteLine(
            "One 100-update batch with id-dependent handler delays; " +
            "`maxParallel = 1` must keep delivery order.");
        Console.WriteLine();
        Console.WriteLine(
            "| Max parallel | In-order starts | In-order completions | Duplicates | Missing | Status |");
        Console.WriteLine("| ---: | ---: | ---: | ---: | ---: | --- |");

        foreach (var maxParallel in ParallelismLevels)
        {
            using var session = new PollingSession(
                BuildPayloads(batchSize, batchSize),
                captureOrder: true,
                capacity: batchSize);

            var metrics = await session.RunAsync(
                limit: batchSize,
                maxParallel,
                batchSize,
                static async (update, _) =>
                {
                    await Task.Delay((int)(update.UpdateId % 7) + 1).ConfigureAwait(false);
                }).ConfigureAwait(false);

            var started = metrics.Started ?? [];
            var completed = metrics.Completed ?? [];
            var inOrderStarts = CountInOrder(started, batchSize);
            var inOrderCompletions = CountInOrder(completed, batchSize);
            var distinct = started.Distinct().Count();
            var duplicates = started.Length - distinct;
            var missing = batchSize - distinct;
            var ordered = maxParallel > 1 ||
                          (inOrderStarts == batchSize && inOrderCompletions == batchSize);
            var status = duplicates == 0 && missing == 0 && ordered ? "ok" : "mismatch";

            Console.WriteLine(
                $"| {maxParallel,4} | {inOrderStarts,15} | {inOrderCompletions,20} | " +
                $"{duplicates,10} | {missing,7} | {status} |");
        }

        Console.WriteLine();
    }

    private static async Task RunExceptionIsolationAsync()
    {
        const int batchSize = 100;
        const int batchCount = 10;
        const int updates = batchSize * batchCount;

        Console.WriteLine("## Exception isolation");
        Console.WriteLine();
        Console.WriteLine(
            "Every 25th update throws OperationCanceledException and every 5th throws " +
            "InvalidOperationException; polling must keep processing and complete normally.");
        Console.WriteLine();

        var failures = 0;
        using var session = new PollingSession(
            BuildPayloads(updates, batchSize),
            captureOrder: false,
            capacity: 0);

        var metrics = await session.RunAsync(
            limit: batchSize,
            maxParallel: 4,
            expectedUpdates: updates,
            async (update, _) =>
            {
                await Task.Yield();

                if (update.UpdateId % 25 == 0)
                {
                    Interlocked.Increment(ref failures);
                    throw new OperationCanceledException(
                        "Simulated non-fatal handler cancellation.");
                }

                if (update.UpdateId % 5 == 0)
                {
                    Interlocked.Increment(ref failures);
                    throw new InvalidOperationException("Simulated handler failure.");
                }
            }).ConfigureAwait(false);

        var expectedFailures = updates / 5;
        var succeeded = metrics.Processed == updates &&
                        failures == expectedFailures &&
                        metrics.Requests == batchCount;

        Console.WriteLine("| Metric | Value |");
        Console.WriteLine("| --- | ---: |");
        Console.WriteLine($"| Updates processed | {Format(metrics.Processed, "N0")} |");
        Console.WriteLine($"| Expected handler failures | {Format(expectedFailures, "N0")} |");
        Console.WriteLine($"| Observed handler failures | {Format(failures, "N0")} |");
        Console.WriteLine($"| getUpdates requests | {Format(metrics.Requests, "N0")} |");
        Console.WriteLine($"| Polling completed without throwing | {(succeeded ? "yes" : "no")} |");
        Console.WriteLine();
    }

    private static async Task RunCancellationAsync(int repetitions)
    {
        Console.WriteLine("## Cancellation latency");
        Console.WriteLine();
        Console.WriteLine(
            "Stop latency from `Cancel()` to `StartPollingAsync` completion; median and maximum " +
            $"of {Counted(repetitions, "run", "runs")} per scenario.");
        Console.WriteLine();
        Console.WriteLine("| Scenario | Max parallel | Median | Maximum |");
        Console.WriteLine("| --- | ---: | ---: | ---: |");

        var idle = new List<double>(repetitions);
        for (var repetition = 0; repetition < repetitions; repetition++)
        {
            using var session = new PollingSession([], captureOrder: false, capacity: 0);
            var run = session.RunAsync(
                limit: 1,
                maxParallel: 1,
                expectedUpdates: int.MaxValue,
                static (_, _) => Task.CompletedTask);

            await Task.Delay(100).ConfigureAwait(false);
            idle.Add(await StopAndMeasureAsync(session, run).ConfigureAwait(false));
        }

        PrintCancellationRow("Idle, blocked in getUpdates", maxParallel: 1, idle);

        var fast = new List<double>(repetitions);
        for (var repetition = 0; repetition < repetitions; repetition++)
        {
            using var session = new PollingSession(
                BuildPayloads(10_000, 100),
                captureOrder: false,
                capacity: 0);

            var run = session.RunAsync(
                limit: 100,
                maxParallel: 1,
                expectedUpdates: int.MaxValue,
                static (_, _) => Task.CompletedTask);

            while (session.Processed < 1_000)
            {
                await Task.Delay(1).ConfigureAwait(false);
            }

            fast.Add(await StopAndMeasureAsync(session, run).ConfigureAwait(false));
        }

        PrintCancellationRow("Fast handler, 1,000 processed", maxParallel: 1, fast);

        foreach (var maxParallel in ParallelismLevels)
        {
            var slow = new List<double>(repetitions);

            for (var repetition = 0; repetition < repetitions; repetition++)
            {
                const int batchSize = 100;
                using var session = new PollingSession(
                    BuildPayloads(batchSize, batchSize),
                    captureOrder: false,
                    capacity: 0);

                var expected = Math.Min(batchSize, maxParallel);
                var started = new TaskCompletionSource(
                    TaskCreationOptions.RunContinuationsAsynchronously);
                var run = session.RunAsync(
                    limit: batchSize,
                    maxParallel,
                    expectedUpdates: int.MaxValue,
                    async (_, cancellationToken) =>
                    {
                        if (session.Active >= expected)
                        {
                            started.TrySetResult();
                        }

                        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken)
                            .ConfigureAwait(false);
                    });

                await started.Task.WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                await Task.Delay(20).ConfigureAwait(false);
                slow.Add(await StopAndMeasureAsync(session, run).ConfigureAwait(false));
            }

            PrintCancellationRow("Slow handler in flight", maxParallel, slow);
        }

        Console.WriteLine();
    }

    private static async Task<double> StopAndMeasureAsync(PollingSession session, Task run)
    {
        var stopwatch = Stopwatch.StartNew();
        session.Cancel();
        await run.ConfigureAwait(false);
        stopwatch.Stop();
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    private static void PrintCancellationRow(string scenario, int maxParallel, List<double> values)
    {
        values.Sort();
        var median = values[values.Count / 2];
        var maximum = values[^1];
        Console.WriteLine(
            $"| {scenario} | {maxParallel,4} | {Format(median, "N2"),6} ms | {Format(maximum, "N2"),7} ms |");
    }

    private static string Format(long value, string format)
        => value.ToString(format, CultureInfo.InvariantCulture);

    private static string Format(double value, string format)
        => value.ToString(format, CultureInfo.InvariantCulture);

    private static string Counted(int count, string singular, string plural)
        => $"{Format(count, "N0")} {(count == 1 ? singular : plural)}";

    private static int CountInOrder(long[] values, int count)
    {
        var inOrder = 0;

        for (var index = 0; index < count; index++)
        {
            if (values[index] == index + 1)
            {
                inOrder++;
            }
        }

        return inOrder;
    }

    private static void ForceCollection()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    private static void UpdateMaximum(ref int maximum, int value)
    {
        while (true)
        {
            var current = Volatile.Read(ref maximum);
            if (value <= current ||
                Interlocked.CompareExchange(ref maximum, value, current) == current)
            {
                return;
            }
        }
    }

    private static byte[][] BuildPayloads(int totalUpdates, int batchSize)
    {
        var payloads = new List<byte[]>((totalUpdates + batchSize - 1) / batchSize);
        var builder = new StringBuilder((batchSize * 160) + 32);

        for (var first = 1; first <= totalUpdates; first += batchSize)
        {
            var last = Math.Min(first + batchSize - 1, totalUpdates);
            builder.Clear();
            builder.Append("{\"ok\":true,\"result\":[");

            for (var updateId = first; updateId <= last; updateId++)
            {
                if (updateId > first)
                {
                    builder.Append(',');
                }

                builder.Append("{\"update_id\":").Append(updateId)
                    .Append(",\"message\":{\"message_id\":").Append(updateId)
                    .Append(",\"date\":1786471241,\"chat\":{\"id\":989722390,")
                    .Append("\"type\":\"private\",\"first_name\":\"Stress\"},")
                    .Append("\"text\":\"Polling stress update\"}}");
            }

            builder.Append("]}");
            payloads.Add(Encoding.UTF8.GetBytes(builder.ToString()));
        }

        return payloads.ToArray();
    }

    private sealed record SessionMetrics(
        TimeSpan Elapsed,
        long AllocatedBytes,
        int Processed,
        int Requests,
        int PeakConcurrency,
        long WorkingSetDelta,
        int Gen0,
        int Gen1,
        int Gen2,
        long[]? Started,
        long[]? Completed);

    private sealed class PollingSession : IDisposable
    {
        private readonly UpdateBatchHandler _transport;
        private readonly HttpClient _httpClient;
        private readonly BotApiClient _client;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly CancellationTokenSource _watchdog = new(TimeSpan.FromSeconds(WatchdogSeconds));
        private readonly CancellationTokenSource _linkedCancellation;
        private readonly long[]? _started;
        private readonly long[]? _completed;
        private int _processed;
        private int _active;
        private int _peak;
        private int _startedCount;
        private int _completedCount;

        public PollingSession(IReadOnlyList<byte[]> payloads, bool captureOrder, int capacity)
        {
            _transport = new UpdateBatchHandler(payloads);
            _httpClient = new HttpClient(_transport)
            {
                Timeout = Timeout.InfiniteTimeSpan
            };
            _client = new BotApiClient(Token, _httpClient, maxRetryAttempts: 0);
            _linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
                _cancellation.Token,
                _watchdog.Token);

            if (captureOrder)
            {
                _started = new long[capacity];
                _completed = new long[capacity];
            }
        }

        public int Processed => Volatile.Read(ref _processed);

        public int Active => Volatile.Read(ref _active);

        public int PeakConcurrency => Volatile.Read(ref _peak);

        public void Cancel() => _cancellation.Cancel();

        public async Task<SessionMetrics> RunAsync(
            int limit,
            int maxParallel,
            int expectedUpdates,
            Func<Update, CancellationToken, Task> handler)
        {
            _client.OnUpdate += async (_, update, cancellationToken) =>
            {
                var active = Interlocked.Increment(ref _active);
                UpdateMaximum(ref _peak, active);

                if (_started is not null)
                {
                    var index = Interlocked.Increment(ref _startedCount) - 1;
                    _started[index] = update.UpdateId;
                }

                try
                {
                    await handler(update, cancellationToken).ConfigureAwait(false);
                }
                finally
                {
                    Interlocked.Decrement(ref _active);

                    if (_completed is not null)
                    {
                        var index = Interlocked.Increment(ref _completedCount) - 1;
                        _completed[index] = update.UpdateId;
                    }

                    if (Interlocked.Increment(ref _processed) == expectedUpdates)
                    {
                        _cancellation.Cancel();
                    }
                }
            };

            ForceCollection();
            var process = Process.GetCurrentProcess();
            process.Refresh();
            var workingSetBefore = process.WorkingSet64;
            var allocatedBefore = GC.GetTotalAllocatedBytes(precise: true);
            var gen0Before = GC.CollectionCount(0);
            var gen1Before = GC.CollectionCount(1);
            var gen2Before = GC.CollectionCount(2);
            var stopwatch = Stopwatch.StartNew();

            await _client.StartPollingAsync(
                limit: limit,
                timeout: 0,
                maxParallel: maxParallel,
                cancellationToken: _linkedCancellation.Token).ConfigureAwait(false);

            stopwatch.Stop();
            var allocatedAfter = GC.GetTotalAllocatedBytes(precise: true);
            process.Refresh();
            var workingSetAfter = process.WorkingSet64;

            if (_watchdog.IsCancellationRequested && !_cancellation.IsCancellationRequested)
            {
                throw new TimeoutException(
                    $"The polling session did not complete within {WatchdogSeconds} seconds.");
            }

            return new SessionMetrics(
                stopwatch.Elapsed,
                allocatedAfter - allocatedBefore,
                Volatile.Read(ref _processed),
                _transport.Requests,
                Volatile.Read(ref _peak),
                workingSetAfter - workingSetBefore,
                GC.CollectionCount(0) - gen0Before,
                GC.CollectionCount(1) - gen1Before,
                GC.CollectionCount(2) - gen2Before,
                _started,
                _completed);
        }

        public void Dispose()
        {
            _client.Dispose();
            _httpClient.Dispose();
            _linkedCancellation.Dispose();
            _cancellation.Dispose();
            _watchdog.Dispose();
        }
    }

    private sealed class UpdateBatchHandler : HttpMessageHandler
    {
        private readonly IReadOnlyList<byte[]> _payloads;
        private int _requests;

        public UpdateBatchHandler(IReadOnlyList<byte[]> payloads)
        {
            _payloads = payloads;
        }

        public int Requests => Volatile.Read(ref _requests);

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var index = Interlocked.Increment(ref _requests) - 1;

            if (index < _payloads.Count)
            {
                var content = new ByteArrayContent(_payloads[index]);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json")
                {
                    CharSet = "utf-8"
                };

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = content
                });
            }

            return WaitForCancellationAsync(cancellationToken);
        }

        private static async Task<HttpResponseMessage> WaitForCancellationAsync(
            CancellationToken cancellationToken)
        {
            var canceled = new TaskCompletionSource(
                TaskCreationOptions.RunContinuationsAsynchronously);

            using (cancellationToken.Register(
                       static state => ((TaskCompletionSource)state!).TrySetResult(),
                       canceled))
            {
                await canceled.Task.ConfigureAwait(false);
            }

            throw new OperationCanceledException(cancellationToken);
        }
    }
}
