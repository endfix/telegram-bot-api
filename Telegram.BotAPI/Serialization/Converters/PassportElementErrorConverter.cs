using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PassportElementErrorConverter : JsonConverter<PassportElementError>
{
    public override PassportElementError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("source", out var source))
        {
            throw new JsonException("Missing discriminator 'source' in PassportElementError");
        }

        return source.GetString() switch
        {
            "data" => root.Deserialize<PassportElementErrorDataField>(options),
            "front_side" => root.Deserialize<PassportElementErrorFrontSide>(options),
            "reverse_side" => root.Deserialize<PassportElementErrorReverseSide>(options),
            "selfie" => root.Deserialize<PassportElementErrorSelfie>(options),
            "file" => root.Deserialize<PassportElementErrorFile>(options),
            "files" => root.Deserialize<PassportElementErrorFiles>(options),
            "translation_file" => root.Deserialize<PassportElementErrorTranslationFile>(options),
            "translation_files" => root.Deserialize<PassportElementErrorTranslationFiles>(options),
            "unspecified" => root.Deserialize<PassportElementErrorUnspecified>(options),
            _ => throw new JsonException($"Unknown PassportElementError source: {source}")
        };
    }

    public override void Write(Utf8JsonWriter writer, PassportElementError value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
