using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class InputMessageContentConverter : JsonConverter<InputMessageContent>
{
    public override InputMessageContent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (root.TryGetProperty("rich_message", out _))
        {
            return root.Deserialize<InputRichMessageContent>(options);
        }

        if (root.TryGetProperty("message_text", out _))
        {
            return root.Deserialize<InputTextMessageContent>(options);
        }

        if (root.TryGetProperty("phone_number", out _))
        {
            return root.Deserialize<InputContactMessageContent>(options);
        }

        if (root.TryGetProperty("payload", out _))
        {
            return root.Deserialize<InputInvoiceMessageContent>(options);
        }

        if (root.TryGetProperty("latitude", out _) && root.TryGetProperty("longitude", out _))
        {
            return root.TryGetProperty("title", out _) && root.TryGetProperty("address", out _)
                ? root.Deserialize<InputVenueMessageContent>(options)
                : root.Deserialize<InputLocationMessageContent>(options);
        }

        throw new JsonException("Unable to determine InputMessageContent type from its properties.");
    }

    public override void Write(Utf8JsonWriter writer, InputMessageContent value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
