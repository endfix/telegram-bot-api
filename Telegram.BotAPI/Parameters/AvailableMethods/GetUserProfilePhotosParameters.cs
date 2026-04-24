using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetUserProfilePhotosParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
