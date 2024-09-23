namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#encryptedpassportelement
    public class EncryptedPassportElement
    {
        public string Type { get; set; }

        public string Data { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<PassportFile> Files { get; set; }

        public PassportFile FrontSide { get; set; }

        public PassportFile ReverseSide { get; set; }

        public PassportFile Selfie { get; set; }

        public List<PassportFile> Translation { get; set; }

        public string Hash { get; set; }
    }
}
