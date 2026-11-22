# Migrating from 2.x to 3.0

The [README](../README.md) links here for the complete list of 3.0 changes.

Version `3.0` targets Bot API `10.5` (November 22, 2026) and contains
intentional source and binary breaking changes required by that Bot API
release:

- `getMe` and `GetMeAsync` now return `BotFullInfo` instead of `User`.
  `BotFullInfo` contains every field that `getMe` returned before, plus
  `active_usernames`, `inline_query_placeholder`,
  `needs_inline_query_location`, and `has_topic_sidebar`. Code that assigned
  the result to `User` must use `BotFullInfo` or `var`.
- The bot-only properties on `User` (`CanJoinGroups`,
  `CanReadAllGroupMessages`, `SupportsGuestQueries`, `SupportsInlineQueries`,
  `CanConnectToBusiness`, `HasMainWebApp`, `HasTopicsEnabled`,
  `AllowsUsersToCreateTopics`, `CanManageBots`, and
  `SupportsJoinRequestQueries`) remain for source and binary compatibility but
  are no longer populated. Read them from `BotFullInfo`.
- `RichBlockExpandableBlockQuotation` and
  `InputRichBlockExpandableBlockQuotation` replaced `Text` with `Blocks`,
  matching Bot API 10.5. Replace `Text = oldText` with a `Blocks` list that
  contains one paragraph block carrying the same text.
- The assembly identity moves from `2.0.0.0` to `3.0.0.0`. Applications that
  reference the library directly are unaffected, but assemblies that bind to
  `Endfix.Telegram.BotAPI` by version must be recompiled against `3.x`.

The additive 10.5 surface needs no migration work: `setMySettings` is exposed
through `SetMySettingsParameters` and `SetMySettingsAsync`, callback query mode
is the `CallbackQueryMode` enum, and `WriteAccessAllowed.Inviter` is populated
for invites sent by the bot's owner.
