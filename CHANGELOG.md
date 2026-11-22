# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project follows [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2026-11-22

Targets Bot API 10.5 (November 22, 2026). This is a major release with the
intentional breaking changes listed under **Changed**.

### Added

- Bot API 10.5 support: `setMySettings` through `SetMySettingsParameters`
  and `SetMySettingsAsync`, the `CallbackQueryMode` enum, and the
  `active_usernames`, `inline_query_placeholder`,
  `needs_inline_query_location`, and `has_topic_sidebar` fields of
  `BotFullInfo`.
- `BotFullInfo`, returned by `getMe`, and `WriteAccessAllowed.Inviter` for
  service messages about users invited to a private chat by the bot's owner.
- A long-polling stress harness (`--polling-stress`) that drives
  `StartPollingAsync` through an in-process fake `getUpdates` transport and
  reports throughput, allocations, Working Set, observed handler concurrency,
  delivery order, exception isolation, and shutdown latency for batches of 10,
  100, 1,000 and 10,000 updates crossed with `maxParallel` values of 1, 4, 10
  and 32. It is a development tool and is not shipped in the package.

### Changed

- `getMe` and `GetMeAsync` now return `BotFullInfo` instead of `User`. The
  legacy bot-only properties on `User` remain for source and binary
  compatibility but are no longer populated; read them from `BotFullInfo`.
- `RichBlockExpandableBlockQuotation` and
  `InputRichBlockExpandableBlockQuotation` carry their content in `Blocks`
  instead of `Text`, matching Bot API 10.5.
- The package README now pins its install command to the release that ships
  it, so the nuget.org page never names an older version. The repository copy
  stays unpinned and installs the latest stable package.

## [2.0.1] - 2026-11-16

Performance and documentation only: the public API surface is unchanged, so
upgrading from `2.0.0` requires no code changes.

### Changed

- Multipart requests that reference nested local files no longer re-sort the
  parameter properties for every nested object and no longer visit properties
  whose type cannot carry a local file. On the focused prepare benchmarks
  `PrepareMemoryMediaGroup10` drops from 24.16 KB to 19.55 KB and
  `PrepareMemoryNestedPoll2` from 10.38 KB to 8.52 KB, with unchanged timing;
  the request body and `attach://` numbering are byte-identical.
- The README now opens with a table of contents, a capabilities-and-limitations
  table, and a complete polling bot example. Detailed compatibility, behavior,
  file-handling, custom-request, migration, and development notes moved to the
  `docs/` directory and are linked from the README. The behavior guide now shows
  both error paths: the `RequestAsync` envelope and the `ExecuteAsync` exception.
- `BotApiClient` caches each method's request `Uri` per client instance and
  resolves it lazily on first use, instead of rebuilding the relative string and
  parsing a new `Uri` on every call. On the focused transport benchmark
  `RequestAndDeserialize` drops from 4,157 B to 3,758 B and from 4.36 µs to
  3.60 µs, and `RequestWithoutParametersAndDeserialize` from 3,707 B to 3,348 B
  and from 3.26 µs to 2.64 µs. The per-request saving no longer appears in
  Gen0; the trade-off is one dictionary entry and one `Uri` for each method name
  a client actually uses. Benchmarks are in
  `Telegram.BotAPI.Benchmarks/RESULTS.md`.

## [2.0.0] - 2026-11-10

Targets Bot API 10.4 (November 9, 2026). This is a major release with the
intentional breaking changes listed under **Changed**.

### Added

- Bot API 10.4 widgets: `Widget`, `Message.Widget`,
  `ExternalReplyInfo.Widget`, `SendWidgetAsync`, `SendSharedWidgetAsync`,
  `WidgetQuery`, `SharedWidgetQuery`, `Update.WidgetQuery`,
  `Update.SharedWidgetQuery`, `WidgetQueryType` with `WidgetQueryTypeData`,
  `WidgetQueryTypeSignData`, `WidgetQueryTypeSentTransaction`, and
  `WidgetQueryWallet`, plus `AnswerWidgetQueryAsync`, `EditMessageWidgetDataAsync`,
  `EditSharedWidgetDataAsync`, `InputWidgetMessageContent`, and
  `InputSharedWidgetMessageContent`.
