namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class KeyboardButtonRequestChat
{
    public int RequestId { get; set; }

    public bool ChatIsChannel { get; set; }

    public bool ChatIsForum { get; set; }

    public bool ChatHasUsername { get; set; }

    public bool ChatIsCreated { get; set; }

    public ChatAdministratorRights UserAdministratorRights { get; set; }

    public ChatAdministratorRights BotAdministratorRights { get; set; }

    public bool BotIsMember { get; set; }

    public bool RequestTitle { get; set; }

    public bool RequestUsername { get; set; }

    public bool RequestPhoto { get; set; }
}
