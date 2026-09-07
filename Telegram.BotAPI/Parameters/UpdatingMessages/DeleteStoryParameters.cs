using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteStory</c> method.
/// </summary>
public sealed class DeleteStoryParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the story to delete.</summary>
    public required int StoryId { get; init; }
}