- Bot API 10.4 ephemeral callback replies: `chat_id` and
  `EphemeralMessageParameters.ReceiverUserId` are now optional.
- Bot API 10.4 quotes from rich messages: `TextQuote.RichTexts` and
  `ReplyParameters.QuoteRichTexts`.
- Bot API 10.4 TON wallet support: `TonWalletCard`,
  `TonWalletCardSticker`, `TonNft`, `TonNftAttribute`,
  `ChatFullInfo.TonWalletCard`, `TonWalletTransfer`, and
  `Message.TonWalletTransfer`.
- Bot API 10.4 chat share themes: `ChatShareTheme`,
  `ChatShareThemeEmoji`, `ChatShareThemeUniqueGift`,
  `ChatFullInfo.ShareTheme`, `EmojiType`, `EmojiTypeEmoji`,
  `EmojiTypeCustomEmoji`, `ChatShareThemeBackdrop`,
  `ChatShareThemeBackdrops`, and `GetChatShareThemeBackdropsAsync`.
- Bot API 10.4 gifts: `GetUniqueGiftAsync` for `getUniqueGift` and
  `DeleteBusinessAccountGiftAsync` for `deleteBusinessAccountGift`.
- Bot API 10.4 general coverage: `RichTextTonAddress`,
  `RichTextType.TonAddress`, `MessageEntityType.TonAddress`,
  `MessageEntityType.BankCardNumber`,
  `KeyboardButtonRequestManagedBot.SuggestedUsername`,
  `custom_description_parse_mode` and `custom_description_entities` on
  `VerifyUserAsync` and `VerifyChatAsync`, and `PaidMessagesWaived` with
  `Message.PaidMessagesWaived`.
- Tests for the 10.4 serialization contract, `ParseMode` wire values, and the
  widget inline message content shapes.
- A package icon for NuGet and GitHub.

### Changed

- **Breaking:** `ParseMode` is an enum instead of a class of string
  constants. All `parse_mode` properties and parameters now use `ParseMode?`;
  the wire values remain `MarkdownV2`, `HTML`, and `Markdown`.
- **Breaking:** renamed `StoryAreaPosition` to `AreaPosition` because Telegram
  now also uses it for TON wallet card stickers.
- **Breaking:** `ChatId` is optional in the send parameters for `sendMessage`,
  `sendAnimation`, `sendAudio`, `sendContact`, `sendDocument`, `sendLivePhoto`,
  `sendLocation`, `sendPhoto`, `sendSticker`, `sendVenue`, `sendVideo`,
  `sendVideoNote`, `sendVoice`, and `sendRichMessage`, and the matching
  convenience overloads accept `ChatIdSource?`. A chat is still required except
  for an ephemeral reply to a callback query.
- **Breaking:** sealed `GetMyNameParameters`, `SetWebhookParameters`, and
  `GetBusinessAccountGiftsParameters`.
- **Breaking:** renamed the `cancellation` parameter to `cancellationToken` in
  `RequestAsync` and `GetFileBytesAsync` on `BotApiClient` and
  `IBotApiClient`.
- Package validation has no baseline for `2.0.0`; restore the `2.0.0` baseline
  after this release is published.
- The publish workflow now stamps the release tag into
  `AssemblyInformationalVersion`, so the packaged assembly reports the released
  version instead of the default `1.0.0`.

### Fixed

- `InputWidgetMessageContent` and `InputSharedWidgetMessageContent` now derive
  from `InputMessageContent`, and the inline content converter recognizes the
  `html` and `widget_id` shapes.
- Corrected stale XML documentation references and descriptions for the renamed
  types and methods.
- Removed a stray `Enums` using from `KeyboardButtonRequestManagedBot` and
  repaired corrupted quotation characters in XML documentation.

## [1.0.2] - 2026-11-05

### Added

