using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GiftPremiumSubscriptionParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required int MonthCount { get; init; }

    public required int StarCount { get; init; }

    public string? Text { get; init; }

    public string? TextParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
