using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Structs;
using Telegram.BotAPI.Serialization.Extensions;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class MenuButtonConverter : JsonConverter<MenuButton>
    {
        public override MenuButton Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                MenuButton.Types.COMMANDS => jsonElement.GetRawText().Deserialize<MenuButton.CommandsStruct>(),
                MenuButton.Types.WEB_APP => jsonElement.GetRawText().Deserialize<MenuButton.WebAppStruct>(),
                MenuButton.Types.DEFAULT => jsonElement.GetRawText().Deserialize<MenuButton.DefaultStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
