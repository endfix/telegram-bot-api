namespace Telegram.BotAPI.Structs
{
    public class UserProfilePhotos
    {
        public int TotalCount { get; set; }

        public List<List<PhotoSize>> Photos { get; set; }
    }
}
