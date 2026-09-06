using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getFile</c> method.
/// </summary>
public sealed class GetFileParameters : ApiRequestParameters
{
    public required string FileId { get; init; }
}
