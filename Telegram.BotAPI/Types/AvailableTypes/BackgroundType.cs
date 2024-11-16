namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class BackgroundType
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string FILL = "fill";

        public const string WALLPAPER = "wallpaper";

        public const string PATTERN = "pattern";

        public const string CHAT_THEME = "chat_theme";
    }
}

public class BackgroundTypeChatTheme : BackgroundType
{
    public override string Type => Types.CHAT_THEME;

    public string ThemeName { get; set; }
}

public sealed class BackgroundTypeFill : BackgroundType
{
    public override string Type => Types.FILL;

    public BackgroundFill Fill { get; set; }

    public int DarkThemeDimming { get; set; }
}

public class BackgroundTypePattern : BackgroundType
{
    public override string Type => Types.PATTERN;

    public Document Document { get; set; }

    public BackgroundFill Fill { get; set; }

    public int Intensity { get; set; }

    public bool IsInverted { get; set; }

    public bool IsMoving { get; set; }
}

public class BackgroundTypeWallpaper : BackgroundType
{
    public override string Type => Types.WALLPAPER;

    public Document Document { get; set; }

    public int DarkThemeDimming { get; set; }

    public bool IsBlurred { get; set; }

    public bool IsMoving { get; set; }
}
