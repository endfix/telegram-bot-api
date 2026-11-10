using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

/// <summary>
/// Reads and writes <see cref="ParseMode"/> using the exact case-sensitive values accepted by the Bot API.
/// </summary>
internal sealed class ParseModeConverter : JsonConverter<ParseMode>
{
    public override ParseMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Expected a string for {nameof(ParseMode)} but found {reader.TokenType}.");
        }

        return reader.GetString() switch
        {
            "MarkdownV2" => ParseMode.MarkdownV2,
            "HTML" => ParseMode.HTML,
            "Markdown" => ParseMode.Markdown,
            var value => throw new JsonException($"Unknown parse mode '{value}'.")
        };
    }

    public override void Write(Utf8JsonWriter writer, ParseMode value, JsonSerializerOptions options)
        => writer.WriteStringValue(value switch
        {
            ParseMode.MarkdownV2 => "MarkdownV2",
            ParseMode.HTML => "HTML",
            ParseMode.Markdown => "Markdown",
            _ => throw new JsonException($"Unknown parse mode '{value}'.")
        });
}
