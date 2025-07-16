namespace Telegram.BotAPI.Types;

public sealed class KeyboardButtonRequestUsers
{
    public int RequestId { get; set; }

    public bool UserIsBot { get; set; }

    public bool UserIsPremium { get; set; }

    public int MaxQuantity { get; set; }

    public bool RequestName { get; set; }

    public bool RequestUsername { get; set; }

    public bool RequestPhoto { get; set; }
}
