namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#chatmemberupdated
public sealed class ChatMemberUpdated
{
    public Chat Chat { get; set; }

    public User From { get; set; }

    public int Date { get; set; }

    public ChatMember OldChatMember { get; set; }

    public ChatMember NewChatMember { get; set; }

    public ChatInviteLink InviteLink { get; set; }

    public bool ViaJoinRequest { get; set; }

    public bool ViaChatFolderInviteLink { get; set; }
}
