using System.Text.Json;
using FluentAssertions;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests;

public class InputMessageContentSerializationTests
{
    public static TheoryData<InputMessageContent> Values => new()
    {
        new InputTextMessageContent
        {
            MessageText = "Inline response",
            ParseMode = "HTML"
        },
        new InputRichMessageContent
        {
            RichMessage = new InputRichMessage
            {
                Markdown = "**Rich inline response**",
                IsRtl = false
            }
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
}
