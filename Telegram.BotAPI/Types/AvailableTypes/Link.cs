namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents an HTTP link attached to a poll option.
/// </summary>
public sealed class Link
{
    /// <summary>The HTTP link.</summary>
    public required string Url { get; init; }
}
