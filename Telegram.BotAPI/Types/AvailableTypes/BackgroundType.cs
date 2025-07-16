using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class BackgroundType
{
    public abstract BackgroundTypes Type { get; }
}

public class BackgroundTypeChatTheme : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.ChatTheme;

    public string ThemeName { get; set; }
}

public sealed class BackgroundTypeFill : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Fill;

    public BackgroundFill Fill { get; set; }

    public int DarkThemeDimming { get; set; }
}

public class BackgroundTypePattern : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Pattern;

    public Document Document { get; set; }

    public BackgroundFill Fill { get; set; }

    public int Intensity { get; set; }

    public bool IsInverted { get; set; }

    public bool IsMoving { get; set; }
}

public class BackgroundTypeWallpaper : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Wallpaper;

    public Document Document { get; set; }

    public int DarkThemeDimming { get; set; }

    public bool IsBlurred { get; set; }

    public bool IsMoving { get; set; }
}
