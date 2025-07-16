namespace Telegram.BotAPI.Types;

public sealed class PassportData
{
    public EncryptedPassportElement[] Data { get; set; }

    public EncryptedCredentials Credentials { get; set; }
}
