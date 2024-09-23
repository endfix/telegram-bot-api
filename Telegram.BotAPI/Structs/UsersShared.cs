namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#usersshared
    public class UsersShared
    {
        public int RequestId { get; set; }

        public List<SharedUser> Users { get; set; }
    }
}
