using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserProfilePhotos</c> method.
/// </summary>
public sealed class GetUserProfilePhotosParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
