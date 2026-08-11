using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class MenuButtonConverter : JsonConverter<MenuButton>
{
    public override MenuButton? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<MenuButtonType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in MenuButton");
        }

        return type switch
        {
            MenuButtonType.Commands => root.Deserialize<MenuButtonCommands>(options),
            MenuButtonType.WebApp => root.Deserialize<MenuButtonWebApp>(options),
            MenuButtonType.Default => root.Deserialize<MenuButtonDefault>(options),
            _ => throw new JsonException($"Unknown MenuButton type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
