using System.Text.Json;
using FluentAssertions;
using Telegram.BotAPI.Extensions;

namespace Telegram.BotAPI.Tests;

internal static class JsonContract
{
    public static T DeserializeFixture<T>(string fixturePath)
    {
        var json = ReadFixture(fixturePath);
        var value = JsonSerializer.Deserialize<T>(json, JsonSerializerExtensions.Options);

        value.Should().NotBeNull("fixture {0} must deserialize to {1}", fixturePath, typeof(T).Name);

        return value!;
    }

    public static void AssertRoundtripsToEquivalentJson<T>(string fixturePath)
    {
        var expectedJson = ReadFixture(fixturePath);
        var value = DeserializeFixture<T>(fixturePath);
        var actualJson = JsonSerializer.Serialize(value, JsonSerializerExtensions.Options);

        AssertJsonEquivalent(actualJson, expectedJson, fixturePath);
    }

    private static void AssertJsonEquivalent(string actualJson, string expectedJson, string because)
    {
        using var actualDocument = JsonDocument.Parse(actualJson);
        using var expectedDocument = JsonDocument.Parse(expectedJson);

        JsonElement.DeepEquals(actualDocument.RootElement, expectedDocument.RootElement)
            .Should().BeTrue(
                "serialized JSON should match fixture {0}. Actual: {1}. Expected: {2}",
                because,
                actualJson,
                expectedJson);
    }

    private static string ReadFixture(string fixturePath)
    {
        var fullPath = Path.Combine(AppContext.BaseDirectory, "Fixtures", fixturePath);

        File.Exists(fullPath).Should().BeTrue("fixture {0} should be copied to the test output", fullPath);

        return File.ReadAllText(fullPath);
    }
}
