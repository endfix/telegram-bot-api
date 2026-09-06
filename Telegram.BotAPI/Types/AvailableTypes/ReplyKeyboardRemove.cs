namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Requests removal of the custom reply keyboard.</summary>
public sealed class ReplyKeyboardRemove : ReplyMarkup
{
    /// <summary>Must be set to <see langword="true"/> to remove the keyboard.</summary>
    public required bool RemoveKeyboard { get; init; }

    /// <summary>Indicates whether the keyboard should be removed only for specific users.</summary>
    public bool? Selective { get; init; }
}
