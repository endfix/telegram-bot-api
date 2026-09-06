using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerShippingQuery</c> method.
/// </summary>
public sealed class AnswerShippingQueryParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the shipping query.</summary>
    public required string ShippingQueryId { get; init; }

    /// <summary>Whether delivery to the specified address is possible.</summary>
    public required bool Ok { get; init; }

    /// <summary>Available shipping options. Required when <see cref="Ok"/> is <see langword="true"/>.</summary>
    public IReadOnlyList<ShippingOption>? ShippingOptions { get; init; }

    /// <summary>Human-readable reason for failure. Required when <see cref="Ok"/> is <see langword="false"/>.</summary>
    public string? ErrorMessage { get; init; }
}
