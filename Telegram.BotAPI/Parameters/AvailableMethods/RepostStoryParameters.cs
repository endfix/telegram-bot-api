using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>repostStory</c> method.
/// </summary>
public sealed class RepostStoryParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection used to repost the story.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the business account that posted the source story.</summary>
    public required long FromChatId { get; init; }

    /// <summary>Identifier of the source story.</summary>
    public required int FromStoryId { get; init; }

    /// <summary>Seconds after which the reposted story is moved to the archive; must be 21600, 43200, 86400 or 172800.</summary>
    public required int ActivePeriod { get; init; }

    /// <summary>Whether to keep the story accessible on the business account's profile after it expires.</summary>
    public bool? PostToChatPage { get; init; }

    /// <summary>Whether to protect the story from forwarding and screenshots.</summary>
    public bool? ProtectContent { get; init; }
}
