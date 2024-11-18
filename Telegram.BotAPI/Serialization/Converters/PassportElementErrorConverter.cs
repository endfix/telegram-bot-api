using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.TelegramPassport;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PassportElementErrorConverter : JsonConverter<PassportElementError>
{
    public override PassportElementError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("source").GetString() switch
            {
                PassportElementError.Sources.DATA => jsonElement.GetRawText().Deserialize<PassportElementErrorDataField>(),
                PassportElementError.Sources.FRONT_SIDE => jsonElement.GetRawText().Deserialize<PassportElementErrorFrontSide>(),
                PassportElementError.Sources.REVERSE_SIDE => jsonElement.GetRawText().Deserialize<PassportElementErrorReverseSide>(),
                PassportElementError.Sources.SELFIE => jsonElement.GetRawText().Deserialize<PassportElementErrorSelfie>(),
                PassportElementError.Sources.FILE => jsonElement.GetRawText().Deserialize<PassportElementErrorFile>(),
                PassportElementError.Sources.FILES => jsonElement.GetRawText().Deserialize<PassportElementErrorFiles>(),
                PassportElementError.Sources.TRANSLATION_FILE => jsonElement.GetRawText().Deserialize<PassportElementErrorTranslationFile>(),
                PassportElementError.Sources.TRANSLATION_FILES => jsonElement.GetRawText().Deserialize<PassportElementErrorTranslationFiles>(),
                PassportElementError.Sources.UNSPECIFIED => jsonElement.GetRawText().Deserialize<PassportElementErrorUnspecified>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, PassportElementError value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
