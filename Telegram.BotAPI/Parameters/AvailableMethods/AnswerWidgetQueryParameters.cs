using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerWidgetQuery</c> method.
/// </summary>
/// <remarks>
/// The query must be answered within 15 seconds. The answer is received only by the widget
/// that sent the query and does not change widget data; use <c>editMessageWidgetData</c> or
/// <c>editSharedWidgetData</c> to change it.
/// </remarks>
public sealed class AnswerWidgetQueryParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the query to answer.</summary>
    public required string WidgetQueryId { get; init; }

    /// <summary>Data to return to the widget, from 0 through 1024 bytes.</summary>
    public string? Data { get; init; }
}
