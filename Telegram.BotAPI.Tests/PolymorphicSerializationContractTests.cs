using FluentAssertions;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class PolymorphicSerializationContractTests
{
    public static TheoryData<ReactionType, string> ReactionTypes => new()
    {
        { new ReactionTypeEmoji { Emoji = "👍" }, "emoji" },
        { new ReactionTypeCustomEmoji { CustomEmojiId = "custom-emoji-id" }, "custom_emoji" },
        { new ReactionTypePaid(), "paid" }
    };

    public static TheoryData<BackgroundFill, string> BackgroundFills => new()
    {
        { new BackgroundFillSolid { Color = 16711680 }, "solid" },
        { new BackgroundFillGradient { TopColor = 16711680, BottomColor = 255, RotationAngle = 45 }, "gradient" },
        { new BackgroundFillFreeformGradient { Colors = [16711680, 65280, 255] }, "freeform_gradient" }
    };

    public static TheoryData<BackgroundType, string> BackgroundTypes => new()
    {
        { new BackgroundTypeChatTheme { ThemeName = "classic" }, "chat_theme" },
        {
            new BackgroundTypeFill
            {
                Fill = new BackgroundFillSolid { Color = 16777215 },
                DarkThemeDimming = 35
            },
            "fill"
        },
        {
            new BackgroundTypePattern
            {
                Document = Cases.Document("pattern.tgs"),
                Fill = new BackgroundFillGradient { TopColor = 16711680, BottomColor = 255, RotationAngle = 90 },
                Intensity = 75,
                IsInverted = true,
                IsMoving = false
            },
            "pattern"
        },
        {
            new BackgroundTypeWallpaper
            {
                Document = Cases.Document("wallpaper.jpg"),
                DarkThemeDimming = 20,
                IsBlurred = true,
                IsMoving = false
            },
            "wallpaper"
        }
    };

    public static TheoryData<MenuButton, string> MenuButtons => new()
    {
        { new MenuButtonCommands(), "commands" },
        { new MenuButtonDefault(), "default" },
        {
            new MenuButtonWebApp
            {
                Text = "Open dashboard",
                WebApp = new WebAppInfo { Url = "https://example.com/dashboard" }
            },
            "web_app"
        }
    };

    public static TheoryData<BotCommandScope, string> BotCommandScopes => new()
    {
        { new BotCommandScopeDefault(), "default" },
        { new BotCommandScopeAllPrivateChats(), "all_private_chats" },
        { new BotCommandScopeAllGroupChats(), "all_group_chats" },
        { new BotCommandScopeAllChatAdministrators(), "all_chat_administrators" },
        { new BotCommandScopeChat { ChatId = -1001234567890L }, "chat" },
        { new BotCommandScopeChatAdministrators { ChatId = "@contract_test_chat" }, "chat_administrators" },
        {
            new BotCommandScopeChatMember
            {
                ChatId = -1001234567890L,
                UserId = 123456789
            },
            "chat_member"
        }
    };

    public static TheoryData<PaidMedia, string> PaidMediaValues => new()
    {
        { new PaidMediaPreview { Width = 320, Height = 240, Duration = 12 }, "preview" },
        { new PaidMediaPhoto { Photo = [Cases.PhotoSize()]  }, "photo" },
        { new PaidMediaVideo { Video = Cases.Video() }, "video" },
        { new PaidMediaLivePhoto { LivePhoto = Cases.LivePhoto() }, "live_photo" }
    };

    public static TheoryData<InputMedia, string> InputMediaValues => new()
    {
        { new InputMediaAnimation { Media = "animation-id" }, "animation" },
        { new InputMediaAudio { Media = "audio-id" }, "audio" },
        { new InputMediaDocument { Media = "document-id" }, "document" },
        { new InputMediaLink { Url = "https://example.com/media" }, "link" },
        {
            new InputMediaLivePhoto
            {
                Media = "live-photo-video-id",
                Photo = "live-photo-image-id"
            },
            "live_photo"
        },
        { new InputMediaLocation { Latitude = 55.75, Longitude = 37.62 }, "location" },
        { new InputMediaPhoto { Media = "photo-id" }, "photo" },
        { new InputMediaSticker { Media = "sticker-id", Emoji = "test" }, "sticker" },
        {
            new InputMediaVenue
            {
                Latitude = 55.75,
                Longitude = 37.62,
                Title = "Venue",
                Address = "Test address"
            },
            "venue"
        },
        {
            new InputMediaVideo
            {
                Media = "video-id",
                Thumbnail = "thumbnail-id",
                Cover = "cover-id"
            },
            "video"
        },
        { new InputMediaVoiceNote { Media = "voice-note-id", Duration = 5 }, "voice_note" }
    };

    public static TheoryData<InputPaidMedia, string> InputPaidMediaValues => new()
    {
        {
            new InputPaidMediaLivePhoto
            {
                Media = "live-photo-video-id",
                Photo = "live-photo-image-id"
            },
            "live_photo"
        },
        { new InputPaidMediaPhoto { Media = "photo-id" }, "photo" },
        {
            new InputPaidMediaVideo
            {
                Media = "video-id",
                Thumbnail = "thumbnail-id",
                Cover = "cover-id"
            },
            "video"
        }
    };

    public static TheoryData<MessageOrigin, string> MessageOrigins => new()
    {
        {
            new MessageOriginUser
            {
                Date = 1_700_000_001,
                SenderUser = Cases.User()
            },
            "user"
        },
        {
            new MessageOriginHiddenUser
            {
                Date = 1_700_000_002,
                SenderUserName = "Hidden User"
            },
            "hidden_user"
        },
        {
            new MessageOriginChat
            {
                Date = 1_700_000_003,
                SenderChat = Cases.Chat(),
                AuthorSignature = "Moderator"
            },
            "chat"
        },
        {
            new MessageOriginChannel
            {
                Date = 1_700_000_004,
                Chat = Cases.Chat(),
                MessageId = 42,
                AuthorSignature = "Editor"
            },
            "channel"
        }
    };

    public static TheoryData<ChatMember, string> ChatMembers => new()
    {
        {
            new ChatMemberOwner
            {
                User = Cases.User(),
                IsAnonymous = false,
                CustomTitle = "Owner"
            },
            "creator"
        },
        {
            new ChatMemberAdministrator
            {
                User = Cases.User(),
                CanBeEdited = true,
                IsAnonymous = false,
                CanManageChat = true,
                CanDeleteMessages = true,
                CanManageVideoChats = true,
                CanRestrictMembers = true,
                CanPromoteMembers = false,
                CanChangeInfo = true,
                CanInviteUsers = true,
                CanPostStories = true,
                CanEditStories = false,
                CanDeleteStories = false,
                CanPinMessages = true,
                CustomTitle = "Moderator"
            },
            "administrator"
        },
        {
            new ChatMemberMember
            {
                User = Cases.User(),
                Tag = "regular",
                UntilDate = 1_800_000_000
            },
            "member"
        },
        {
            new ChatMemberRestricted
            {
                User = Cases.User(),
                IsMember = true,
                CanSendMessages = true,
                CanSendAudios = false,
                CanSendDocuments = false,
                CanSendPhotos = true,
                CanSendVideos = false,
                CanSendVideoNotes = false,
                CanSendVoiceNotes = false,
                CanSendPolls = true,
                CanSendOtherMessages = false,
                CanAddWebPagePreviews = true,
                CanReactToMessages = true,
                CanEditTag = false,
                CanChangeInfo = false,
                CanInviteUsers = true,
                CanPinMessages = false,
                CanManageTopics = false,
                UntilDate = 1_800_000_000
            },
            "restricted"
        },
        { new ChatMemberLeft { User = Cases.User() }, "left" },
        {
            new ChatMemberBanned
            {
                User = Cases.User(),
                UntilDate = 1_800_000_000
            },
            "kicked"
        }
    };

    [Theory]
    [MemberData(nameof(ReactionTypes))]
    public void ReactionType_Roundtrips(ReactionType value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(BackgroundFills))]
    public void BackgroundFill_Roundtrips(BackgroundFill value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(BackgroundTypes))]
    public void BackgroundType_Roundtrips(BackgroundType value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(MenuButtons))]
    public void MenuButton_Roundtrips(MenuButton value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(BotCommandScopes))]
    public void BotCommandScope_Roundtrips(BotCommandScope value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(PaidMediaValues))]
    public void PaidMedia_Roundtrips(PaidMedia value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(InputMediaValues))]
    public void InputMedia_Roundtrips(InputMedia value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(InputPaidMediaValues))]
    public void InputPaidMedia_Roundtrips(InputPaidMedia value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Fact]
    public void InputSticker_Roundtrips()
    {
        JsonContract.AssertRoundtrip(new InputSticker
        {
            Sticker = "sticker-file-id",
            Format = Endfix.Telegram.BotAPI.Enums.InputStickerFormat.Static,
            EmojiList = ["test"]
        });
    }

    [Theory]
    [MemberData(nameof(MessageOrigins))]
    public void MessageOrigin_Roundtrips(MessageOrigin value, string discriminator)
        => AssertRoundtrip(value, discriminator);

    [Theory]
    [MemberData(nameof(ChatMembers))]
    public void ChatMember_Roundtrips(ChatMember value, string discriminator)
        => AssertRoundtrip(value, discriminator, "status");

    private static void AssertRoundtrip<T>(T value, string discriminator, string discriminatorProperty = "type")
        where T : notnull
    {
        var actual = JsonContract.AssertRoundtrip(value);

        actual.Should().BeOfType(value.GetType());
        JsonContract.AssertDiscriminator(value, discriminator, discriminatorProperty);
    }

    private static class Cases
    {
        public static Document Document(string fileName) => new()
        {
            FileId = $"{fileName}-id",
            FileUniqueId = $"{fileName}-unique-id",
            FileName = fileName,
            MimeType = "application/octet-stream"
        };

        public static PhotoSize PhotoSize() => new()
        {
            FileId = "photo-file-id",
            FileUniqueId = "photo-unique-id",
            Width = 320,
            Height = 240,
            FileSize = 1024
        };

        public static LivePhoto LivePhoto() => new()
        {
            FileId = "live-photo-file-id",
            FileUniqueId = "live-photo-unique-id",
            Width = 320,
            Height = 240,
            Duration = 3,
            MimeType = "video/mp4",
            Photo = [PhotoSize()]
        };

        public static Video Video() => new()
        {
            FileId = "video-file-id",
            FileUniqueId = "video-unique-id",
            Width = 640,
            Height = 480,
            Duration = 12,
            FileName = "video.mp4",
            MimeType = "video/mp4",
            FileSize = 4096,
            Thumbnail = PhotoSize()
        };

        public static User User() => new()
        {
            Id = 123456789,
            IsBot = false,
            FirstName = "Alex",
            LastName = "Tester",
            Username = "contract_test_user",
            LanguageCode = "en"
        };

        public static Chat Chat() => new()
        {
            Id = -1001234567890,
            Type = Endfix.Telegram.BotAPI.Enums.ChatTypes.Supergroup,
            Title = "Contract Test Chat",
            Username = "contract_test_chat"
        };
    }
}
