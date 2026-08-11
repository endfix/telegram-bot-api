using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class RevenueWithdrawalStateConverter : JsonConverter<RevenueWithdrawalState>
{
    public override RevenueWithdrawalState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<RevenueWithdrawalStateType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in RevenueWithdrawalState");
        }

        return type switch
        {
            RevenueWithdrawalStateType.Pending => root.Deserialize<RevenueWithdrawalStatePending>(options)!,
            RevenueWithdrawalStateType.Succeeded => root.Deserialize<RevenueWithdrawalStateSucceeded>(options)!,
            RevenueWithdrawalStateType.Failed => root.Deserialize<RevenueWithdrawalStateFailed>(options)!,
            _ => throw new JsonException($"Unknown RevenueWithdrawalState type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RevenueWithdrawalState value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
