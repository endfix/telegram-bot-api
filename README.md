# Telegram Bot API (С#)
[![Bot%20API](https://img.shields.io/badge/Bot%20API-10.3-red.svg)](https://core.telegram.org/bots/api#august-24-2026)
[![.NET%20Standard](https://img.shields.io/badge/.NET%20Standard-2.0-blue.svg)](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)

Typed .NET client for the Telegram Bot API. The library targets .NET Standard 2.0 and uses `System.Text.Json` for request and response contracts.

## Installation

```bash
dotnet add package Endfix.Telegram.BotAPI
```

## Features

- strongly typed Bot API methods, parameters and response models;
- polymorphic JSON serialization for Telegram union types;
- JSON and multipart/form-data requests;
- local file uploads, Telegram file IDs and `attach://` references;
- long polling and webhook examples;
- unit tests for serialization and transport contracts.

## Initialization
Each bot is given a unique authentication token [when it is created](https://core.telegram.org/bots/features#botfather). Store the token in User Secrets or an environment variable; do not put it in `appsettings.json` or source control. You can learn about obtaining tokens and generating new ones in [this document](https://core.telegram.org/bots/features#botfather).
```cs
var api = new BotApiClient(
    "<token>",
    new HttpClient(new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromSeconds(5), MaxConnectionsPerServer = 10 }) { Timeout = TimeSpan.FromMinutes(5) }
);
```

## Examples
 * [**Long polling**: Sequential (FIFO) or parallel update processing.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/LongPolling)
 * [**Webhook**: Built-in exponential backoff and retry policy.](https://github.com/endfix/telegram-bot-api/tree/main/Telegram.BotAPI.Examples/Webhook)

The example projects include placeholder configuration files. Replace the placeholders locally or use User Secrets before running them.

## Download file
Use this method to get basic information about a file and prepare it for downloading. For the moment, bots can download files of up to 20MB in size.
```cs
var message = await api.SendDocumentAsync(chatId: 1234567890, document: new InputDocumentFile("path to file"));

var file = await api.GetFileAsync(fileId: message.Document!.FileId);

var fileBytes = await api.GetFileBytesAsync(filePath: file.FilePath!);

File.WriteAllBytes("path to downloaded file", fileBytes);
```

## Tests

Run the local test suite with:

```bash
dotnet test Telegram.BotAPI.sln
```

Telegram integration tests are disabled unless their environment variables are configured. They can send real messages and are intended for a dedicated test bot and chat.

## Status

The project follows the Telegram Bot API release it targets. The public API may change when Telegram adds or revises API methods and types.

## License

This project is licensed under the [MIT License](LICENSE).
