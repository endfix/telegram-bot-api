using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class TransactionPartnerConverter : JsonConverter<TransactionPartner>
{
    public override TransactionPartner? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<TransactionPartnerType>(options, out var transactionPartnerType))
        {
            throw new JsonException("Missing discriminator 'type' in TransactionPartner");
        }

        return transactionPartnerType switch
        {
            TransactionPartnerType.User => root.Deserialize<TransactionPartnerUser>(options),
            TransactionPartnerType.Chat => root.Deserialize<TransactionPartnerChat>(options),
            TransactionPartnerType.AffiliateProgram => root.Deserialize<TransactionPartnerAffiliateProgram>(options),
            TransactionPartnerType.Fragment => root.Deserialize<TransactionPartnerFragment>(options),
            TransactionPartnerType.TelegramAds => root.Deserialize<TransactionPartnerTelegramAds>(options),
            TransactionPartnerType.TelegramApi => root.Deserialize<TransactionPartnerTelegramApi>(options),
            TransactionPartnerType.Other => root.Deserialize<TransactionPartnerOther>(options),
            _ => throw new JsonException($"Unknown TransactionPartner type: {typeProperty.GetString()}")
        };
    }

    public override void Write(Utf8JsonWriter writer, TransactionPartner value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
