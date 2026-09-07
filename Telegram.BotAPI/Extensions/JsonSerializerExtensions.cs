using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Serialization.Converters;

namespace Endfix.Telegram.BotAPI.Extensions;

/// <summary>Provides JSON serialization helpers configured for the Telegram Bot API contract.</summary>
public static class JsonSerializerExtensions
{
    /// <summary>Gets the serializer options used for Telegram Bot API payloads.</summary>
    public static readonly JsonSerializerOptions Options = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = {
            new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.SnakeCaseLower),
            new ChatIdSourceConverter(),
            new MediaSourceConverter(),
            new CoverSourceConverter(),
            new StickerSourceConverter(),
            new ThumbnailSourceConverter(),
            new BackgroundFillConverter(),
            new BackgroundTypeConverter(),
            new BotCommandScopeConverter(),
            new ChatBoostSourceConverter(),
            new ChatMemberConverter(),
            new InputMediaConverter(),
            new MaybeInaccessibleMessageConverter(),
            new MenuButtonConverter(),
            new MessageOriginConverter(),
            new OwnedGiftConverter(),
            new PaidMediaConverter(),
            new PassportElementErrorConverter(),
            new ReactionTypeConverter(),
            new RichTextSourceConverter(),
            new RichTextConverter(),
            new RichBlockConverter(),
            new InlineQueryResultConverter(),
            new TransactionPartnerConverter(),
            new RevenueWithdrawalStateConverter(),
            new StoryAreaTypeConverter(),
            new InputMessageContentConverter(),
            new InputProfilePhotoConverter(),
            new InputStoryContentConverter(),
            new InputPaidMediaConverter(),
            new InputRichBlockConverter(),
            new InputPollMediaConverter(),
            new InputPollOptionMediaConverter()
        }
    };

    /// <summary>Gets the serializer options used for indented Telegram Bot API payloads.</summary>
    public static readonly JsonSerializerOptions IndentedOptions = new(Options)
    {
        WriteIndented = true,
        IndentCharacter = ' ',
        IndentSize = 4
    };

    /// <summary>Deserializes JSON using the Telegram Bot API serializer options.</summary>
    /// <typeparam name="T">Type of value to deserialize.</typeparam>
    /// <param name="json">JSON text to deserialize.</param>
    /// <returns>The deserialized value, or the default value when <paramref name="json"/> is null or empty.</returns>
    public static T? Deserialize<T>(this string json) 
        => string.IsNullOrEmpty(json) ? default : JsonSerializer.Deserialize<T>(json, Options);

    /// <summary>Asynchronously deserializes JSON from a stream using the Telegram Bot API serializer options.</summary>
    /// <typeparam name="T">Type of value to deserialize.</typeparam>
    /// <param name="stream">UTF-8 encoded JSON stream to deserialize.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the deserialized value.</returns>
    public static ValueTask<T?> DeserializeAsync<T>(
        this Stream stream,
        CancellationToken cancellationToken = default)
        => JsonSerializer.DeserializeAsync<T>(stream, Options, cancellationToken);

    /// <summary>Serializes a value using the Telegram Bot API serializer options.</summary>
    /// <param name="obj">Value to serialize.</param>
    /// <param name="writeIndented">Whether to format the JSON with indentation.</param>
    /// <returns>The serialized JSON, or an empty string when <paramref name="obj"/> is null.</returns>
    public static string Serialize(this object obj, bool writeIndented = false) 
        => obj is null ? string.Empty : JsonSerializer.Serialize(obj, writeIndented ? IndentedOptions : Options);
}
