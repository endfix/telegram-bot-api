# Live-verified methods

This page records which parts of the library have been exercised against the
real Bot API, not just compiled and unit-tested. The point is to keep "it
builds" and "Telegram accepted the call" from being confused with each other,
and to write down the request shapes that are known to work.

## Environment

- Library: `Endfix.Telegram.BotAPI` 2.0.1, `net8.0` asset.
- Verified in November 2026 against `https://api.telegram.org`.
- Manual harness: a small console app that reads the token from
  `TELEGRAM_BOT_TOKEN` and drives a real, private video-sticker pack end to end —
  render, upload, create, extend, replace, retag, inspect. No test doubles, no
  local Bot API server.
- Content: 512×512 WebM/VP9 stickers with alpha, 36–40 frames at 24 fps,
  109–179 KB each.
- Automated counterpart: the integration suite described below, which covers
  chat, media, sticker, and inline workflows.

## Automated live suite (November 17, 2026)

The manual passes on this page are probes with one method (or one family) in
focus. The integration suite in `Telegram.BotAPI.Tests` is the other half: it
drives complete workflows against `https://api.telegram.org`, asserts on the
returned objects, and undoes every mutation it makes.

Run metadata:

- Library `Endfix.Telegram.BotAPI` 2.0.1, `net8.0`, Release build, bot
  `@endfixbot`.
- Bulk run: 37 tests — 34 passed, 3 skipped, 0 failed in 2 m 43 s.
- Inline run, started separately because it waits for a human: 1 test, passed
  in 18 s.
- Total: 38 tests, 35 passed, 3 skipped, 0 failed.
- Chats: a private chat, a discussion supergroup, a forum supergroup, an
  administered channel, and a disposable non-administrator test user, all
  supplied through user secrets.

```powershell
dotnet test Telegram.BotAPI.Tests\Telegram.BotAPI.Tests.csproj -c Release `
  --filter "Category=Integration&FullyQualifiedName!~TelegramInlineIntegrationTests"
