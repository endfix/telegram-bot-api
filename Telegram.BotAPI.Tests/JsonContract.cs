using System.Text.Json;
using FluentAssertions;
using Telegram.BotAPI.Extensions;

namespace Telegram.BotAPI.Tests;

internal static class JsonContract
{
    public static T AssertRoundtrip<T>(T expected)
        where T : notnull
    {
        var json = expected.Serialize();
        var actual = json.Deserialize<T>();

        actual.Should().NotBeNull("serialized {0} should deserialize", typeof(T).Name);
        actual.Should().BeEquivalentTo(
            expected,
            options => options.PreferringRuntimeMemberTypes());

        return actual!;
    }

    public static void AssertDiscriminator<T>(T value, string expected, string propertyName = "type")
        where T : notnull
    {
        using var document = JsonDocument.Parse(value.Serialize());

        document.RootElement.GetProperty(propertyName).GetString().Should().Be(expected);
    }
}
