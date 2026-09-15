using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

internal static class StressRunner
{
    private const int Iterations = 1_000_000;
    private const int WarmupIterationsPerWorker = 1_000;

    public static async Task RunAsync(int maxParallel)
    {
        if (maxParallel < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxParallel));
        }

        using var httpClient = new HttpClient(new StressHandler());
        var client = new BotApiClient("benchmark-token", httpClient);
        var request = new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = 989722390L,
            Text = "Stress test message"
        });

        // Warm up the same concurrency shape so worker tasks, ThreadPool threads,
        // and per-thread runtime caches are not counted as retained workload state.
        var warmupIterations = checked(maxParallel * WarmupIterationsPerWorker);
        await RunWorkersAsync(client, request, warmupIterations, maxParallel).ConfigureAwait(false);
        ForceCollection();
        var process = Process.GetCurrentProcess();
        process.Refresh();
        var managedBefore = GC.GetTotalMemory(forceFullCollection: false);
        var allocatedBefore = GC.GetTotalAllocatedBytes(precise: true);
        var workingSetBefore = process.WorkingSet64;
        var cpuBefore = process.TotalProcessorTime;
        var collectionsBefore = new[]
        {
            GC.CollectionCount(0),
            GC.CollectionCount(1),
            GC.CollectionCount(2)
        };
        var stopwatch = Stopwatch.StartNew();

        await RunWorkersAsync(client, request, Iterations, maxParallel).ConfigureAwait(false);

        stopwatch.Stop();
        var allocatedAfter = GC.GetTotalAllocatedBytes(precise: true);
        var collectionsAfter = new[]
        {
            GC.CollectionCount(0),
            GC.CollectionCount(1),
            GC.CollectionCount(2)
        };
        process.Refresh();
        var cpuAfter = process.TotalProcessorTime;
        ForceCollection();
        var managedAfter = GC.GetTotalMemory(forceFullCollection: false);
        process.Refresh();
        var workingSetAfter = process.WorkingSet64;

        Console.WriteLine($"Iterations:       {Iterations:N0}");
        Console.WriteLine($"Warm-up:         {warmupIterations:N0}");
        Console.WriteLine($"Max parallel:     {maxParallel:N0}");
        Console.WriteLine($"GC mode:          {(System.Runtime.GCSettings.IsServerGC ? "Server" : "Workstation")}");
        Console.WriteLine($"Elapsed:          {stopwatch.Elapsed}");
        Console.WriteLine($"Average:          {stopwatch.Elapsed.TotalMilliseconds * 1_000 / Iterations:N2} us/op");
        Console.WriteLine($"CPU time:         {cpuAfter - cpuBefore}");
        Console.WriteLine($"Total allocated:  {(allocatedAfter - allocatedBefore) / 1024.0 / 1024.0:N1} MB");
        Console.WriteLine($"Allocated/op:     {(allocatedAfter - allocatedBefore) / (double)Iterations:N1} B");
        Console.WriteLine($"Retained managed before: {managedBefore / 1024.0:N1} KB");
        Console.WriteLine($"Retained managed after:  {managedAfter / 1024.0:N1} KB");
        Console.WriteLine($"Retained managed delta:  {(managedAfter - managedBefore) / 1024.0:N1} KB");
        Console.WriteLine($"Working set before: {workingSetBefore / 1024.0 / 1024.0:N1} MB");
        Console.WriteLine($"Working set after:  {workingSetAfter / 1024.0 / 1024.0:N1} MB");
        Console.WriteLine($"Working set delta:  {(workingSetAfter - workingSetBefore) / 1024.0 / 1024.0:N1} MB");
        Console.WriteLine($"GC collections:     Gen0 {collectionsAfter[0] - collectionsBefore[0]:N0}, " +
                          $"Gen1 {collectionsAfter[1] - collectionsBefore[1]:N0}, " +
                          $"Gen2 {collectionsAfter[2] - collectionsBefore[2]:N0}");
    }

    private static async Task RunWorkersAsync(
        BotApiClient client,
        ApiRequest request,
        int iterations,
        int maxParallel)
    {
        if (maxParallel == 1)
        {
            await RunWorkerAsync(iterations).ConfigureAwait(false);
            return;
        }

        var iterationsPerWorker = iterations / maxParallel;
        var remainder = iterations % maxParallel;
        var workers = new Task[maxParallel];

        for (var workerIndex = 0; workerIndex < maxParallel; workerIndex++)
        {
            var workerIterations = iterationsPerWorker + (workerIndex < remainder ? 1 : 0);
            workers[workerIndex] = Task.Run(() => RunWorkerAsync(workerIterations));
        }

        await Task.WhenAll(workers).ConfigureAwait(false);

        async Task RunWorkerAsync(int workerIterations)
        {
            for (var i = 0; i < workerIterations; i++)
            {
                var response = await client.RequestAsync<Message>(request).ConfigureAwait(false);
                ValidateResponse(response);
            }
        }
    }

    private static void ValidateResponse(ApiResponse<Message> response)
    {
        if (!response.Ok ||
            response.Result is null ||
            response.Result.MessageId != 1001 ||
            response.Result.Chat.Id != 989722390L ||
            response.Result.Text != "Stress response")
        {
            throw new InvalidOperationException("The fake API response did not match the expected message.");
        }
    }

    private static void ForceCollection()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    private sealed class StressHandler : HttpMessageHandler
    {
        private const string ResponseJson = "{\"ok\":true,\"result\":{\"message_id\":1001,\"date\":1786471241,\"chat\":{\"id\":989722390,\"type\":\"private\",\"first_name\":\"Stress\"},\"text\":\"Stress response\"}}";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ResponseJson, Encoding.UTF8, "application/json")
            });
        }
    }
}
