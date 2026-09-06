namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a video chat scheduled in the chat.
/// </summary>
public sealed class VideoChatScheduled
{
    /// <summary>Point in time when the video chat is supposed to be started, in Unix time.</summary>
    public required int StartDate { get; init; }
}
