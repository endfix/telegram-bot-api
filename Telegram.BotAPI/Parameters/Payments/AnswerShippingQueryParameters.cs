using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class AnswerShippingQueryParameters : ApiRequestParameters
{
    public required string ShippingQueryId { get; init; }

    public required bool Ok { get; init; }

    public IReadOnlyList<ShippingOption>? ShippingOptions { get; init; }

    public string? ErrorMessage { get; init; }
}
