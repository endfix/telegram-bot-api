using System.Collections.Generic;

namespace Telegram.BotAPI.Types.TelegramPassport;

/// <summary>
/// Describes Telegram Passport data shared with the bot by the user.
/// </summary>
public sealed class PassportData
{
    /// <summary>
    /// Array with information about documents and other Telegram Passport elements that was shared with the bot
    /// </summary>
    public List<EncryptedPassportElement> Data { get; set; }

    /// <summary>
    /// Encrypted credentials required to decrypt the data
    /// </summary>
    public EncryptedCredentials Credentials { get; set; }
}
