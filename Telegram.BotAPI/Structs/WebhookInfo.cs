namespace Telegram.BotAPI.Structs
{
    public class WebhookInfo
    {
        public string Url { get; set; }

        public bool HasCustomCertificate { get; set; }

        public int PendingUpdateCount { get; set; }

        public string IpAddress { get; set; }

        public int LastErrorDate { get; set; }

        public string LastErrorMessage { get; set; }

        public int LastSynchronizationErrorDate { get; set; }

        public int MaxConnections { get; set; }

        public List<string> AllowedUpdates { get; set; }
    }
}
