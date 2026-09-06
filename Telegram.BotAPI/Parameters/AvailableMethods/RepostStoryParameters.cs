using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>repostStory</c> method.
/// </summary>
public sealed class RepostStoryParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required long FromChatId { get; init; }

    public required int FromStoryId { get; init; }

    public required int ActivePeriod { get; init; }

    public bool? PostToChatPage { get; init; }

    public bool? ProtectContent { get; init; }
}
