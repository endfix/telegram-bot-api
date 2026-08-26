using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetFileParameters : ApiRequestParameters
{
    public required string FileId { get; init; }
}
