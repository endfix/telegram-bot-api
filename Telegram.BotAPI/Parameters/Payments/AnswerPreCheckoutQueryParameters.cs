using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class AnswerPreCheckoutQueryParameters : ApiRequestParameters
{
    public required string PreCheckoutQueryId { get; init; }

    public required bool Ok { get; init; }

    public string? ErrorMessage { get; init; }
}
