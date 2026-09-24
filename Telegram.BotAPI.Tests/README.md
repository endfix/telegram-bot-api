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

The local suite covers JSON contracts, polymorphic serialization, JSON request
bodies for methods without files, multipart transport for path, memory and
stream-factory file sources, stream disposal and retry behavior, error
behavior, and long-polling ordering.

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

The inline-message edit test is interactive. It sends a private-chat prompt
with a button that opens inline mode; `/start` in that chat resends the prompt.
Select the offered result. Telegram only assigns `inline_message_id` when the
result includes an inline keyboard. The test skips if no result is chosen
within 3 minutes.

## Chat permissions

The bot must be an administrator in the discussion group with these rights:

- manage chat;
- change chat info;
- delete messages;
- invite users;
- pin messages.
- restrict members.

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
| `TELEGRAM_BOT_TEST_USER_ID` | Ordinary member used by membership and rollback-safe restriction tests |
| `TELEGRAM_BOT_KEEP_MESSAGES` | Optional `true` value that keeps file-test messages for inspection |
| `TELEGRAM_BOT_GROUP_STICKER_SET_ACCESS` | Optional `true` value enabling the group sticker-set test after `getChat` reports `can_set_sticker_set=true` |

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

Tests whose required secrets are absent are skipped. CI does not run this
suite. There is no timing snapshot: live duration is Telegram RTT and rate
limits, not client CPU.

### Live coverage matrix

Required secrets are the minimum for that row. Extra opt-in flags are listed
under Skip. Methods named in the tests are the Bot API methods exercised, not
a complete Telegram catalog.

| Area | Test | Secrets | Skip / note |
| --- | --- | --- | --- |
| Bot | `BotFatherCapabilities_AreEnabled` | token, chat | — |
| Bot | `BotChatSettings_RollBack` | token, chat | Telegram may `429` `setMyName` for many hours after a previous run |
| Bot | `BotDefaultAdministratorRights_RollBack` | token, chat | — |
| Private chat | `PrivateChatStructuredMessages_AreDeliveredAndDeleted` | token, chat | drafts, venue, contact, stop poll |
| Private chat | `OrdinaryChatMessageEdits_ReturnEditedMessage` | token, chat | `editMessageText` / `editMessageReplyMarkup` return `Message` |
| Inline | `InlineMessageEdits_ReturnTrue` | token, chat | Interactive: tap the bot prompt (or `/start`) and choose the result. Skips after 3 minutes. Covers `editMessage*` `true` for inline |
| Group | `GroupConfiguration_IsUsable` | token, group | — |
| Group | `GroupDefaultPermissions_RollBack` | token, group | — |
| Group | `GroupMetadataMessageAndInviteLink_RollBack` | token, group | Title/description restore treats Telegram `not modified` as success |
| Channel | `ChannelConfiguration_IsUsable` | token, channel | — |
| Channel | `ChannelMetadataAndMessage_RollBack` | token, channel | Empty `setMessageReaction` list can return `REACTION_EMPTY` |
| Channel | `ChannelPhoto_RollBack` | token, channel | Restores bytes, not a cached file ID |
| Routing | `ChannelAndGroup_AreLinkedForDiscussion` | token, chat, group, channel | — |
| Routing | `ChannelReadOnlyCollections_Deserialize` | token, chat, group, channel | gifts, boosts |
| Routing | `Messages_CopyAndForwardAcrossConfiguredChats` | token, chat, group, channel | — |
| Forum | `ForumConfiguration_IsUsable` | token, forum | — |
| Forum | `ForumTopicLifecycle_RollBack` | token, forum | — |
| Moderation | `TestUser_IsVisibleInGroup` | token, group, test user | — |
| Moderation | `TestUserRestriction_RollBack` | token, group, test user | No `banChatMember`/`unbanChatMember` |
| Moderation | `TestUserTag_RollBack` | token, group, test user | Needs Manage Tags |
| Moderation | `TestUserPromotionAndCustomTitle_RollBack` | token, group, test user | Needs Add New Admins |
| Premium | `PremiumOwner_CustomEmojiButton_RoundTrips` | token, chat, group | Skips if `getChatMember` has no `is_premium` |
| Premium | `PremiumUser_ReadOnlyProfileCollections_Deserialize` | token, chat, group | Same Premium skip |
| Premium | `PremiumUser_EmojiStatus_MutationIsAcceptedAndRestored` | token, chat, group | Also needs Mini App grant and `TELEGRAM_BOT_EMOJI_STATUS_ACCESS=true` |
| Files | `SendPhoto_UploadsLocalFile_ThenResendsByFileId` | token, chat | Path then file_id |
| Files | `SendDocument_UploadsLocalFile_ThenResendsByFileId` | token, chat | — |
| Files | `DownloadFile_StreamsTelegramDocumentAndLeavesDestinationOpen` | token, chat | — |
| Files | `SendMediaGroup_UploadsFilesThroughAttachReferences` | token, chat | — |
| Files | `SendMediaGroup_UploadsTypedVideoThumbnailAndCover` | token, chat | — |
| Files | `SendPaidMedia_UploadsLocalPhoto_ThenResendsByFileId` | token, chat | — |
| Files | `SendPoll_UploadsNestedOptionAndDescriptionMedia` | token, chat | — |
| Files | `SendAdditionalStandaloneMedia_UploadsLocalFiles` | token, chat | — |
| Files | `SendRichMessage_UploadsPhotoFromNestedBlock` | token, chat | — |
| Files | `SetMyProfilePhoto_UploadsNestedPhoto_ThenRestoresPreviousPhoto` | token, chat | — |
| Files | `UpdatingMethods_ForwardChatAndReplyMarkupParameters` | token, chat | Caption, media, live location, reply markup on ordinary messages |
| Files | `StickerSetMethods_UploadNestedFiles` | token, chat | — |
| Files | `ChatStickerSet_RollBack` | token, chat, group | Opt-in: group with 100+ members and `TELEGRAM_BOT_GROUP_STICKER_SET_ACCESS=true` |

