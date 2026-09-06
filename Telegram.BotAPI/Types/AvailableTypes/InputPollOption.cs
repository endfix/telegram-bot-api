using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an answer option in a poll to be sent.
/// </summary>
public sealed class InputPollOption
{
    /// <summary>Option text.</summary>
    public required string Text { get; init; }

    /// <summary>Optional mode for parsing entities in the option text.</summary>
    public string? TextParseMode { get; init; }

    /// <summary>Optional special entities that appear in the option text.</summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    /// <summary>Optional media attached to the option.</summary>
    public IInputPollOptionMedia? Media { get; init; }
}
