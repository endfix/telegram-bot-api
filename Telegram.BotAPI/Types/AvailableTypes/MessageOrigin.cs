using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(MessageOriginChannel), "channel")]
[JsonDerivedType(typeof(MessageOriginChat), "chat")]
[JsonDerivedType(typeof(MessageOriginHiddenUser), "hidden_user")]
[JsonDerivedType(typeof(MessageOriginUser), "user")]
public abstract class MessageOrigin
{
    [JsonIgnore]
    public abstract MessageOriginTypes Type { get; }
}

public sealed class MessageOriginChannel : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.Channel;

    public required int Date { get; init; }

    public required Chat Chat { get; init; }

    public required long MessageId { get; init; }

    public string? AuthorSignature { get; init; }
}

public sealed class MessageOriginChat : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.Chat;

    public required int Date { get; init; }

    public required Chat SenderChat { get; init; }

    public string? AuthorSignature { get; init; }
}

public sealed class MessageOriginHiddenUser : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.HiddenUser;

    public required int Date { get; init; }

    public required string SenderUserName { get; init; }
}

public sealed class MessageOriginUser : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.User;

    public required int Date { get; init; }

    public required User SenderUser { get; init; }
}
