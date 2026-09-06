namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes which users may be selected using a keyboard button.</summary>
public sealed class KeyboardButtonRequestUsers
{
    /// <summary>Identifier of the request.</summary>
    public required int RequestId { get; init; }

    /// <summary>Restricts selection to bots when <see langword="true"/> or to regular users when <see langword="false"/>.</summary>
    public bool? UserIsBot { get; init; }

    /// <summary>Restricts selection to Telegram Premium users when set.</summary>
    public bool? UserIsPremium { get; init; }

    /// <summary>Maximum number of users that can be selected.</summary>
    public int? MaxQuantity { get; init; }

    /// <summary>Requests the selected users' names.</summary>
    public bool? RequestName { get; init; }

    /// <summary>Requests the selected users' usernames.</summary>
    public bool? RequestUsername { get; init; }

    /// <summary>Requests the selected users' profile photos.</summary>
    public bool? RequestPhoto { get; init; }
}
