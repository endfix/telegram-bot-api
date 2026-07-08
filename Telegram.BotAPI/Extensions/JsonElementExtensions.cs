using System;
using System.Text.Json;

namespace Telegram.BotAPI.Extensions;

public static class JsonElementExtensions
{
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
