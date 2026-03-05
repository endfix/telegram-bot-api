using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class InlineQueryResultConverter : JsonConverter<InlineQueryResult>
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
        var type = jsonElement.GetProperty("type").Deserialize<InlineQueryResultTypes>(options);

        return type switch
        {
            InlineQueryResultTypes.Article => jsonElement.Deserialize<InlineQueryResultArticle>(innerOptions)!,

            InlineQueryResultTypes.Photo => jsonElement.TryGetProperty("photo_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultPhoto>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedPhoto>(innerOptions)!,

            InlineQueryResultTypes.Gif => jsonElement.TryGetProperty("gif_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultGif>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedGif>(innerOptions)!,

            InlineQueryResultTypes.Mpeg4Gif => jsonElement.TryGetProperty("mpeg4_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultMpeg4Gif>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedMpeg4Gif>(innerOptions)!,

            InlineQueryResultTypes.Video => jsonElement.TryGetProperty("video_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultVideo>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedVideo>(innerOptions)!,

            InlineQueryResultTypes.Audio => jsonElement.TryGetProperty("audio_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultAudio>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedAudio>(innerOptions)!,

            InlineQueryResultTypes.Voice => jsonElement.TryGetProperty("voice_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultVoice>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedVoice>(innerOptions)!,

            InlineQueryResultTypes.Document => jsonElement.TryGetProperty("document_url", out _)
                ? jsonElement.Deserialize<InlineQueryResultDocument>(innerOptions)!
                : jsonElement.Deserialize<InlineQueryResultCachedDocument>(innerOptions)!,

            InlineQueryResultTypes.CachedSticker => jsonElement.Deserialize<InlineQueryResultCachedSticker>(innerOptions)!,

            InlineQueryResultTypes.Location => jsonElement.Deserialize<InlineQueryResultLocation>(innerOptions)!,

            InlineQueryResultTypes.Venue => jsonElement.Deserialize<InlineQueryResultVenue>(innerOptions)!,

            InlineQueryResultTypes.Contact => jsonElement.Deserialize<InlineQueryResultContact>(innerOptions)!,

            InlineQueryResultTypes.Game => jsonElement.Deserialize<InlineQueryResultGame>(innerOptions)!,

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
