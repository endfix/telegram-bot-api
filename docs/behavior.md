# Behavior and guarantees

The [README](../README.md) summarizes the most important contract points. This
page is the full runtime contract behind that summary.

The following behavior is part of the library's current runtime contract and
is covered by deterministic tests. Intentional changes to these guarantees
should update both the tests and this documentation.

| Concern | Guarantee |
| --- | --- |
| Telegram API errors | `RequestAsync` returns the response; `ExecuteAsync` throws `ApiRequestException` when `ok` is `false`. |
| Rate limits | Error `429` is retried after Telegram's `retry_after`, up to six retries by default. |
| Other request failures | Timeouts, cancellation, transport failures and non-429 API errors are not retried automatically by `RequestAsync`. |
| Polling session | Only one session can run per client instance; the client can be started again after that session stops unless it was disposed. |
| Polling retries | Transient request timeouts and retryable Telegram errors are retried; non-retryable `4xx` errors stop polling and are rethrown. |
| Update ordering | `maxParallel = 1` is sequential and FIFO; parallel mode does not guarantee update start or completion order. |
| Update handlers | Subscribers run in registration order for each update and each returned task is awaited. A failing subscriber does not prevent later subscribers from running. |
| Delivery | Long polling is best effort. Handler failures are not retried and interrupted sessions may receive an update again. |
| Cancellation | Handlers receive the polling session token, which is canceled by the caller or by `Dispose`. |
| Disposal | `Dispose` stops an active polling session, is idempotent, and rejects new requests with `ObjectDisposedException`. |
| External `HttpClient` | Remains owned by the caller and is never disposed by `BotApiClient`. |
| Internal `HttpClient` | Is owned by `BotApiClient` and disposed with it. |
| Upload source | A fresh stream is opened for each attempt and disposed by the request. |
| Download destination | Remains open and positioned after the downloaded content. |
| Download path | `DownloadFileAsync` and `GetFileBytesAsync` reject absolute paths, parent-directory segments, query strings, fragments, and backslashes. |

## Requests and retries

For `RequestAsync`, the client automatically retries Telegram responses with
error code `429`, waiting for the server-provided `retry_after` interval before
the next attempt. It makes at most six retries by default; configure
`maxRetryAttempts` in the constructor or set it to `0` to disable automatic
retries. For API requests, timeouts, cancellations and other transport failures
are not retried automatically because the client cannot know whether Telegram
processed the original request.

`RequestAsync` returns the envelope after the retries are exhausted, so an
API-level failure is a value to inspect rather than an exception. `ExecuteAsync`
throws `ApiRequestException` when Telegram returns `ok = false`, and the typed
helpers such as `SendMessageAsync` are built on it:

```cs
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

var response = await api.RequestAsync<Message>(new ApiRequest(
    "sendMessage",
    new SendMessageParameters { ChatId = 1234567890L, Text = "Hello" }));

if (!response.Ok)
{
    Console.WriteLine($"{response.ErrorCode}: {response.Description}");
}

try
{
    await api.SendMessageAsync(chatId: 1234567890, text: "Hello");
}
catch (ApiRequestException ex)
{
    Console.WriteLine($"Telegram error {ex.ErrorCode}: {ex.Message}");
}
```

Argument errors, caller cancellation, timeouts, HTTP and network failures, and
malformed JSON responses retain their standard .NET exception types.

`ApiResponse<T>` exposes `Ok`, `ErrorCode`, `Description`, `Parameters` and
`Result`. `ApiRequestException` exposes `ErrorCode` and `Parameters`, while
Telegram's description is its `Message`; the exception has no `Description`
property.

## Polling and update handlers

Only one `StartPollingAsync` session can run on a client instance at a time. A
concurrent start fails with `InvalidOperationException`; after the active
session stops, the same client can be started again unless it was disposed.
`StartPollingAsync` validates `limit` (1-100), `timeout` (non-negative),
`maxParallel` (at least 1), and rejects `UpdateType.Unknown` in
`allowedUpdates`.

All `OnUpdate` subscribers are invoked in registration order and each returned
task is awaited before processing for that update completes. Handlers receive
the polling session's cancellation token so long-running work can stop
cooperatively. A failing subscriber is logged without preventing later
subscribers from running; cancellation caused by the polling token is treated
as a normal shutdown.

Transient request timeouts and retryable Telegram errors are retried with a
short backoff; non-retryable `4xx` errors stop the session and are rethrown as
`ApiRequestException`. `Dispose` cancels an active session, so a hosted service
can stop polling by disposing its client.

`StartPollingAsync` uses best-effort delivery. Handler failures are logged and
are not retried; a failed update is confirmed if the polling loop later sends a
higher offset. Because the offset is neither sent until the next `getUpdates`
request nor persisted by the client, an interrupted polling session may receive
an update again even after its handler ran. Applications that require durable
processing or explicit delivery guarantees should own the `GetUpdatesAsync`
loop and persist their checkpoint explicitly.

## Resource ownership

Path-based upload sources are lazy. Stream factories may be called repeatedly
for retries or repeated requests, and concurrently when the same source is used
by parallel requests. Each call must return an independent readable stream with
equivalent content. The library disposes streams returned to an API request;
code that calls `InputFile.GetStream()` directly owns that returned stream.

The client never disposes a supplied `HttpClient`. If no client is supplied,
`BotApiClient` creates one and disposes it with the bot client; `Dispose` first
cancels an active polling session. Streaming file downloads never dispose the
caller's destination stream.
