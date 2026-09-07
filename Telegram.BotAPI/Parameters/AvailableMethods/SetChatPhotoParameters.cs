using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatPhoto</c> method.
/// </summary>
public sealed class SetChatPhotoParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>New chat photo to upload.</summary>
    public required InputPhotoFile Photo { get; init; }
}
