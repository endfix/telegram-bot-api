namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains encrypted credentials required to decrypt Telegram Passport data.</summary>
public sealed class EncryptedCredentials
{
    /// <summary>Base64-encoded encrypted JSON-serialized data with the user's payload, data hashes and secrets required for decryption and authentication.</summary>
    public required string Data { get; init; }

    /// <summary>Base64-encoded hash of the encrypted credentials data.</summary>
    public required string Hash { get; init; }

    /// <summary>Base64-encoded secret encrypted with the bot's public RSA key, required for data decryption.</summary>
    public required string Secret { get; init; }
}
