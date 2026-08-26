namespace Endfix.Telegram.BotAPI.Types;

public sealed class EncryptedCredentials
{
    public required string Data { get; init; }

    public required string Hash { get; init; }

    public required string Secret { get; init; }
}
