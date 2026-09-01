# Telegram Bot API (С#)
[![Bot%20API](https://img.shields.io/badge/Bot%20API-10.3-red.svg)](https://core.telegram.org/bots/api#august-24-2026)
[![.NET%20Standard](https://img.shields.io/badge/.NET%20Standard-2.0-blue.svg)](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)
[![NuGet](https://img.shields.io/nuget/v/Endfix.Telegram.BotAPI.svg)](https://www.nuget.org/packages/Endfix.Telegram.BotAPI/)

Typed .NET client for the Telegram Bot API. The library targets .NET Standard 2.0 and uses `System.Text.Json` for request and response contracts.

## Features

- strongly typed Bot API methods, parameters and response models;
- polymorphic JSON serialization for Telegram union types;
- JSON and multipart/form-data requests;
- local file uploads, Telegram file IDs and `attach://` references;
- sequential or parallel long polling and an ASP.NET Core webhook example;
- contract, transport and live Telegram integration tests;
- BenchmarkDotNet suites and million-request stress profiles.

## Installation

```bash
dotnet add package Endfix.Telegram.BotAPI --version 0.4.0
```

## Quick start

Each bot is given a unique authentication token [when it is created](https://core.telegram.org/bots/features#botfather). Store the token in User Secrets or an environment variable; do not put it in `appsettings.json` or source control. You can learn about obtaining tokens and generating new ones in [this document](https://core.telegram.org/bots/features#botfather).

```cs
using var httpClient = new HttpClient(new SocketsHttpHandler
{
    PooledConnectionLifetime = TimeSpan.FromSeconds(5),
    MaxConnectionsPerServer = 10
})
{
    Timeout = TimeSpan.FromMinutes(5)
};

using var api = new BotApiClient(
    "<token>",
    httpClient);

var message = await api.SendMessageAsync(
    chatId: 1234567890,
    text: "Hello from Endfix.Telegram.BotAPI");
```

`BotApiClient` disposes the `HttpClient` it creates when none is supplied. A supplied `HttpClient` remains owned by the caller and should normally be reused for the application's lifetime.

## Examples

- [**Long polling**: sequential (FIFO) or parallel update processing.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/LongPolling)
- [**Webhook**: ASP.NET Core endpoint with secret-token validation.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/Webhook)

Both examples accept `TELEGRAM_BOT_TOKEN` from an environment variable or .NET User Secrets while retaining their existing `appsettings.json` keys as a fallback:

```bash
dotnet user-secrets set "TELEGRAM_BOT_TOKEN" "<token>" --project Telegram.BotAPI.Examples/LongPolling/Telegram.BotAPI.Example.LongPolling.csproj
dotnet user-secrets set "TELEGRAM_BOT_TOKEN" "<token>" --project Telegram.BotAPI.Examples/Webhook/Telegram.BotAPI.Example.Webhook.csproj
```

Long polling processes updates sequentially in FIFO order by default (`maxParallel = 1`). Set `maxParallel` to a value greater than `1` to enable concurrent processing. FIFO ordering is not guaranteed in parallel mode, including the order in which handlers start or complete. Use sequential processing for stateful workflows that depend on update ordering.

Only one `StartPollingAsync` session can run on a client instance at a time. A concurrent start fails with `InvalidOperationException`; after the active session stops, the same client can be started again.

All `OnUpdate` subscribers are invoked in registration order and each returned task is awaited before processing for that update completes. Handlers receive the polling session's cancellation token so long-running work can stop cooperatively. A failing subscriber is logged without preventing later subscribers from running; cancellation caused by the polling token is treated as a normal shutdown.

`StartPollingAsync` uses best-effort delivery. Handler failures are logged and are not retried; a failed update is confirmed if the polling loop later sends a higher offset. Because the offset is neither sent until the next `getUpdates` request nor persisted by the client, an interrupted polling session may receive an update again even after its handler ran. Applications that require durable processing or explicit delivery guarantees should own the `GetUpdatesAsync` loop and persist their checkpoint explicitly.

The example projects include placeholder configuration files. Replace the placeholders locally or use User Secrets before running them.

## Retry behavior

The client automatically retries Telegram responses with error code `429`, waiting for the server-provided `retry_after` interval before the next attempt. It makes at most six retries by default; configure `maxRetryAttempts` in the constructor or set it to `0` to disable automatic retries. Timeouts, cancellations and other transport failures are not retried automatically because the client cannot know whether Telegram processed the original request.

`RequestAsync` returns Telegram API responses, while `ExecuteAsync` throws `ApiRequestException` when Telegram returns `ok = false`. Argument errors, caller cancellation, timeouts, HTTP and network failures, and malformed JSON responses retain their standard .NET exception types.

## Downloading files

Use this method to get basic information about a file and prepare it for downloading. For the moment, bots can download files of up to 20MB in size.

```cs
var message = await api.SendDocumentAsync(
    chatId: 1234567890,
    document: new InputDocumentFile("report.pdf"));

var file = await api.GetFileAsync(message.Document!.FileId);
var fileBytes = await api.GetFileBytesAsync(file.FilePath!);

await File.WriteAllBytesAsync("downloaded-report.pdf", fileBytes);
```

## Development

Repository builds are pinned to .NET SDK `9.0.317` through `global.json`. The complete solution also runs `net8.0` tests and examples, so install the .NET 8 SDK or runtime alongside SDK 9 when working locally. CI installs both SDK versions explicitly.

## Tests

Run the solution test suite (live integration tests are skipped when their secrets are not configured):

```bash
dotnet test Telegram.BotAPI.sln
```

Telegram integration tests are disabled unless their credentials are configured. They can send real messages and are intended for a dedicated test bot and chat.

Run local tests without contacting Telegram:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "Category!=Integration"
```

See the [test project guide](Telegram.BotAPI.Tests/README.md) for the live test topology, BotFather settings, administrator rights, secrets, rollback behavior and focused run commands.

## Benchmarks

The [benchmark project](Telegram.BotAPI.Benchmarks/README.md) contains serialization, rich-message and local transport benchmarks, plus sequential and bounded-parallel stress profiles:

```bash
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress-parallel 10
```

## Status

The project follows the Telegram Bot API release it targets. While the package remains below `1.0`, public contracts may still change to correct modeling issues or complete the file-source API. After `1.0`, incompatible public API changes will require a major version.

## Releases

Push the intended release commit to `main` and wait for CI to pass before creating a `vX.Y.Z` tag. Pushing the tag starts the publish workflow, which independently restores, builds, tests, packs with the version derived from the tag, and publishes the package to NuGet.

## License

This project is licensed under the [MIT License](LICENSE).
