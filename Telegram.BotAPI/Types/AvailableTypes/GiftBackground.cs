namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the background of a gift.</summary>
public sealed class GiftBackground
{
    /// <summary>Center color of the background in RGB format.</summary>
    public required int CenterColor { get; init; }

    /// <summary>Edge color of the background in RGB format.</summary>
    public required int EdgeColor { get; init; }

    /// <summary>Text color of the background in RGB format.</summary>
    public required int TextColor { get; init; }
}
