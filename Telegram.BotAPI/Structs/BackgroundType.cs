namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#backgroundtype
    public abstract class BackgroundType
    {
        public virtual string Type { get; set; }

        public class Types
        {
            public const string FILL = "fill";

            public const string WALLPAPER = "wallpaper";

            public const string PATTERN = "pattern";

            public const string CHAT_THEME = "chat_theme";
        }

        // https://core.telegram.org/bots/api#backgroundtypefill
        public class FillStruct : BackgroundType
        {
            public override string Type => Types.FILL;

            public BackgroundFill Fill { get; set; }

            public int DarkThemeDimming { get; set; }
        }

        // https://core.telegram.org/bots/api#backgroundtypewallpaper
        public class WallpaperStruct : BackgroundType
        {
            public override string Type => Types.WALLPAPER;

            public Document Document { get; set; }

            public int DarkThemeDimming { get; set; }

            public bool IsBlurred { get; set; }

            public bool IsMoving { get; set; }
        }

        // https://core.telegram.org/bots/api#backgroundtypepattern
        public class PatternStruct : BackgroundType
        {
            public override string Type => Types.PATTERN;

            public Document Document { get; set; }

            public BackgroundFill Fill { get; set; }

            public int Intensity { get; set; }

            public bool IsInverted { get; set; }

            public bool IsMoving { get; set; }
        }

        // https://core.telegram.org/bots/api#backgroundtypechattheme
        public class ChatThemeStruct : BackgroundType
        {
            public override string Type => Types.CHAT_THEME;

            public string ThemeName { get; set; }
        }
    }
}
