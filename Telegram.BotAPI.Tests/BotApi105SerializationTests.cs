using System.Text.Json;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class BotApi105SerializationTests
{
    [Fact]
    public void SetMySettings_Serializes_All_Parameters()
    {
        var parameters = new SetMySettingsParameters
        {
            SupportsInlineQueries = true,
            InlineQueryPlaceholder = "search",
            NeedsInlineQueryLocation = true,
            InlineFeedbackShareDenominator = 100,
            CanJoinGroups = true,
            CanReadAllGroupMessages = true,
            CanConnectToBusiness = true,
            CanManageBots = true,
            SupportsGuestQueries = true,
            SupportsJoinRequestQueries = true,
            HasTopicsEnabled = true,
            AllowsUsersToCreateTopics = true,
            HasTopicSidebar = true,
            CanCommunicateWithBots = true,
            CallbackQueryMode = CallbackQueryMode.Auto
        };

        using var document = JsonDocument.Parse(parameters.Serialize());
        var root = document.RootElement;

        root.GetProperty("supports_inline_queries").GetBoolean().Should().BeTrue();
        root.GetProperty("inline_query_placeholder").GetString().Should().Be("search");
        root.GetProperty("needs_inline_query_location").GetBoolean().Should().BeTrue();
        root.GetProperty("inline_feedback_share_denominator").GetInt32().Should().Be(100);
        root.GetProperty("can_join_groups").GetBoolean().Should().BeTrue();
        root.GetProperty("can_read_all_group_messages").GetBoolean().Should().BeTrue();
        root.GetProperty("can_connect_to_business").GetBoolean().Should().BeTrue();
        root.GetProperty("can_manage_bots").GetBoolean().Should().BeTrue();
        root.GetProperty("supports_guest_queries").GetBoolean().Should().BeTrue();
        root.GetProperty("supports_join_request_queries").GetBoolean().Should().BeTrue();
        root.GetProperty("has_topics_enabled").GetBoolean().Should().BeTrue();
        root.GetProperty("allows_users_to_create_topics").GetBoolean().Should().BeTrue();
        root.GetProperty("has_topic_sidebar").GetBoolean().Should().BeTrue();
        root.GetProperty("can_communicate_with_bots").GetBoolean().Should().BeTrue();
        root.GetProperty("callback_query_mode").GetString().Should().Be("auto");
        root.TryGetProperty("supports_quest_queries", out _).Should().BeFalse();
    }

    [Theory]
    [InlineData(CallbackQueryMode.Default, "default")]
    [InlineData(CallbackQueryMode.Auto, "auto")]
    [InlineData(CallbackQueryMode.Inline, "inline")]
    public void CallbackQueryMode_Serializes_Using_BotApi_Value(
        CallbackQueryMode callbackQueryMode,
        string expected)
    {
        var parameters = new SetMySettingsParameters
        {
            CallbackQueryMode = callbackQueryMode
        };

        using var document = JsonDocument.Parse(parameters.Serialize());

        document.RootElement
            .GetProperty("callback_query_mode")
            .GetString()
            .Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(CallbackQueryMode.Default, "default")]
    [InlineData(CallbackQueryMode.Auto, "auto")]
    [InlineData(CallbackQueryMode.Inline, "inline")]
    public void CallbackQueryMode_Deserializes_From_BotApi_Value(
        CallbackQueryMode expected,
        string value)
    {
        var json = JsonSerializer.Serialize(value, JsonSerializerExtensions.Options);

        var actual = json.Deserialize<CallbackQueryMode>();

        actual.Should().Be(expected);
    }

    [Fact]
    public void BotFullInfo_Roundtrips()
    {
        var actual = JsonContract.AssertRoundtrip(new BotFullInfo
        {
            Id = 123456789L,
            IsBot = true,
            FirstName = "Bot",
            Username = "bot",
            ActiveUsernames = ["bot", "bot_two"],
            CanJoinGroups = true,
            CanReadAllGroupMessages = true,
            SupportsGuestQueries = true,
            SupportsInlineQueries = true,
            InlineQueryPlaceholder = "search",
            NeedsInlineQueryLocation = true,
            CanConnectToBusiness = true,
            HasMainWebApp = true,
            HasTopicsEnabled = true,
            AllowsUsersToCreateTopics = true,
            HasTopicSidebar = true,
            CanManageBots = true,
            SupportsJoinRequestQueries = true
        });

        actual.ActiveUsernames.Should().Equal("bot", "bot_two");
        actual.HasTopicSidebar.Should().BeTrue();
    }

    [Fact]
    public void WriteAccessAllowed_Preserves_Inviter()
    {
        var actual = JsonContract.AssertRoundtrip(new WriteAccessAllowed
        {
            Inviter = new User
            {
                Id = 987654321L,
                IsBot = false,
                FirstName = "Owner",
                Username = "owner"
            }
        });

        actual.Inviter.Should().NotBeNull();
        actual.Inviter!.Id.Should().Be(987654321L);
        actual.Inviter.Username.Should().Be("owner");
    }

    [Fact]
    public void InputRichBlockExpandableBlockQuotation_Uses_Blocks()
    {
        var value = new InputRichBlockExpandableBlockQuotation
        {
            Blocks =
            [
                new InputRichBlockParagraph
                {
                    Text = new RichTextBold { Text = "quoted" }
                }
            ],
            Credit = new RichTextItalic { Text = "Author" }
        };

        using var document = JsonDocument.Parse(value.Serialize());
        var root = document.RootElement;

        root.GetProperty("type").GetString().Should().Be("expandable_blockquote");
        root.GetProperty("blocks")[0].GetProperty("type").GetString().Should().Be("paragraph");
        root.TryGetProperty("text", out _).Should().BeFalse();
    }

    [Fact]
    public void RichBlockExpandableBlockQuotation_Uses_Blocks()
    {
        var value = new RichBlockExpandableBlockQuotation
        {
            Blocks =
            [
                new RichBlockParagraph { Text = "quoted" }
            ],
            Credit = new RichTextItalic { Text = "Author" }
        };

        var actual = JsonContract.AssertRoundtrip<RichBlock>(value);

        actual.Should().BeOfType<RichBlockExpandableBlockQuotation>();
        JsonContract.AssertDiscriminator(actual, "expandable_blockquote");
        ((RichBlockExpandableBlockQuotation)actual).Blocks.Should().ContainSingle();
    }
}
