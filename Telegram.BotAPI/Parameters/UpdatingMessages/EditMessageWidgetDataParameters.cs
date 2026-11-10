using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageWidgetData</c> method.
/// </summary>
/// <remarks>Public data of a shared widget can be changed at most once per second.</remarks>
public sealed class EditMessageWidgetDataParameters : ApiRequestParameters
{
    /// <summary>
    /// Identifier of the target chat or username of the target supergroup in the format
    /// <c>@username</c>; required if <see cref="InlineMessageId"/> is not specified.
    /// </summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>
    /// Identifier of the message with the widget; required if <see cref="InlineMessageId"/>
    /// is not specified.
    /// </summary>
    public long? MessageId { get; init; }

    /// <summary>
    /// Identifier of the inline message; required if <see cref="ChatId"/> and
    /// <see cref="MessageId"/> are not specified.
    /// </summary>
    public string? InlineMessageId { get; init; }

    /// <summary>
    /// New public data of the widget, from 0 through 1024 bytes; pass an empty string to remove
    /// the data. The current data is kept when the value is omitted.
    /// </summary>
    public string? PublicData { get; init; }

    /// <summary>
    /// New data of the widget that is specific to the message, from 0 through 1024 bytes; pass
    /// an empty string to remove the data. The current data is kept when the value is omitted.
    /// </summary>
    public string? ChatData { get; init; }
}
