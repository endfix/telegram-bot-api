using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PassportElementErrorConverter : JsonConverter<PassportElementError>
{
    public override PassportElementError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("source", out var sourceProperty) || !sourceProperty.TryGetEnum<PassportElementErrorSource>(options, out var source))
        {
            throw new JsonException("Missing discriminator 'source' in PassportElementError");
        }

        return source switch
        {
            PassportElementErrorSource.Data => root.Deserialize<PassportElementErrorDataField>(options),
            PassportElementErrorSource.FrontSide => root.Deserialize<PassportElementErrorFrontSide>(options),
            PassportElementErrorSource.ReverseSide => root.Deserialize<PassportElementErrorReverseSide>(options),
            PassportElementErrorSource.Selfie => root.Deserialize<PassportElementErrorSelfie>(options),
            PassportElementErrorSource.File => root.Deserialize<PassportElementErrorFile>(options),
            PassportElementErrorSource.Files => root.Deserialize<PassportElementErrorFiles>(options),
            PassportElementErrorSource.TranslationFile => root.Deserialize<PassportElementErrorTranslationFile>(options),
            PassportElementErrorSource.TranslationFiles => root.Deserialize<PassportElementErrorTranslationFiles>(options),
            PassportElementErrorSource.Unspecified => root.Deserialize<PassportElementErrorUnspecified>(options),
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
