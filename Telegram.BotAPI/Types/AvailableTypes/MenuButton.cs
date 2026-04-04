using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class MenuButton
{
    public abstract MenuButtonType Type { get; }
}

public sealed class MenuButtonCommands : MenuButton
{
    public override MenuButtonType Type => MenuButtonType.Commands;
}

public sealed class MenuButtonDefault : MenuButton
{
    public override MenuButtonType Type => MenuButtonType.Default;
}

public sealed class MenuButtonWebApp : MenuButton
{
    public override MenuButtonType Type => MenuButtonType.WebApp;

    public required string Text { get; init; }

    public required WebAppInfo WebApp { get; init; }
}
