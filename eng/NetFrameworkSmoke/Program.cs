using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

try
{
    await RunLocalChecksAsync();
    await RunLiveChecksAsync();
    Console.WriteLine("NetFramework smoke passed.");
    return 0;
}
catch (Exception exception)
{
    Console.Error.WriteLine(exception);
    return 1;
}

static async Task RunLocalChecksAsync()
{
    var libraryAssembly = typeof(BotApiClient).Assembly;
    var framework = libraryAssembly
        .GetCustomAttribute<TargetFrameworkAttribute>()?
        .FrameworkName;

    Console.WriteLine(
        $"Library: {libraryAssembly.GetName().Name} {libraryAssembly.GetName().Version} ({framework ?? "unknown"})");
    Console.WriteLine($"Runtime: {Environment.Version}");

    Ensure(JsonSerializerExtensions.Options.IsReadOnly, "Shared serializer options must be read-only.");
    Ensure(JsonSerializerExtensions.IndentedOptions.IsReadOnly, "Indented serializer options must be read-only.");

    EnsureThrows<JsonException>(
        () => default(ChatIdSource).Serialize(),
        "Serializing a default ChatIdSource must throw JsonException.");

    EnsureThrows<ArgumentException>(
        () => new ApiRequest("../getMe", parameters: null),
        "ApiRequest must reject method names that contain path separators.");

    EnsureThrows<JsonException>(
        () => "123".Deserialize<MediaSource>(),
        "Deserializing a non-string MediaSource must throw JsonException.");

    using (var document = JsonDocument.Parse(
        new SendMessageParameters
        {
            ChatId = 42L,
            Text = "smoke"
        }.Serialize()))
    {
        var root = document.RootElement;
        Ensure(root.GetProperty("chat_id").GetInt64() == 42L, "Parameters must use snake_case names.");
        Ensure(root.GetProperty("text").GetString() == "smoke", "Parameter values must survive serialization.");
    }

    using (var client = new BotApiClient("smoke-token"))
    {
        await EnsureThrowsAsync<ArgumentException>(
            () => client.DownloadFileAsync("../../bottest-token/getMe", Stream.Null),
            "DownloadFileAsync must reject parent-directory traversal.");

        await EnsureThrowsAsync<ArgumentException>(
            () => client.DownloadFileAsync("documents/file.bin?x=1", Stream.Null),
            "DownloadFileAsync must reject query strings.");

        await EnsureThrowsAsync<ArgumentException>(
            () => client.DownloadFileAsync("/etc/passwd", Stream.Null),
            "DownloadFileAsync must reject absolute paths.");
    }

    await RunPollingRetryCheckAsync();
    await RunFatalPollingErrorCheckAsync();
    await RunDisposeStopsPollingCheckAsync();
}

static async Task RunPollingRetryCheckAsync()
{
    using var cancellation = new CancellationTokenSource();
    using var handler = new TimeoutThenEmptyHandler(cancellation);
    using var httpClient = new HttpClient(handler);
    using var client = new BotApiClient("smoke-token", httpClient, maxRetryAttempts: 0);
    client.PollingRetryDelay = TimeSpan.FromMilliseconds(10);

    await WithTimeoutAsync(
        client.StartPollingAsync(limit: 1, timeout: 1, cancellationToken: cancellation.Token),
        TimeSpan.FromSeconds(5),
        "Polling did not recover from a simulated HttpClient timeout.");

    Ensure(handler.RequestCount == 2, "Polling must retry after an HttpClient timeout.");
}

static async Task RunFatalPollingErrorCheckAsync()
{
    using var handler = new StaticJsonHandler(
        """{"ok":false,"error_code":401,"description":"Unauthorized"}""");
    using var httpClient = new HttpClient(handler);
    using var client = new BotApiClient("smoke-token", httpClient, maxRetryAttempts: 0);
    client.PollingRetryDelay = TimeSpan.FromMilliseconds(10);

    try
    {
        await WithTimeoutAsync(
            client.StartPollingAsync(cancellationToken: CancellationToken.None),
            TimeSpan.FromSeconds(5),
            "Polling did not stop on a fatal Telegram error.");
    }
    catch (ApiRequestException exception) when (exception.ErrorCode == 401)
    {
        Ensure(handler.RequestCount == 1, "Polling must not retry fatal Telegram errors.");
        return;
    }

    throw new InvalidOperationException(
        "Polling must propagate a fatal Telegram error instead of retrying it.");
}

static async Task RunDisposeStopsPollingCheckAsync()
{
    using var handler = new BlockingPollingHandler();
    using var httpClient = new HttpClient(handler);
    var client = new BotApiClient("smoke-token", httpClient, maxRetryAttempts: 0);

    var polling = client.StartPollingAsync(cancellationToken: CancellationToken.None);
    await WithTimeoutAsync(
        handler.RequestStarted.Task,
        TimeSpan.FromSeconds(5),
        "The polling request did not start.");

    client.Dispose();
    await WithTimeoutAsync(
        polling,
        TimeSpan.FromSeconds(5),
        "Dispose did not stop the active polling session.");

    Ensure(
        polling.Status == TaskStatus.RanToCompletion,
        "Polling must stop cleanly when the client is disposed.");

    await EnsureThrowsAsync<ObjectDisposedException>(
        () => client.RequestAsync<User>(new ApiRequest("getMe", parameters: null)),
        "Requests after Dispose must throw ObjectDisposedException.");
}

