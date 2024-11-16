namespace Telegram.BotAPI.Types.TelegramPassport;

/// <summary>
/// Describes data required for decrypting and authenticating <see cref="EncryptedPassportElement">EncryptedPassportElement</see>. 
/// See the <see href="https://core.telegram.org/passport#receiving-information">Telegram Passport Documentation</see>
/// for a complete description of the data decryption and authentication processes.
/// </summary>
public sealed class EncryptedCredentials
{
    /// <summary>
    /// Base64-encoded encrypted JSON-serialized data with unique user's payload, data hashes and 
    /// secrets required for <see cref="EncryptedPassportElement">EncryptedPassportElement</see> decryption and authentication
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    /// Base64-encoded data hash for data authentication
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    /// Base64-encoded secret, encrypted with the bot's public RSA key, required for data decryption
    /// </summary>
    public string Secret { get; set; }
}
