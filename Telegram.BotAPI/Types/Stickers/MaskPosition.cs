using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class MaskPosition
{
    public required MaskPositionPoint Point { get; init; }

    public required float XShift { get; init; }

    public required float YShift { get; init; }

    public required float Scale { get; init; }
}
