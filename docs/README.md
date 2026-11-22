# Documentation

The guides below cover the parts of the library that need more detail than the
[README](../README.md) summary.

## Guides

| Guide | Contents |
| --- | --- |
| [Runtime compatibility](compatibility.md) | Target frameworks, NuGet asset selection, the full consumer-target table, dependency footprint, and trimming/Native AOT expectations. |
| [Behavior and guarantees](behavior.md) | The tested runtime contract: errors and retries, polling sessions and update handlers, delivery semantics, disposal, and resource ownership. |
| [Files: uploads and downloads](files.md) | Local path, in-memory, and stream-factory sources; ownership and retry rules; buffered and streaming downloads. |
| [Custom requests](custom-requests.md) | Deriving from `ApiRequestParameters`, JSON naming, multipart switching, and nested `attach://` references. |
| [Live-verified methods](verified-methods.md) | Methods exercised against the real Bot API, the request shapes that worked, confirmed gotchas, and what is still compiled-only. |
| [Migrating from 1.x to 2.0](migrating-to-2.0.md) | The intentional source and binary breaking changes in the 2.0 release. |
| [Migrating from 2.x to 3.0](migrating-to-3.0.md) | The intentional source and binary breaking changes in the 3.0 release. |
| [Development](development.md) | SDK requirements, test commands, package smoke tests, README validation, benchmarks, API documentation sources, and the release process. |

## Examples

| Example | Contents |
| --- | --- |
| [Long polling](../Telegram.BotAPI.Examples/LongPolling/README.md) | `ILogger` integration, hosted lifetime, scope-per-update, and sequential or parallel processing. |
| [Webhook](../Telegram.BotAPI.Examples/Webhook/README.md) | ASP.NET Core hosted webhook registration, secret-token validation, and scope-per-update processing. |
| [Mini App](../Telegram.BotAPI.Examples/MiniApp/README.md) | Browser capability harness for Telegram Web App and Premium scenarios. |

## Project documentation

| Document | Contents |
| --- | --- |
| [Tests](../Telegram.BotAPI.Tests/README.md) | Live test topology, BotFather settings, secrets, rollback behavior, and focused run commands. |
| [Benchmarks](../Telegram.BotAPI.Benchmarks/README.md) | Benchmark groups, stress profiles, and how to run them. |
| [Benchmark results](../Telegram.BotAPI.Benchmarks/RESULTS.md) | Environment, interpretation, all measurements, and historical comparisons. |
| [Changelog](../CHANGELOG.md) | Release notes and unreleased changes. |
