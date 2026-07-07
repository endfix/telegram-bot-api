using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerGuestQueryParameters : ApiRequestParameters
{
    public required string GuestQueryId { get; init; }

    public required InlineQueryResult Result { get; init; }
}