Not covered on purpose: payments/business live, webhooks, `banChatMember` followed by `unbanChatMember`. Local contract tests cover JSON vs multipart routing without Telegram.

Live-test HTTP calls are spaced by 500 ms. Clients still disable automatic
retries for Telegram `429` responses so a run reports the affected method and
`retry_after` value instead of waiting for a potentially long server cooldown.

The bot needs the **Add New Admins** and **Manage Tags** administrator rights for
the promotion and member-tag scenarios. The group sticker-set scenario is
disabled by default because Telegram exposes group sticker sets only for groups
with at least 100 members; smaller groups omit `can_set_sticker_set` even when
the bot can change chat information. Enable it only for an eligible supergroup
by setting `TELEGRAM_BOT_GROUP_STICKER_SET_ACCESS=true`.

Premium scenarios derive the user ID from `TELEGRAM_BOT_CHAT_ID` and verify the
account through `getChatMember` before exercising Premium-dependent behavior.
When Telegram does not report `is_premium`, only those scenarios are skipped;
the rest of the live suite remains unaffected.

The emoji-status mutation additionally requires the user to grant access through
the Mini App example. Set `TELEGRAM_BOT_EMOJI_STATUS_ACCESS=true` only after that
permission has been granted. The test restores the user's previous emoji status
and expiration date in its cleanup block.

## Side effects and rollback

The suite deliberately changes live resources. It creates messages, invite
links, forum topics and sticker sets, temporarily edits group/channel metadata,
member tags, administrator status, per-chat bot settings and an unused
Esperanto localization, and replaces the bot profile photo. Stateful tests use
cleanup blocks to restore the previous values and to delete or revoke temporary
resources.

`TELEGRAM_BOT_KEEP_MESSAGES=true` only preserves messages created by file tests.
Chat lifecycle tests still clean up their messages and state. A failed cleanup
also fails the test; inspect the dedicated chats after an interrupted process or
network failure.

The regular suite does not exercise `banChatMember` followed by
`unbanChatMember`: unbanning allows a user to rejoin but does not restore their
membership. That lifecycle requires an explicitly destructive scenario and a
cooperating account that rejoins the group afterward.

The channel-photo test downloads the current large photo before making any
change because Telegram invalidates chat-photo file IDs when the photo changes.
It restores the saved bytes by uploading them as a new photo during cleanup.
