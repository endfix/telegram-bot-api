using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetCustomEmojiStickersParameters : ApiRequestParameters
{
    public required IReadOnlyList<string> CustomEmojiIds { get; init; }
}
