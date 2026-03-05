using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class MaskPosition
{
    public required MaskPositionPoints Point { get; init; }

    public required float XShift { get; init; }

    public required float YShift { get; init; }

    public required float Scale { get; init; }
}
