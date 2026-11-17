# Live-verified methods

This page records which parts of the library have been exercised against the
real Bot API, not just compiled and unit-tested. The point is to keep "it
builds" and "Telegram accepted the call" from being confused with each other,
and to write down the request shapes that are known to work.

## Environment

- Library: `Endfix.Telegram.BotAPI` 2.0.1, `net8.0` asset.
- Verified in November 2026 against `https://api.telegram.org`.
- Harness: a small console app that reads the token from `TELEGRAM_BOT_TOKEN`
  and drives a real, private video-sticker pack end to end — render, upload,
  create, extend, replace, retag, inspect. No test doubles, no local Bot API
  server.
- Content: 512×512 WebM/VP9 stickers with alpha, 36–40 frames at 24 fps,
  109–179 KB each.

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

- `sendSticker`, `getCustomEmojiStickers`
- `deleteStickerFromSet`, `setStickerPositionInSet`
- `setStickerKeywords`, `setStickerMaskPosition`
- `setStickerSetTitle`, `setStickerSetThumbnail`,
  `setCustomEmojiStickerSetThumbnail`

When any of them gets a live pass, add a row to the table above and the exact
call shape that worked. Static stickers (WebP) and animated stickers (TGS) were
not uploaded either; only the video path was exercised.
