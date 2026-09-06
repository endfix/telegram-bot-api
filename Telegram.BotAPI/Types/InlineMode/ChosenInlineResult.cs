namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an inline result that was chosen by a user and sent to their chat partner.</summary>
public sealed class ChosenInlineResult
{
    /// <summary>Unique identifier for the result that was chosen.</summary>
    public required string ResultId { get; init; }

    /// <summary>Sender of the chosen result.</summary>
    public required User From { get; init; }

    /// <summary>Sender location, if the user has enabled location access for the bot.</summary>
    public Location? Location { get; init; }

    /// <summary>Identifier of the sent inline message, if available.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>The inline query that was used to obtain the chosen result.</summary>
    public required string Query { get; init; }
}
