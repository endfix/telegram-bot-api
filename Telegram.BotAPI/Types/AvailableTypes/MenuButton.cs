using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(MenuButtonCommands), "commands")]
[JsonDerivedType(typeof(MenuButtonDefault), "default")]
[JsonDerivedType(typeof(MenuButtonWebApp), "web_app")]
public abstract class MenuButton
{
    [JsonIgnore]
    public abstract MenuButtonTypes Type { get; }
}

public sealed class MenuButtonCommands : MenuButton
{
    public override MenuButtonTypes Type => MenuButtonTypes.Commands;
}

public sealed class MenuButtonDefault : MenuButton
{
    public override MenuButtonTypes Type => MenuButtonTypes.Default;
}

public sealed class MenuButtonWebApp : MenuButton
{
    public override MenuButtonTypes Type => MenuButtonTypes.WebApp;

    public required string Text { get; init; }

    public required WebAppInfo WebApp { get; init; }
}
