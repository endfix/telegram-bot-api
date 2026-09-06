namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a login URL button.</summary>
public sealed class LoginUrl
{
    /// <summary>HTTPS URL opened by the button.</summary>
    public required string Url { get; init; }

    /// <summary>Text forwarded to the bot when the user is redirected, if configured.</summary>
    public string? ForwardText { get; init; }

    /// <summary>Bot username that receives the authorization data, if configured.</summary>
    public string? BotUsername { get; init; }

    /// <summary>Requests permission for the bot to write to the user's private chat.</summary>
    public bool? RequestWriteAccess { get; init; }
}
