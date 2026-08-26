namespace Endfix.Telegram.BotAPI.Types;

public sealed class WriteAccessAllowed
{
    public bool? FromRequest { get; init; }

    public string? WebAppName { get; init; }

    public bool? FromAttachmentMenu { get; init; }
}
