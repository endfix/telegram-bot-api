using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PassportElementErrorConverter : JsonConverter<PassportElementError>
{
    public override PassportElementError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is PassportElementErrorConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var source = jsonElement.GetProperty("source").Deserialize<PassportElementErrorSources>(options);

        return source switch
        {
            PassportElementErrorSources.Data => jsonElement.Deserialize<PassportElementErrorDataField>(innerOptions)!,
            PassportElementErrorSources.FrontSide => jsonElement.Deserialize<PassportElementErrorFrontSide>(innerOptions)!,
            PassportElementErrorSources.ReverseSide => jsonElement.Deserialize<PassportElementErrorReverseSide>(innerOptions)!,
            PassportElementErrorSources.Selfie => jsonElement.Deserialize<PassportElementErrorSelfie>(innerOptions)!,
            PassportElementErrorSources.File => jsonElement.Deserialize<PassportElementErrorFile>(innerOptions)!,
            PassportElementErrorSources.Files => jsonElement.Deserialize<PassportElementErrorFiles>(innerOptions)!,
            PassportElementErrorSources.TranslationFile => jsonElement.Deserialize<PassportElementErrorTranslationFile>(innerOptions)!,
            PassportElementErrorSources.TranslationFiles => jsonElement.Deserialize<PassportElementErrorTranslationFiles>(innerOptions)!,
            PassportElementErrorSources.Unspecified => jsonElement.Deserialize<PassportElementErrorUnspecified>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {source}")
        };
    }

    public override void Write(Utf8JsonWriter writer, PassportElementError value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is PassportElementErrorConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
