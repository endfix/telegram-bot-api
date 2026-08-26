using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class InlineQueryResultConverter : JsonConverter<InlineQueryResult>
{
    public override InlineQueryResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is InlineQueryResultConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<InlineQueryResultType>(options);

        return type switch
        {
            InlineQueryResultType.Article => jsonElement.Deserialize<InlineQueryResultArticle>(innerOptions)!,

            InlineQueryResultType.Photo => jsonElement.TryGetProperty("photo_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultPhoto>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedPhoto>(innerOptions)!,

            InlineQueryResultType.Gif => jsonElement.TryGetProperty("gif_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultGif>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedGif>(innerOptions)!,

            InlineQueryResultType.Mpeg4Gif => jsonElement.TryGetProperty("mpeg4_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultMpeg4Gif>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedMpeg4Gif>(innerOptions)!,

            InlineQueryResultType.Video => jsonElement.TryGetProperty("video_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultVideo>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedVideo>(innerOptions)!,

            InlineQueryResultType.Audio => jsonElement.TryGetProperty("audio_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultAudio>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedAudio>(innerOptions)!,

            InlineQueryResultType.Voice => jsonElement.TryGetProperty("voice_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultVoice>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedVoice>(innerOptions)!,

            InlineQueryResultType.Document => jsonElement.TryGetProperty("document_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultDocument>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedDocument>(innerOptions)!,

            InlineQueryResultType.CachedSticker => jsonElement.Deserialize<InlineQueryResultCachedSticker>(innerOptions)!,

            InlineQueryResultType.Location => jsonElement.Deserialize<InlineQueryResultLocation>(innerOptions)!,

            InlineQueryResultType.Venue => jsonElement.Deserialize<InlineQueryResultVenue>(innerOptions)!,

            InlineQueryResultType.Contact => jsonElement.Deserialize<InlineQueryResultContact>(innerOptions)!,

            InlineQueryResultType.Game => jsonElement.Deserialize<InlineQueryResultGame>(innerOptions)!,

            _ => throw new JsonException($"Unknown InlineQueryResult type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InlineQueryResult value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is InlineQueryResultConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