static async Task RunLiveChecksAsync()
{
    var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN");
    var chatIdValue = Environment.GetEnvironmentVariable("TELEGRAM_BOT_CHAT_ID");

    if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatIdValue))
    {
        Console.WriteLine(
            "Live checks skipped: TELEGRAM_BOT_TOKEN and TELEGRAM_BOT_CHAT_ID are not both set.");
        return;
    }

    ChatIdSource chatId = long.TryParse(
        chatIdValue,
        NumberStyles.Integer,
        CultureInfo.InvariantCulture,
        out var numericChatId)
        ? (ChatIdSource)numericChatId
        : (ChatIdSource)chatIdValue;

    using var httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(60)
    };
    using var client = new BotApiClient(token, httpClient, maxRetryAttempts: 2);

    var me = await client.GetMeAsync();
    Console.WriteLine($"Live bot: @{me.Username ?? me.FirstName}");

    var message = await client.SendMessageAsync(
        chatId,
        $"NetFramework smoke {DateTime.UtcNow:O}");
    try
    {
        Ensure(message.MessageId > 0, "sendMessage returned an invalid message identifier.");

        var content = Encoding.UTF8.GetBytes($"NetFramework smoke document {Guid.NewGuid():N}");
        var document = await client.SendDocumentAsync(
            chatId,
            new InputDocumentFile(InputFileSource.FromMemory(content, "netframework-smoke.txt")),
            caption: "net48 smoke document");
        try
        {
            Ensure(document.Document is not null, "sendDocument did not return document metadata.");

            var file = await client.GetFileAsync(document.Document!.FileId);
            Ensure(!string.IsNullOrWhiteSpace(file.FilePath), "getFile did not return a file path.");

            var bytes = await client.GetFileBytesAsync(file.FilePath!);
            Ensure(bytes.SequenceEqual(content), "getFileBytesAsync returned unexpected content.");

            using var destination = new MemoryStream();
            await client.DownloadFileAsync(file.FilePath!, destination);
            Ensure(
                destination.ToArray().SequenceEqual(content),
                "downloadFileAsync returned unexpected content.");
        }
        finally
        {
            await client.DeleteMessageAsync(chatId, document.MessageId);
        }
    }
    finally
    {
        await client.DeleteMessageAsync(chatId, message.MessageId);
    }

    var webhook = await client.GetWebhookInfoAsync();
    Console.WriteLine(
        $"Live webhook: {(string.IsNullOrEmpty(webhook.Url) ? "<not set>" : webhook.Url)}");

    if (!string.IsNullOrEmpty(webhook.Url))
    {
        Console.WriteLine("Live long polling skipped: a webhook is configured.");
        return;
    }

    using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(4));
    await WithTimeoutAsync(
        client.StartPollingAsync(limit: 1, timeout: 1, cancellationToken: cancellation.Token),
        TimeSpan.FromSeconds(10),
        "Live long polling did not stop after cancellation.");
    Console.WriteLine("Live long polling: stopped cleanly after cancellation.");
}

static async Task WithTimeoutAsync(Task task, TimeSpan timeout, string message)
{
    var completed = await Task.WhenAny(task, Task.Delay(timeout));
    if (completed != task)
    {
        throw new TimeoutException(message);
    }

    await task;
}

static void Ensure(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

static void EnsureThrows<TException>(Action action, string message)
    where TException : Exception
{
    try
    {
        action();
    }
    catch (TException)
    {
        return;
    }
    catch (Exception exception)
    {
        throw new InvalidOperationException(
            $"{message} Expected {typeof(TException).Name}, got {exception.GetType().Name}.",
            exception);
    }

    throw new InvalidOperationException(
        $"{message} Expected {typeof(TException).Name}, but no exception was thrown.");
}

static async Task EnsureThrowsAsync<TException>(Func<Task> action, string message)
    where TException : Exception
{
    try
    {
        await action();
    }
    catch (TException)
    {
        return;
    }
    catch (Exception exception)
    {
        throw new InvalidOperationException(
            $"{message} Expected {typeof(TException).Name}, got {exception.GetType().Name}.",
            exception);
    }

    throw new InvalidOperationException(
        $"{message} Expected {typeof(TException).Name}, but no exception was thrown.");
}

internal sealed class TimeoutThenEmptyHandler : HttpMessageHandler
{
    private readonly CancellationTokenSource _cancellation;
    private int _requestCount;

    public TimeoutThenEmptyHandler(CancellationTokenSource cancellation)
    {
        _cancellation = cancellation;
    }

    public int RequestCount => Volatile.Read(ref _requestCount);

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var requestNumber = Interlocked.Increment(ref _requestCount);
        if (requestNumber == 1)
        {
            return Task.FromException<HttpResponseMessage>(
                new TaskCanceledException("simulated HttpClient timeout"));
        }

        _cancellation.Cancel();
        return Task.FromResult(SmokeResponse.Json("""{"ok":true,"result":[]}"""));
    }
}

internal sealed class StaticJsonHandler : HttpMessageHandler
{
    private readonly string _json;
    private int _requestCount;

    public StaticJsonHandler(string json)
    {
        _json = json;
    }

    public int RequestCount => Volatile.Read(ref _requestCount);

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _requestCount);
        return Task.FromResult(SmokeResponse.Json(_json));
    }
}

internal sealed class BlockingPollingHandler : HttpMessageHandler
{
    private int _requestCount;

    public int RequestCount => Volatile.Read(ref _requestCount);

    public TaskCompletionSource<bool> RequestStarted { get; } = new(
        TaskCreationOptions.RunContinuationsAsynchronously);

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _requestCount);
        RequestStarted.TrySetResult(true);
        await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        throw new InvalidOperationException("The polling request should end through cancellation.");
    }
}

internal static class SmokeResponse
{
    public static HttpResponseMessage Json(string json)
        => new(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
}
