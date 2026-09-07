namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the source represented by forwarded-message origin information.</summary>
public enum MessageOriginType
{
    /// <summary>A known Telegram user.</summary>
    User,

    /// <summary>A user whose identity was hidden by privacy settings.</summary>
    HiddenUser,

    /// <summary>A chat acting as the original sender.</summary>
    Chat,

    /// <summary>A channel post.</summary>
    Channel
}
