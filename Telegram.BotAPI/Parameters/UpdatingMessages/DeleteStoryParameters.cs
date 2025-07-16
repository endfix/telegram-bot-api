namespace Telegram.BotAPI.Parameters;

public sealed class DeleteStoryParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public int StoryId;
}
