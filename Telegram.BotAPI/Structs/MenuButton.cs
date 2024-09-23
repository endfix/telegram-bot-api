namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#menubutton
    public abstract class MenuButton
    {
        public virtual string Type { get; set; }

        public sealed class Types
        {
            public const string COMMANDS = "commands";

            public const string WEB_APP = "web_app";

            public const string DEFAULT = "default";
        }

        // https://core.telegram.org/bots/api#menubuttoncommands
        public sealed class CommandsStruct : MenuButton
        {
            public override string Type => Types.COMMANDS;
        }

        // https://core.telegram.org/bots/api#menubuttondefault
        public sealed class DefaultStruct : MenuButton
        {
            public override string Type => Types.DEFAULT;
        }

        // https://core.telegram.org/bots/api#menubuttonwebapp
        public sealed class WebAppStruct : MenuButton
        {
            public override string Type => Types.WEB_APP;

            public string Text { get; set; }

            public WebAppInfo WebApp { get; set; } = new WebAppInfo();
        }
    }
}
