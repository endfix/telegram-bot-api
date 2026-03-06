using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class GiftsStruct
{
    public required IReadOnlyList<Gift> Gifts { get; init; }
}
