namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#passportdata
    public class PassportData
    {
        public List<EncryptedPassportElement> Data { get; set; }

        public EncryptedCredentials Credentials { get; set; }
    }
}
