using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getFile</c> method.
/// </summary>
public sealed class GetFileParameters : ApiRequestParameters
{
    /// <summary>Identifier of the file.</summary>
    public required string FileId { get; init; }
}
