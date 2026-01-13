using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(BackgroundTypeChatTheme), "chat_theme")]
[JsonDerivedType(typeof(BackgroundTypeFill), "fill")]
[JsonDerivedType(typeof(BackgroundTypePattern), "pattern")]
[JsonDerivedType(typeof(BackgroundTypeWallpaper), "wallpaper")]
public abstract class BackgroundType
{
    [JsonIgnore]
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

    public required bool IsInverted { get; init; }

    public required bool IsMoving { get; init; }
}

public sealed class BackgroundTypeWallpaper : BackgroundType
{
    public override BackgroundTypes Type => BackgroundTypes.Wallpaper;

    public required Document Document { get; init; }

    public required int DarkThemeDimming { get; init; }

    public required bool IsBlurred { get; init; }

    public required bool IsMoving { get; init; }
}
