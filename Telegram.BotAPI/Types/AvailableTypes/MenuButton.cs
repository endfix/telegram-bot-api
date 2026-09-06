using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a bot menu button.</summary>
public abstract class MenuButton
{
    /// <summary>Gets the menu button kind.</summary>
    public abstract MenuButtonType Type { get; }
}

/// <summary>Represents the default menu button.</summary>
public sealed class MenuButtonCommands : MenuButton
{
    /// <summary>Gets the commands button kind.</summary>
    public override MenuButtonType Type => MenuButtonType.Commands;
}

/// <summary>Represents the default client-defined menu button.</summary>
public sealed class MenuButtonDefault : MenuButton
{
    /// <summary>Gets the default button kind.</summary>
    public override MenuButtonType Type => MenuButtonType.Default;
}

/// <summary>Represents a menu button that opens a Web App.</summary>
public sealed class MenuButtonWebApp : MenuButton
{
    /// <summary>Gets the Web App button kind.</summary>
    public override MenuButtonType Type => MenuButtonType.WebApp;

    /// <summary>Button text.</summary>
    public required string Text { get; init; }

    /// <summary>Web App opened by the button.</summary>
    public required WebAppInfo WebApp { get; init; }
}
