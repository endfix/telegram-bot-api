using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

public sealed class PassportData
{
    public List<EncryptedPassportElement> Data { get; set; }

    public EncryptedCredentials Credentials { get; set; }
}
