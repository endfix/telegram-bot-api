using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>giftPremiumSubscription</c> method.
/// </summary>
public sealed class GiftPremiumSubscriptionParameters : ApiRequestParameters
{
    /// <summary>Identifier of the target user who will receive the Telegram Premium subscription.</summary>
    public required long UserId { get; init; }

    /// <summary>Subscription duration; must be 3, 6 or 12 months.</summary>
    public required int MonthCount { get; init; }

    /// <summary>Price in Telegram Stars: 1000 for 3 months, 1500 for 6 months or 2500 for 12 months.</summary>
    public required int StarCount { get; init; }

    /// <summary>Text shown with the subscription service message, from 0 through 128 characters.</summary>
    public string? Text { get; init; }

    /// <summary>
    /// Mode for parsing entities in <see cref="Text"/>. Entities other than bold, italic, underline,
    /// strikethrough, spoiler, custom emoji, and date-time entities are ignored.
    /// </summary>
    public string? TextParseMode { get; init; }

    /// <summary>
    /// Special entities in the gift text; can be specified instead of <see cref="TextParseMode"/>.
    /// Entities other than bold, italic, underline, strikethrough, spoiler, custom emoji, and date-time
    /// entities are ignored.
    /// </summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
