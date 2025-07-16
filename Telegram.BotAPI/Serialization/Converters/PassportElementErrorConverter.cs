using System;
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
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(PassportElementErrorSources), jsonElement.GetProperty("source").GetString()?.ToUpperInvariant()) switch
            {
                PassportElementErrorSources.Data => jsonElement.GetRawText().Deserialize<PassportElementErrorDataField>(),
                PassportElementErrorSources.FrontSide => jsonElement.GetRawText().Deserialize<PassportElementErrorFrontSide>(),
                PassportElementErrorSources.ReverseSide => jsonElement.GetRawText().Deserialize<PassportElementErrorReverseSide>(),
                PassportElementErrorSources.Selfie => jsonElement.GetRawText().Deserialize<PassportElementErrorSelfie>(),
                PassportElementErrorSources.File => jsonElement.GetRawText().Deserialize<PassportElementErrorFile>(),
                PassportElementErrorSources.Files => jsonElement.GetRawText().Deserialize<PassportElementErrorFiles>(),
                PassportElementErrorSources.TranslationFile => jsonElement.GetRawText().Deserialize<PassportElementErrorTranslationFile>(),
                PassportElementErrorSources.TranslationFiles => jsonElement.GetRawText().Deserialize<PassportElementErrorTranslationFiles>(),
                PassportElementErrorSources.Unspecified => jsonElement.GetRawText().Deserialize<PassportElementErrorUnspecified>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, PassportElementError value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
