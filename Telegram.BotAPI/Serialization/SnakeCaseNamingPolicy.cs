using System.Text.Json;

namespace Telegram.BotAPI.Serialization
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var result = string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + char.ToLowerInvariant(x).ToString() : char.ToLowerInvariant(x).ToString()));

            return result;
        }
    }
}
