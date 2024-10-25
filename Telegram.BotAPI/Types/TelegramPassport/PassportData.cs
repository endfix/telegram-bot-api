using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

// https://core.telegram.org/bots/api#passportdata
public sealed class PassportData
{
    public List<EncryptedPassportElement> Data { get; set; }

    public EncryptedCredentials Credentials { get; set; }
}
