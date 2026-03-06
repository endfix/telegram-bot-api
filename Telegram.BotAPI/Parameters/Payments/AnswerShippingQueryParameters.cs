using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerShippingQueryParameters : ApiRequestParameters
{
    public required string ShippingQueryId { get; init; }

    public required bool Ok { get; init; }

    public IReadOnlyList<ShippingOption>? ShippingOptions { get; init; }

    public string? ErrorMessage { get; init; }
}
