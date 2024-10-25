/*using System.Text.Json;

namespace Telegram.BotAPI.Serialization;

public class LowerCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return string.IsNullOrEmpty(name) || !char.IsUpper(name[0]) ? name : name.ToLower();
    }
}
*/