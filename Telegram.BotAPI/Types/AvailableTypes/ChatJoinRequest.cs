namespace Telegram.BotAPI.Types;

public sealed class ChatJoinRequest
{
    public required Chat Chat { get; set; }

    public required User From { get; set; }

    public required long UserChatId { get; set; }

    public required int Date { get; set; }

    public string? Bio { get; set; }

    public ChatInviteLink? InviteLink { get; set; }
}
