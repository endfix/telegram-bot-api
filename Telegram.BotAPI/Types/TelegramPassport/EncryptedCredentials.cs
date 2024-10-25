namespace Telegram.BotAPI.Types.TelegramPassport;

// https://core.telegram.org/bots/api#encryptedcredentials
public sealed class EncryptedCredentials
{
    public string Data { get; set; }

    public string Hash { get; set; }

    public string Secret { get; set; }
}
