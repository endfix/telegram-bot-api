using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class WidgetQueryTypeConverter : JsonConverter<WidgetQueryType>
{
    public override WidgetQueryType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<WidgetQueryTypes>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in WidgetQueryType");
        }

        return type switch
        {
            WidgetQueryTypes.Data => root.Deserialize<WidgetQueryTypeData>(options),
            WidgetQueryTypes.SignData => root.Deserialize<WidgetQueryTypeSignData>(options),
            WidgetQueryTypes.SentTransaction => root.Deserialize<WidgetQueryTypeSentTransaction>(options),
            _ => throw new JsonException($"Unknown WidgetQueryType type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, WidgetQueryType value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
