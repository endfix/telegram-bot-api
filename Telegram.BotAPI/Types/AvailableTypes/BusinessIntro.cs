namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about the business account's introduction.</summary>
public sealed class BusinessIntro
{
    /// <summary>Optional. Title of the business introduction.</summary>
    public string? Name { get; init; }

    /// <summary>Optional. Message shown in the business introduction.</summary>
    public string? Message { get; init; }

    /// <summary>Optional. Sticker shown in the business introduction.</summary>
    public Sticker? Sticker { get; init; }
}
