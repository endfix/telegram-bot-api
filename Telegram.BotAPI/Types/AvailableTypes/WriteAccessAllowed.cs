namespace Telegram.BotAPI.Types;

public sealed class WriteAccessAllowed
{
    public bool FromRequest { get; set; }

    public string WebAppName { get; set; }

    public bool FromAttachmentMenu { get; set; }
}