```

### Bot identity, commands, and profile

| Test | Methods exercised | Result |
| --- | --- | --- |
| `BotFatherCapabilities_AreEnabled` | `getMe` | Passed after the BotFather flags were enabled; see below. |
| `BotChatSettings_RollBack` | `getChatMenuButton`, `setChatMenuButton`, `getMyCommands`, `setMyCommands`, `deleteMyCommands`, `getMyDescription`, `setMyDescription`, `getMyShortDescription`, `setMyShortDescription` | Passed; the previous menu button, command list, and descriptions were restored. |
| `BotName_RollBack` | `getMyName`, `setMyName` | Skipped — access flag not set. |
| `BotDefaultAdministratorRights_RollBack` | `getMyDefaultAdministratorRights`, `setMyDefaultAdministratorRights` | Passed for `for_channels=false` and `true`; the original rights were restored. |
| `SetMyProfilePhoto_UploadsNestedPhoto_ThenRestoresPreviousPhoto` | `getUserProfilePhotos`, `setMyProfilePhoto`, `removeMyProfilePhoto` | Passed; the bot's previous photo was uploaded back afterwards. |

### Private-chat messages

| Test | Methods exercised | Result |
| --- | --- | --- |
| `PrivateChatStructuredMessages_AreDeliveredAndDeleted` | `sendMessage`, `sendChatAction`, `sendContact`, `sendVenue`, `sendPoll`, `stopPoll`, `sendMessageDraft`, `deleteMessage` | Passed; `stopPoll` returns the closed poll, and the draft is sent under an explicit `draft_id`. |
| `OrdinaryChatMessageEdits_ReturnEditedMessage` | `sendMessage`, `editMessageText`, `editMessageReplyMarkup`, `deleteMessage` | Passed; the per-message helpers return the edited `Message`, not `true`. |
| `Messages_CopyAndForwardAcrossConfiguredChats` | `sendMessage`, `getChat`, `getChatMember`, `copyMessage`, `forwardMessage`, `getFile`, `getFileBytes`, `deleteMessage` | Passed; copies a group message into the channel, forwards one into the private chat, then resolves the copied photo with `getFile` and reads its bytes. |

### Media and files

| Test | Methods exercised | Result |
| --- | --- | --- |
| `SendPhoto_UploadsLocalFile_ThenResendsByFileId` | `sendPhoto` | Passed twice: multipart `InputPhotoFile`, then the returned `file_id`. |
| `SendDocument_UploadsLocalFile_ThenResendsByFileId` | `sendDocument` | Same shape as photo: upload, then resend by `file_id`. |
| `DownloadFile_StreamsTelegramDocumentAndLeavesDestinationOpen` | `sendDocument`, `getFile`, `downloadFile` | Passed; the document streams into a `MemoryStream` that stays writable, and the bytes match the fixture. |
| `SendMediaGroup_UploadsFilesThroughAttachReferences` | `sendMediaGroup` | Passed; two local photos in one album, uploaded through generated `attach://` references. |
| `SendMediaGroup_UploadsTypedVideoThumbnailAndCover` | `sendMediaGroup` | Passed; `InputMediaVideo` with separate `thumbnail` and `cover` uploads. |
| `SendPaidMedia_UploadsLocalPhoto_ThenResendsByFileId` | `sendPaidMedia` | Passed with `StarCount = 1`, as a multipart photo and by `file_id`; the response carries `PaidMedia.StarCount` and `PaidMediaPhoto`. |
| `SendPoll_UploadsNestedOptionAndDescriptionMedia` | `sendPoll` | Passed; poll-level `Media` and `InputPollOption.Media` upload in the same multipart request and return as `Poll.Media.Photo` / `Poll.Options[0].Media.Photo`; `is_closed: true` is accepted on send. |
| `SendAdditionalStandaloneMedia_UploadsLocalFiles` | `sendAudio`, `sendAnimation`, `sendVideo`, `sendVoice`, `sendVideoNote`, `sendSticker` | Passed; one local fixture per method. |
| `SendRichMessage_UploadsPhotoFromNestedBlock` | `sendRichMessage` | Passed; a photo inside `InputRichBlockPhoto` travels through the nested multipart graph and is echoed in `Message.RichMessage`. |
| `UpdatingMethods_ForwardChatAndReplyMarkupParameters` | `sendMessage`, `editMessageReplyMarkup`, `sendPhoto`, `editMessageCaption`, `editMessageMedia`, `sendLocation`, `editMessageLiveLocation`, `stopMessageLiveLocation` | Passed; the "for message" helpers forward `chat_id` and `message_id` and return the edited message. |

### Sticker sets

| Test | Methods exercised | Result |
| --- | --- | --- |
| `StickerSetMethods_UploadNestedFiles` | `getMe`, `uploadStickerFile`, `createNewStickerSet`, `addStickerToSet`, `replaceStickerInSet`, `getStickerSet`, `deleteStickerSet` | Passed; builds a real video-sticker set from local files through `attach://`, verifies its contents, then deletes it. |
| `ChatStickerSet_RollBack` | `getChat`, `getMe`, `createNewStickerSet`, `setChatStickerSet`, `deleteChatStickerSet`, `deleteStickerSet` | Skipped — no group with `can_set_sticker_set=true`. |

### Groups, channels, and forum topics

