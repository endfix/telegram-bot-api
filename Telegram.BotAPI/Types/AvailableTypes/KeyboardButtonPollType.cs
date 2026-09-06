using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the poll type requested by a keyboard button.</summary>
public sealed class KeyboardButtonPollType
{
    /// <summary>Requested poll type, if restricted.</summary>
    public PollType? Type { get; init; }
}
