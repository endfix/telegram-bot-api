namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a backdrop for a chat share theme.</summary>
public sealed class ChatShareThemeBackdrop
{
    /// <summary>Unique identifier of the backdrop.</summary>
    public required int Id { get; init; }

    /// <summary>Name of the backdrop.</summary>
    public required string Name { get; init; }

    /// <summary>Colors of the backdrop.</summary>
    public required UniqueGiftBackdropColors Colors { get; init; }
}