| Test | Methods exercised | Result |
| --- | --- | --- |
| `GroupConfiguration_IsUsable` | `getChat`, `getChatAdministrators`, `getMe` | Passed; supergroup, bot is an administrator. |
| `ChannelConfiguration_IsUsable` | `getChat`, `getChatAdministrators`, `getMe` | Passed. |
| `ForumConfiguration_IsUsable` | `getChat`, `getChatAdministrators`, `getMe` | Passed; `is_forum: true`. |
| `GroupDefaultPermissions_RollBack` | `getChat`, `setChatPermissions` | Passed; the original permission mask was restored. |
| `TestUser_IsVisibleInGroup` | `getChatMember` | Passed; the test user is a plain member, not an administrator. |
| `TestUserRestriction_RollBack` | `getChatMember`, `restrictChatMember` | Passed; the restriction was applied, verified, and lifted. |
| `TestUserTag_RollBack` | `getMe`, `getChatMember`, `setChatMemberTag` | Passed; the tag was set and cleared. |
| `TestUserPromotionAndCustomTitle_RollBack` | `getMe`, `getChatMember`, `promoteChatMember`, `setChatAdministratorCustomTitle`, `setChatMemberTag` | Passed; the user was promoted, given a custom title, then demoted. |
| `PremiumOwner_CustomEmojiButton_RoundTrips` | `getForumTopicIconStickers`, `sendMessage`, `deleteMessage` | Passed; uses a real `custom_emoji_id` in `icon_custom_emoji_id` together with a button `style`. |
| `PremiumUser_ReadOnlyProfileCollections_Deserialize` | `getUserProfileAudios`, `getUserGifts`, `getAvailableGifts` | Passed; the Premium-only collections deserialize. |
| `PremiumUser_EmojiStatus_MutationIsAcceptedAndRestored` | `getChat`, `getForumTopicIconStickers`, `setUserEmojiStatus` | Skipped — no emoji-status access. |
| `ChannelAndGroup_AreLinkedForDiscussion` | `getChat` | Passed; `linked_chat_id` resolves in both directions. |
| `ForumTopicLifecycle_RollBack` | `createForumTopic`, `editForumTopic`, `sendMessage`, `setMessageReaction`, `closeForumTopic`, `reopenForumTopic`, `deleteForumTopic` | Passed; the topic was created with a custom icon, renamed, closed, reopened, and deleted. |
| `GroupMetadataMessageAndInviteLink_RollBack` | `getChat`, `setChatTitle`, `setChatDescription`, `sendMessage`, `editMessageText`, `pinChatMessage`, `unpinChatMessage`, `createChatInviteLink`, `editChatInviteLink`, `revokeChatInviteLink`, `deleteMessage` | Passed; title, description, pin, and invite link were all restored. |
| `ChannelMetadataAndMessage_RollBack` | `getChat`, `setChatTitle`, `setChatDescription`, `getChatMemberCount`, `sendMessage`, `editMessageText`, `setMessageReaction`, `pinChatMessage`, `unpinChatMessage`, `createChatInviteLink`, `editChatInviteLink`, `revokeChatInviteLink`, `createChatSubscriptionInviteLink`, `editChatSubscriptionInviteLink`, `deleteMessage` | Passed; also covers a star subscription invite link. |
| `ChannelReadOnlyCollections_Deserialize` | `getChatGifts`, `getUserChatBoosts` | Passed; empty read-only collections deserialize. |
| `ChannelPhoto_RollBack` | `getChat`, `setChatPhoto`, `deleteChatPhoto` | Passed; the channel photo was replaced, removed, and the original restored. |

### Inline

| Test | Methods exercised | Result |
| --- | --- | --- |
| `InlineMessageEdits_ReturnTrue` | `getMe`, `deleteWebhook`, `sendMessage`, `getUpdates`, `answerInlineQuery`, `editMessageText`, `editMessageReplyMarkup` | Passed; a human taps the button and picks the result, after which both inline edits return `true`. |

### The failure in the first run was configuration, not a library bug

The first bulk run ended with 33 passed, 3 skipped, and one failure:
`BotFatherCapabilities_AreEnabled` stopped at
`Assert.True(bot.CanReadAllGroupMessages)`. The `getMe` request itself
succeeded and returned a valid `Bot`; the bot was simply configured with

```
can_read_all_group_messages=false
supports_inline_queries=false
has_topics_enabled=false
```

Turning Group Privacy off and enabling Inline Mode and topics in BotFather made
`getMe` report all three as `true`. The rerun passed the same test binary, and
only then could the inline test work at all. A failure here means "this bot is
configured differently", not "the library broke".

