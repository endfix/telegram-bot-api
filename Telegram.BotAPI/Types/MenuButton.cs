namespace Telegram.BotAPI.Types;

public abstract class MenuButton
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string COMMANDS = "commands";

        public const string WEB_APP = "web_app";

        public const string DEFAULT = "default";
    }
}

public sealed class MenuButtonCommands : MenuButton
{
    public override string Type => Types.COMMANDS;
}

public sealed class MenuButtonDefault : MenuButton
{
    public override string Type => Types.DEFAULT;
}

public sealed class MenuButtonWebApp : MenuButton
{
    public override string Type => Types.WEB_APP;

    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; } = new WebAppInfo();
}
