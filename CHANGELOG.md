# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project follows [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Added a native `net8.0` package asset alongside `netstandard2.0`.
- Added packaged-asset smoke tests for .NET 6 and .NET 8 consumers.
- Added hosted long-polling and explicitly configured logging examples.

### Changed

- Reorganized the README around the consumer workflow and documented runtime,
  retry, delivery, cancellation, and resource-ownership guarantees.
- Aligned the `netstandard2.0` dependency baseline with .NET 8:
  `System.Text.Json` 8.0.6 and `Microsoft.Extensions.Logging.Abstractions` 8.0.3.
- Separated multipart request preparation from response handling without
  changing disposal semantics.
- Normalized the invoice extension's `chatId` parameter casing.
- Kept required-member compiler shims internal and limited them to the
  `netstandard2.0` asset.
- Made stress profiles warm up their measured concurrency shape, report total
  allocations and GC mode, and exclude measurement-induced collections.

### Fixed

- Preserve unexpected enum converter failures instead of treating every
  exception as an unknown enum value.
- Freeze the shared serializer options during type initialization to prevent
  process-wide mutation; callers can still copy them for customization.
- Parse numeric chat identifiers using the invariant JSON contract regardless
  of the process culture.
- Serialize live-photo message effect identifiers and vCard fields using the
  Telegram wire types and names.
- Preserve the absence of optional migration and retry response parameters
  instead of exposing their default numeric values.
- Dispose an opened upload stream if multipart header validation fails before
  its content is transferred to the request container.

## [0.5.0] - 2026-09-09

### Added

- Added parameter-object overloads across the Bot API client.
- Added reusable local, memory-backed, and stream-backed input file sources,
  plus streaming file downloads with explicit ownership contracts.
- Added multipart source diagnostics, reproducible BenchmarkDotNet snapshots,
  and million-request stress profiles.
- Expanded rollback-safe live coverage for chats, channels, administrators,
  subscriptions, gifts, boosts, Mini Apps, and interactive long polling.
- Added comprehensive XML documentation for the public API, request models,
  response models, extension methods, and enum values.

### Changed

- Reworked the README to document runtime compatibility, upload choices,
  resource ownership, polling behavior, and production usage.

### Fixed

- Preserved custom Bot API URL path prefixes.
- Preserved original input-source open exceptions.
- Corrected `deleteStory` and user-gift response contracts.

[Unreleased]: https://github.com/endfix/telegram-bot-api/compare/v0.5.0...HEAD
[0.5.0]: https://github.com/endfix/telegram-bot-api/compare/v0.4.0...v0.5.0