### Skipped tests and what would unblock them

These are explicit opt-in gates read from environment variables or user secrets,
so a fresh checkout skips them instead of failing:

| Test | Gate | What is needed |
| --- | --- | --- |
| `ChatStickerSet_RollBack` | `TELEGRAM_BOT_GROUP_STICKER_SET_ACCESS` | A group whose `getChat` reports `can_set_sticker_set=true` — in practice a supergroup with 100+ members where the bot may install a sticker set. |
| `BotName_RollBack` | `TELEGRAM_BOT_SET_MY_NAME_ACCESS` | The bot may call `setMyName`; Telegram can keep this method rate-limited for hours after a previous change. |
| `PremiumUser_EmojiStatus_MutationIsAcceptedAndRestored` | `TELEGRAM_BOT_EMOJI_STATUS_ACCESS` | Emoji-status access granted to the bot through the Mini App. |

### Suite caveats

- The tests share one xUnit collection and run serially against real chats.
  Mutations are restored in `finally` blocks, but aborting a run can leave a
  temporary title, photo, invite link, or sticker set behind.
- Uploads use small bundled fixtures rather than the sticker harness media; the
  "resends by `file_id`" variants reuse the returned id instead of uploading
  twice.
- `sendPaidMedia` was called with `StarCount = 1` in a private chat and the
  messages were deleted immediately. The test checks the returned
  `PaidMedia`, not star accounting.
- The inline test needs a person: it sends a button to the private chat, waits up
  to three minutes for `chosen_inline_result`, and skips rather than fails when
  nothing is chosen. Keep it out of unattended CI.
- Some calls are verified in read form only. `getChatGifts` and
  `getUserChatBoosts` returned empty collections, and the Premium profile
  assertions accept empty payloads (count within the reported total), so those
  rows prove deserialization, not non-empty data.
- Capability flags in `BotFatherCapabilities_AreEnabled` reflect BotFather
  settings and live outside the repository.

## Sticker and sticker-set methods

| Method | Request shape that was used | Result |
| --- | --- | --- |
| `getMe` | — | Returns `Bot`; used to confirm the token and `@username`. |
| `getStickerSet` | Set name of an existing set | Returns `StickerSet` with stickers in pack order and their `file_id`s. **Throws `ApiRequestException`** for an unknown name; it does not return `null`. |
| `uploadStickerFile` | `UserId`, `InputStickerFile(path)`, `StickerFormat.Video` | Uploads 512×512 WebM with alpha; returns `FileStruct` with `FileId` and `FileSize`. Rejected files surface as `ApiRequestException`. |
| `createNewStickerSet` | `UserId`, `Name`, `Title`, `StickerType.Regular`, one `InputSticker` | Creates the set with the first sticker. The name must end with `_by_<bot_username>`. |
| `addStickerToSet` | `UserId`, `Name`, `InputSticker` | Appends a sticker; the pack count grows by one, order is preserved. |
| `replaceStickerInSet` | `UserId`, `Name`, `OldSticker` (a `file_id` from `getStickerSet`), `InputSticker` | Replaces one sticker **in place**: count and position stay the same, the new file is served immediately. Used repeatedly on indices 0 and 1. |
| `setStickerEmojiList` | `Sticker` (a `file_id`), `EmojiList` | Retags an existing sticker without re-uploading it. Both the parameters object and the `(sticker, emojiList)` overload work. |
| `deleteStickerSet` | `Name` | Deletes a set owned by the bot. Works, but see the re-creation pitfall below. |

All of the above were called with a normal bot token and a set owned by that
bot's own user id; the same calls used the convenience overloads and the
`...Parameters` objects interchangeably.

### Request shapes worth copying

Upload, then build the `InputSticker` — the two format enums are separate types:

