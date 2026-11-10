using System.Text.Json;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class BotApi104SerializationTests
{
    [Fact]
    public void Widget_Roundtrips()
    {
        var actual = JsonContract.AssertRoundtrip(new Widget
        {
            Id = "shared-widget-id",
            Width = 320,
            Height = 480,
            Html = "<div>Widget</div>",
            PublicData = "public",
            ChatData = "chat"
        });

        actual.Html.Should().Be("<div>Widget</div>");
    }

    [Fact]
    public void ChatShareThemeEmoji_Roundtrips()
    {
        var actual = JsonContract.AssertRoundtrip<ChatShareTheme>(new ChatShareThemeEmoji
        {
            Emojis = [new EmojiTypeEmoji { Emoji = "🎉" }, new EmojiTypeCustomEmoji { CustomEmojiId = "5368324170671202286" }],
            BackgroundBackdropId = 7
        });

        actual.Should().BeOfType<ChatShareThemeEmoji>();
        JsonContract.AssertDiscriminator(actual, "emoji");
    }

    [Fact]
    public void ChatShareThemeUniqueGift_Roundtrips()
    {
        var actual = JsonContract.AssertRoundtrip<ChatShareTheme>(new ChatShareThemeUniqueGift
        {
            Gift = CreateUniqueGift()
        });

        actual.Should().BeOfType<ChatShareThemeUniqueGift>();
        JsonContract.AssertDiscriminator(actual, "unique_gift");
    }

    [Fact]
    public void ChatShareThemeBackdrops_Roundtrips()
    {
        JsonContract.AssertRoundtrip(new ChatShareThemeBackdrops
        {
            Backdrops =
            [
                new ChatShareThemeBackdrop
                {
                    Id = 1,
                    Name = "First",
                    Colors = new UniqueGiftBackdropColors
                    {
                        CenterColor = 1,
                        EdgeColor = 2,
                        SymbolColor = 3,
                        TextColor = 4
                    }
                }
            ]
        });
    }

    [Fact]
    public void EmojiTypeEmoji_Uses_Emoji_Discriminator()
    {
        JsonContract.AssertDiscriminator<EmojiType>(new EmojiTypeEmoji { Emoji = "🙂" }, "emoji");
    }

    [Fact]
    public void EmojiTypeCustomEmoji_Uses_CustomEmoji_Discriminator()
    {
        JsonContract.AssertDiscriminator<EmojiType>(
            new EmojiTypeCustomEmoji { CustomEmojiId = "5368324170671202286" },
            "custom_emoji");
    }

    [Fact]
    public void TonWalletCard_Roundtrips()
    {
        JsonContract.AssertRoundtrip(new TonWalletCard
        {
            Address = "EQD__________________________________________",
            Amount = "1000000000",
            Stickers =
            [
                new TonWalletCardSticker
                {
                    Position = new AreaPosition
                    {
                        XPercentage = 10,
                        YPercentage = 20,
                        WidthPercentage = 30,
                        HeightPercentage = 40,
                        RotationAngle = 0,
                        CornerRadiusPercentage = 5
                    },
                    Nft = CreateTonNft()
                }
            ],
            BackgroundNftAddress = "EQD__________________________________________"
        });
    }

    [Fact]
    public void TonWalletTransfer_Roundtrips()
    {
        JsonContract.AssertRoundtrip(new TonWalletTransfer
        {
            TransactionId = "transaction",
            PeerAddress = "EQD__________________________________________",
            Amount = "-1000000000",
            Comment = "Thanks"
        });
    }

    [Fact]
    public void RichTextTonAddress_Uses_TonAddress_Discriminator()
    {
        var value = new RichTextTonAddress
        {
            Text = new RichTextBold { Text = "wallet" },
            Address = "EQD__________________________________________"
        };

        var actual = JsonContract.AssertRoundtrip<RichText>(value);

        actual.Should().BeOfType<RichTextTonAddress>();
        JsonContract.AssertDiscriminator(actual, "ton_address");
    }

    [Fact]
    public void TextQuote_Preserves_RichTexts()
    {
        JsonContract.AssertRoundtrip(new TextQuote
        {
            Text = "quoted",
            Position = 0,
            RichTexts = [new RichTextBold { Text = "quoted" }]
        });
    }

    [Fact]
    public void ReplyParameters_Preserves_QuoteRichTexts()
    {
        JsonContract.AssertRoundtrip(new ReplyParameters
        {
            MessageId = 42,
            QuoteRichTexts = [new RichTextItalic { Text = "quoted" }]
        });
    }

    [Fact]
    public void WidgetQuery_Roundtrips()
    {
        var actual = JsonContract.AssertRoundtrip(new WidgetQuery
        {
            Id = "query-id",
            From = new User { Id = 1, IsBot = false, FirstName = "User" },
            Chat = new Chat { Id = 1, Type = ChatTypes.Private },
            MessageId = 42,
            ChatInstance = "instance",
            Type = new WidgetQueryTypeData
            {
                WalletCard = new TonWalletCard
                {
                    Address = "address",
                    Amount = "1",
                    Stickers = []
                }
            },
            Data = "payload",
            WidgetId = "shared-widget-id"
        });

        actual.Type.Should().BeOfType<WidgetQueryTypeData>();
    }

    [Fact]
    public void WidgetQuery_Update_Has_WidgetQuery_Type()
    {
        var update = new Update
        {
            UpdateId = 1,
            WidgetQuery = new WidgetQuery
            {
                Id = "query-id",
                From = new User { Id = 1, IsBot = false, FirstName = "User" },
                ChatInstance = "instance",
                Type = new WidgetQueryTypeSignData
                {
                    Wallet = new WidgetQueryWallet { Address = "address", Amount = "1" },
                    SignData = "signed"
                },
                Data = "payload"
            }
        };

        update.Type.Should().Be(UpdateType.WidgetQuery);
        Utils.AssertRoundtrip(update);
    }

    [Fact]
    public void SharedWidgetQuery_Update_Has_SharedWidgetQuery_Type()
    {
        var update = new Update
        {
            UpdateId = 1,
            SharedWidgetQuery = new SharedWidgetQuery
            {
                Id = "query-id",
                From = new User { Id = 1, IsBot = false, FirstName = "User" },
                Type = new WidgetQueryTypeSentTransaction
                {
                    Wallet = new WidgetQueryWallet { Address = "address", Amount = "1" },
                    MsgHash = "hash"
                },
                Data = "payload",
                WidgetId = "shared-widget-id"
            }
        };

        update.Type.Should().Be(UpdateType.SharedWidgetQuery);
        Utils.AssertRoundtrip(update);
    }

    [Fact]
    public void PaidMessagesWaived_Roundtrips()
    {
        var json = new PaidMessagesWaived().Serialize();

        json.Should().Be("{}");
        json.Deserialize<PaidMessagesWaived>().Should().BeOfType<PaidMessagesWaived>();
    }

    [Fact]
    public void EphemeralReply_Omits_ChatId_And_ReceiverUserId()
    {
        var parameters = new SendMessageParameters
        {
            Text = "ephemeral reply",
            EphemeralMessageParameters = new EphemeralMessageParameters
            {
                CallbackQueryId = "callback-query-id"
            }
        };

        using var document = JsonDocument.Parse(parameters.Serialize());
        var root = document.RootElement;

        root.TryGetProperty("chat_id", out _).Should().BeFalse();
        root.TryGetProperty("receiver_user_id", out _).Should().BeFalse();
        root.GetProperty("ephemeral_message_parameters")
            .GetProperty("callback_query_id")
            .GetString()
            .Should()
            .Be("callback-query-id");
    }

    private static UniqueGift CreateUniqueGift() => new()
    {
        GiftId = "gift-id",
        BaseName = "Base",
        Name = "Gift",
        Number = 1,
        Model = new UniqueGiftModel
        {
            Name = "Model",
            Sticker = CreateSticker(),
            RarityPerMille = 1
        },
        Symbol = new UniqueGiftSymbol
        {
            Name = "Symbol",
            Sticker = CreateSticker(),
            RarityPerMille = 1
        },
        Backdrop = new UniqueGiftBackdrop
        {
            Name = "Backdrop",
            Colors = new UniqueGiftBackdropColors
            {
                CenterColor = 1,
                EdgeColor = 2,
                SymbolColor = 3,
                TextColor = 4
            },
            RarityPerMille = 1
        }
    };

    private static TonNft CreateTonNft() => new()
    {
        Address = "nft-address",
        Index = "0",
        Name = "NFT",
        Description = "NFT description"
    };

    private static Sticker CreateSticker() => new()
    {
        FileId = "file-id",
        FileUniqueId = "file-unique-id",
        Type = StickerType.Regular,
        Width = 512,
        Height = 512,
        IsAnimated = false,
        IsVideo = false
    };
}
