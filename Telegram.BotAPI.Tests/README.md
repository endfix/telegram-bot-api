# Tests

The test project contains local contract and transport tests together with an
optional live Telegram integration suite. Live tests use real Telegram chats,
messages, files and bot settings, so run them only with dedicated test
resources.

## Local tests

Run tests that do not contact Telegram:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "Category!=Integration"
```

The local suite covers JSON contracts, polymorphic serialization, multipart
transport, retry and error behavior, and long-polling ordering.

## Live test topology

The complete integration suite expects:

- a dedicated bot;
- a private chat between the bot and its owner;
- a supergroup linked to a channel as its discussion group;
- a separate forum-enabled supergroup;
- a channel administered by the bot;
- a non-administrator test user who is a member of the discussion group.

The discussion group and forum must be separate. Telegram does not allow Topics
in a group while it is linked to a channel.

Integration tests are placed in one non-parallel xUnit collection to avoid
concurrent changes to shared Telegram resources.

## BotFather settings

Configure the dedicated bot with:

- group privacy disabled with `/setprivacy`;
- inline mode enabled with `/setinline`;
- Secretary Mode enabled;
- private threaded conversations enabled with `/setthreads`.

The capability test verifies the corresponding `getMe` fields. Telegram warns
that private threaded conversations may affect fees for Telegram Star
purchases; these tests do not make Star purchases.

## Chat permissions

The bot must be an administrator in the discussion group with these rights:

- manage chat;
- change chat info;
- delete messages;
- invite users;
- pin messages.

The bot must be an administrator in the channel with these rights:

- manage channel;
- change channel info;
- delete messages;
- post messages;
- edit messages.

In the forum group, enable Topics and grant the bot permission to manage topics
and delete messages. Enable standard reactions in the group and channel.

## Secrets

Configure values with .NET User Secrets from the repository root:

```bash
dotnet user-secrets set "TELEGRAM_BOT_TOKEN" "<token>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_CHAT_ID" "<private-chat-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_GROUP_ID" "<discussion-group-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_FORUM_ID" "<forum-group-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_CHANNEL_ID" "<channel-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
dotnet user-secrets set "TELEGRAM_BOT_TEST_USER_ID" "<test-user-id>" --project Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj
```

The same names can be supplied as environment variables. Environment variables
take precedence over User Secrets. Never commit tokens or real IDs.

| Key | Purpose |
| --- | --- |
| `TELEGRAM_BOT_TOKEN` | Token of the dedicated test bot |
| `TELEGRAM_BOT_CHAT_ID` | Private chat and owner ID used for messages, profile and sticker tests |
| `TELEGRAM_BOT_GROUP_ID` | Discussion supergroup linked to the test channel |
| `TELEGRAM_BOT_FORUM_ID` | Separate forum-enabled supergroup |
| `TELEGRAM_BOT_CHANNEL_ID` | Test channel linked to the discussion group |
| `TELEGRAM_BOT_TEST_USER_ID` | Ordinary member used by membership and future moderation tests |
| `TELEGRAM_BOT_KEEP_MESSAGES` | Optional `true` value that keeps file-test messages for inspection |

Media files used by multipart tests are versioned under `Fixtures/Media` and
copied to the test output directory. No external media paths are required.

## Running live tests

Run the complete integration suite:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "Category=Integration"
```

Run only chat and forum scenarios:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "FullyQualifiedName~TelegramChatIntegrationTests"
```

Run only file and multipart scenarios:

```bash
dotnet test Telegram.BotAPI.Tests/Telegram.BotAPI.Tests.csproj --filter "FullyQualifiedName~TelegramFileIntegrationTests"
```

Tests whose required secrets are absent are skipped. A fully configured run
currently verifies bot capabilities, chat permissions, channel/discussion
linking, forum topic lifecycle, cross-chat copy and forwarding, profile-photo
restore, sticker-set lifecycle, standalone media, media groups, paid media and
nested rich-message uploads.

## Side effects and rollback

The suite deliberately changes live resources. It creates messages, invite
links, forum topics and sticker sets, temporarily edits group/channel metadata,
and replaces the bot profile photo. Stateful tests use cleanup blocks to restore
metadata and the previous profile photo and to delete or revoke temporary
resources.

`TELEGRAM_BOT_KEEP_MESSAGES=true` only preserves messages created by file tests.
Chat lifecycle tests still clean up their messages and state. A failed cleanup
also fails the test; inspect the dedicated chats after an interrupted process or
network failure.
