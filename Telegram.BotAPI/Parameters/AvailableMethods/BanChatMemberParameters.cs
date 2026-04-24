using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class BanChatMemberParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }

    public int? UntilDate { get; init; }

    public bool? RevokeMessages { get; init; }
}
