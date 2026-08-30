using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Serialization.Converters;

namespace Endfix.Telegram.BotAPI.Extensions;

public static class JsonSerializerExtensions
{
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
            new InputRichBlockConverter()
        }
    };

    public static readonly JsonSerializerOptions IndentedOptions = new(Options)
    {
        WriteIndented = true,
        IndentCharacter = ' ',
        IndentSize = 4
    };

    public static T? Deserialize<T>(this string json) 
        => string.IsNullOrEmpty(json) ? default : JsonSerializer.Deserialize<T>(json, Options);

    public static ValueTask<T?> DeserializeAsync<T>(
        this Stream stream,
        CancellationToken cancellationToken = default)
        => JsonSerializer.DeserializeAsync<T>(stream, Options, cancellationToken);

    public static string Serialize(this object obj, bool writeIndented = false) 
        => obj is null ? string.Empty : JsonSerializer.Serialize(obj, writeIndented ? IndentedOptions : Options);
}
