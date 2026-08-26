using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteStoryParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required int StoryId { get; init; }
}
