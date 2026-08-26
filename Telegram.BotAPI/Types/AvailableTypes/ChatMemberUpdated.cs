namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatMemberUpdated
{
    public required Chat Chat { get; init; }

    public required User From { get; init; }

    public required int Date { get; init; }

    public required ChatMember OldChatMember { get; init; }

    public required ChatMember NewChatMember { get; init; }

    public ChatInviteLink? InviteLink { get; init; }

    public bool? ViaJoinRequest { get; init; }

    public bool? ViaChatFolderInviteLink { get; init; }
}
