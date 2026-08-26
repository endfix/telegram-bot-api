using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostInfo
{
    public SuggestedPostInfoState State { get; init; }

    public SuggestedPostPrice? Price { get; init; }

    public int? SendDate { get; init; }
}
