using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class ReplyMarkupConverter : JsonConverter<ReplyMarkup>
{
    public override ReplyMarkup? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (root.TryGetProperty("inline_keyboard", out _))
        {
            return root.Deserialize<InlineKeyboardMarkup>(options);
        }

        if (root.TryGetProperty("keyboard", out _))
        {
            return root.Deserialize<ReplyKeyboardMarkup>(options);
        }

        if (root.TryGetProperty("remove_keyboard", out _))
        {
            return root.Deserialize<ReplyKeyboardRemove>(options);
        }

        if (root.TryGetProperty("force_reply", out _))
        {
            return root.Deserialize<ForceReplyStruct>(options);
        }

        throw new JsonException("Unknown ReplyMarkup shape.");
    }

    public override void Write(Utf8JsonWriter writer, ReplyMarkup value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
