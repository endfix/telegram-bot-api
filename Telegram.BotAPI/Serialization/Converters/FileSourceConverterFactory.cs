using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class FileSourceConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsValueType && typeof(IFileSource).IsAssignableFrom(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(FileSourceConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}

internal sealed class FileSourceConverter<TSource> : JsonConverter<TSource>
    where TSource : IFileSource
{
    private static readonly Func<string, TSource> FromString = CreateFromStringConverter();

    public override TSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unexpected token type for {typeof(TSource).Name}: {reader.TokenType}");
        }

        var value = reader.GetString()
            ?? throw new JsonException($"{typeof(TSource).Name} must be a string.");
        return FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TSource value, JsonSerializerOptions options)
    {
        switch (value.Value)
        {
            case string source:
                writer.WriteStringValue(source);
                return;
            case InputFile:
                writer.WriteNullValue();
                return;
            default:
                throw new JsonException($"Unsupported {typeof(TSource).Name} value.");
        }
    }

    private static Func<string, TSource> CreateFromStringConverter()
    {
        var method = typeof(TSource).GetMethod(
            "op_Implicit",
            BindingFlags.Public | BindingFlags.Static,
            binder: null,
            types: [typeof(string)],
            modifiers: null)
            ?? throw new InvalidOperationException(
                $"{typeof(TSource).Name} does not define an implicit conversion from string.");

        return (Func<string, TSource>)Delegate.CreateDelegate(typeof(Func<string, TSource>), method);
    }
}
