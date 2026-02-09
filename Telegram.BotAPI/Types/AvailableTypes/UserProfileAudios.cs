namespace Telegram.BotAPI.Types;

public sealed class UserProfileAudios
{
    public required int TotalCount {  get; set; }

    public required Audio[] Audios { get; set; }
}
