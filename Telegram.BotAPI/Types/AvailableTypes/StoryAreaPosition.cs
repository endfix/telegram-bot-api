namespace Telegram.BotAPI.Types;

public sealed class StoryAreaPosition
{
    public required float XPercentage { get; init; }

    public required float YPercentage { get; init; }

    public required float WidthPercentage { get; init; }

    public required float HeightPercentage { get; init; }

    public required float RotationAngle { get; init; }

    public required float CornerRadiusPercentage { get; init; }
}
