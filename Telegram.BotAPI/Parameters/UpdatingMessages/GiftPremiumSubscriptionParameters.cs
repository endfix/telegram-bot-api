using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GiftPremiumSubscriptionParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required int MonthCount { get; init; }

    public required int StarCount { get; init; }

    public string? Text { get; init; }

    public string? TextParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
