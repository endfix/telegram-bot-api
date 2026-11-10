using System.Text.Json;
using FluentAssertions;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class InputMessageContentSerializationTests
{
    public static TheoryData<InputMessageContent> Values => new()
    {
        new InputTextMessageContent
        {
            MessageText = "Inline response",
            ParseMode = ParseMode.HTML
        },
        new InputRichMessageContent
        {
            RichMessage = new InputRichMessage
            {
                Markdown = "**Rich inline response**",
                IsRtl = false
            }
        },
        new InputWidgetMessageContent
        {
            Html = "<div>Widget</div>",
            Width = 320,
            Height = 480,
            PublicData = "public",
            ChatData = "chat",
            Caption = "Widget caption",
            ParseMode = ParseMode.HTML,
            AllowQueries = true,
            IsShared = true
        },
        new InputSharedWidgetMessageContent
        {
            WidgetId = "shared-widget-id",
            ChatData = "chat",
            Caption = "Shared widget caption"
        },
        new InputLocationMessageContent
        {
            Latitude = 55.7558,
            Longitude = 37.6173,
            HorizontalAccuracy = 12.5f,
            LivePeriod = 300
        },
        new InputVenueMessageContent
        {
            Latitude = 55.7558,
            Longitude = 37.6173,
            Title = "Red Square",
            Address = "Moscow"
        },
        new InputContactMessageContent
        {
            PhoneNumber = "+79990000000",
            FirstName = "Alex",
            LastName = "Tester"
        },
        new InputInvoiceMessageContent
        {
            Title = "Test product",
            Description = "Contract test invoice",
            Payload = "invoice-payload",
            Currency = "XTR",
            Prices = new[]
            {
                new LabeledPrice
                {
                    Label = "Test product",
                    Amount = 100
                }
            }
        }
    };

    [Theory]
    [MemberData(nameof(Values))]
    public void InputMessageContent_Roundtrips(InputMessageContent value)
    {
        var actual = JsonContract.AssertRoundtrip(value);

        actual.Should().BeOfType(value.GetType());
    }

    [Fact]
    public void InputMessageContent_UnknownShape_ThrowsJsonException()
    {
        var act = () => "{}".Deserialize<InputMessageContent>();

        act.Should().Throw<JsonException>();
    }

    [Fact]
    public void InputWidgetMessageContent_Serializes_Html()
    {
        var content = new InputWidgetMessageContent
        {
            Html = "<div>Widget</div>"
        };

        using var document = JsonDocument.Parse(content.Serialize());

        document.RootElement.GetProperty("html").GetString().Should().Be("<div>Widget</div>");
        "{\"html\":\"<div>Widget</div>\"}".Deserialize<InputMessageContent>()
            .Should()
            .BeOfType<InputWidgetMessageContent>();
    }

    [Fact]
    public void InputSharedWidgetMessageContent_Serializes_WidgetId()
    {
        var content = new InputSharedWidgetMessageContent
        {
            WidgetId = "shared-widget-id"
        };

        using var document = JsonDocument.Parse(content.Serialize());

        document.RootElement.GetProperty("widget_id").GetString().Should().Be("shared-widget-id");
        "{\"widget_id\":\"shared-widget-id\"}".Deserialize<InputMessageContent>()
            .Should()
            .BeOfType<InputSharedWidgetMessageContent>();
    }
}
