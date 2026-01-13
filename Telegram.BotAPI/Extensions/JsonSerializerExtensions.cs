using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Converters;

namespace Telegram.BotAPI.Extensions;

public static class JsonSerializerExtensions
{
    private static readonly JsonSerializerOptions _option = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = {
            new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.SnakeCaseLower),
            new MaybeInaccessibleMessageConverter()
        }
    };

    private static readonly JsonSerializerOptions _indentedOption = new JsonSerializerOptions(_option)
    {
        WriteIndented = true,
        IndentCharacter = ' ',
        IndentSize = 4
    };

    public static T? Deserialize<T>(this string json) 
        => string.IsNullOrEmpty(json) ? default : JsonSerializer.Deserialize<T>(json, _option);

    public static string Serialize(this object obj, bool writeIndented = false) 
        => obj is null ? string.Empty : JsonSerializer.Serialize(obj, writeIndented ? _indentedOption : _option);
}
