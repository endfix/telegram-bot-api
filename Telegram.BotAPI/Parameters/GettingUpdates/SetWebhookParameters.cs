using System.Collections.Generic;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public class SetWebhookParameters : ApiRequestParameters
{
    public required string Url { get; init; }

    public InputFile? Certificate { get; init; }

    public string? IpAddress { get; init; }

    public int? MaxConnections { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }

    public bool? DropPendingUpdates { get; init; }

    public string? SecretToken { get; init; }
}
