namespace Telegram.BotAPI.Types;

public sealed class KeyboardButtonRequestChat
{
    public required int RequestId { get; init; }

    public required bool ChatIsChannel { get; init; }

    public bool? ChatIsForum { get; init; }

    public bool? ChatHasUsername { get; init; }

    public bool? ChatIsCreated { get; init; }

    public ChatAdministratorRights? UserAdministratorRights { get; init; }

    public ChatAdministratorRights? BotAdministratorRights { get; init; }

    public bool? BotIsMember { get; init; }

    public bool? RequestTitle { get; init; }

    public bool? RequestUsername { get; init; }

    public bool? RequestPhoto { get; init; }
}
