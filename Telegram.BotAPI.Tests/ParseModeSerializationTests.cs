using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class ParseModeSerializationTests
{
    public static TheoryData<ParseMode, string> Values => new()
    {
        { ParseMode.MarkdownV2, "MarkdownV2" },
        { ParseMode.HTML, "HTML" },
        { ParseMode.Markdown, "Markdown" }
    };

    [Theory]
    [MemberData(nameof(Values))]
    public void ParseMode_Serializes_Using_BotApi_Value(ParseMode parseMode, string expected)
    {
        var parameters = new SendMessageParameters
        {
            ChatId = 123456789L,
            Text = "text",
            ParseMode = parseMode
        };

        using var document = JsonDocument.Parse(parameters.Serialize());

        document.RootElement.GetProperty("parse_mode").GetString().Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Values))]
    public void ParseMode_Deserializes_From_BotApi_Value(ParseMode expected, string value)
    {
        var json = JsonSerializer.Serialize(value, JsonSerializerExtensions.Options);

        var actual = json.Deserialize<ParseMode>();

        actual.Should().Be(expected);
    }

    [Fact]
    public void ParseMode_Rejects_Unknown_Value()
    {
        var act = () => "\"markdown_v2\"".Deserialize<ParseMode>();

        act.Should().Throw<JsonException>();
    }

    [Fact]
    public void ParseMode_Is_Omitted_When_Null()
    {
        var parameters = new SendMessageParameters
        {
            ChatId = 123456789L,
            Text = "text"
        };

        using var document = JsonDocument.Parse(parameters.Serialize());

        document.RootElement.TryGetProperty("parse_mode", out _).Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(Values))]
    public void Widget_Caption_ParseMode_Serializes_Using_BotApi_Value(ParseMode parseMode, string expected)
    {
        var parameters = new SendWidgetParameters
        {
            ChatId = 123456789L,
            Html = "<div>Widget</div>",
            Caption = "caption",
            ParseMode = parseMode
        };

        using var document = JsonDocument.Parse(parameters.Serialize());

        document.RootElement.GetProperty("parse_mode").GetString().Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Values))]
    public void InputTextMessageContent_ParseMode_Serializes_Using_BotApi_Value(ParseMode parseMode, string expected)
    {
        var content = new InputTextMessageContent
        {
            MessageText = "text",
            ParseMode = parseMode
        };

        using var document = JsonDocument.Parse(content.Serialize());

        document.RootElement.GetProperty("parse_mode").GetString().Should().Be(expected);
    }

    [Fact]
    public void All_ParseMode_Properties_Use_The_ParseMode_Enum()
    {
        var invalidProperties = typeof(ParseMode).Assembly
            .GetExportedTypes()
            .SelectMany(type => type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            .Where(property => property.Name.EndsWith("ParseMode", System.StringComparison.Ordinal))
            .Where(property => property.PropertyType != typeof(ParseMode?))
            .Select(property => $"{property.DeclaringType?.FullName}.{property.Name}")
            .ToArray();

        invalidProperties.Should().BeEmpty();
    }

    [Fact]
    public void ParseMode_Enum_Contains_Only_BotApi_Values()
    {
        System.Enum.GetNames<ParseMode>().Should().BeEquivalentTo(new[]
        {
            "MarkdownV2",
            "HTML",
            "Markdown"
        });
    }
}
