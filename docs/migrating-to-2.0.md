# Migrating from 1.x to 2.0

The [README](../README.md) links here for the complete list of 2.0 changes.

Version `2.0` targets Bot API `10.4` and contains intentional source and binary
breaking changes that were deferred from the `1.x` line:

- `ParseMode` is now an enum in `Endfix.Telegram.BotAPI.Enums` instead of a class
  of string constants. Every `parse_mode` property and parameter uses
  `ParseMode?`. Add `using Endfix.Telegram.BotAPI.Enums;` and replace
  `ParseMode = "HTML"` with `ParseMode = ParseMode.HTML`. The wire values stay
  `MarkdownV2`, `HTML`, and `Markdown`.
- `StoryAreaPosition` was renamed to `AreaPosition`; update type references.
- The send-message convenience overloads accept `ChatIdSource? chatId`, and the
  matching send parameters no longer require `ChatId`. Pass a chat for a regular
  send; omit it only for an ephemeral reply to a callback query.
- `EphemeralMessageParameters.ReceiverUserId` is optional when the message is an
  ephemeral reply to a callback query.
- `GetMyNameParameters`, `SetWebhookParameters`, and
  `GetBusinessAccountGiftsParameters` are sealed.
- `RequestAsync` and `GetFileBytesAsync` renamed the `cancellation` parameter to
  `cancellationToken` on `BotApiClient` and `IBotApiClient`. Update named
  arguments that use `cancellation:`.
- Package validation has no baseline for `2.0.0`; the compatibility check
  against `2.0.0` resumes with the next release.
