namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a user allowing a bot to write messages
/// after adding it to the attachment menu, launching a Web App from a link,
/// accepting an explicit request from a Web App, or being invited by the bot's
/// owner.
/// </summary>
public sealed class WriteAccessAllowed
{
    /// <summary>True, if the access was granted after the user accepted an explicit request from a Web App sent by the method requestWriteAccess.</summary>
    public bool? FromRequest { get; init; }

    /// <summary>Optional name of the Web App, if access was granted when it was launched from a link.</summary>
    public string? WebAppName { get; init; }

    /// <summary>True if access was granted when the bot was added to the attachment or side menu.</summary>
    public bool? FromAttachmentMenu { get; init; }

    /// <summary>
    /// The owner of the bot, when the access was granted after the owner invited
    /// the user to the private chat with the bot. Bot owners can invite up to 10
    /// users at once with <c>https://t.me/botinvite/&lt;bot_username&gt;</c>.
    /// </summary>
    public User? Inviter { get; init; }
}
