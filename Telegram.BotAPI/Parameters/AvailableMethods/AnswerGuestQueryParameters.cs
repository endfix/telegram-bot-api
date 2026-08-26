using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class AnswerGuestQueryParameters : ApiRequestParameters
{
    public required string GuestQueryId { get; init; }

    public required InlineQueryResult Result { get; init; }
}
