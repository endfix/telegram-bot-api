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
dotnet add package Endfix.Telegram.BotAPI
```

## Quick start

Each bot is given a unique authentication token [when it is created](https://core.telegram.org/bots/features#botfather). Store the token in User Secrets or an environment variable; do not put it in `appsettings.json` or source control. You can learn about obtaining tokens and generating new ones in [this document](https://core.telegram.org/bots/features#botfather).

```cs
var api = new BotApiClient(
    "<token>",
    new HttpClient(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromSeconds(5),
        MaxConnectionsPerServer = 10
    })
    {
        Timeout = TimeSpan.FromMinutes(5)
    }
);

var message = await api.SendMessageAsync(
    chatId: 1234567890,
    text: "Hello from Endfix.Telegram.BotAPI");
```

## Examples

- [**Long polling**: sequential (FIFO) or parallel update processing.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/LongPolling)
- [**Webhook**: ASP.NET Core endpoint with secret-token validation.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/Webhook)

Long polling processes updates sequentially in FIFO order by default (`maxParallel = 1`). Set `maxParallel` to a value greater than `1` to enable concurrent processing. FIFO ordering is not guaranteed in parallel mode, including the order in which handlers start or complete. Use sequential processing for stateful workflows that depend on update ordering.

The example projects include placeholder configuration files. Replace the placeholders locally or use User Secrets before running them.

## Retry behavior

The client automatically retries Telegram responses with error code `429`, waiting for the server-provided `retry_after` interval before the next attempt. Timeouts, cancellations and other transport failures are not retried automatically because the client cannot know whether Telegram processed the original request.

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

## Tests

Run the local test suite with:

```bash
dotnet test Telegram.BotAPI.sln
```

Telegram integration tests are disabled unless their credentials are configured. They can send real messages and are intended for a dedicated test bot and chat.

For local runs, configure the required values with .NET User Secrets:

```bash
dotnet user-secrets set "TELEGRAM_BOT_TOKEN" "<token>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_CHAT_ID" "<chat-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "Category=Integration"
```

The same keys can be supplied as environment variables, which take precedence over User Secrets. Integration tests delete their messages after each run by default; set `TELEGRAM_BOT_KEEP_MESSAGES=true` to keep them. The typed video, thumbnail and cover scenario additionally uses the `TELEGRAM_BOT_TEST_VIDEO_PATH`, `TELEGRAM_BOT_TEST_IMAGE_PATH`, `TELEGRAM_BOT_TEST_THUMBNAIL_PATH` and `TELEGRAM_BOT_TEST_COVER_PATH` keys.

## Benchmarks

The [benchmark project](Telegram.BotAPI.Benchmarks/README.md) contains serialization, rich-message and local transport benchmarks, plus sequential and bounded-parallel stress profiles:

```bash
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress
dotnet run --project Telegram.BotAPI.Benchmarks/Telegram.BotAPI.Benchmarks.csproj -c Release -- --stress-parallel 10
```

## Status

The project follows the Telegram Bot API release it targets. The public API may change when Telegram adds or revises API methods and types.

## License

This project is licensed under the [MIT License](LICENSE).
