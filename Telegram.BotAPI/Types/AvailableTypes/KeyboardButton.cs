using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents one button in a custom reply keyboard.</summary>
public sealed class KeyboardButton
{
    /// <summary>Label of the button.</summary>
    public required string Text { get; init; }

    /// <summary>Custom emoji shown as the button icon, if available.</summary>
    public string? IconCustomEmojiId { get; init; }

    /// <summary>Visual style of the button, if configured.</summary>
    public KeyboardButtonStyle? Style { get; init; }

    /// <summary>Request for users shared through this button, if configured.</summary>
    public KeyboardButtonRequestUsers? RequestUsers { get; init; }

    /// <summary>Request for a chat shared through this button, if configured.</summary>
    public KeyboardButtonRequestChat? RequestChat { get; init; }

    /// <summary>Request for a managed bot created through this button, if configured.</summary>
    public KeyboardButtonRequestManagedBot? RequestManagedBot { get; init; }

    /// <summary>Indicates whether the button requests the user's contact.</summary>
    public bool? RequestContact { get; init; }

    /// <summary>Indicates whether the button requests the user's location.</summary>
    public bool? RequestLocation { get; init; }

    /// <summary>Poll type requested by the button, if configured.</summary>
    public KeyboardButtonPollType? RequestPoll { get; init; }

    /// <summary>Web App launched by the button, if configured.</summary>
    public WebAppInfo? WebApp { get; init; }
}
