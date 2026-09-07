using System;
using System.Text.Json;

namespace Endfix.Telegram.BotAPI.Extensions;

/// <summary>Provides conversion helpers for <see cref="JsonElement"/> values.</summary>
public static class JsonElementExtensions
{
    /// <summary>Attempts to deserialize a JSON value as an enumeration member.</summary>
    /// <typeparam name="TEnum">Enumeration type to deserialize.</typeparam>
    /// <param name="element">JSON value to deserialize.</param>
    /// <param name="options">Serializer options used for the conversion.</param>
    /// <param name="value">When this method returns, contains the deserialized value on success; otherwise, the default value.</param>
    /// <returns><see langword="true"/> when the value was deserialized successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnum<TEnum>(this JsonElement element, JsonSerializerOptions options, out TEnum value)
        where TEnum : struct, Enum
    {
        try
        {
            var result = JsonSerializer.Deserialize<TEnum>(element.GetRawText(), options);

            value = result;
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }
}
