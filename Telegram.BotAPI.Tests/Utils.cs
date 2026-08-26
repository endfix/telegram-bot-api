using FluentAssertions;
using Endfix.Telegram.BotAPI.Extensions;

namespace Endfix.Telegram.BotAPI.Tests;

public static class Utils
{
    public static void AssertRoundtrip<T>(T obj) where T : class
    {
        ArgumentNullException.ThrowIfNull(obj);

        var json = obj.Serialize(true);
        var deserialized = json.Deserialize<T>();

        deserialized.Should().BeEquivalentTo(obj,
            "because serialization and deserialization should be lossless. JSON: {0}", json);
    }
}