```csharp
var uploaded = await api.UploadStickerFileAsync(new UploadStickerFileParameters
{
    UserId = ownerId,
    Sticker = new InputStickerFile("sticker.webm"),
    StickerFormat = StickerFormat.Video          // Endfix.Telegram.BotAPI.Enums
});

var sticker = new InputSticker
{
    Sticker = uploaded.FileId,                   // or new InputStickerFile(path)
    Format = InputStickerFormat.Video,           // the other enum
    EmojiList = new[] { "\U0001F44B" }
};
```

Replacing one sticker without touching the rest of the pack:

```csharp
var set = await api.GetStickerSetAsync(setName);
var oldFileId = set.Stickers[index].FileId;

await api.ReplaceStickerInSetAsync(new ReplaceStickerInSetParameters
{
    UserId = ownerId,
    Name = setName,
    OldSticker = oldFileId,
    Sticker = sticker
});
```

## Poll methods

| Method | Request shape that was used | Result |
| --- | --- | --- |
| `sendPoll` | `ChatId` (numeric id), `Question`, `Options` = `InputPollOption { Text = ... }[]`, `Type = PollType.Regular`, `IsAnonymous = false`, `AllowsMultipleAnswers = true`, `AllowAddingOptions = true` | Sends the poll into the chat and returns a `Message` whose `Poll` carries the server-generated `Id`, option list, `TotalVoterCount`, `IsAnonymous`, `AllowsMultipleAnswers`, `AllowsRevoting`. Two polls with 11 and 10 options were accepted. |

### `allow_adding_options` requires a non-anonymous poll

The flag is not mentioned in the `Poll` response, so a successful call is the
only positive signal. The negative case is explicit: sending the same request
with `is_anonymous=true` and `allow_adding_options=true` fails with

```
400 Bad Request: ANONYMOUS_OPEN_INVALID
```

That error also confirms the server actually reads the field rather than
ignoring it, which is why `SendPollParameters.AllowsMultipleAnswers` /
`AllowAddingOptions` can be trusted. In practice: set `IsAnonymous = false`
whenever voters should be able to add their own options.

### The returned `Poll` does not echo `AllowAddingOptions`

`Poll` echoes `IsAnonymous`, `AllowsMultipleAnswers`, `AllowsRevoting` and
`MembersOnly`, but it has no `AllowAddingOptions` property at all. Do not try
to read the flag back from the response; treat the request parameter as
write-only and verify in a client, or rely on the error above.

### Twelve options is the ceiling

`SendPollParameters.Options` is documented and enforced as 1-12 items, so a
longer list has to be split. Covering a 21-item list took two regular polls
(11 + 10) sent in one loop; keeping the original index as a prefix in the
option text (`"7. ..."`) makes the halves easy to correlate in chat.

```csharp
var sent = await api.SendPollAsync(new SendPollParameters
{
    ChatId = chatId,                 // implicit conversion from long
    Question = "Which one lands best? 1/2",
    Options = labels.Select(t => new InputPollOption { Text = t }).ToArray(),
    Type = PollType.Regular,
    IsAnonymous = false,             // required for allow_adding_options
    AllowsMultipleAnswers = true,
    AllowAddingOptions = true
});

Console.WriteLine($"{sent.Poll!.Id} {sent.Poll.Options.Count} options");
```

## Gotchas confirmed on the live API

### `deleteStickerSet` followed by an immediate `createNewStickerSet`

Observed sequence, reproduced twice:

1. `deleteStickerSet(name)` — succeeds.
2. `createNewStickerSet(...)` with the **same name** — succeeds and returns `true`.
3. `addStickerToSet(...)` on that set — fails with
   `Bad Request: STICKERSET_INVALID`.

Creating a set under a fresh name afterwards works normally. Treat deletion
as a separate operation, not as a way to "reset" a pack: edit the existing set
with `addStickerToSet` / `replaceStickerInSet` / `deleteStickerFromSet` /
`setStickerPositionInSet` instead. The per-sticker methods keep the pack
identity, its link, and its subscribers.

### Replacing a sticker rewrites its emoji tag

