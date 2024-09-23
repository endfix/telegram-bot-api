namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatinvitelink
    public class ChatInviteLink
    {
        public string InviteLink { get; set; }

        public User Creator { get; set; }

        public bool CreatesJoinRequest { get; set; }

        public bool IsPrimary { get; set; }
        public bool IsRevoked { get; set; }

        public string Name { get; set; }

        public int ExpireDate { get; set; }

        public int MemberLimit { get; set; }

        public int PendingJoinRequestCount { get; set; }

        public int SubscriptionPeriod { get; set; }

        public int SubscriptionPrice { get; set; }
    }
}
