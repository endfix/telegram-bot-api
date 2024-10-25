namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#menubutton
public abstract class MenuButton
{
    public virtual string Type { get; set; }

    public static class Types
    {
        public const string COMMANDS = "commands";

        public const string WEB_APP = "web_app";

        public const string DEFAULT = "default";
    }
}

// https://core.telegram.org/bots/api#menubuttoncommands
public sealed class MenuButtonCommands : MenuButton
{
    public override string Type => Types.COMMANDS;
}

// https://core.telegram.org/bots/api#menubuttondefault
public sealed class MenuButtonDefault : MenuButton
{
    public override string Type => Types.DEFAULT;
}

// https://core.telegram.org/bots/api#menubuttonwebapp
public sealed class MenuButtonWebApp : MenuButton
{
    public override string Type => Types.WEB_APP;

    public string Text { get; set; }

    public WebAppInfo WebApp { get; set; } = new WebAppInfo();
}
