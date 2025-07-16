using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class MenuButton
{
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

    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; }
}
