namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a user allowing a bot to write messages.
/// </summary>
public sealed class WriteAccessAllowed
{
    /// <summary>True if access was granted after the user accepted an explicit request from a Web App.</summary>
    public bool? FromRequest { get; init; }

    /// <summary>Optional name of the Web App, if access was granted when it was launched from a link.</summary>
    public string? WebAppName { get; init; }

    /// <summary>True if access was granted when the bot was added to the attachment or side menu.</summary>
    public bool? FromAttachmentMenu { get; init; }
}
