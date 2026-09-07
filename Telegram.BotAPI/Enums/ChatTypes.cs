namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies a chat type, including the special inline-query sender context.</summary>
public enum ChatTypes
{
    /// <summary>The private chat with the sender of an inline query.</summary>
    Sender,

    /// <summary>A private chat.</summary>
    Private,

    /// <summary>A basic group chat.</summary>
    Group,

    /// <summary>A supergroup chat.</summary>
    Supergroup,

    /// <summary>A channel chat.</summary>
    Channel
}
