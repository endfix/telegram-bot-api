namespace Telegram.BotAPI.Types;

public sealed class KeyboardButtonRequestUsers
{
    public required int RequestId { get; init; }

    public bool? UserIsBot { get; init; }

    public bool? UserIsPremium { get; init; }

    public int? MaxQuantity { get; init; }

    public bool? RequestName { get; init; }

    public bool? RequestUsername { get; init; }

    public bool? RequestPhoto { get; init; }
}
