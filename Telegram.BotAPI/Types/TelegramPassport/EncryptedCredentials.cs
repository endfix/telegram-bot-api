namespace Telegram.BotAPI.Types;

public sealed class EncryptedCredentials
{
    public string Data { get; set; }

    public string Hash { get; set; }

    public string Secret { get; set; }
}
