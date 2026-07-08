using FluentAssertions;
using Telegram.BotAPI.Extensions;

namespace Telegram.BotAPI.Tests;

public static class Utils
{
    public static int GetRandomInt(int min = 1, int max = int.MaxValue) 
        => Random.Shared.Next(min, max);

    public static long GetRandomLong(long min = 1, long max = long.MaxValue) 
        => Random.Shared.NextInt64(min, max);

    public static double GetRandomDouble(double min = 1, double max = double.MaxValue)
        => Random.Shared.NextDouble() * (max - min) + min;

    public static string GetRandomText(int length = 1024)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        return new string(Random.Shared.GetItems(chars.AsSpan(), length));
    }

    public static T GetRandomEnum<T>() where T : struct, Enum
    {
        var values = (T[])Enum.GetValues(typeof(T));

        return values[Random.Shared.Next(values.Length)];
    }

    public static bool GetRandomBool() => Random.Shared.Next(2) == 0;

    public static void AssertRoundtrip<T>(T obj) where T : class
    {
        ArgumentNullException.ThrowIfNull(obj);

        var json = obj.Serialize(true);
        var deserialized = json.Deserialize<T>();

        deserialized.Should().BeEquivalentTo(obj,
            "because serialization and deserialization should be lossless. JSON: {0}", json);
    }
}
