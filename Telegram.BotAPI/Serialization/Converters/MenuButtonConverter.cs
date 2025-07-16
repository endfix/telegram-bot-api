using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Serialization.Converters;

public class MenuButtonConverter : JsonConverter<MenuButton>
{
    public override MenuButton Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(MenuButtonTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                MenuButtonTypes.Commands => jsonElement.GetRawText().Deserialize<MenuButtonCommands>(),
                MenuButtonTypes.WebApp => jsonElement.GetRawText().Deserialize<MenuButtonWebApp>(),
                MenuButtonTypes.Default => jsonElement.GetRawText().Deserialize<MenuButtonDefault>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
