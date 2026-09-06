using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatPhoto</c> method.
/// </summary>
public sealed class SetChatPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required InputPhotoFile Photo { get; init; }
}