- Added a `net48` smoke harness under `eng/NetFrameworkSmoke` that exercises the
  `netstandard2.0` asset and optional live Telegram calls.

### Changed

- Long polling now validates `limit`, `timeout`, `maxParallel`, and
  `allowedUpdates`, retries transient `HttpClient` timeouts, honors
  `retry_after` for retryable Telegram errors, and stops on non-retryable
  `4xx` errors.
- `BotApiClient.Dispose` now cancels an active polling session and is
  idempotent; requests after disposal throw `ObjectDisposedException`.
- `ApiRequest` requires a method name that starts with an ASCII letter and
  contains only ASCII letters, digits, and underscores. `DownloadFileAsync`
  rejects parent-directory segments, absolute paths, query strings, fragments,
  and backslashes.

### Fixed

- `ChatIdSource` serialization now throws `JsonException` for a default value
  instead of `NullReferenceException`.
- `MediaSource` deserialization now rejects non-string JSON tokens.

## [1.0.1] - 2026-09-24

### Changed

- Give <c>BotApiClient.ExecuteAsync</c> the same optional cancellation token
  as <c>IBotApiClient.ExecuteAsync</c>.
- Include Telegram's error description when the API envelope is invalid.
- Return the inner task from typed extension wrappers instead of wrapping
  each call in an extra async state machine.
- Compare the public API against the `1.0.0` NuGet package during pack.

### Fixed

- Detect uploaded files on custom <c>ApiRequestParameters</c> types outside
  the library namespace so <c>RequestAsync</c> still uses multipart.

## [1.0.0] - 2026-09-24

### Added

- Added <c>RequestAsync</c> to <c>IBotApiClient</c> so custom requests use the
  same injected client as the typed helpers.

### Changed

- Send parameterized requests without uploaded files as `application/json`.
  Keep `multipart/form-data` only when an `InputFile` is present in the
  request graph.
- Reworked the ASP.NET Core webhook example to the same singleton client,
  scope-per-update, and hosted lifetime model as long polling.
- Clarified that the package is a low-level Bot API client, not a bot
  framework.
- Treat long-polling cancellation during parallel dispatch as a normal stop.
  `ExecuteAsync` and the polling loop no longer capture a synchronization
  context.
- Renamed <c>SetGameScoreInlineAsync</c> to
  <c>SetGameScoreForInlineMessageAsync</c> to match
  <c>SetGameScoreForMessageAsync</c>.
- Split <c>editMessage*</c> and <c>stopMessageLiveLocation</c> into
  <c>ForMessage</c> (<c>Message</c>) and <c>ForInlineMessage</c> (<c>bool</c>)
  overloads. Telegram returns <c>true</c> for inline messages, which cannot
  deserialize as <c>Message</c>.

The public contract is frozen. Incompatible API changes will require a major
version. Additive Telegram Bot API coverage remains a minor version.

## [0.6.0] - 2026-09-15

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
- Consolidated committed benchmark evidence into one rolling human-readable
  report and one normalized JSON data file; raw exports remain CI artifacts.
- Added automatic GitHub Release creation from the matching changelog section
  when a version tag is built, and made repeat package publication idempotent.

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

[3.0.0]: https://github.com/endfix/telegram-bot-api/compare/v2.0.1...v3.0.0
[2.0.1]: https://github.com/endfix/telegram-bot-api/compare/v2.0.0...v2.0.1
[2.0.0]: https://github.com/endfix/telegram-bot-api/compare/v1.0.2...v2.0.0
[1.0.2]: https://github.com/endfix/telegram-bot-api/compare/v1.0.1...v1.0.2
[1.0.1]: https://github.com/endfix/telegram-bot-api/compare/v1.0.0...v1.0.1
[1.0.0]: https://github.com/endfix/telegram-bot-api/compare/v0.6.0...v1.0.0
[0.6.0]: https://github.com/endfix/telegram-bot-api/compare/v0.5.0...v0.6.0
[0.5.0]: https://github.com/endfix/telegram-bot-api/compare/v0.4.0...v0.5.0
