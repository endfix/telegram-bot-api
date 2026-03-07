using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class BackgroundType
{
    public abstract BackgroundTypes Type { get; }
}

public sealed class BackgroundTypeChatTheme : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.ChatTheme;

    public required string ThemeName { get; init; }
}

public sealed class BackgroundTypeFill : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Fill;

    public required BackgroundFill Fill { get; init; }

    public required int DarkThemeDimming { get; init; }
}

public sealed class BackgroundTypePattern : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Pattern;

    public required Document Document { get; init; }

    public required BackgroundFill Fill { get; init; }

    public required int Intensity { get; init; }

    public bool? IsInverted { get; init; }

    public bool? IsMoving { get; init; }
}

public sealed class BackgroundTypeWallpaper : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Wallpaper;

    public required Document Document { get; init; }

    public required int DarkThemeDimming { get; init; }

    public bool? IsBlurred { get; init; }

    public bool? IsMoving { get; init; }
}
