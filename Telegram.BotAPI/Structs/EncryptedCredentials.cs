namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#encryptedcredentials
    public class EncryptedCredentials
    {
        public string Data { get; set; }

        public string Hash { get; set; }

        public string Secret { get; set; }
    }
}
