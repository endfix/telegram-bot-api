using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class MaskPosition
{
    public MaskPositionPoints Point { get; set; }

    public float XShift { get; set; }

    public float YShift { get; set; }

    public float Scale { get; set; }
}
