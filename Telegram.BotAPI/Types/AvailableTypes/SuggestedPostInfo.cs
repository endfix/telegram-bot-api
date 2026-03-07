using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostInfo
{
    public SuggestedPostInfoState State { get; init; }

    public SuggestedPostPrice? Price { get; init; }

    public int? SendDate { get; init; }
}
