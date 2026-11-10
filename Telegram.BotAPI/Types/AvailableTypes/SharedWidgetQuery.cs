namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an incoming query from a forwarded message with a shared widget created by the bot.
/// </summary>
/// <remarks>
/// Use <c>answerWidgetQuery</c> to answer the query. Each user can send at most 5 queries per
/// 5 seconds to the bot from all their widgets.
/// </remarks>
public sealed class SharedWidgetQuery
{
    /// <summary>Unique identifier of the query.</summary>
    public required string Id { get; init; }

    /// <summary>Sender.</summary>
    public required User From { get; init; }

    /// <summary>Type of the query.</summary>
    public required WidgetQueryType Type { get; init; }

    /// <summary>Query data, from 1 through 64 bytes.</summary>
    public required string Data { get; init; }

    /// <summary>Unique identifier of the shared widget that sent the query.</summary>
    public required string WidgetId { get; init; }
}