`replaceStickerInSet` takes a full `InputSticker`, so the emoji list is part of
the replacement rather than something Telegram carries over. Our first
replacements passed a hard-coded 👋 and silently retagged two existing
stickers; `getStickerSet` still reported the set as healthy, because the tag is
metadata, not an error. Read `Sticker.Emoji` before replacing and pass it back:

```csharp
var set = await api.GetStickerSetAsync(setName);
var old = set.Stickers[index];

await api.ReplaceStickerInSetAsync(new ReplaceStickerInSetParameters
{
    UserId = ownerId,
    Name = setName,
    OldSticker = old.FileId,
    Sticker = new InputSticker
    {
        Sticker = uploaded.FileId,
        Format = InputStickerFormat.Video,
        EmojiList = new[] { old.Emoji }        // keep the tag
    }
});
```

If a tag is already wrong, `setStickerEmojiList` fixes it in place — no
re-upload, no position change, and the sticker keeps its `file_id`.

`addStickerToSet` appends to the end of the pack, and `getStickerSet` returns
that order, so the new position is `set.Stickers.Count` at the time of the
call. The Bot API has no "insert at index" request: append, then reorder with
`setStickerPositionInSet`.

### A repeated `createNewStickerSet` is not a failure signal

Creating a set for a name the bot already owns returned `true` in our runs
without rebuilding the set — the previously added stickers stayed as they were.
A `true` from this method means "Telegram did not reject the request", not
"the set now contains exactly what I passed".

### `getStickerSet` throws on a missing set

There is no `TryGetStickerSet`. An existence check is a `try`/`catch` around
`GetStickerSetAsync`; the exception type is `ApiRequestException` and the
message carries the Bot API description. This is how "create if absent" was
implemented in the harness.

### Extension methods need their namespace

The `...Async` helpers on `IBotApiClient` live in
`Endfix.Telegram.BotAPI.Extensions`. Without

```csharp
using Endfix.Telegram.BotAPI.Extensions;
```

the compiler reports `CS1061` ("does not contain a definition for
`CreateNewStickerSetAsync`"), which reads like a missing feature rather than a
missing `using`. It is worth calling out in any sample or template.

### `StickerFormat` and `InputStickerFormat` are duplicates by design

Both enums declare `Static`, `Animated`, and `Video`, and they are not
interchangeable types: `UploadStickerFileParameters.StickerFormat` takes
`StickerFormat`, while `InputSticker.Format` takes `InputStickerFormat`. A
mismatch is a compile error, so it cannot silently send the wrong value — but
it does mean two `using`s of near-identical enums in every sticker file, which
is easy to misread in review.

## Observed media constraints

These are Telegram's limits, confirmed by uploading real files rather than
only reading documentation:

- Video stickers are 512×512, WebM/VP9 with alpha, and must stay under 256 KB.
  Uploads in the 109–179 KB range were accepted without resizing or re-encoding
  by the server.
- The video loops, so every clip should end where it starts; a one-frame
  duplicate at the seam is not visible.
- The emoji list drives how the pack is indexed in Telegram search, so it is
  worth setting deliberately even though the field is optional in the model.

## Not yet verified live

Everything else in `BotApiClientExtensions.Stickers.cs` is untested against the
live API here and should be treated as compiled-only until someone exercises it:

- `getCustomEmojiStickers`
- `deleteStickerFromSet`, `setStickerPositionInSet`
- `setStickerKeywords`, `setStickerMaskPosition`
- `setStickerSetTitle`, `setStickerSetThumbnail`,
  `setCustomEmojiStickerSetThumbnail`

Three live tests did not run for want of access, so their methods are still
unverified here: `setMyName` (`BotName_RollBack`), `setUserEmojiStatus`
(`PremiumUser_EmojiStatus_MutationIsAcceptedAndRestored`), and
`setChatStickerSet` / `deleteChatStickerSet` (`ChatStickerSet_RollBack`).

When any of them gets a live pass, add it to the tables above together with the
call shape that worked, and remove it from this list. Static stickers (WebP) and
animated stickers (TGS) were not uploaded either; only the video path was
exercised.
