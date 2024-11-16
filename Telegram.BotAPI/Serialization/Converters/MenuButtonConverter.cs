using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Serialization.Converters;

public class MenuButtonConverter : JsonConverter<MenuButton>
{
    public override MenuButton Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                MenuButton.Types.COMMANDS => jsonElement.GetRawText().Deserialize<MenuButtonCommands>(),
                MenuButton.Types.WEB_APP => jsonElement.GetRawText().Deserialize<MenuButtonWebApp>(),
                MenuButton.Types.DEFAULT => jsonElement.GetRawText().Deserialize<MenuButtonDefault>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
    {
        //writer.WriteRawValue(value.Serialize());
        writer.WriteStartObject();
        {
            writer.WriteString("type", value.Type);
            if (value.Type == MenuButton.Types.WEB_APP)
            {
                var menuButtonWebApp = (MenuButtonWebApp)value;
                writer.WriteString("text", menuButtonWebApp.Text);
                writer.WriteStartObject("web_app");
                {
                    writer.WriteString("url", menuButtonWebApp.WebApp.Url);
                }
                writer.WriteEndObject();
            }
        }
        writer.WriteEndObject();
    }
}
